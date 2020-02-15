using System;
using IAC.BL;
using IAC.BL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lesson11_01.IAC.test
{
    [TestClass]
    public class ReportGeneratorTests
    {
        [TestMethod]
        public void GenerateReportAircraftInEuropeShouldReturnListWithReportItems()
        {
            // Assign
            ReportGeneratorcs reportGenerator = new ReportGeneratorcs(
                new AircraftRepository(),
                new AircraftModelRepository(),
                new CountryRepository(),
                new CompanyRepository());

            //// Act
            var report = reportGenerator.GenerateReportAircraftInEurope();

            // Assert
            Assert.IsNotNull(report);
        }
    }
}
