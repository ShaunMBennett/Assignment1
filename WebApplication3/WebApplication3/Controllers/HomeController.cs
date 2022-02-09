using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        //Simple types program ment to show knowledge of simple types and how they can be used
        public IActionResult SimpleTypes()
        {
       
            string name = "Bob";

            byte age = 21;
            
            bool isOverTwenty = true;
            
            sbyte sbyteMinValue = sbyte.MinValue;
            sbyte sbyteMaxValue = sbyte.MaxValue;
            
            char gender = 'M';
            decimal money = 250.34m;
            float height = 5.11f;
            
            int intMinValue = int.MinValue; 
            int intMaxValue = int.MaxValue;

            uint uintMinValue = uint.MinValue;
            uint uintMaxValue = uint.MaxValue;

            long longMinValue = long.MinValue; 
            long longMaxValue = long.MaxValue;

            ulong ulongMinValue = ulong.MinValue;
            ulong ulongMaxValue = ulong.MaxValue;
            
            short shortMinValue = short.MinValue;
            short shortMaxValue = short.MaxValue;

            ushort ushortMinValue = ushort.MinValue;
            ushort ushortMaxValue = ushort.MaxValue;

            string example = $"Name: {name} Age: {age} Over 20?: {isOverTwenty} Gender: {gender} Money On Hand: {money} Height: {height}\n " +
                $"\nsbyte Min Value: {sbyteMinValue}                  sbyte Max Value: {sbyteMaxValue}\n" +
                $"\nint Min Value:   {intMinValue}           int Max Value: {intMaxValue}\n" +
                $"\nuint Min Value:  {uintMinValue}                     uint Max Value: {uintMaxValue}\n" +
                $"\nlong Min Value:  {longMinValue}  long Max Value {longMaxValue}\n" +
                $"\nulong Min Value: {ulongMinValue}                     ulong Max Value: {ulongMaxValue}\n" +
                $"\nshort Min Value: {shortMinValue}                short Max Value: {shortMaxValue}\n" +
                $"\nushortMinValue: {ushortMinValue}                      ushort Max Value: {ushortMaxValue}\n"

                ;

            return Content(example);
            
        }


        //"An enumeration type (or enum type) is a value type defined by a set of named constants of the underlying integral numeric type."
        //via:https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
        
        public enum Alphabet { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z }
       
        public IActionResult EnumLetter()
        {
            Array letters = Enum.GetValues(typeof(Alphabet));
            Random random = new Random();
            Alphabet randomLetter = (Alphabet)letters.GetValue(random.Next(letters.Length));
            string letter = $"A random letter: {randomLetter}";
            return Content(letter);
        }

        
        public class Student
        {
            public string Name { get; set; }
            public string Year { get; set; }

            public string Information()
            {
                return "Name: " + Name + " Year: " + Year; 
            }
        }

        public IActionResult ClassExample()
        {
            Student student = new Student { Name = "Shaun", Year = "Junior" };
            string example = student.Information();
            return Content(example);
           
        }
        //An interface contains definitions for a group of related functionalities that a non-abstract class or a struct must implement.
        //    An interface may define static methods, which must have an implementation.Beginning with C# 8.0, an interface may define a default implementation for members. 
        //    An interface may not declare instance data such as fields, auto-implemented properties, or property-like events.
        //By using interfaces, you can, for example, include behavior from multiple sources in a class.
        //That capability is important in C# because the language doesn't support multiple inheritance of classes.
        //In addition, you must use an interface if you want to simulate inheritance for structs, because they can't actually inherit from another struct or class.
        //You define an interface by using the interface keyword as the following example shows.
        //https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces
        public interface IGetArea
        {
            double GetArea();
        }

        public class Triangle : IGetArea
        {
            public double Base { get; set; }
            public double Height { get; set; } 

            public double GetArea()
            {
                return .50 * Base * Height;
            }
        }
        public IActionResult InterfaceExample()
        {
            double bas = 10;
            double height = 7;
            IGetArea area = new Triangle {Base = bas, Height= height };
            string example = $"The area of a triangle with the base of {bas} and the height of {height} is {area.GetArea()}  ";
            return Content(example);
        }

        //You can store multiple variables of the same type in an array data structure.
        //  You declare an array by specifying the type of its elements.
        //  f you want the array to store elements of any type, you can specify object as its type.
        //  In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from Object.
        //Via: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/
        public IActionResult ArrayExample()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, };
            string example = $"The sum of the array is {array.Sum()}\nThe length is { array.Length}";
            return Content(example);

        }
        //Anonymous types provide a convenient way to encapsulate a set of read-only properties into a single object without having to explicitly define a type first.
        //The type name is generated by the compiler and is not available at the source code level.The type of each property is inferred by the compiler.
        //VIA: https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/anonymous-types
        public IActionResult AnonTypesExample()
        {
            var anonType = new { Name = "Shaun" , Cash = 20.40, Age = 20 };
            string example = $" Name = {anonType.Name} Cash = { anonType.Cash} Age = {anonType.Age}";
            return Content(example);
        }
        public class Car
        {
            public string Maker { get; set; }
            public string Color { get; set; }

            public int Cost { get; set; }
        }
        //Language-Integrated Query(LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language.
        //Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support.
        //Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on.
        //With LINQ, a query is a first-class language construct, just like classes, methods, events.
        //You write queries against strongly typed collections of objects by using language keywords and familiar operators. 
        //The LINQ family of technologies provides a consistent query experience for objects (LINQ to Objects), relational databases (LINQ to SQL), and XML (LINQ to XML).
        //VIA: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        public IActionResult  LinqExample()
        {
            IList<Car> carList = new List<Car>()
            {
                new Car(){Maker = "Ford", Color = "Red", Cost = 24500},
                new Car(){Maker = "Telsa", Color = "Black", Cost = 50000},
                new Car(){Maker = "Volkswagen", Color = "Grey", Cost = 18000}
            };

            var carSearch = from car in carList
                            select new { car.Maker, car.Color, car.Cost };

            var example = "";
            foreach (var c  in carSearch)
            {
                example += $"Maker: {c.Maker} Color: {c.Color} Cost: {c.Cost}\n";
            }

            return Content(example);
        }

        // nullable value type T? represents all values of its underlying value type T and an additional null value.
        // For example, you can assign any of the following three values to a bool? variable: true, false, or null.
        // An underlying value type T cannot be a nullable value type itself.
        //VIA:https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
        public IActionResult NullableTypes()
        {
            int? x = null;
            int? y = 12;

            var example = $"Nullable types allow for values to be null\n" +
                $"Does X have a value? {x.HasValue}\n" +
                $"Does y have a value? {y.HasValue}";
            return Content(example);
                
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}