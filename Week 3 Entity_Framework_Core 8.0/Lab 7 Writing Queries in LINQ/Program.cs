using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using var context = new AppDbContext();
var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

Console.WriteLine("Filtered and Sorted Products:");
foreach (var p in filtered)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");
var productDTOs = await context.Products
    .Select(p => new { p.Name, p.Price })
    .ToListAsync();

Console.WriteLine("\n Product DTOs (Name and Price only):");
foreach (var dto in productDTOs)
    Console.WriteLine($"{dto.Name} - ₹{dto.Price}");