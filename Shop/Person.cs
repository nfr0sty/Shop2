namespace Shop;

public abstract class Person
{
    public Person(string name, int money)
    {
        Name = name;
        Money = money;
        Products = new List<Product>();
    }
    
    public string Name { get; private set; }
    public int Money { get; private set; }
    protected List<Product> Products { get; private set; }
    
    protected void IncreaseMoney(int amount)
    {
        Money += amount;
    }

    protected void DecreaseMoney(int amount)
    {
        Money -= amount;
    }

    public abstract void ShowProducts();
}