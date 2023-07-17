using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Project.Data;

namespace Project.Controllers
{
    public class BugController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bug1()
        {
            int counter = 0;

            // Luồng 1
            Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter++;
                }
            });

            // Luồng 2
            Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter--;
                }
            });

            // Chờ hoàn thành các luồng
            Task.WaitAll();

            Console.WriteLine(counter); // Kết quả không xác định
            return View();

        }

        public string GetInputFromUser(){
            return "";
}
        public IActionResult Bug2()
        {
            string username = GetInputFromUser(); 

            string query = "SELECT * FROM Users WHERE Username = @Username";
            SqlCommand command = new SqlCommand(query, ShopContext);
            command.Parameters.AddWithValue("@Username", username);


            return View();
        }
        // Lỗi:
        public class MyClass
        {
            private List<int> _data = new List<int>();

            public void AddData(int value)
            {
                _data.Add(value);
            }
        }
        public IActionResult Bug3()
        {
        
            var instance = new MyClass();
            instance.AddData(1);
            instance = null;
            return View();
        }


        public static void RecursiveMethod(int depth)
        {
            if (depth > 0)
            {
                RecursiveMethod(depth - 1);
            }
        }

       

        public static void RecursiveMethod()
        {
            RecursiveMethod(1000); 
        }

        public IActionResult Bug5()
        {
            int counter = 0;

            // Luồng 1
            Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter++;
                }
            });

            // Luồng 2
            Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    counter--;
                }
            });

            // Chờ hoàn thành các luồng
            Task.WaitAll();

            Console.WriteLine(counter); // Kết quả không xác định

            return View();
        }



    }
}
