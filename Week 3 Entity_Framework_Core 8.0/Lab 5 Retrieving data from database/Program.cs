﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        if (!await context.Categories.AnyAsync())
        {
            var electronics = new Category { Name = "Electronics" };
            var groceries = new Category { Name = "Groceries" };

            await context.Categories.AddRangeAsync(electronics, groceries);

            var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
            var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

            await context.Products.AddRangeAsync(product1, product2);
            await context.SaveChangesAsync();

            Console.WriteLine("✅ Initial data inserted.");
        }
        else
        {
            Console.WriteLine("ℹ Data already exists. Skipping insertion.");
        }

        Console.WriteLine("\n=== All Products ===");
        var products = await context.Products.Include(p => p.Category).ToListAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price} (Category: {p.Category.Name})");
        }

        Console.WriteLine("\n=== Find Product by ID ===");
        var productById = await context.Products.FindAsync(1);
        Console.WriteLine($"Found: {productById?.Name ?? "Not Found"}");

        Console.WriteLine("\n=== First Product With Price > ₹50000 ===");
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive: {expensive?.Name ?? "None"}");
    }
}