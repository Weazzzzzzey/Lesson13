using System;
using System.Collections.Generic;
using System.Text;

namespace IAC.BL.Repositories
{
    public class HTMLGenerator
    {
        ReportGeneratorcs reportGenerator;
        List<ReportItem> ataskaitele = new List<ReportItem>();
        HTMLFormatter htmlFormater;

        public HTMLGenerator(ReportGeneratorcs reportGenerator, HTMLFormatter hTMLformater)
        {
            this.reportGenerator = reportGenerator;
            this.htmlFormater = hTMLformater;
        }

        public string GenerateHTMLWithColors()
        {
            ataskaitele = reportGenerator.GenerateReportAircraftInEurope();
            return htmlFormater.FormatHTML(ataskaitele);
        }
    }
}
