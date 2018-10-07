using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************************");

            DecodeURl();



            Console.WriteLine("\n*************************");
            Console.ReadKey();
        }

        private static void DecodeURl()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            string encode = context.ER_Supports.Where(o => o.ID == 112).FirstOrDefault().Message;
            Console.WriteLine(encode);

            Console.WriteLine("************ Decode *************");
           string decode = HttpUtility.UrlDecode( encode);
            Console.WriteLine(decode);



        }
    }
}
