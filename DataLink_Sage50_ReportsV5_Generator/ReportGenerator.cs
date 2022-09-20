using Sage.Reporting.Engine.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLink_Sage50_ReportsV5_Generator
{
    public class ReportCreator
    {
        private ReportCreator() { }

        static public bool Generate(string template, string sageDBLocation, string outputFileName, string sageVersion, string username, string pass) {
            IReportingEngineHost oHost;
            ReportingEngine oEngine;
            IReportingEngineSite oSite;


            oHost = new MyHost();
            oEngine = new ReportingEngine();
            oSite = oEngine.CreateInstance(oHost);

            IExportService oExport = (IExportService)oSite.GetService(ServiceIdentifiers.Export);
            oExport.SetAttribute("DIR", sageDBLocation);
            oExport.SetAttribute("DSN", $"SageLine50v{sageVersion}");
            oExport.SetAttribute("UID", username);
            oExport.SetAttribute("PWD", pass);

            oExport.Criteria.Add("CUSTOMER_REF_FROM", "");
            oExport.Criteria.Add("CUSTOMER_REF_TO", "ZZZZZZZZ");

            try
            {
                // Load the report file
                oExport.Load(template);
                if (oExport.Run(ExportType.pdf,
                    outputFileName, ExportFlags.SuppressUserInteraction))                
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }
    }
}
