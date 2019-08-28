using System.Linq;
using WebApplication2.Models.DOMAINModel.Abstract;
using WebApplication2.Models.DOMAINModel.Entities;

namespace WebApplication2.Models.DOMAINModel.Concrete
{
    public class EFItemRepository : IRepository
    {
        private FyzrukShopEntities context = new FyzrukShopEntities();
        public IQueryable<Item> Items
        {
            get
            {
                return context.Items;
            }
        }

        public void SaveItem(Item item)
        {
           Item aimItem = context.Items.Find(item.ID);
            if (aimItem == null)
                context.Items.Add(item);
            else
            {
                aimItem.Name = item.Name;
                aimItem.Category = item.Category;
                aimItem.Price = item.Price;
                aimItem.ShortDescription = item.ShortDescription;
                aimItem.FullDescription = item.FullDescription;
                aimItem.ImageType = item.ImageType;
                aimItem.Image = item.Image;
            }
            context.SaveChanges();

        }

        public void DeleteItem(Item item)
        {
            context.Items.Remove(item);
            context.SaveChanges();
        }
    }
}