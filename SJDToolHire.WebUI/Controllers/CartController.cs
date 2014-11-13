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
    public class CartController : Controller
    {
        private IToolRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IToolRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Tool tool = repository.Tools.FirstOrDefault(p => p.ProductID == productId);
            if (tool != null)
            {
                cart.AddItem(tool, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Tool tool = repository.Tools.FirstOrDefault(p => p.ProductID == productId);
            if (tool != null)
            {
                cart.RemoveLine(tool);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult IncrementQty(Cart cart, int productId, string returnUrl)
        {
            Tool tool = repository.Tools.FirstOrDefault(p => p.ProductID == productId);
            if (tool != null)
            {
                cart.AddItem(tool, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult DecrementQty(Cart cart, int productId, string returnUrl)
        {
            Tool tool = repository.Tools.FirstOrDefault(p => p.ProductID == productId);
            if (tool != null)
            {
                cart.RemoveItem(tool);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        
        [HttpPost]
        public RedirectToRouteResult SetStartDate(string startdate, Cart cart, string returnUrl)
        {
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public RedirectToRouteResult SetEndDate(string enddate, Cart cart, string returnUrl)
        {
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
