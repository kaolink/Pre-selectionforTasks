using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Task3_2
{
    class WorkWithFileSerialize
    {
        public void Serialize(List<ElectricalAppliances> list, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);   //Delete if exist
            }

            using (FileStream fs = File.Create(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    bf.Serialize(fs, list);
                    Console.WriteLine("The data have been successfully serialized into following file = {0}!",path);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Unexpected erroe, find details here:{0}", e);
                    throw;
                }
                finally
                {
                    fs.Close();
                }

            }
        }
        public List<ElectricalAppliances> Deserialize(string path)
        {
            List<ElectricalAppliances> list = null;

            using (FileStream fs = File.OpenRead(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    list = (List<ElectricalAppliances>)bf.Deserialize(fs);
                    Console.WriteLine("The data have been successfully deserialized:");
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Unexpected erroe, find details here:{0}", e);
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
            return list;
        }
    }
}
