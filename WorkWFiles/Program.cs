using System;

namespace WorkWFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            DateTime ds, df;
            ds = DateTime.Now;
            Console.WriteLine(parser.GetUserModel(3958).Name);
            df = DateTime.Now;
            Console.WriteLine(df-ds);
            Console.ReadLine();
        }
    }
}
