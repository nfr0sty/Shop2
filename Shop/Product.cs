namespace Shop;

public class Product
{
    public Product(string title, decimal price)
    {
        Title = title;
        Price = price;
    }
    
    public string Title { get; private set; }
    public decimal Price { get; private set; }

    public string GetInfo()
    {
        return $"{Title} , {Price}";
    }
}