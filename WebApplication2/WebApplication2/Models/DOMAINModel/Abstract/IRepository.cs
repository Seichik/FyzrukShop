using System.Linq;
using WebApplication2.Models.DOMAINModel.Entities;

namespace WebApplication2.Models.DOMAINModel.Abstract
{
    public interface IRepository
    {
        IQueryable<Item> Items { get; }
        void SaveItem(Item item);
        void DeleteItem(Item item);
    }
}
