using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace transactionFeeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\mobilePayTest.txt";
            string outputPath = @"c:\temp\mobilePayOutput.txt";
            StreamWriter mockDataWriter = new StreamWriter(path);
            using (mockDataWriter)
            {
                mockDataWriter.WriteLine("2018-09-01 7-ELEVEN 50");
                mockDataWriter.WriteLine("2018-09-02 CIRCLE_K 30");
                mockDataWriter.WriteLine("2018-09-03 7-ELEVEN 50");
                mockDataWriter.WriteLine("2018-09-04 CIRCLE_K 30");
                mockDataWriter.WriteLine("2018-09-05 7-ELEVEN 50");
                mockDataWriter.WriteLine("2018-09-10 CIRCLE_K 30");
                mockDataWriter.WriteLine("2018-09-11 7-ELEVEN 50");
                mockDataWriter.WriteLine("2018-09-12 CIRCLE_K 30");
                mockDataWriter.WriteLine("2018-09-13 7-ELEVEN 50");
                mockDataWriter.WriteLine("2018-09-14 CIRCLE_K 30");
                mockDataWriter.WriteLine("2018-09-15 7-ELEVEN 50");
                mockDataWriter.WriteLine("2018-09-16 CIRCLE_K 30");
            }
            StreamWriter streamWriter = new StreamWriter(outputPath);
            StreamReader streamReader = new StreamReader(path);
            TransactionApplication.Run(streamReader, streamWriter);
        }
    }


}
