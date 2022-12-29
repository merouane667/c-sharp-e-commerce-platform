using System;
using System.Collections.Generic;
namespace c__project
{
public class Admin : User
{
    public Admin(int Id, int Index, string FullName, string Email, string PhoneNumber, string Address, PaymentMethod PaymentMethod, int Orders, List<Product> Wishlist) 
        : base(Id, Index, FullName, Email, PhoneNumber, Address, PaymentMethod, Orders, Wishlist)
    {
        // Any additional initialization for the Admin class can go here
    }

    // Method to create a new product
    public void CreateProduct(Product product)
    {
        // Implementation to create a new product goes here
    }

    // Method to read a product
    public Product ReadProduct(int productId)
    {
        // Implementation to read a product goes here
        return null;
    }

    // Method to update a product
    public void UpdateProduct(Product product)
    {
        // Implementation to update a product goes here
    }

    // Method to delete a product
    public void DeleteProduct(int productId)
    {
        // Implementation to delete a product goes here
    }

    // Method to create a new category
    public void CreateCategory(Category category)
    {
        // Implementation to create a new category goes here
    }

    // Method to read a category
    public Category ReadCategory(int categoryId)
    {
        // Implementation to read a category goes here
        return null;
    }

    // Method to update a category
    public void UpdateCategory(Category category)
    {
        // Implementation to update a category goes here
    }

    // Method to delete a category
    public void DeleteCategory(int categoryId)
    {
        // Implementation to delete a category goes here
    }
}
}