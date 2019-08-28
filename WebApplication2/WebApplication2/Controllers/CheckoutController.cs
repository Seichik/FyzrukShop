using System.Web.Mvc;
using WebApplication2.Models.DOMAINModel.Entities;

namespace WebApplication2.Controllers
{
    [HandleError]
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Order()
        {
            OrderDetails order = null;
            return View(order);
        }
        
        public ActionResult Payment(Cart cart, OrderDetails order)
        {
            //Implemention of order saving
            ViewBag.TotalPrice = cart.TotalPrice.ToDollar();
            return View("Payment");
        }
    }
}