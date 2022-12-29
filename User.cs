using System;
using System.Collections.Generic;

namespace c__project
{
public class User{
    private int Id;
    private enum Role{
        Admin,
        Normal
    }
    private string chosenRole;
    private string FullName;
    private string Email;
    private string PhoneNumber;
    private string Address;
    private PaymentMethod PaymentMethod;
    private int Orders;
    private List<Product> Wishlist;

    public User(int Id, int Index, string FullName, string Email, string PhoneNumber, string Address,PaymentMethod PaymentMethod, int Orders, List<Product> Wishlist){
        this.Id = Id;
        this.chosenRole = ((Role)Index).ToString();
        this.FullName=FullName;
        this.Email=Email;
        this.PhoneNumber=PhoneNumber;
        this.Address=Address;
        this.PaymentMethod=PaymentMethod;
        this.Orders=Orders;
        this.Wishlist=Wishlist;

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

    public string GetChosenRole()
    {
        return this.chosenRole;
    }

    public void SetChosenRole(string chosenRole)
    {
        this.chosenRole = chosenRole;
    }

    public string GetFullName()
    {
        return this.FullName;
    }

    public void SetFullName(string FullName)
    {
        this.FullName = FullName;
    }

    public string GetEmail()
    {
        return this.Email;
    }

    public void SetEmail(string Email)
    {
        this.Email = Email;
    }


    public string GetPhoneNumber()
    {
        return this.PhoneNumber;
    }

    public void SetPhoneNumber(string PhoneNumber)
    {
        this.PhoneNumber = PhoneNumber;
    }


    public string GetAddress()
    {
        return this.Address;
    }

    public void SetAddress(string Address)
    {
        this.Address = Address;
    }


    public PaymentMethod GetPaymentMethod()
    {
        return this.PaymentMethod;
    }

    public void SetPaymentMethod(PaymentMethod PaymentMethod)
    {
        this.PaymentMethod = PaymentMethod;
    }


    public int GetOrders()
    {
        return this.Orders;
    }

    public void SetOrders(int Orders)
    {
        this.Orders = Orders;
    }

    
    public List<Product> GetWishlist()
    {
        return this.Wishlist;
    }

    public void SetWishlist(List<Product> Wishlist)
    {
        this.Wishlist = Wishlist;
    }

}
}