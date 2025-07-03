using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
if (product != null)
{
    product.Price = 70000;
    await context.SaveChangesAsync();
    Console.WriteLine("Laptop price updated to ₹70000");
}
else
{
    Console.WriteLine("Laptop not found for update.");
}


var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
if (toDelete != null)
{
    context.Products.Remove(toDelete);
    await context.SaveChangesAsync();
    Console.WriteLine("'Rice Bag' deleted.");
}
else
{
    Console.WriteLine("Rice Bag not found for deletion.");
}