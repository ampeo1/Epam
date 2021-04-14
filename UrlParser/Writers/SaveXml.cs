using ParsingInterfaces;
using System;
using System.IO;
using System.Xml;
using WriterInterfaces;

namespace Writers
{
    public class SaveXml : IWriter
    {
        public void Save(Url[] urls, string path)
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("urlAddresses");
                    foreach(Url url in urls)
                    {
                        xmlWriter.WriteStartElement("urlAddress");

                        xmlWriter.WriteStartElement("host");
                        xmlWriter.WriteAttributeString("name", url.HostName);
                        xmlWriter.WriteEndElement();

                        if (!(url.Uri is null))
                        {
                            xmlWriter.WriteStartElement("uri");
                            foreach (string segment in url.Uri)
                            {
                                xmlWriter.WriteStartElement("segment");
                                xmlWriter.WriteString(segment);
                                xmlWriter.WriteEndElement();
                            }
                            xmlWriter.WriteEndElement();
                        }

                        if (!(url.Parameters is null))
                        {
                            xmlWriter.WriteStartElement("parameters");
                            foreach (var parameter in url.Parameters)
                            {
                                xmlWriter.WriteStartElement("parameter");
                                xmlWriter.WriteAttributeString("value", parameter.Item2);
                                xmlWriter.WriteAttributeString("key", parameter.Item1);
                                xmlWriter.WriteEndElement();
                            }
                            xmlWriter.WriteEndElement();
                        }
                        
                        xmlWriter.WriteEndElement();
                    }
                }
            }
        }
    }
}
