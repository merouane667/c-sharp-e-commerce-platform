using System;

namespace c__project
{
public class Category{
    private int Id;
    private string Name;
    private string Description;

    public Category(int Id, string Name, string Description){
        this.Id = Id;
        this.Name=Name;
        this.Description=Description;
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
}
}