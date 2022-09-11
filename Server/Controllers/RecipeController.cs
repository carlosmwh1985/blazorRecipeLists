using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using CKSummary.Shared.Models;
using CKSummary.Shared.Helpers;
using CKSummary.Server.DataAccess;

namespace CKSummary.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public RecipeController(IDataAccessProvider provider)
        {
            _dataAccessProvider = provider;
        }

        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _dataAccessProvider.GetRecipeList();
        }

        [HttpGet]
        [Route("details/{id}")]
        public Recipe Details(int id)
        {
            return _dataAccessProvider.GetRecipe(id);
        }

        // NOTE: If Route = "bla/bla" => End Point = "api/[controller]/bla/bla"
        // If Route = "/bla/bla" => End Point = "bla/bla"
        [HttpGet]
        [Route("query/{coded}")]
        public List<Recipe> GetQuery(string coded)
        {
            string body = Base64Encoder.Decode(coded);
            Dictionary<string, List<string>> vals = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(body);
            return _dataAccessProvider.FilterByItems(vals);
        }
    }
}