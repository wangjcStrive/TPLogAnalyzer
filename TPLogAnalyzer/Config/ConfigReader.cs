using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TPLogAnalyzer.Config
{
    class ConfigRedaer : IAnalyzerConfigReader
    {
        public ConfigRedaer(enumLogType logType)
        {
            XDocument document = XDocument.Load(@".\TPLogAnalyzer Config.xml");
            XElement xele = null;
            //XElement xele = XElement.Load(@".\TPLogAnalyzer Config.xml");
            switch (logType)
            {
                case enumLogType.stsLogType:
                    xele = document.Root.Element("StsLog");
                    break;
                case enumLogType.DevLogType:
                    xele = document.Root.Element("DevLog");
                    break;
                case enumLogType.DebugLogType:
                    xele = document.Root.Element("DebugLog");
                    break;
                default:
                    //todo. throw exception.
                    break;
            }

            var devSQL = from item in xele.Element("Highlight").Elements("Config")
                         select new ConfigModel(item.Element("keyword").Value,
                                               item.Element("fontBold").Value,
                                               item.Element("fontColor").Value,
                                               item.Element("fontSize").Value,
                                               item.Element("backgroundColor").Value);
            m_configList = devSQL.ToList();
        }

        public void readConfig(enumLogType logType)
        {
            throw new NotImplementedException();
        }

        #region Members
        private List<ConfigModel> m_configList = new List<ConfigModel>();

        public List<ConfigModel> ConfigList { get => m_configList; set => m_configList = value; }
        #endregion
    }
}
