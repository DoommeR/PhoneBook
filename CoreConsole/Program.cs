using System;
using Core;


namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var element = new ContractElement();            
            Console.WriteLine(element.GetContacts());
        }
    }
}
