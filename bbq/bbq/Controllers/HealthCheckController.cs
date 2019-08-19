﻿using InsideTechConf.Library.HealthCheck;
using bbq.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace bbq.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public HealthCheckController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult HealthCheck()
        {
            try
            {
                var healthCheck = HealthCheckHelper.GetGetHostNameAndIPAddress();

                _logger.LogInformation($"{JsonConvert.SerializeObject(healthCheck)}");

                return Ok(healthCheck);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.ToLogString(Environment.StackTrace));
                return new StatusCodeResult(500);
            }
        }
    }
}