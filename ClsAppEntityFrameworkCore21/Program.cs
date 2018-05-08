using ClsAppEntityFrameworkCore21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
//https://docs.microsoft.com/pt-br/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-2.1
namespace ClsAppEntityFrameworkCore21
{
    class Program
    {
        static void Main(string[] args)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.ConfigureLogging(Console.WriteLine);
                //Console.WriteLine("Cadastre uma Pessoa");
                //Console.Write("Digite o nome");
                //string name = Console.ReadLine();
                //db.People.Add(new People { Name = name });
                //db.SaveChanges();

                var dateCreated = DateTime.Parse("06/05/2018");                
                

                var items = db.People
                    .Where(x => DatabaseContext.Date(x.Created.Value) == DatabaseContext.Date(dateCreated) || x.Created == null)                    
                    .ToList();

                foreach(var item in items)
                {
                    Console.WriteLine("{0:000} {1}", item.Id, item.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
