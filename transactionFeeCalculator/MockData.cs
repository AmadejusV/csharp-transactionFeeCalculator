using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace transactionFeeCalculator
{
    public class MockData
    {
        public static void CreateMockData(StreamWriter writer)
        {
            using (writer)
            {
                writer.WriteLine("2018-09-01 7-ELEVEN 50");
                writer.WriteLine("2018-09-02 CIRCLE_K 30");
                writer.WriteLine("2018-09-03 Telia 50");
                writer.WriteLine("2018-09-04 CIRCLE_K 30");
                writer.WriteLine("2018-09-05 7-ELEVEN 50");
                writer.WriteLine("2018-09-10 Telia 30");
                writer.WriteLine("2018-09-11 7-ELEVEN 50");
                writer.WriteLine("2018-09-12 CIRCLE_K 30");
                writer.WriteLine("2018-09-13 7-Telia 50");
                writer.WriteLine("2018-09-14 CIRCLE_K 30");
                writer.WriteLine("2018-09-15 7-ELEVEN 50");
                writer.WriteLine("2018-09-16 Telia 30");
            }
        }
    }
}
