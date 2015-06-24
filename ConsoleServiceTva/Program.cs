using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibraryTva;

namespace ConsoleServiceTva
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ServiceHost hote = new ServiceHost(typeof(ServiceTva));

            hote.Open();

            Console.WriteLine("service démarré...");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur entrée pour terminer");
            Console.ReadLine();

            hote.Close();
        }
    }
}
