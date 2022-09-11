using System;
using Microsoft.AspNetCore.Mvc;
using CKSummary.Shared.Models;

namespace CKSummary.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public IngredientController(IDataAccessProvider provider)
        {
            _dataAccessProvider = provider;
        }

        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            return _dataAccessProvider.GetAllIngredients();
        }
    }
}