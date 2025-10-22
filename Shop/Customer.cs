namespace Shop;

public class Customer: Person
{
    public Customer(string name,  int money) : base(name, money){}

    public bool CanBuy(Product product)
    {
        return Money >= product.Price;
    }

    public void BuyProduct(Product product)
    {
        Products.Add(product);
        DecreaseMoney(product.Price);
        Console.WriteLine($"{Name} купил {product.Title} за {product.Price} руб.");
    }
    
    public override void ShowProducts()
    {
        Console.WriteLine($"\nУ {Name} куплены товары:");

        if (Products.Count == 0)
        {
            Console.WriteLine("Пока что нет купленных товаров.");
        }
        else
        {
            foreach (var product in Products)
            {
                Console.WriteLine($"{product.Title}");
            }
        }

        Console.WriteLine($"Остаток денег: {Money} руб.");
    }
}