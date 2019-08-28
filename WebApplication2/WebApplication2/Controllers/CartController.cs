using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models.DOMAINModel.Abstract;
using WebApplication2.Models.DOMAINModel.Entities;

namespace WebApplication2.Controllers
{
    [HandleError]
    public class CartController : Controller
    {
        private IRepository repository;
        public CartController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult RemoveItem(Cart cart, int ID)
        {
           int quantity = --cart.Lines.FirstOrDefault(l => l.Item.ID == ID).Quantity;
            if (quantity < 1)
                return RedirectToAction("RemoveLineFromCart", new { id = ID});
            return RedirectToAction("OpenCart");
        }
        public ActionResult AddItem(Cart cart, int ID)
        {
            int quantity = cart.Lines.FirstOrDefault(l => l.Item.ID == ID).Quantity;
            if (quantity < 99)
                cart.Lines.FirstOrDefault(l => l.Item.ID == ID).Quantity++;//( ͡° ͜ʖ ͡°)
            return RedirectToAction("OpenCart");//( ͡° ͜ʖ ͡°)
        }
        public ActionResult OpenCart(Cart cart)//( ͡° ͜ʖ ͡°)
        {
            return PartialView(cart);
        }

        public ActionResult CartWidget(Cart cart)//( ͡° ͜ʖ ͡°)
        {
            return PartialView(cart);
        }

        public ActionResult AddToCart(Cart cart, int ID, int quantity = 1)//( ͡° ͜ʖ ͡°)
        {
            Item item = repository.Items.FirstOrDefault(i => i.ID == ID);
            cart.AddItem(item, quantity);
            return RedirectToAction("CartWidget");//( ͡° ͜ʖ ͡°)
        }

        public ActionResult RemoveLineFromCart(Cart cart, int ID)//( ͡° ͜ʖ ͡°)
        {
            cart.RemoveLine(ID);
            return RedirectToAction("OpenCart");//( ͡° ͜ʖ ͡°)
        }
    }
}