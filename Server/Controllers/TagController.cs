using System;
using Microsoft.AspNetCore.Mvc;
using CKSummary.Shared.Models;

namespace CKSummary.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public TagController(IDataAccessProvider provider)
        {
            _dataAccessProvider = provider;
        }

        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return _dataAccessProvider.GetAllTags();
        }
    }
}