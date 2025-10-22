namespace Shop;

public class Product
{
    public Product(string title, string description, decimal price)
    {
        Title = title;
        Description = description;
        Price = price;
    }
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }

    public string GetInfo()
    {
        return $"{Title} , {Description} , {Price}";
    }
}