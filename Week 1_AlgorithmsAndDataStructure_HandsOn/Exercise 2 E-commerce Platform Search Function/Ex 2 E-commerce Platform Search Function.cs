using System;

class Product
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(string id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Category: {Category}");
    }
}

class SearchExample
{
   
    public static int LinearSearch(Product[] products, string name)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

   
    public static int BinarySearch(Product[] products, string name)
    {
        int left = 0, right = products.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int cmp = string.Compare(products[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);
            if (cmp == 0) return mid;
            else if (cmp < 0) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    static void Main()
    {
        Product[] products = {
            new Product("P001", "Keyboard", "Electronics"),
            new Product("P002", "Mouse", "Electronics"),
            new Product("P003", "Monitor", "Electronics"),
            new Product("P004", "Pen", "Stationery"),
            new Product("P005", "Notebook", "Stationery")
        };

        Console.WriteLine("🔍 Linear Search for 'Mouse':");
        int index = LinearSearch(products, "Mouse");
        if (index != -1) products[index].Display();
        else Console.WriteLine("Product not found.");


        Array.Sort(products, (p1, p2) => p1.ProductName.CompareTo(p2.ProductName));

        Console.WriteLine("\n🔍 Binary Search for 'Monitor':");
        index = BinarySearch(products, "Monitor");
        if (index != -1) products[index].Display();
        else Console.WriteLine("Product not found.");
    }
}
