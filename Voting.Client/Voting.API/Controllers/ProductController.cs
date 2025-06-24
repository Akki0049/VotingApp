using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voting.API.Data;
using Voting.API.Models;

namespace Voting.API.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class productController
        {
            private readonly ILogger<productController> _logger;

            public productController(ILogger<productController> logger) 
            {
                _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
           return ProductContext.Products;
        }
        
    }
}
