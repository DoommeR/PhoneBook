using System;
using Core;


namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var element = new ContractElement();
           var res = element.GetContacts().Result;
            Console.WriteLine(res);
        }
    }
}
