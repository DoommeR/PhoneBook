using System;
using Core;


namespace CoreConsole
{
    class Program
    {
        static   void  Main(string[] args)
        {
            Core.Init.CoreInit();
            var elem = new ContractElement();

            var res = elem.getContactsList().Result;

            res.ForEach(r => Console.WriteLine(r.Phone));
            
        }
    }
}
