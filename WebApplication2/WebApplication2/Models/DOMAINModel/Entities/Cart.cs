using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Models.DOMAINModel.Entities
{

    public sealed class Cart
    {
        private List<CartLine> lines = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get => lines; }

        public void AddItem(Item item, int quantity)
        {
            CartLine line = lines.FirstOrDefault(l => l.Item.ID == item.ID);
            if (line == null)
                lines.Add(new CartLine
                {
                    Item = item,
                    Quantity = quantity
                });
            else
                line.Quantity += quantity;
        }

        public void RemoveLine(int ID)
        {
            lines.RemoveAll(l => l.Item.ID == ID);
        }

        public void Clear()
        {
            lines.Clear();
        }

        public int TotalItems { get => lines.Sum(l => l.Quantity); }

        public decimal TotalPrice { get => lines.Sum(l => l.Item.Price * l.Quantity); }
    }

    public class CartLine
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
    }

    public static class Stringer
    {
        public static string ToDollar(this decimal Price)
        {
            string finalPrice = "";
            string price = Price.ToString();
            string integerPartOfPrice = price.Substring(0, price.IndexOf(','));
            string decimalPartOfPrice = price.Substring(price.IndexOf(',') + 1,
                price.Substring(price.IndexOf(',')+1).Length);
            int lastDigitalOfIntPart =
                Convert.ToInt32(integerPartOfPrice[integerPartOfPrice.Length - 1].ToString());
            int lastDigitalOfDecPart =
                Convert.ToInt32(decimalPartOfPrice[decimalPartOfPrice.Length - 1].ToString());

            if (lastDigitalOfIntPart == 1)
                finalPrice += $"{integerPartOfPrice} dollar";
            else
                finalPrice += $"{integerPartOfPrice} dollars";

            if (Convert.ToInt32(decimalPartOfPrice) > 0)
            {
                if (lastDigitalOfDecPart == 1)
                    finalPrice += $" {decimalPartOfPrice} cent";
                else
                    finalPrice += $" {decimalPartOfPrice} cents";
            }
            return finalPrice;
        }
    }
}