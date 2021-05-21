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
            MockData.CreateMockData(mockDataWriter);

            StreamWriter streamWriter = new StreamWriter(outputPath);
            StreamReader streamReader = new StreamReader(path);

            TransactionApplication.Run(streamReader, streamWriter);
        }
    }
}
