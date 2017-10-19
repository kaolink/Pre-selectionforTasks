using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;

namespace Task4_1
{
    [Serializable]
    [XmlRoot(Namespace = "Space",DataType = "string", IsNullable =true)]

    class DataInXmL
    {
        public void SerializeXml(List<ElectricalAppliances> list, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ElectricalAppliances>));
            TextWriter tw = new StreamWriter(path);

            try
            {
                
                    serializer.Serialize(tw, list);
                
                Console.WriteLine("\nData have been successfully serialized to XML file!");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Unexpected error due to serialization, find details here:{0}", e);
            }
            finally
            {
                tw.Close();
            }
        }


        public List<ElectricalAppliances> DeserializeXml(string path)
        {

            XmlSerializer deserializer = new XmlSerializer(typeof(List<ElectricalAppliances>));
            TextReader tr = new StreamReader(path);
            List<ElectricalAppliances> backList = new List<ElectricalAppliances>();

            try
            {
                backList = (List<ElectricalAppliances>)deserializer.Deserialize(tr);
                Console.WriteLine("\nData have been successfully deserialized from the XML file!");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Unexpected error due to serialization, find details here:{0}", e);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                tr.Close();
            }

            return backList;
        }


    }
}
