using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemClassLibrary
{
    public class CanadianIncomeTaxManage
    {
        public List<string> LoadFromCsvFile(string filepath)
        {
            
            string line;
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
        }
    }
}
