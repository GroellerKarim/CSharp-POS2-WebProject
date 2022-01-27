// See https://aka.ms/new-console-template for more information
using Spg.Domain.Model;
using Spg.Infrastructure;

using (var db = new WebDbContext())
{
    Console.WriteLine("Does this even work");


    Category c1 = new Category("Kekw");
    db.Categories.Add(c1);
    db.SaveChanges();

}