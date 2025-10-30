namespace Shop;

public class Supermarket
{
    private List<Product> _products;
    private Queue<Customer> _customers;
    private decimal _earnedMoney;

    public Supermarket(List<Product> products)
    {
        _products = products;
        _customers = new Queue<Customer>();
        _earnedMoney = 0;
    }
    
    public IReadOnlyList<Product> Products => _products;
    public IReadOnlyCollection<Customer> Customers => _customers;
    
    public decimal EarnedMoney => _earnedMoney;
    
    public void AddCustomer(Customer customer)
    {
        _customers.Enqueue(customer);
    }

    public void ServeNextCustomer()
    {
        if (_customers.Count == 0)
            return;
        
        Customer customer = _customers.Dequeue();

        while (!customer.CanBuyBasket() && customer.Basket.Count > 0)
        {
            RemoveRandomProductFromCustomerBasket(customer);
        }

        if (customer.TryBuyBasket())
        {
            _earnedMoney += customer.GetBasketTotal();
        }
    }
    
    private void RemoveRandomProductFromCustomerBasket(Customer customer)
    {
        int productIndex = UserUtils.GenerateRandomNumber(customer.Basket.Count);
        Product productToRemove = customer.Basket[productIndex];
        customer.RemoveProductFromBasket(productToRemove);
    }
}