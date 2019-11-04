using NBAWithLinq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSolution
{
    class Program
    {
        static void Main(string[] args)
        {

            Position c1 = new Position() { Id = 1, Name = "Small Forward", Tier = 3 };
   
            Position c2 = new Position() { Id = 2, Name = "Point Gaurd", Tier = 1 };
 
            Position c3 = new Position() { Id = 3, Name = "Shooting Gaurd", Tier = 2 };

            List<Players> Players = new List<Players>()
            {
                new Players() { Id = 1, Name= "Daminan Lillard", Price = 1100.0, Position = c2  },
                new Players() { Id = 2, Name= "Lebron James", Price = 90.00, Position = c1 },
                new Players() { Id = 3, Name= "Devon Booker", Price = 1700.00, Position = c3 },
                new Players() { Id = 4, Name= "Rajon Rondo", Price = 1300.0, Position = c2 },
                new Players() { Id = 5, Name= "Ben Simmons", Price = 80.0, Position = c1 },
                new Players() { Id = 6, Name= "Steve Nash", Price = 700.0, Position = c2 },
                new Players() { Id = 7, Name= "Klay Thompson", Price = 700.0, Position = c3 },
                new Players() { Id = 8, Name= "JJ Redick", Price = 350.0, Position = c3 },
                new Players() { Id = 9, Name= "Stephen Curry", Price = 1800.0, Position = c2},
                new Players() { Id = 10, Name= "Cj MCcollum", Price = 700.0, Position = c3 },
                new Players() { Id = 11, Name= "Evan Turner", Price = 70.0, Position = c1 }
            };


            // ex1: Returns Tier with a price Less Than 900 

            var ex1 = from p in Players
                     where p.Position.Tier == 1 && p.Price < 900.0
                     select p;
            Print("From Tier 1 AND A PRICE < 900: ", ex1);


            // ex2: Returns Names of the Players from The "Small Forward" List

            var ex2 = from p in Players
                     where p.Position.Name == "Small Forward"
                     select p.Name;
            Print("NAMES OF Players FROM Small Forward: ", ex2);


            // ex3 = Returns The Position of Names that start with C {Cj MCcollum}

            var ex3 = from p in Players
                     where p.Name[0] == 'C'
                     select new { p.Name, p.Price, PositionName = p.Position.Name };
            Print("NAMES THAT START WITH 'C' ", ex3);


            // ex4 Returns the Small Forward Position Ordered By Price and then Name

            var ex4 = from p in Players
                     where p.Position.Tier == 1
                     orderby p.Name
                     orderby p.Price
                     select p;
            Print("TIER 1 ORDERED BY PRICE THEN BY NAME", ex4);

            // ex5 Returns the Small Forward Position Skipping to and return a total of 4

            var ex5 = (from p in ex4
                      select p).Skip(2).Take(4);
            Print("TIER 1 ORDEED BY PRICE THEN BY NAME SKIP 2 TAKE 4", ex5);

            // ex6 Returns a default of the first Player 

            var ex6 = (from p in Players select p).FirstOrDefault();
            Console.WriteLine("First or default test1: " + ex6);

            //ex 7 Returns Null because no player is worth 3000.00

            var ex7 = (from p in Players
                      where p.Price > 3000.00
                      select p).FirstOrDefault();
            Console.WriteLine("First or default test2: " + ex7);


            //ex 8 Returns the Highest price

            var ex8 = Players.Max(p => p.Price);
            Console.WriteLine("Max price: " + ex8);



            //ex 9 retruns the lowest price

            var ex9 = Players.Min(p => p.Price);
            Console.WriteLine("Min price: " + ex9);

            //ex 10 returns the sum of the small forwards price

            var ex10 = Players.Where(p => p.Position.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Position 1 Sum prices: " + ex10);

           // ex 11 returns the price of the player at ID position 1

            var ex11 = Players.Where(p => p.Position.Id == 1).Average(p => p.Price);
            Console.WriteLine("Position 1 average prices: " + ex11);

            //ex 12 returns the price of the player at ID position 5

            var ex12 = Players.Where(p => p.Position.Id == 5).Select(P => P.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Position 5 average prices: " + ex12);

            //ex13 Returns the Player of position 1's aggregated sum

            var ex13 = Players.Where(p => p.Position.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);
            Console.WriteLine("Position 1 aggregate sum: " + ex13);


            Console.WriteLine();
            //ex 14 returns the group players representitive of ther position
            var ex14 = from p in Players
                      group p by p.Position;

        

            foreach (IGrouping<Position, Players> group in ex14)
            {
                Console.WriteLine("Position " + group.Key.Name + ":");

                foreach (Players p in group)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine();
            }

        }

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
    }
}
