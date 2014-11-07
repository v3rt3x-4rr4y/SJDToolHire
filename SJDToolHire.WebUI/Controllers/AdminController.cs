﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJDToolHire.Domain.Abstract;
using SJDToolHire.Domain.Entities;

namespace SJDToolHire.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IToolRepository repository;
        public AdminController(IToolRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.Tools);
        }

        public ViewResult Edit(int productId)
        {
            Tool tool = repository.Tools
                        .FirstOrDefault(p => p.ProductID == productId);
            return View(tool);
        }

        [HttpPost]
        public ActionResult Edit(Tool tool)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTool(tool);
                TempData["message"] = string.Format("{0} was successfully updated", tool.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(tool);
            }
        }
    }
}