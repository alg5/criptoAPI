using CriptoAPI.Models;
using CriptoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CriptoAPI.Controllers
{
    public class CriptoController : ControllerBase
    {
        private readonly ILogger<CriptoController> _logger;

        private readonly CriptoService _criptoService;

        public CriptoController(ILogger<CriptoController> logger, CriptoService criptoService)
        {
            _logger = logger;
            _criptoService = criptoService;
        }

        public IActionResult Index()
        {
            string res = "Welcome to Cryptocurrency";
            return Ok(res);
        }
        [HttpGet]
        public IActionResult GetCurrencyData(int limit)
        {
            string res = _criptoService.GetCurrencyData(limit);
            return Ok(res);
        }

 
    }
}
