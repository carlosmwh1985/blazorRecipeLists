using System;

using CKSummary.Shared.Models;

namespace CKSummary.Server.DataAccess
{
    public class QueryBuilder
    {
        private static List<string> abc = new List<string> {
            "a", "b", "c", "d", "e", "f", "g", "h",
            "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x",
            "y", "z" 
        };

        private static string _base = "SELECT * FROM tbl_recipes_ckm";
        private static string _query;

        private static string Query
        {
            get
            {
                return (_query + ";");
            }
            set
            {
                _query += value;
            }
        }

        public static string ConfigureQuery(List<string> ingList, List<string> tagList)
        {
            _query = null;
            Query = _base;

            if ((ingList == null || ingList.Count == 0) && (tagList == null || tagList.Count == 0))
            {
                return Query;
            }

            string connector = " WHERE ";
            
            string ingConditions = "";
            List<string> tmp = new();
            foreach(string name in ingList)
            {
                tmp.Add(SetQueryCol(name));
            }
            if (tmp.Count > 0)
            {
                ingConditions += String.Join(" AND ", tmp);
            }
            
            string tagConditions = "";
            tmp = new();
            foreach(string tag in tagList)
            {
                tmp.Add($"\'{tag}\' = ANY (tags)");
            }
            if (tmp.Count > 0)
            {
                tagConditions += String.Join(" OR ", tmp);
                if (ingConditions != "")
                {
                    tagConditions = " AND (" + tagConditions + ")";
                }
            }            

            Query = connector + ingConditions + tagConditions;
            
            return Query;
        }

        private static string SetQueryCol(string name)
        {
            var firstLetter = name.Substring(0, 1).ToLower();
 
            string cond = $"\'{name}\' = ANY ";
            string arrayCol;

            if (abc.Contains(firstLetter))
            {
                arrayCol = $"(ing_{firstLetter})";
            }
            else if (firstLetter == "ä")
            {
                arrayCol = "(ing_ae)";
            }
            else if (firstLetter == "ö")
            {
                arrayCol = "(ing_oe)";
            }
            else if (firstLetter == "ü")
            {
                arrayCol = "(ing_ue)";
            }
            else
            {
                arrayCol = "(ing_others)";
            }

            cond += arrayCol;

            return cond;
        }
    }
}