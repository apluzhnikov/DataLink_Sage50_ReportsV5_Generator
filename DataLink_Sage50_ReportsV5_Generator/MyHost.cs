using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLink_Sage50_ReportsV5_Generator
{
    public class MyHost : Sage.Reporting.Engine.Integration.IReportingEngineHost
    {

        private Sage.Reporting.Engine.Integration.IReportingEngineSite _oSite;



        public object GetService(Guid identifier)

        {

            return null;

        }



        public Sage.Reporting.Engine.Integration.IReportingEngineSite Site

        {

            get { return _oSite; }

            set { _oSite = value; }

        }

    }

}
