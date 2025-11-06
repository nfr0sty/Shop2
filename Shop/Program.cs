namespace Shop;

class Program
{
    private const int MinItemsInBasket = 2;
    private const int MaxItemsInBasket = 4;
    
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    private List<Product> CreateProducts()
    {
        return new List<Product>
        {
            new Product("Молко", 2.50m),
            new Product("Курица", 15),
            new Product("Хлеб", 1.5m),
            new Product("Йогурт", 3.45m),
            new Product("Яйца", 3.70m),
            new Product("Вода минеральная 2л", 2),
            new Product("Стейк из говядины", 45),
            new Product("Гранола", 14.70m),
            new Product("Сникерс", 1.8m),
            new Product("Рыба Хек", 14),
            new Product("Консервированный тунец", 6.7m),
            new Product("Виноград", 10),
            new Product("Огурцы", 8.65m),
            new Product("Яблоко", 5.5m),
            new Product("Сыр легкий", 4.25m)
        };
    }
    
    private List<Customer> CreateCustomers()
    {
        return new List<Customer>
        {
            new Customer("Максим", 30),
            new Customer("Василий", 100),
            new Customer("Екатерина", 155),
            new Customer("Бомж Инакентий", 15)
        };
    }

    private void FillCustomersBaskets(List<Customer> customers, List<Product> products)
    {
        foreach (var customer in customers)
        {
            int itemCount = UserUtils.GenerateRandomNumber(MinItemsInBasket, MaxItemsInBasket);
            
            for (int i = 0; i < itemCount; i++)
            {
                int index = UserUtils.GenerateRandomNumber(products.Count);
                customer.AddProductToBasket(products[index]);
            }
        }
    }
    
    private void Run()
    {
        List<Product> products = CreateProducts();
        Supermarket supermarket = new Supermarket(products);

        List<Customer> customers = CreateCustomers();
        FillCustomersBaskets(customers, products);

        foreach (var customer in customers)
            supermarket.AddCustomer(customer);

        while (supermarket.Customers.Count > 0)
            supermarket.ServeNextCustomer();

        ConsoleDialog.ShowSupermarketStats(supermarket);
        
        foreach (var customer in customers)
            ConsoleDialog.ShowCustomerStatus(customer);
    }
}