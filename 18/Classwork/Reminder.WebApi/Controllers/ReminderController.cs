﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reminder.Storage;
using Reminder.WebApi.ViewModels;

namespace Reminder.WebApi.Controllers
{
	[Route("api/reminders")]
	public class ReminderController : Controller
	{
		private readonly IReminderStorage _storage;
		public ReminderController(IReminderStorage storage)
		{
			_storage = storage;
		}
		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			if (id == Guid.Empty)
			{
				return BadRequest();
			}
			var item = _storage.FindById(id);
			return Ok(item);
		}
		[HttpGet]
		public IActionResult GetList([FromQuery()]ReminderFilterViewModel model)
		{
			var filter = new ReminderItemFilter(model?.DateTime, model?.Status);
			var items = _storage.FindBy(filter);
			return Ok(items);
		}
		[HttpPost]
		public IActionResult Create()
		{
			return Ok();
		}
		[HttpPut("{id}")]
		public IActionResult Update(Guid id)
		{
			return Ok();
		}
	}
}
