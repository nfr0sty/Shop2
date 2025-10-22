namespace Shop;

public abstract class Person
{
    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        Products = new List<Product>();
    }
    
    public string Name { get; private set; }
    public decimal Money { get; private set; }
    protected List<Product> Products { get; private set; }
    
    protected void IncreaseMoney(int amount)
    {
        Money += amount;
    }

    protected void DecreaseMoney(decimal amount)
    {
        Money -= amount;
    }

    public abstract void ShowBag();
}