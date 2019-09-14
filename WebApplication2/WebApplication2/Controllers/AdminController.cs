using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models.DOMAINModel.Abstract;
using WebApplication2.Models.DOMAINModel.Entities;
using System.Web;

namespace WebApplication2.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
        private IRepository repository;

        public AdminController(IRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            IEnumerable<Item> items = repository.Items;
            return View(items);
        }

        public ActionResult Edit(int id)
        {
            Item item = repository.Items.FirstOrDefault(i => i.ID == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item, HttpPostedFileBase image)
        {
            //Need to fix it
            if(image != null)
            {
                item.Image.ImageType = image.ContentType;
                item.Image.MainImage = new byte[image.ContentLength];
                image.InputStream.Read(item.Image.MainImage, 0, image.ContentLength);
            }
            repository.SaveItem(item);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Edit",new Item());
        }

        public ActionResult Delete(int id)
        {
            Item item = repository.Items.FirstOrDefault(i => i.ID == id);
            repository.DeleteItem(item);
            return RedirectToAction("Index");
        }

    }
}