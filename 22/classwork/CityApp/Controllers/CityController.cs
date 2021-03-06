﻿using CityApp.WiewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CityApp.Models;
using CityApp.Services;
using Microsoft.Extensions.Logging;
using System;
using CityApp.ViewModels;

namespace CityApp.Controllers
{

	public class CityController : Controller
	{
		private ILogger _logger;
		private CityStorage _storage;
		public CityController(ILogger<CityController> logger, CityStorage storage)
		{
			_logger = logger;
			_storage = storage;
		}

		[HttpGet ("cities")]
		[HttpGet("api/city/list")]
		public IActionResult List()
		{

			var cities = _storage
				.GetAll()
				.Select((City city) => new CityViewModel(city))
				.OrderBy((CityViewModel viewModel) => viewModel.Name).ToArray();
			return Ok(cities);
		}
		[HttpPost("cities/{id}")]
		[HttpPost("api/city/{id}")]
		public IActionResult Create([FromBody] CreateCityModel city)
		{
			if (city == null)
			{
				return BadRequest();
			}
			var model = new City(
				city.Name,
				city.Description,
				city.Population);


			_storage.Create(model);
			return CreatedAtAction("Get", model);
		}
		[HttpGet("cities/{id}", Name ="Get")]
		[HttpGet("api/city/{id}", Name = "ApiGet")]
		public IActionResult Get (Guid id)
		{
			if (id == Guid.Empty)
			{
				_logger.LogWarning("Invalid id specifies");
				return BadRequest();
			}
			var city = _storage.GetById(id);
			if (city == null)
			{
				_logger.LogWarning("City with id {0} is not found", id);
				return NotFound();
			}
			return Ok(new DetailCityViewModel(city));
		}
        [HttpDelete("cities/{id}")]
        [HttpDelete("api/city/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("Invalid id specifies");
                return BadRequest();
            }
			var city = _storage.GetById(id);
			if (city == null)
			{
				_logger.LogWarning("City with id {0} is not found", id);
				return NotFound();
			}
			_storage.Delete(id);
            return Ok();
        }
        [HttpPut("cities/{id}")]
        [HttpPut("api/city/{id}")]
        public IActionResult Update([FromBody] UpdateCityViewModel city, Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("Invalid id specifies");
                return BadRequest();
            }
			var cityId = _storage.GetById(id);
			if (cityId == null)
			{
				_logger.LogWarning("City with id {0} is not found", id);
				return NotFound();
			}
			if (city == null)
			{
				_logger.LogWarning("City with id {0} is not found", id);
				return BadRequest();
			}
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var model = new City(city.Name, city.Description, city.Population, id);
            _storage.Update(model);
			
			return Ok();
        }
    }
}
