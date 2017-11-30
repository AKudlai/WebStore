namespace WebStore.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cart
    {
        private readonly List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines => this.lineCollection;

        public void AddItem(Product product, int quantity)
        {
            CartLine line = this.lineCollection.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (line == null)
            {
                this.lineCollection.Add(new CartLine
                                       {
                                           Product = product,
                                           Quantity = quantity
                                       });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            this.lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return this.lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            this.lineCollection.Clear();
        }
    }
}
