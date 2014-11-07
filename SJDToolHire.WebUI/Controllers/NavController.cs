using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJDToolHire.Domain.Abstract;

namespace SJDToolHire.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IToolRepository repository;

        public NavController(IToolRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Tools
                                             .Select(x => x.Category)
                                             .Distinct()
                                             .OrderBy(x => x);
            return PartialView("FlexMenu", categories);
        }
    }
}