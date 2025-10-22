namespace Shop;

public class Product
{
    public Product(string title, int price)
    {
        Title = title;
        Price = price;
    }
    
    public string Title { get; private set; }
    public int Price { get; private set; }

    public string GetInfo()
    {
        return $"{Title} , {Price}";
    }
}