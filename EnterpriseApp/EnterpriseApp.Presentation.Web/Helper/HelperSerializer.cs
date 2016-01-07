using EnterpriseApp.Domain.Shared.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;

namespace EnterpriseApp.Presentation.Web.Helper
{
    public class HelperSerializer : IHelperSerializer
    {
        public HelperSerializer()
        {

        }

        public string SerializeObjectWithXMLFormatter(object o)
        {
            string result = "";

            try
            {

                XmlAttributeOverrides overrides = new XmlAttributeOverrides();
                XmlAttributes attribs = new XmlAttributes();
                attribs.XmlIgnore = true;

                Type type = o.GetType();

                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    MethodInfo[] accessors = property.GetAccessors();
                    if (accessors != null && accessors.Count() > 0 && accessors.Any(a => a.IsVirtual))
                    {
                        attribs.XmlElements.Add(new XmlElementAttribute(property.Name));
                        overrides.Add(o.GetType(), property.Name, attribs);
                    }

                }

                XmlSerializer xmlSerializer = new XmlSerializer(o.GetType(), overrides);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(memoryStream, o);
                    memoryStream.Position = 0;
                    result = new StreamReader(memoryStream).ReadToEnd();
                }
            }
            catch (Exception)
            {

            }


            return result;
        }

        public byte[] DeSerializeObjectWithXMLFormatter(object o)
        {
            throw new NotImplementedException();
        }
    }

}