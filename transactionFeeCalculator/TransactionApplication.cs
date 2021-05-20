using System.IO;

namespace transactionFeeCalculator
{
    public static class TransactionApplication
    {
        public static void Run(StreamReader reader, StreamWriter writer)
        {
            var transactionProcessor = new TransactionProcessor();
            transactionProcessor.Process(reader, writer);
        }
    }
}
