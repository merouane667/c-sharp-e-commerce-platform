using System;
using System.Collections.Generic;
namespace c__project

{
    class Cart
    {
        private List<Product> Products;
        private float TotalToPay;

        //constructor
        public Cart(List<Product> Products,float TotalToPay)
        {
            this.Products = Products;
            this.TotalToPay = TotalToPay;
        }

        //getters setters
        public List<Product> GetProducts()
        {
            return this.Products;
        }

        public void SetProducts(List<Product> Products)
        {
            this.Products = Products;
        }

        public float GetTotalToPay()
        {
            return this.TotalToPay;
        }

        public void SetTotalToPay(float TotalToPay)
        {
            this.TotalToPay = TotalToPay;
        }
        
    }
}