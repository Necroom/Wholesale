using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Wholesale_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<WholesaleContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            using (WholesaleContext db = new WholesaleContext(options))
            {
                var products = db.Products.Take(5).ToList();
                Console.WriteLine("Демонстрация подключения к базе данных.");
                foreach (Product u in products)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }
            }
            Console.Read();

            using (WholesaleContext context = new())
            {
                Select(context);
                Update(context);
                Insert(context);
                Delete(context);
            }
        }
        static void Print(string sqltext, IEnumerable items)
        {
            Console.WriteLine(sqltext);
            Console.WriteLine("Записи: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        static void Select(WholesaleContext db)
        {
            // Задание 1 - выборка
            var query1 = from t in db.ProductsTypes
                         select new
                         {
                             Номер = t.Id,
                             Название = t.Name,
                             Упаковка = t.Packing,
                             Условия_Хранения = t.StorageConditions,
                             Описание = t.Description,
                             Особенности = t.Features
                         };
            Print("Выборка из таблицы со стороны один", query1.Take(5).ToList());
            //Задание 2 выборка с ограничением мз таблицы на стороне один
            var query2 = from t in db.ProductsTypes
                         where (t.Packing == "коробка") 
                         select new
                         {
                             Номер = t.Id,
                             Название = t.Name,
                             Упаковка = t.Packing,
                             Условия_Хранения = t.StorageConditions,
                             Описание = t.Description,
                             Особенности = t.Features
                         };
            Print("Выборка из таблицы на стороне один с упаковкой 'коробка'", query2.Take(10).ToList());
            //Задание 3 выборка с группировкой из таблицы на стороне многие
            var query3 = from p in db.Products
                         group p by p.TypeId into pr
                         select new
                         {
                             Тип = pr.Key,
                            // Название = string.Join(',', pr.Select(x => x.Name)),
                             Цена = pr.Sum(x => x.Price)
                         };
            Print("Выборка из таблицы на стороне многие c сложением цены товаров одного типа", query3.Take(5).ToList());
            //Задание 4 выборка из двух полей таблиц со связью один-ко-многим
            var query4 = from p in db.Products
                         join m in db.Manufacturers on p.ManufacturerId equals m.Id
                         select new
                         {
                             Номер = p.Id,
                             Название = p.Name,
                             Производитель = m.Name,
                             Цена = p.Price
                         };
            Print("Выборка из двух полей таблиц со связью один-ко-многим", query4.Take(5).ToList());
            //Задание 5 выборка из двух таблиц один-ко-многим, с ограничениями
            var query5 = from p in db.Products
                         join m in db.Manufacturers on p.ManufacturerId equals m.Id
                         where (p.Price < 100)
                         select new
                         {
                             Номер = p.Id,
                             Название = p.Name,
                             Производитель = m.Name,
                             Цена = p.Price
                         };
            Print("Выборка из двух таблиц один-ко-многим, с ценой продукта менее 100", query5.Take(5).ToList());
        }

        public static void  Insert(WholesaleContext db)
        {
            //Вставка на стороне 1
            ProductsType t = new()
            { 
                Name = "Карамельный петушок",
                Packing = "Целофан",
                Description = "Неудачная ходка",
                Features = "Тает",
                StorageConditions = "Прохлада"
            };
            db.ProductsTypes.Add(t);
            db.SaveChanges();
            var query1 = from pt in db.ProductsTypes
                         where pt.Name == "Карамельный петушок"
                         select new
                         {
                             Id = pt.Id,
                             Name = pt.Name
                         };
            Print("Результат добавления в таблицу на стороне один\n", query1.Take(5).ToList());
            //Вствка на стороне многие
            Product product = new()
            {
                Name = "Леденец на палочке",
                Price = 4,
                TypeId = 19,
                ManufacturerId = 20,
                ExpirationDate = new DateOnly(2026, 4, 17)
            };
            db.Products.Add(product);
            db.SaveChanges();
            var query2 = from p in db.Products
                         where p.Name == "Леденец на палочке"
                         select new 
                         {
                             Id = p.Id,
                             Name = p.Name
                         };
            Print("Результат добавления в таблицу на стороне многие\n", query2.Take(5).ToList());
        }
        public static void Delete(WholesaleContext db) 
        {
            string nametype = "коробка";
            var query1 = from p in db.Products
                         where (p.Type.Packing == nametype)
                         select new { Id = p.Id, Name = p.Name };
            Print("Записи, подлежащие удалению\n", query1.Take(5).ToList());

            var type = db.ProductsTypes.Where(c => c.Packing == nametype);
            var ptoduct = from p in db.Products
                          join t in db.ProductsTypes on p.TypeId equals t.Id
                          where t.Packing == nametype
                          select p;
            //Удаление нескольких записей в таблице ProductsTypes
            //Удаление записей в таблице Products
            db.Products.RemoveRange(ptoduct);
            db.ProductsTypes.RemoveRange(type);

            // сохранить изменения в базе данных
            db.SaveChanges();

            //Удаление записи из таблицы многие
            var query3 = from p in db.Products
                         where (p.Type.Packing == nametype)
                         select new { Id = p.Id, Name = p.Name };
            Print("Результат удаления\n", query3.Take(5).ToList());
        }
        static void Update(WholesaleContext db)
        {
            var query = from p in db.Products
                        join t in db.ProductsTypes on p.TypeId equals t.Id
                        where t.Packing == "коробка"
                        select new
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Type = t.Packing
                        };
            Print("Список продуктов с типом коробка до изменения", query.Take(5).ToList());

            string namepacking = "коробка";
            //подлежащие обновлению записи в связанной таблице Operations
            var someProducts = db.Products.Include("Type")
                .Where(o => (o.Type.Packing == namepacking));
            //обновление
            if (someProducts != null)
            {
                foreach (var p in someProducts)
                {
                    p.Name = "Печенье";
                };
            }

            // сохранить изменения в базе данных
            db.SaveChanges();

            var query1 = from p in db.Products
                        join t in db.ProductsTypes on p.TypeId equals t.Id
                        where t.Packing == "коробка"
                        select new
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Type = t.Packing
                        };
            Print("Список продуктов с типом коробка после изменения", query1.Take(5).ToList());

        }


    }
}
