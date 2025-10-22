namespace Shop;

public class Customer: Person
{
    public Customer(string name, decimal money) : base(name, money)
    {
        _basket = new List<Product>();
        _bag = new List<Product>();
    }
    
    private List<Product> _basket;
    private List<Product> _bag;
    
    public IReadOnlyList<Product> Basket => _basket;
    public IReadOnlyList<Product> Bag => _bag;

    public bool CanBuyBasket()
    {
        decimal total = 0;

        foreach (Product product in _basket)
        {
            total += product.Price;
        }
        
        return total >= Money;
    }

    public decimal GetBasketTotal()
    {
        decimal total = 0;

        foreach (Product product in _basket)
        {
            total += product.Price;
        }
        
        return total;
    }

    public void AddProductToBasket(Product product)
    {
        _basket.Add(product);
    }

    public void RemoveProductFromBasket(Product product)
    {
        _basket.Remove(product);
    }

    public void MoveBasketToBag()
    {
        _bag.AddRange(_basket);
        _basket.Clear();
    }

    public bool TryBuyBasket()
    {
        decimal total = GetBasketTotal();

        if (Money >= total)
        {
            DecreaseMoney(total);
            MoveBasketToBag();
            return true;
        }
        
        return false;
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