using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task4_2
{
    class WorkWithFile
    {
        public void Write(List<ElectricalAppliances> list, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);   //Delete if exist
            }

            using (FileStream fs = File.Create(path))
            {
                foreach (ElectricalAppliances EA in list)
                {
                    AddText(fs, EA.GetTypeOf() + " " + EA.GetName() + " " + EA.GetStatus() + " " + EA.GetPower() + "\n");
                }
                Console.WriteLine("\nText has been successfully added to the file by the following path={0}!",path);
                fs.Close();
            }
        }

        public void Read(string path)              //File reading
        { 
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] bt = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(bt, 0, bt.Length) != 0)
                {
                    Console.WriteLine(temp.GetString(bt));
                }
                fs.Close();
            }
        }

        public void AddText(FileStream fs, string text)
        {
            byte[] bt = new UTF8Encoding(true).GetBytes(text);
            fs.Write(bt, 0, bt.Length);
        }
    }
}
