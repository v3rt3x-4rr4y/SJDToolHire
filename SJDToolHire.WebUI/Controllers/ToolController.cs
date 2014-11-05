using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJDToolHire.Domain.Abstract;
using SJDToolHire.Domain.Entities;
using SJDToolHire.WebUI.Models;

namespace SJDToolHire.WebUI.Controllers
{
    public class ToolController : Controller
    {
        private IToolRepository repository;
        public int PageSize = 4;

        public ToolController(IToolRepository toolRepository)
        {
            this.repository = toolRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ToolsListViewModel model = new ToolsListViewModel
            {
                Tools = repository.Tools
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Tools.Count() : repository.Tools.Where(e => e.Category == category).Count() 
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}