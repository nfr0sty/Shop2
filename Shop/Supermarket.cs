namespace Shop;

public class Supermarket
{
    private const int RemoveProductDelayMs = 500;
    private const int ServeCustomerDelayMs = 1000;
    private List<Product> _products;
    private Queue<Customer> _customers;
    private decimal _earnedMoney;
    private ConsoleDialog _consoleDialog = new ConsoleDialog();


    public Supermarket(List<Product> products)
    {
        _products = products;
        _customers = new Queue<Customer>();
        _earnedMoney = 0;
    }
    
    public IReadOnlyList<Product> Products => _products;
    public int CustomersCount => _customers.Count;
    
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
            Thread.Sleep(RemoveProductDelayMs);
        }
        
        decimal basketTotal = customer.GetBasketTotal();
        
        if (customer.TryBuyBasket())
        {
            _earnedMoney += basketTotal;
            _consoleDialog.ShowPurchaseSuccess(customer, basketTotal);
        }
        else
        {
            _consoleDialog.ShowPurchaseFailure(customer);
        }
        
        Thread.Sleep(ServeCustomerDelayMs);
    }
    
    private void RemoveRandomProductFromCustomerBasket(Customer customer)
    {
        int productIndex = UserUtils.GenerateRandomNumber(customer.Basket.Count);
        Product productToRemove = customer.Basket[productIndex];
        customer.RemoveProductFromBasket(productToRemove);
        _consoleDialog.ShowRemoveProduct(customer, productToRemove);
    }
}