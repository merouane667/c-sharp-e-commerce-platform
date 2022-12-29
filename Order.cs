using System;
using System.Collections.Generic;
namespace c__project
{
    class Order
    {
        private int Id = 0;
        private string Title;
        private List<Product> Products;
        private float TotalPrice;
        private DateTime CreatedAt;

        //constructor
        public Order(string Title,List<Product> Products,float TotalPrice,DateTime CreatedAt)
        {
            this.Id++;
            this.Title = Title;
            this.Products = Products;
            this.TotalPrice = TotalPrice;
            this.CreatedAt = CreatedAt;
        }
        
        //getters setters
        public int GetId()
        {
            return this.Id;
        }

        public void SetId(int Id)
        {
            this.Id = Id;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public void SetTitle(string Title)
        {
            this.Title = Title;
        }

        public List<Product> GetProducts()
        {
            return this.Products;
        }

        public void SetProducts(List<Product> Products)
        {
            this.Products = Products;
        }
        
        public float GetTotalPrice()
        {
            return this.TotalPrice;
        }

        public void SetTotalPrice(float TotalPrice)
        {
            this.TotalPrice = TotalPrice;
        }

        public DateTime GetCreatedAt()
        {
            return this.CreatedAt;
        }

        public void SetCreatedAt(DateTime CreatedAt)
        {
            this.CreatedAt = CreatedAt;
        }
    }
}