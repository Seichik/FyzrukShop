using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models.DOMAINModel.Entities;
using WebApplication2.Models.DOMAINModel.Abstract;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public enum ImageView { MainImage, ListImage, CartImage}
        private IRepository repository;
        int PageSize = 12; // Amount of items on a page
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }


        // GET: Home
        public ActionResult List(string category = "All", int page = 1)
        {
            IEnumerable<Item> ItemsOfSelectedCategory;
            if (category == "All")
                ItemsOfSelectedCategory = repository.Items.Where(it => it.Category != "Secret");
            else
                ItemsOfSelectedCategory = repository.Items.Where(it => it.Category == category);
            if (ItemsOfSelectedCategory.Count() == 0)
                return RedirectToAction("NotFound", new
                {
                    message = "Invalid category or items" +
                    " of the category are over."
                });
                ItemsListViewModel itemsViewModel = new ItemsListViewModel
                {
                    Items = ItemsOfSelectedCategory.OrderBy(i => i.ID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                    CurrentCategory = category,
                    PageInfo = new PageInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = ItemsOfSelectedCategory.Count()
                    }
                };
                return View(itemsViewModel);
          }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ItemPage(int id)
        {
            Item item = repository.Items.First(i => i.ID == id);
            return View(item);
        }

        public FileContentResult GetImage(int id, int imageKind)
        {
            Item item = repository.Items.SingleOrDefault(it => it.ID == id);
            
            if (item.Image.ListImage != null)
                return File(item.Image.Get((Image.ImageKind)imageKind), item.Image.ImageType);
            else
                return null;
        }

        public ActionResult NotFound(string message = "Incorrectly typed address " +
            "or such page on the site no longer exists.")
        {
            return View((object)message);
        }

    }
}