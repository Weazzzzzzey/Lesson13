using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IAC.BL.Repositories;
using IAC.BL;
using System.Net;
using System.Net.Mail;
namespace Mainas
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportGeneratorcs reportGenerator = new ReportGeneratorcs(
                new AircraftRepository(),
                new AircraftModelRepository(),
                new CountryRepository(),
                new CompanyRepository());


            var Ataskaitele = reportGenerator.GenerateReportAircraftInEurope();
            /*
            foreach (var item in Ataskaitele)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}",item.AircraftTailNumber,item.BelongsToEU, item.CompanyCountryCode, item.CompanyCountryName,item.ModelDescription, item.ModelNumber, item.OwnerCompanyName);
            }
            Console.ReadLine(); */

            HTMLFormatter htmlformater = new HTMLFormatter();
            HTMLGenerator htmlGenerator = new HTMLGenerator(reportGenerator, htmlformater);
            Console.WriteLine(htmlGenerator.GenerateHTMLWithColors());
            Console.ReadLine();
        }
    }
}
