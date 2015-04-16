using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Merger
{
    class XMLWorker
    {
        private string settingsFile = "settings.xml";

        public XMLWorker()
        {
            if (!File.Exists(settingsFile))
            {
                CreateXMLDocument(settingsFile);
            }
        }

        private void CreateXMLDocument(string filepath)
        {
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF32);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("settings");
            xtw.WriteEndDocument();
            xtw.Close();
        }

        public void updateCols(Array[] cols, int table, int row)
        {
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(this.settingsFile, FileMode.Open);
            xd.Load(fs);

            XmlElement work = xd.CreateElement("work");
            work.SetAttribute("id", "work1");

            //xd.GetElementsByTagName("settings")[0].AppendChild(work);

            //fs.Close();
            //xd.Save(this.settingsFile);

            XmlNodeList rw = xd.GetElementsByTagName("work")[table].ChildNodes;

            fs.Close();
            xd.Save(this.settingsFile);
        }

        private void WriteToXMLDocument(string filepath, string name, string descr, string photoPath = null)
        {
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            XmlElement user = xd.CreateElement("user");
            user.SetAttribute("id", (xd.GetElementsByTagName("user").Count + 1).ToString());

            XmlElement login = xd.CreateElement("name");
            XmlElement descr1 = xd.CreateElement("description");
            XmlElement pPath = xd.CreateElement("PhotoPath");
            XmlElement value = xd.CreateElement("Value");

            XmlText tLogin = xd.CreateTextNode(name);
            XmlText tDescr = xd.CreateTextNode(descr);
            XmlText tPhoto = xd.CreateTextNode(photoPath);
            XmlText tValue = xd.CreateTextNode("0");

            login.AppendChild(tLogin);
            descr1.AppendChild(tDescr);
            pPath.AppendChild(tPhoto);
            value.AppendChild(tValue);

            user.AppendChild(login);
            user.AppendChild(descr1);
            user.AppendChild(pPath);
            user.AppendChild(value);

            xd.DocumentElement.AppendChild(user);

            fs.Close();
            xd.Save(filepath);
        }
    }
}
