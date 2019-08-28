using System;
using System.Collections.Generic;
using WebApplication2.Models.DOMAINModel.Entities;


namespace WebApplication2.Models
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentCategory { get; set; }
        public double PagesCount
        {
            get
            {
                return Math.Ceiling((double)PageInfo.TotalItems / PageInfo.ItemsPerPage);
            }
        }

    }
}