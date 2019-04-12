﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace LinqPractice101
{
    public class LinqSamples
    {
        private List<Product> productList;
        private List<Customer> customerList;

        private List<Product> GetProductList()
        {
            if (productList == null)
            {
                createLists();
            }

            return productList;
        }

        private List<Customer> GetCustomerList()
        {
            if (productList == null)
            {
                createLists();
            }

            return customerList;
        }

        // Create a productList and customer list
        private void createLists()
        {
            productList = GetProductListFromRawData();
            customerList = GetCustomerListFromXML();
        }

        protected DataTable CreateProductList()
        {
            DataTable table = new DataTable("Products");
            table.Columns.Add("ProductID", typeof(int));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("UnitPrice", typeof(decimal));
            table.Columns.Add("UnitsInStock", typeof(int));

            productList = GetProductListFromRawData();

            foreach (var p in productList)
            {
                table.Rows.Add(p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock);
            }

            return table;
        }

        // Product data created in-memory using collection initializer:
        protected List<Product> GetProductListFromRawData()
        {
            return new List<Product> {
                new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 39 },
                new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
                new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
                new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
                new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.3500M, UnitsInStock = 0 },
                new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.0000M, UnitsInStock = 120 },
                new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.0000M, UnitsInStock = 15 },
                new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.0000M, UnitsInStock = 6 },
                new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.0000M, UnitsInStock = 29 },
                new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 31 },
                new Product { ProductID = 11, ProductName = "Queso Cabrales", Category = "Dairy Products", UnitPrice = 21.0000M, UnitsInStock = 22 },
                new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", Category = "Dairy Products", UnitPrice = 38.0000M, UnitsInStock = 86 },
                new Product { ProductID = 13, ProductName = "Konbu", Category = "Seafood", UnitPrice = 6.0000M, UnitsInStock = 24 },
                new Product { ProductID = 14, ProductName = "Tofu", Category = "Produce", UnitPrice = 23.2500M, UnitsInStock = 35 },
                new Product { ProductID = 15, ProductName = "Genen Shouyu", Category = "Condiments", UnitPrice = 15.5000M, UnitsInStock = 39 },
                new Product { ProductID = 16, ProductName = "Pavlova", Category = "Confections", UnitPrice = 17.4500M, UnitsInStock = 29 },
                new Product { ProductID = 17, ProductName = "Alice Mutton", Category = "Meat/Poultry", UnitPrice = 39.0000M, UnitsInStock = 0 },
                new Product { ProductID = 18, ProductName = "Carnarvon Tigers", Category = "Seafood", UnitPrice = 62.5000M, UnitsInStock = 42 },
                new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", Category = "Confections", UnitPrice = 9.2000M, UnitsInStock = 25 },
                new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", Category = "Confections", UnitPrice = 81.0000M, UnitsInStock = 40 },
                new Product { ProductID = 21, ProductName = "Sir Rodney's Scones", Category = "Confections", UnitPrice = 10.0000M, UnitsInStock = 3 },
                new Product { ProductID = 22, ProductName = "Gustaf's Knäckebröd", Category = "Grains/Cereals", UnitPrice = 21.0000M, UnitsInStock = 104 },
                new Product { ProductID = 23, ProductName = "Tunnbröd", Category = "Grains/Cereals", UnitPrice = 9.0000M, UnitsInStock = 61 },
                new Product { ProductID = 24, ProductName = "Guaraná Fantástica", Category = "Beverages", UnitPrice = 4.5000M, UnitsInStock = 20 },
                new Product { ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme", Category = "Confections", UnitPrice = 14.0000M, UnitsInStock = 76 },
                new Product { ProductID = 26, ProductName = "Gumbär Gummibärchen", Category = "Confections", UnitPrice = 31.2300M, UnitsInStock = 15 },
                new Product { ProductID = 27, ProductName = "Schoggi Schokolade", Category = "Confections", UnitPrice = 43.9000M, UnitsInStock = 49 },
                new Product { ProductID = 28, ProductName = "Rössle Sauerkraut", Category = "Produce", UnitPrice = 45.6000M, UnitsInStock = 26 },
                new Product { ProductID = 29, ProductName = "Thüringer Rostbratwurst", Category = "Meat/Poultry", UnitPrice = 123.7900M, UnitsInStock = 0 },
                new Product { ProductID = 30, ProductName = "Nord-Ost Matjeshering", Category = "Seafood", UnitPrice = 25.8900M, UnitsInStock = 10 },
                new Product { ProductID = 31, ProductName = "Gorgonzola Telino", Category = "Dairy Products", UnitPrice = 12.5000M, UnitsInStock = 0 },
                new Product { ProductID = 32, ProductName = "Mascarpone Fabioli", Category = "Dairy Products", UnitPrice = 32.0000M, UnitsInStock = 9 },
                new Product { ProductID = 33, ProductName = "Geitost", Category = "Dairy Products", UnitPrice = 2.5000M, UnitsInStock = 112 },
                new Product { ProductID = 34, ProductName = "Sasquatch Ale", Category = "Beverages", UnitPrice = 14.0000M, UnitsInStock = 111 },
                new Product { ProductID = 35, ProductName = "Steeleye Stout", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 20 },
                new Product { ProductID = 36, ProductName = "Inlagd Sill", Category = "Seafood", UnitPrice = 19.0000M, UnitsInStock = 112 },
                new Product { ProductID = 37, ProductName = "Gravad lax", Category = "Seafood", UnitPrice = 26.0000M, UnitsInStock = 11 },
                new Product { ProductID = 38, ProductName = "Côte de Blaye", Category = "Beverages", UnitPrice = 263.5000M, UnitsInStock = 17 },
                new Product { ProductID = 39, ProductName = "Chartreuse verte", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 69 },
                new Product { ProductID = 40, ProductName = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18.4000M, UnitsInStock = 123 },
                new Product { ProductID = 41, ProductName = "Jack's New England Clam Chowder", Category = "Seafood", UnitPrice = 9.6500M, UnitsInStock = 85 },
                new Product { ProductID = 42, ProductName = "Singaporean Hokkien Fried Mee", Category = "Grains/Cereals", UnitPrice = 14.0000M, UnitsInStock = 26 },
                new Product { ProductID = 43, ProductName = "Ipoh Coffee", Category = "Beverages", UnitPrice = 46.0000M, UnitsInStock = 17 },
                new Product { ProductID = 44, ProductName = "Gula Malacca", Category = "Condiments", UnitPrice = 19.4500M, UnitsInStock = 27 },
                new Product { ProductID = 45, ProductName = "Rogede sild", Category = "Seafood", UnitPrice = 9.5000M, UnitsInStock = 5 },
                new Product { ProductID = 46, ProductName = "Spegesild", Category = "Seafood", UnitPrice = 12.0000M, UnitsInStock = 95 },
                new Product { ProductID = 47, ProductName = "Zaanse koeken", Category = "Confections", UnitPrice = 9.5000M, UnitsInStock = 36 },
                new Product { ProductID = 48, ProductName = "Chocolade", Category = "Confections", UnitPrice = 12.7500M, UnitsInStock = 15 },
                new Product { ProductID = 49, ProductName = "Maxilaku", Category = "Confections", UnitPrice = 20.0000M, UnitsInStock = 10 },
                new Product { ProductID = 50, ProductName = "Valkoinen suklaa", Category = "Confections", UnitPrice = 16.2500M, UnitsInStock = 65 },
                new Product { ProductID = 51, ProductName = "Manjimup Dried Apples", Category = "Produce", UnitPrice = 53.0000M, UnitsInStock = 20 },
                new Product { ProductID = 52, ProductName = "Filo Mix", Category = "Grains/Cereals", UnitPrice = 7.0000M, UnitsInStock = 38 },
                new Product { ProductID = 53, ProductName = "Perth Pasties", Category = "Meat/Poultry", UnitPrice = 32.8000M, UnitsInStock = 0 },
                new Product { ProductID = 54, ProductName = "Tourtière", Category = "Meat/Poultry", UnitPrice = 7.4500M, UnitsInStock = 21 },
                new Product { ProductID = 55, ProductName = "Pâté chinois", Category = "Meat/Poultry", UnitPrice = 24.0000M, UnitsInStock = 115 },
                new Product { ProductID = 56, ProductName = "Gnocchi di nonna Alice", Category = "Grains/Cereals", UnitPrice = 38.0000M, UnitsInStock = 21 },
                new Product { ProductID = 57, ProductName = "Ravioli Angelo", Category = "Grains/Cereals", UnitPrice = 19.5000M, UnitsInStock = 36 },
                new Product { ProductID = 58, ProductName = "Escargots de Bourgogne", Category = "Seafood", UnitPrice = 13.2500M, UnitsInStock = 62 },
                new Product { ProductID = 59, ProductName = "Raclette Courdavault", Category = "Dairy Products", UnitPrice = 55.0000M, UnitsInStock = 79 },
                new Product { ProductID = 60, ProductName = "Camembert Pierrot", Category = "Dairy Products", UnitPrice = 34.0000M, UnitsInStock = 19 },
                new Product { ProductID = 61, ProductName = "Sirop d'érable", Category = "Condiments", UnitPrice = 28.5000M, UnitsInStock = 113 },
                new Product { ProductID = 62, ProductName = "Tarte au sucre", Category = "Confections", UnitPrice = 49.3000M, UnitsInStock = 17 },
                new Product { ProductID = 63, ProductName = "Vegie-spread", Category = "Condiments", UnitPrice = 43.9000M, UnitsInStock = 24 },
                new Product { ProductID = 64, ProductName = "Wimmers gute Semmelknödel", Category = "Grains/Cereals", UnitPrice = 33.2500M, UnitsInStock = 22 },
                new Product { ProductID = 65, ProductName = "Louisiana Fiery Hot Pepper Sauce", Category = "Condiments", UnitPrice = 21.0500M, UnitsInStock = 76 },
                new Product { ProductID = 66, ProductName = "Louisiana Hot Spiced Okra", Category = "Condiments", UnitPrice = 17.0000M, UnitsInStock = 4 },
                new Product { ProductID = 67, ProductName = "Laughing Lumberjack Lager", Category = "Beverages", UnitPrice = 14.0000M, UnitsInStock = 52 },
                new Product { ProductID = 68, ProductName = "Scottish Longbreads", Category = "Confections", UnitPrice = 12.5000M, UnitsInStock = 6 },
                new Product { ProductID = 69, ProductName = "Gudbrandsdalsost", Category = "Dairy Products", UnitPrice = 36.0000M, UnitsInStock = 26 },
                new Product { ProductID = 70, ProductName = "Outback Lager", Category = "Beverages", UnitPrice = 15.0000M, UnitsInStock = 15 },
                new Product { ProductID = 71, ProductName = "Flotemysost", Category = "Dairy Products", UnitPrice = 21.5000M, UnitsInStock = 26 },
                new Product { ProductID = 72, ProductName = "Mozzarella di Giovanni", Category = "Dairy Products", UnitPrice = 34.8000M, UnitsInStock = 14 },
                new Product { ProductID = 73, ProductName = "Röd Kaviar", Category = "Seafood", UnitPrice = 15.0000M, UnitsInStock = 101 },
                new Product { ProductID = 74, ProductName = "Longlife Tofu", Category = "Produce", UnitPrice = 10.0000M, UnitsInStock = 4 },
                new Product { ProductID = 75, ProductName = "Rhönbräu Klosterbier", Category = "Beverages", UnitPrice = 7.7500M, UnitsInStock = 125 },
                new Product { ProductID = 76, ProductName = "Lakkalikööri", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 57 },
                new Product { ProductID = 77, ProductName = "Original Frankfurter grüne Soße", Category = "Condiments", UnitPrice = 13.0000M, UnitsInStock = 32 }
            };
        }

        private List<Customer> GetCustomerListFromXML()
        {
            // Customer/Order data read into memory from XML file using XLinq:
            var folderPath = Directory.GetCurrentDirectory();
            const string xmlFileName = "Customers.xml";
            var xmlFilePath = folderPath + "\\..\\..\\..\\" + xmlFileName;
            var customerList = (
                from e in XDocument.Load(xmlFilePath).
                    Root.Elements("customer")
                select new Customer
                {
                    CustomerID = (string)e.Element("id"),
                    CompanyName = (string)e.Element("name"),
                    Address = (string)e.Element("address"),
                    City = (string)e.Element("city"),
                    Region = (string)e.Element("region"),
                    PostalCode = (string)e.Element("postalcode"),
                    Country = (string)e.Element("country"),
                    Phone = (string)e.Element("phone"),
                    Fax = (string)e.Element("fax"),
                    Orders = (
                            from o in e.Elements("orders").Elements("order")
                            select new Order
                            {
                                OrderID = (int)o.Element("id"),
                                OrderDate = (DateTime)o.Element("orderdate"),
                                Total = (decimal)o.Element("total")
                            })
                        .ToArray()
                }).ToList();

            return customerList;
        }

        [Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
        public void Linq1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var lowNums =
                from n in numbers
                where n < 5
                select n;
            Console.WriteLine("Numbers < 5");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }

        [Description("This sample uses the where clause to find all products that are out of stock.")]
        public void Linq2()
        {
            List<Product> products = GetProductList();

            var soldOutProducts =
                from p in products
                where p.UnitsInStock == 0
                select p;

            Console.WriteLine("Sold out products:");
            foreach (var product in soldOutProducts)
            {
                Console.WriteLine("{0} is sold out!", product.ProductName);
            }
        }

        [Description("This sample uses where to find all products that are in stock and cost more than 3.00 per unit.")]
        public void Linq3()
        {
            List<Product> products = GetProductList();
            var expensiveInStockProducts =
                from p in products
                where p.UnitsInStock > 0 && p.UnitPrice > 3.00M
                select p;

            Console.WriteLine("In-stock products that cost more than 3.00:");
            foreach (var producut in products)
            {
                Console.WriteLine("{0} is in stock and costs more than 3.00.", producut.ProductName);
            }
        }

        [Description("This sample uses where to find all customers in Washington and then uses the resulting sequence to drill down into their orders.")]
        public void Linq4()
        {
            List<Customer> customers = GetCustomerList();

            var waCustomers =
                from c in customers
                where c.Region == "WA"
                select c;

            Console.WriteLine("Customers from Washington and their orders:");
            foreach (var waCustomer in waCustomers)
            {
                Console.WriteLine("Customer {0}: {1}", waCustomer.CustomerID, waCustomer.CompanyName);
                foreach (var order in waCustomer.Orders)
                {
                    Console.WriteLine("  Order: {0} : {1}", order.OrderID, order.OrderDate);
                }
            }
        }

        [Description("This sample demonstrates an indexed Where clause that returns digits whose name is shorter than their value.")]
        public void Linq5()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //            way1
            //            var shortDigits =
            //                from strDigit in digits
            //                where strDigit.Length < Array.IndexOf(digits, strDigit)
            //                select strDigit;

            //            way2
            //            var shortDigits = digits.Where(strDigit => strDigit.Length < Array.IndexOf(digits, strDigit));

            var shortDigits = digits.Where((strDigit, index) => strDigit.Length < index);

            foreach (var d in shortDigits)
            {
                Console.WriteLine("The word '{0}' is shorter than its value.", d);
            }
        }

        [Description("This sample uses select to produce a sequence of ints one higher than" +
                     "those in an existing array of ints")]
        public void Linq6()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //            var numPlusOne =
            //                from n in numbers
            //                select n + 1;

            var numPlusOne = numbers.Select(n => n + 1);

            Console.WriteLine("Number + 1");
            foreach (var i in numPlusOne)
            {
                Console.WriteLine(i);
            }
        }

        [Description("This sample uses select to return a sequence of just the names of a list of products.")]
        public void Linq7()
        {
            List<Product> products = GetProductList();

            //            var productNames =
            //                from p in products
            //                select p.ProductName;

            var productNames = products.Select(p => p.ProductName);

            Console.WriteLine("Product Names:");
            foreach (var pName in productNames)
            {
                Console.WriteLine(pName);
            }
        }

        [Description("This sample uses select to produce a sequence of strings representing the text version of a sequence of ints.")]
        public void Linq8()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //            var textNums =
            //                from n in numbers
            //                select strings[n];

            var textNums = numbers.Select(n => strings[n]);

            Console.WriteLine("Number strings:");
            foreach (var s in textNums)
            {
                Console.WriteLine(s);
            }
        }

        [Description("This sample uses select to produce a sequence of the uppercase and lowercase versions of each word in the original array.")]
        public void Linq9()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //            var upperLowerWords =
            //                from w in words
            //                select new { Upper = w.ToUpper(), Lower = w.ToLower() };
            var upperLowerWords = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
            }
        }

        [Description("This sample uses select to produce a sequence containing text representations of digits and whether their length is even or odd.")]
        public void Linq10()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //            var digitOddEvens =
            //                from n in numbers
            //                select new { Digit = strings[n], Even = (n % 2 == 0) ? "even" : "odd" };

            var digitOddEvens = numbers.Select(n => new { Digit = strings[n], Even = (n % 2 == 0) ? "even" : "odd" });

            foreach (var d in digitOddEvens)
            {
                Console.WriteLine("The digit {0} is {1}.", d.Digit, d.Even);
            }
        }

        [Description("This sample uses select to produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.")]
        public void Linq11()
        {
            List<Product> products = GetProductList();

            //            var productList =
            //                from p in products
            //                select new { p.ProductName, p.Category, Price = p.UnitPrice };

            var productInfos = products.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });

            Console.WriteLine("Product Info:");
            foreach (var productInfo in productInfos)
            {
                Console.WriteLine("{0} is in the category {1} and costs {2} per unit.", productInfo.ProductName, productInfo.Category, productInfo.Price);
            }
        }

        [Description("This sample uses an indexed Select clause to determine if the value of ints in an array match their position in the array.")]
        public void Linq12()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // way1 - by me
            //            var i = 0;
            //            var numsInPlace =
            //                from n in numbers
            //                select new { Num = n, InPlace = (i++ == n) };

            // way2 - by me
            //            var numsInPlace = numbers.Select(n => new { Num = n, InPlace = Array.IndexOf(numbers, n) == n });

            // way3 - official code way
            var numsInPlace = numbers.Select((n, index) => new { Num = n, InPlace = (n == index) });

            Console.WriteLine("Number: In-Place?");
            foreach (var n in numsInPlace)
            {
                Console.WriteLine("{0} : {1}", n.Num, n.InPlace);
            }
        }

        [Description("This sample combines select and where to make a simple query that returns the text form of each digit less than 5.")]
        public void Linq13()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            // way1
            //            var lowNums =
            //                from n in numbers
            //                where n < 5
            //                select digits[n];

            // way2
            var lowNums = numbers.Where(n => n < 5).Select(n => digits[n]);

            Console.WriteLine("Numbers < 5");
            foreach (var n in lowNums)
            {
                Console.WriteLine(n);
            }
        }

        [Description("This sample uses a compound from clause to make a query that returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.")]
        public void Linq14()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            /*
            // way1 - by me
            var pairs = numbersA.Select(n => new { Num = n, GreaterNums = numbersB.Where(greaterNum => greaterNum > n).Select(greaterNum => greaterNum) });

            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs)
            {
                foreach (var greaterNum in pair.GreaterNums)
                {
                    Console.WriteLine("{0} is less than {1}", pair.Num, greaterNum);
                }
            }*/

            // way2 - official way
            var pairs =
                from a in numbersA
                from b in numbersB
                where a < b
                select new { a, b };

            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs)
            {
                Console.WriteLine("{0} is less than {1}", pair.a, pair.b);
            }
        }

        [Description("This sample uses a compound from clause to select all orders where the order total is less than 500.00.")]
        public void Linq15()
        {
            List<Customer> customers = GetCustomerList();

            //  way1
            var orders =
                from c in customers
                from o in c.Orders
                where o.Total < 500.00M
                select new { c.CustomerID, o.OrderID, o.Total };

            // way2
            //            var orders = customers.SelectMany(c => c.Orders, (c, o) => new { c, o })
            //                .Where(@t => @t.o.Total < 500.00M)
            //                .Select(@t => new { @t.c.CustomerID, @t.o.OrderID, @t.o.Total });

            foreach (var order in orders)
            {
                Console.WriteLine("CustomerID={0} OrderID={1}, Total={2}", order.CustomerID, order.OrderID, order.Total);
            }
        }

        [Description("This sample uses a compound from clause to select all orders where the order was made in 1998 or later.")]
        public void Linq16()
        {
            List<Customer> customers = GetCustomerList();

            // way1
            var orders =
                from c in customers
                from o in c.Orders
                where o.OrderDate >= new DateTime(1998, 1, 1)
                select new { c.CustomerID, o.OrderID, o.OrderDate };

            // way2
            //            var orders = customers.SelectMany(c => c.Orders, (c, o) => new { c, o })
            //                .Where(@t => @t.o.OrderDate >= new DateTime(1998, 1, 1))
            //                .Select(@t => new { @t.c.CustomerID, @t.o.OrderID, @t.o.OrderDate });

            foreach (var order in orders)
            {
                Console.WriteLine("CustomerID={0} OrderID={1} OrderDate={2}", order.CustomerID, order.OrderID, order.OrderDate.ToString("M/d/yyyy"));
            }
        }

        [Description("This sample uses a compound from clause to select all orders where the order total is greater than 2000.00 and uses from assignment to avoid requesting the total twice.")]
        public void Linq17()
        {
            var customers = GetCustomerList();

            //            var orders =
            //                from c in customers
            //                from o in c.Orders
            //                where o.Total >= 2000.0M
            //                select new { c.CustomerID, o.OrderID, o.Total };

            var orders = customers.SelectMany(c => c.Orders, (c, o) => new { c, o })
                .Where(@t => @t.o.Total >= 2000.0M)
                .Select(@t => new { @t.c.CustomerID, @t.o.OrderID, @t.o.Total });

            foreach (var order in orders)
            {
                Console.WriteLine("CustomerID={0} OrderID={1} Total={2}", order.CustomerID, order.OrderID, order.Total);
            }
        }

        [Description("This sample uses multiple from clauses so that filtering on customers can be done before selecting their orders. This makes the query more efficient by not selecting and then discarding orders for customers outside of Washington.")]
        public void Linq18()
        {
            var customers = GetCustomerList();

            DateTime cutOffDate = new DateTime(1997, 1, 1);

            //            var orders =
            //                from c in customers
            //                where c.Region == "WA"
            //                from o in c.Orders
            //                where o.OrderDate >= cutOffDate
            //                select new { c.CustomerID, o.OrderID };

            var orders = customers.Where(c => c.Region == "WA")
                .SelectMany(c => c.Orders, (c, o) => new { c, o })
                .Where(@t => @t.o.OrderDate >= cutOffDate)
                .Select(@t => new { @t.c.CustomerID, @t.o.OrderID });

            foreach (var o in orders)
            {
                Console.WriteLine("CustomerID={0} OrderID={1}", o.CustomerID, o.OrderID);
            }
        }

        [Description("This sample uses an indexed SelectMany clause to select all orders, while referring to customers by the order in which they are returned from the query.")]
        public void Linq19()
        {
            var customers = GetCustomerList();

            var customerOrders =
                customers.SelectMany(
                    (cust, custIndex) =>
                        cust.Orders.Select(o => new { CustIndex = custIndex + 1, o.OrderID }));

            foreach (var customerOrder in customerOrders)
            {
                Console.WriteLine("Customer #{0} has an order with OrderID {1}", customerOrder.CustIndex, customerOrder.OrderID);
            }
        }

        [Description("This sample uses Take to get only the first 3 elements of the array.")]
        public void Linq20()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // way1 - by using 'Where' and 'Select'
            //            var first3Numbers = numbers.Where(n => Array.IndexOf(numbers, n) < 3).Select(n => n);

            // way2 - by using 'Take'
            var first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:");

            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }
        }

        [Description("This sample uses Take to get only the first N elements of the array.")]
        public void Linq20_extend_by_me()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var numOfGetNumbersFromArray = numbers.Length + 100; // out of that array's range

            // way1 - by using 'Where' and 'Select'
            //            var first3Numbers = numbers.Where(n => Array.IndexOf(numbers, n) < numOfGetNumbersFromArray).Select(n => n);

            // way2 - by using 'Take'
            var first3Numbers = numbers.Take(numOfGetNumbersFromArray);

            Console.WriteLine("First N numbers:");

            // will show all elements in this array, and no exception occurred
            foreach (var n in first3Numbers)
            {
                Console.WriteLine(n);
            }
        }

        [Description("This sample uses Take to get the first 3 orders from customers in Washington.")]
        public void Linq21()
        {
            List<Customer> customers = GetCustomerList();

            var first3WAOrders = (
                from c in customers
                from o in c.Orders
                where c.Region == "WA"
                select new { c.CustomerID, o.OrderID, o.OrderDate })
                .Take(3);

            //            var first3WAOrders = customers.SelectMany(c => c.Orders, (c, o) => new { c, o })
            //                .Where(@t => @t.c.Region == "WA")
            //                .Select(@t => new { @t.c.CustomerID, @t.o.OrderID, @t.o.OrderDate }).Take(3);

            Console.WriteLine("First 3 orders in WA:");
            foreach (var order in first3WAOrders)
            {
                Console.WriteLine("CustomerID={0} OrderID={1} OrderDate={2:M/d/yyyy}", order.CustomerID, order.OrderID, order.OrderDate);
            }
        }

        [Description("This sample uses Skip to get all but the first 4 elements of the array.")]
        public void Linq22()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // way1 - by using 'Where' and 'Select'
            //            var subArrayStartIndex = 4;
            //            var allButFirst4Numbers = numbers.Where(n => Array.IndexOf(numbers, n) >= subArrayStartIndex).Select(n => n);

            // way2 - by using 'Skip'
            var allButFirst4Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:");

            foreach (var n in allButFirst4Numbers)
            {
                Console.WriteLine(n);
            }
        }

        [Description("This sample uses Take to get all but the first 2 orders from customers in Washington.")]
        public void Linq23()
        {
            List<Customer> customers = GetCustomerList();

            var waOrders =
                from c in customers
                from o in c.Orders
                where c.Region == "WA"
                select new { c.CustomerID, o.OrderID, o.OrderDate };

            var allButFirst2Orders = waOrders.Skip(2);

            Console.WriteLine("All but first 2 orders in WA:");

            foreach (var order in allButFirst2Orders)
            {
                Console.WriteLine("CustomerID={0} OrderID={1} OrderDate={2:M/d/yyyy}", order.CustomerID, order.OrderID, order.OrderDate);
            }
        }

        [Description("This sample uses TakeWhile to return elements starting from the beginning of the array until a number is hit that is not less than 6.")]
        public void Linq24()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // way1 - by using 'First', 'Where' and 'Select'
            //            var firstNumberGreaterThan6 = numbers.First(n => n >= 6);
            //            var firstNumbersLessThan6 = numbers.Where(n => Array.IndexOf(numbers, n) < Array.IndexOf(numbers, firstNumberGreaterThan6)).Select(n => n);

            // way2
            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            Console.WriteLine("First numbers less than 6:");

            foreach (var n in firstNumbersLessThan6)
            {
                Console.WriteLine(n);
            }
        }

        [Description("This sample uses TakeWhile to return elements starting from the beginning of the array until a number is hit that is less than its position in the array.")]
        public void Linq25()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // way1 - by using 'First', 'Where' and 'Select'
            var firstNumLessThanSelfIndex = numbers.First(n => n < Array.IndexOf(numbers, n));
            var firstSmallNumbers = numbers.Where(n => Array.IndexOf(numbers, n) < Array.IndexOf(numbers, firstNumLessThanSelfIndex)).Select(n => n);

            // way2 - by using 'TakeWhile'
            //            var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);

            Console.WriteLine("First numbers not less than their position:");

            foreach (var n in firstSmallNumbers)
            {
                Console.WriteLine(n);
            }
        }

        [Description("This sample uses SkipWhile to get the elements of the array starting from the first element divisible by 3.")]
        public void Linq26()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // way1 - by using 'First', 'Where' and 'Select'
            //            var indexOfFirstNumDivBy3 = numbers.First(n => n % 3 == 0);
            //            var numbersOfDivBy3 = numbers.Where(n => Array.IndexOf(numbers, n) >= indexOfFirstNumDivBy3).Select(n => n);

            // way2 - by using 'First' and 'Skip'
            //            var indexOfFirstNumDivBy3 = numbers.First(n => n % 3 == 0);
            //            var toSkipCnt = indexOfFirstNumDivBy3;
            //            var numbersOfDivBy3 = numbers.Skip(toSkipCnt);

            // way3 - by using - 'SkipWhile'
            var numbersOfDivBy3 = numbers.SkipWhile(n => n % 3 != 0);

            Console.WriteLine("All elements starting from first element divisible by 3:");

            foreach (var n in numbersOfDivBy3)
            {
                Console.WriteLine(n);
            }
        }

        [Description("This sample uses SkipWhile to get the elements of the array starting from the first element less than its position.")]
        public void Linq27()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            // way1 - by using 'First' and 'Where'
            //            var firstNumLessThanSelfIndex = numbers.First(n => n < Array.IndexOf(numbers, n));
            //            var indexOfFirstNumLessThanSelfIndex = Array.IndexOf(numbers, firstNumLessThanSelfIndex);
            //            var numbersLessThanSelfIndex = numbers.Where((n, index) => index >= indexOfFirstNumLessThanSelfIndex);

            // way2 - by using 'First' and 'Skip'
            //            var firstNumLessThanSelfIndex = numbers.First(n => n < Array.IndexOf(numbers, n));
            //            var indexOfFirstNumLessThanSelfIndex = Array.IndexOf(numbers, firstNumLessThanSelfIndex);
            //            var toSkipCnt = indexOfFirstNumLessThanSelfIndex;
            //            var numbersLessThanSelfIndex = numbers.Skip(toSkipCnt);

            // way3 - by using -'SkipWhile'
            var numbersLessThanSelfIndex = numbers.SkipWhile((n, index) => n >= index);

            Console.WriteLine("All elements starting from first element divisible by 3:");
            foreach (var n in numbersLessThanSelfIndex)
            {
                Console.WriteLine(n);
            }
        }

        [Description("This sample uses orderby to sort a list of words alphabetically.")]
        public void Linq28()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            //            var sortedWords =
            //                from w in words
            //                orderby w
            //                select w;

            var sortedWords = words.OrderBy(w => w);

            Console.WriteLine("The sorted list of words:");
            foreach (var w in sortedWords)
            {
                Console.WriteLine(w);
            }
        }

        [Description("This sample uses orderby to sort a list of words by length.")]
        public void Linq29()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWordsByLength = words.OrderBy(n => n.Length);

            Console.WriteLine("The sorted list of words (by length):");
            foreach (var w in sortedWordsByLength)
            {
                Console.WriteLine(w);
            }
        }

        [Description("This sample uses orderby to sort a list of products by name.")]
        public void Linq30()
        {
            List<Product> products = GetProductList();

            var sortedProductsByName = products.OrderBy(n => n.ProductName);

            foreach (var p in sortedProductsByName)
            {
                Console.WriteLine("ProductID= {0} ProductName={1} Category={2} UnitPrice={3} UnitsInStock={4}",
                    p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock);
            }
        }

        [Description("This sample uses an OrderBy clause with a custom comparer to do a case-insensitive sort of the words in an array.")]
        public void Linq31()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedInsensitiveWords = words.OrderBy(w => w, new CaseInsensitiveComparer());

            foreach (var w in sortedInsensitiveWords)
            {
                Console.WriteLine(w);
            }
        }

        public class CaseInsensitiveComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }
        }

        [Description("This sample uses orderby and descending to sort a list of doubles from highest to lowest.")]
        public void Linq32()
        {
            double[] decimalsNumbers = { 1.7, 2.3, 1.9, 4.1, 2.9 };

            //            var sortedDecimalsNumbersByDesc =
            //                from d in decimalsNumbers
            //                orderby d descending
            //                select d;

            var sortedDecimalsNumbersByDesc = decimalsNumbers.OrderByDescending(d => d);

            Console.WriteLine("The decimals numbers from highest to lowest:");
            foreach (var d in sortedDecimalsNumbersByDesc)
            {
                Console.WriteLine(d);
            }
        }

        [Description("This sample uses orderby to sort a list of products by units in stock from highest to lowest.")]
        public void Linq33()
        {
            List<Product> products = GetProductList();

            var sortedProductsByDesc = products.OrderByDescending(p => p.UnitsInStock);

            foreach (var p in sortedProductsByDesc)
            {
                Console.WriteLine("ProductID= {0} ProductName={1} Category={2} UnitPrice={3} UnitsInStock={4}",
                    p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock);
            }
        }

        [Description("This sample uses an OrderBy clause with a custom comparer to do a case-insensitive descending sort of the words in an array.")]
        public void Linq34()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWordsCaseInsensitiveByDesc = words.OrderByDescending(w => w, new CaseInsensitiveComparer());

            foreach (var w in sortedWordsCaseInsensitiveByDesc)
            {
                Console.WriteLine(w);
            }
        }

        [Description("This sample uses a compound orderby to sort a list of digits, first by length of their name, and then alphabetically by the name itself.")]
        public void Linq35()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //            var sortedDigitsByLengthAndAlphabet =
            //                from d in digits
            //                orderby d.Length, d
            //                select d;

            var sortedDigitsByLengthThenByAlphabet = digits.OrderBy(d => d.Length).ThenBy(d => d);

            Console.WriteLine("Sorted digits:");
            foreach (var d in sortedDigitsByLengthThenByAlphabet)
            {
                Console.WriteLine(d);
            }
        }

        [Description("This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort first by word length and then by a case-insensitive sort of the words in an array.")]
        public void Linq36()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWordsByLengthAndAlphabet = words.OrderBy(w => w.Length).ThenBy(w => w, new CaseInsensitiveComparer());

            foreach (var w in sortedWordsByLengthAndAlphabet)
            {
                Console.WriteLine(w);
            }
        }

        [Description("This sample uses a compound orderby to sort a list of products, first by category, and then by unit price, from highest to lowest.")]
        public void Linq37()
        {
            List<Product> products = GetProductList();

            var sortedProductsByCategoryThenByUnitPriceDesc =
                products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            foreach (var p in sortedProductsByCategoryThenByUnitPriceDesc)
            {
                Console.WriteLine("ProductID= {0} ProductName={1} Category={2} UnitPrice={3} UnitsInStock={4}",
                    p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock);
            }
        }

        [Description("This sample uses an OrderBy and a ThenBy clause with a custom comparer to sort first by word length and then by a case-insensitive descending sort of the words in an array.")]
        public void Linq38()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWordsByLengthThenByAlphabetCaseInsensitive =
                words.OrderBy(w => w.Length).ThenByDescending(w => w, new CaseInsensitiveComparer());

            foreach (var w in sortedWordsByLengthThenByAlphabetCaseInsensitive)
            {
                Console.WriteLine(w);
            }
        }

        [Description("This sample uses Reverse to create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.")]
        public void Linq39()
        {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var reversedIDigits = digits.Where(str => str[1].Equals('i')).Reverse();

            Console.WriteLine("A backwards list of the digits with a second character of 'i'");

            foreach (var reversedIDigit in reversedIDigits)
            {
                Console.WriteLine(reversedIDigit);
            }
        }

        [Description("This sample uses group by to partition a list of numbers by their remainder when divided by 5.")]
        public void Linq40()
        {
            int divisor = 5;
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //            var numberGroups =
            //                from n in numbers
            //                group n by n % divisor into g
            //                select new { Remainder = g.Key, Numbers = g };

            var numberGroups = numbers.GroupBy(n => n % divisor).Select(g => new { Remainder = g.Key, Numbers = g });

            foreach (var g in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by {1}", g.Remainder, divisor);
                foreach (var number in g.Numbers)
                {
                    Console.WriteLine(number);
                }
            }
        }

        [Description("This sample uses group by to partition a list of words by their first letter.")]
        public void Linq41()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };
            //            var wordGroups =
            //                from w in words
            //                group w by w[0] into g
            //                select new { FirstLetter = g.Key, Words = g };

            var wordGroups = words.GroupBy(w => w[0]).Select(g => new { FirstLetter = g.Key, Words = g });

            foreach (var g in wordGroups)
            {
                Console.WriteLine("Words that start with the letter '{0}'", g.FirstLetter);
                foreach (var word in g.Words)
                {
                    Console.WriteLine(word);
                }
            }
        }

        [Description("This sample uses group by to partition a list of products by category.")]
        public void Linq42()
        {
            var productList = GetProductList();

            //            var orderGroups =
            //                from p in productList
            //                group p by p.Category into g
            //                select new { Category = g.Key, Products = g };

            var orderGroups = productList.GroupBy(p => p.Category).Select(g => new { Category = g.Key, Products = g });

            foreach (var orderGroup in orderGroups)
            {
                Console.WriteLine("Category={0} Products=...", orderGroup.Category);
                foreach (var p in orderGroup.Products)
                {
                    Console.WriteLine("Products:ProductID= {0} ProductName={1} Category={2} UnitPrice={3} UnitsInStock={4}",
                        p.ProductID, p.ProductName, p.Category, p.UnitPrice, p.UnitsInStock);
                }
            }
        }

        [Description("This sample uses group by to partition a list of each customer's orders, first by year, and then by month.")]
        public void Linq43()
        {
            List<Customer> customers = GetCustomerList();

            var customerOrderGroups =
                from c in customers
                select
                    new
                    {
                        c.CompanyName,
                        YearGroups =
                            from o in c.Orders
                            group o by o.OrderDate.Year into yearGroup
                            select
                                new
                                {
                                    Year = yearGroup.Key,
                                    MonthGroups =
                                        from o in yearGroup
                                        group o by o.OrderDate.Month into monthGroup
                                        select new { Month = monthGroup.Key, Orders = monthGroup }
                                }
                    };

            foreach (var customerOrderGroup in customerOrderGroups)
            {
                Console.WriteLine("CompanyName={0}=...", customerOrderGroup.CompanyName);
                foreach (var yearGroup in customerOrderGroup.YearGroups)
                {
                    Console.WriteLine("YearGroups:Year={0} MonthGroups=...", yearGroup.Year);
                    foreach (var monthGroup in yearGroup.MonthGroups)
                    {
                        Console.WriteLine("MonthGroups: Month={0} Orders", monthGroup.Month);
                        foreach (var month in monthGroup.Orders)
                        {
                            Console.WriteLine("OrderID={0} OrderDate={1:MM/dd/yyyy} Total={2}", month.OrderID, month.OrderDate, month.Total);
                        }
                    }
                }
            }
        }

        [Description("This sample uses GroupBy to partition trimmed elements of an array using a custom comparer that matches words that are anagrams of each other.")]
        public void Linq44()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var orderGroups = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer()).Select(g => new { TrimWord = g.Key, Words = g });

            foreach (var orderGroup in orderGroups)
            {
                Console.WriteLine("...");
                foreach (var word in orderGroup.Words)
                {
                    Console.WriteLine(word.Trim());
                }
            }
        }

        [Description("This sample uses GroupBy to partition trimmed elements of an array using a custom comparer that matches words that are anagrams of each other, and then converts the results to uppercase.")]
        public void Linq45()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            var orderGroups = anagrams.GroupBy(w => w.Trim(), upperCaseWord => upperCaseWord.ToUpper(), new AnagramEqualityComparer()).Select(g => new { TrimWord = g.Key, UpperCaseWords = g });

            foreach (var orderGroup in orderGroups)
            {
                Console.WriteLine("...");
                foreach (var upperCaseWord in orderGroup.UpperCaseWords)
                {
                    Console.WriteLine(upperCaseWord.Trim());
                }
            }
        }

        public class AnagramEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return GetCanonicalString(x) == GetCanonicalString(y);
            }

            public int GetHashCode(string obj)
            {
                return GetCanonicalString(obj).GetHashCode();
            }

            private static string GetCanonicalString(string word)
            {
                char[] wordChars = word.ToCharArray();
                Array.Sort<char>(wordChars);
                return new string(wordChars);
            }
        }

        [Description("This sample uses Distinct to remove duplicate elements in a sequence of factors of 300.")]
        public void Linq46()
        {
            int[] numbers = { 2, 2, 3, 5, 5 };

            var numberSet = numbers.Distinct();

            Console.WriteLine("Distinct numbers:");
            foreach (var uniqueNumber in numberSet)
            {
                Console.WriteLine(uniqueNumber);
            }
        }

        [Description("This sample uses Distinct to find the unique Category names.")]
        public void Linq47()
        {
            List<Product> products = GetProductList();

            var uniqueCategoryNames = products.Select(p => p.Category).Distinct();

            Console.WriteLine("Unique category names");
            foreach (var uniqueCategoryName in uniqueCategoryNames)
            {
                Console.WriteLine(uniqueCategoryName);
            }
        }

        [Description("This sample uses Union to create one sequence that contains the unique values from both arrays.")]
        public void Linq48()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Unique numbers from both arrays:");
            foreach (var uniqueNumber in uniqueNumbers)
            {
                Console.WriteLine(uniqueNumber);
            }
        }

        [Description("This sample uses Union to create one sequence that contains the unique first letter from both product and customer names.")]
        public void Linq49()
        {
            var products = GetProductList();
            var custormers = GetCustomerList();

            var productFirstChars = products.Select(p => p.ProductName[0]);
            var custormerFirstChars = custormers.Select(p => p.CompanyName[0]);

            var uniqueFirstChars = productFirstChars.Union(custormerFirstChars);

            foreach (var uniqueFirstChar in uniqueFirstChars)
            {
                Console.WriteLine(uniqueFirstChar);
            }
        }

        [Description("This sample uses Intersect to create one sequence that contains the common values shared by both arrays.")]
        public void Linq50()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var commonNumbers = numbersA.Intersect(numbersB);

            Console.WriteLine("Common numbers shared by both arrays:");
            foreach (var commonNumber in commonNumbers)
            {
                Console.WriteLine(commonNumber);
            }
        }

        [Description("This sample uses Intersect to create one sequence that contains the common first letter from both product and customer names.")]
        public void Linq51()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productFirstChars = products.Select(p => p.ProductName[0]);
            var customerFirstChars = customers.Select(c => c.CompanyName[0]);

            var commonFirstChars = productFirstChars.Intersect(customerFirstChars);

            Console.WriteLine("Conmmon first letters from Product names and Customer names:");
            commonFirstChars.ToList().ForEach(commonChar => Console.WriteLine(commonChar));
        }

        [Description("This sample uses Except to create a sequence that contains the values from first number array that are not also in second number array.")]
        public void Linq52()
        {
            int[] firstNumberArray = { 0, 2, 4, 5, 6, 8, 9 };
            int[] secondNumberArray = { 1, 3, 5, 7, 8 };

            var numbersOnlyInFirstArray = firstNumberArray.Except(secondNumberArray);
            Console.WriteLine("Numbers in first array but not second array:");
            numbersOnlyInFirstArray.ToList().ForEach(Console.WriteLine);
        }

        [Description("This sample uses Except to create one sequence that contains the first letters of product names that are not also first letters of customer names.")]
        public void Linq53()
        {
            var products = GetProductList();
            var customers = GetCustomerList();

            var productFirstChars = products.Select(p => p.ProductName[0]);
            var customerFirstChars = customers.Select(c => c.CompanyName[0]);

            var productOnlyFirstChars = productFirstChars.Except(customerFirstChars);

            Console.WriteLine("First letters from Product names, but not from Customer names:");
            productOnlyFirstChars.ToList().ForEach(Console.WriteLine);
        }

        [Description("This sample uses ToArray to immediately evaluate a sequence into an array.")]
        public void Linq54()
        {
            double[] doubles = { 1.7, 2.3, 4.1, 1.9, 2.9 };

            var sortedDoublesByDesc = doubles.OrderByDescending(d => d);

            var doublesArrayByDesc = sortedDoublesByDesc.ToArray();

            Console.WriteLine("Every other double from highest to lowest:");
            for (int i = 0; i < doublesArrayByDesc.Length; i += 2)
            {
                Console.WriteLine(doublesArrayByDesc[i]);
            }
        }

        [Description("This sample uses ToList to immediately evaluate a sequence into a List<T>.")]
        public void Linq55()
        {
            string[] words = { "cherry", "apple", "blueberry" };

            var sortedWords = words.OrderBy(w => w);
            var wordList = sortedWords.ToList();

            Console.WriteLine("The sorted word list:");
            wordList.ForEach(Console.WriteLine);
        }

        [Description("This sample uses ToDictionary to immediately evaluate a sequence and a related key expression into a dictionary.")]
        public void Linq56()
        {
            var scoreRecords = new[]
            {
                new {Name="Alice", Score=50},
                new {Name="Bob", Score=40},
                new {Name="Cathy", Score=45},
            };

            var scoreRecordsDictionary = scoreRecords.ToDictionary(sr => sr.Name);
            Console.WriteLine("Bob's score: {0}", scoreRecordsDictionary["Bob"]);
        }

        [Description("This sample uses OfType to return only the elements of the array that are of type double.")]
        public void Linq57()
        {
            object[] numbers = { null, 1.0, "two", 3, "four", 5, "six", 7.0, "#ABC" };

            var doubles = numbers.OfType<double>();

            Console.WriteLine("Numbers stored as doubles:");
            doubles.ToList().ForEach(Console.WriteLine);
        }

        [Description("This sample uses First to return the first matching element as a Product, instead of as a sequence containing a Product.")]
        public void Linq58()
        {
            var products = GetProductList();

            Product productObjIdIs12 = products.First(p => p.ProductID == 12);

            Console.WriteLine("ProductID= {0} ProductName={1} Category={2} UnitPrice={3} UnitsInStock={4}",
                productObjIdIs12.ProductID, productObjIdIs12.ProductName, productObjIdIs12.Category, productObjIdIs12.UnitPrice, productObjIdIs12.UnitsInStock);
        }
    }
}