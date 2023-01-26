using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhlSystemClassLibrary;

namespace NHLSystemTestProject
{
    [TestClass]
    public class CanadianIncomeTaxManagerTest
    {
        [TestMethod]
        [DataRow(@"..\..\..\..\CanadianPersonalIncomeTaxRates.csv", 439)]
        public void LoadFromCsvFile_RowCount_CorrectCount(string filepath, int rows)
        {
            var dataManager = new CanadianIncomeTaxManage();

            List<string> list = dataManager.LoadFromCsvFile(filepath);

            Assert.AreEqual(rows, list.Count);
        }

        
    }
}
