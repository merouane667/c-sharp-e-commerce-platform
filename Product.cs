using System;
using System.Collections.Generic;

namespace c__project
{
public class Product{
    private int Id;
    private string Name;
    private string Description;
    private float Price;
    private Category Category;
    private string Reference;
    private DateTime CreatedAt;
    private int NumberOfOrders;
    private Boolean InStock;

    public Product(int Id, string Name, string Description, float Price,Category Category, string Reference, DateTime CreatedAt, int NumberOfOrders, Boolean InStock) {
        this.Id = Id;
        this.Name=Name;
        this.Description=Description;
        this.Price=Price;
        this.Category=Category;
        this.Reference=Reference;
        this.CreatedAt=CreatedAt;
        this.NumberOfOrders=NumberOfOrders;
        this.InStock=InStock;
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

    public string GetName()
    {
        return this.Name;
    }

    public void SetName(string Name)
    {
        this.Name = Name;
    }

    public string GetDescription()
    {
        return this.Description;
    }

    public void SetDescription(string Description)
    {
        this.Description = Description;
    }

    public float GetPrice()
    {
        return this.Price;
    }

    public void SetPrice(float Price)
    {
        this.Price = Price;
    }

    public Category GetCategory()
    {
        return this.Category;
    }

    public void SetCategory(Category Category)
    {
        this.Category = Category;
    }

    public string GetReference()
    {
        return this.Reference;
    }

    public void SetReference(string Reference)
    {
        this.Reference = Reference;
    }


    public DateTime GetCreatedAt()
    {
        return this.CreatedAt;
    }

    public void SetCreatedAt(DateTime CreatedAt)
    {
        this.CreatedAt = CreatedAt;
    } 

    public int GetNumberOfOrders()
    {
        return this.NumberOfOrders;
    }

    public void SetNumberOfOrders(int NumberOfOrders)
    {
        this.NumberOfOrders = NumberOfOrders;
    } 

    public Boolean GetInStock()
    {
        return this.InStock;
    }

    public void SetInStock(Boolean InStock)
    {
        this.InStock = InStock;
    } 
}
}