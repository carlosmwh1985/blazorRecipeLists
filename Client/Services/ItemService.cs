using System;
using System.Collections.Generic;
using System.Linq;
using CKSummary.Shared.Models;

namespace CKSummary.Client.Services
{
    public class ItemService
    {
        MenuItem[] allItems = new[] {
            new MenuItem()
            {
                Name = "Home",
                Path = "/",
                Icon = "home"
            },
            new MenuItem()
            {
                Name = "Recipes",
                Icon = "menu_book",
                Children = new[] {
                    new MenuItem
                    {
                        Name = "All Recipes",
                        Path = "/recipes",
                        Icon = "lunch_dining"
                    },
                    new MenuItem
                    {
                        Name = "All Ingredients",
                        Path = "/ingredients",
                        Icon = "egg"
                    },
                    new MenuItem
                    {
                        Name = "All Tags",
                        Path = "/tags",
                        Icon = "local_offer"
                    }
                }
            }
        };

        public IEnumerable<MenuItem> GetItems
        {
            get { return allItems; }
        }
    }
}
