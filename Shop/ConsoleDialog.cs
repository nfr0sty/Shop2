namespace Shop;

public static class ConsoleDialog
{
    public static int ReadInt(string prompt)
    {
        bool isWork = true;
        int number = 0;

        while (isWork)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: Пустой ввод. Введите целое число.\n");
                continue;   
            }

            if (int.TryParse(input, out number) == false)
            {
                Console.WriteLine("Ошибка: Некорректное число. Пример: 10 или -3. Попробуйте снова.\n");
                continue;
            }

            isWork = false;
        }
        
        return number;
    }

    public static int ReadIntInRange(string prompt, int min, int max)
    {
        bool isWork = true;
        int number = 0;

        while (isWork)
        {
            number = ReadInt($"{prompt} от {min} до {max}\n");

            if (number < min || number > max)
            {
                Console.WriteLine($"Ошибка: введите число от {min} до {max}.");
                continue;
            }
            
            isWork = false;
        }

        return number;
    }

    public static void ReadRange(out int min, out int max, string promptMin, string promptMax)
    {
        bool isWork = true;
        min = 0;
        max = 0;
        
        while (isWork)
        {
            min = ReadInt(promptMin);
            max = ReadInt(promptMax);

            if (max < min)
            {
                Console.WriteLine($"Ошибка: максимум ({max}) меньше минимума ({min}). Введите значения заново.\n");
                continue;
            }
            
            isWork = false;
        }
    }

    public static bool ReadYesNo(string prompt)
    {
        string[] yes = { "y", "yes", "д", "да", "ага", "lf" };
        string[] no  = { "n", "no", "н", "нет", "неа", "ytn" };
        
        bool isWork = true;

        while (isWork)
        {
            string input = ReadNonEmptyString(prompt).Trim();

            if (yes.Contains(input, StringComparer.OrdinalIgnoreCase))
                return true;

            if (no.Contains(input, StringComparer.OrdinalIgnoreCase))
                return false;

            Console.WriteLine("Ожидался ответ 'y/yes/д/да' или 'n/no/н/нет'. Попробуйте ещё раз.\n");
        }

        return false;
    }
    
    public static string ReadNonEmptyString(string prompt)
    {
        bool isWork = true;
        string value = string.Empty;

        while (isWork)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка: пустой ввод. Повторите.\n");
                continue;
            }

            value = input.Trim();
            isWork = false;
        }

        return value;
    }
    
    public static void ShowRemoveProduct(Customer customer, Product product)
    {
        Console.WriteLine($"{customer.Name} выкинул {product.Title} из корзины. Оставшиеся деньги: {customer.Money}");
    }
    
    public static void ShowPurchaseSuccess(Customer customer)
    {
        Console.WriteLine($"{customer.Name} успешно купил корзину за {customer.GetBasketTotal()} руб.");
        Console.WriteLine("Товары перемещены в сумку:");
        
        foreach (var product in customer.Bag)
        {
            Console.WriteLine($" - {product.Title}");
        }
        
        Console.WriteLine($"Осталось денег: {customer.Money} руб.");
    }

    public static void ShowPurchaseFailure(Customer customer)
    {
        Console.WriteLine($"{customer.Name} не смог оплатить корзину. Он ушёл ни с чем.");
    }
}