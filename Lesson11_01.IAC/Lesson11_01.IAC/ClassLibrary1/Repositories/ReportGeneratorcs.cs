using System;
using System.Collections.Generic;
using System.Text;

namespace IAC.BL.Repositories
{
    public class ReportGeneratorcs
    {
        public AircraftRepository aircraftRepository { get; set; }
        public AircraftModelRepository aircraftModelRepository { get; set; }
        public CountryRepository countryRepository { get; set; }
        public CompanyRepository companyRepository { get; set; }

        public ReportGeneratorcs(AircraftRepository aRepository, AircraftModelRepository aModelRepository, CountryRepository cRepository, CompanyRepository comRepository)
        {
            this.aircraftRepository = aRepository;
            this.aircraftModelRepository = aModelRepository;
            this.countryRepository = cRepository;
            this.companyRepository = comRepository;
        }

        public List<ReportItem> GenerateReportAircraftInEurope()
        {
            List < Aircraft > aircrafts = aircraftRepository.Retrieve();
         
            List<ReportItem> ataskaitele = new List<ReportItem>();
            
            foreach (var lektuvas in aircrafts)
            {
                Company lektuvoKompanija = companyRepository.Retrieve(lektuvas.CompanyId);
                Country salis = countryRepository.Retrieve(lektuvoKompanija.CountryId);
                AircraftModel lektuvoModelis = aircraftModelRepository.Retrieve(lektuvas.ModelId);
                if (salis.Continent == "Europe")
                {
                    ataskaitele.Add(new ReportItem(
                        lektuvas.TailNumber,
                        lektuvoModelis.Number,
                        lektuvoModelis.Description,
                        lektuvoKompanija.Name,
                        salis.Code,
                        salis.Name,
                        salis.BelongsToEU)) ;
                }

            }


            return ataskaitele;
        } 
    }
}
