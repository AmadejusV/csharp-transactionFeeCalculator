using System;
using System.IO;

namespace transactionFeeCalculator
{
    public class TransactionProcessor
    {
        public void Process(StreamReader transactions, StreamWriter writer)
        {
            using (writer)
            {
                string transaction;
                int transactionCount = 0;
                while ((transaction = transactions.ReadLine()) != null)
                {
                    if (transactionCount < 10)
                    {
                        transactionCount++;
                    }
                    PrintTransactionsToFile(transaction, transactionCount, writer);
                }
            }
        }

        public static void PrintTransactionsToFile(string transaction, int transactionCount, StreamWriter writer)
        {
            string[] words = transaction.Split(" ");
            string[] givenDate = words[0].Split("-");
            int[] nums = new int[3];
            string merchant = words[1].ToUpper();
            //Console.WriteLine(merchant);

            double additionalDiscount = CountAdditionalDiscount(transactionCount);
            double merchantDiscount = CountMerchantDiscount(merchant);
            nums = RemoveDateZeros(givenDate, nums);
            bool weekend = isWeekend(nums);
            double fee = CalculateTransactionFee(words, merchantDiscount, additionalDiscount, weekend);

            writer.WriteLine($"{words[0]} {words[1]} {fee}");
        }

        public static double CalculateTransactionFee(string[] stringArray, double merchantDiscount, double additionalDiscount, bool isWeekend)
        {
            double cost = Convert.ToDouble(stringArray[2]);
            double fee = cost * 0.01;
            fee -= (fee * merchantDiscount);
            fee -= (fee * additionalDiscount);
            if (isWeekend)
            {
                fee = 0.00;
            }
            fee = Math.Round(fee, 2);
            //Console.WriteLine(fee);
            return fee;
        }

        public static double CountMerchantDiscount(string merchant)
        {
            double merchantDiscount=0;

            if (merchant == "CIRCLE_K")
            {
                merchantDiscount = 0.2;
            }
            else if (merchant == "TELIA")
            {
                merchantDiscount = 0.1;
            }
            return merchantDiscount;
        }

        public static double CountAdditionalDiscount(int count)
        {
            double additionalDiscount = 0;
            if (count < 10)
            {
                additionalDiscount = 0.2;
            }
            return additionalDiscount;
        }

        public static int[] RemoveDateZeros(string[] date, int[] numArray)
        {
            for (int i = 0; i < date.Length; i++)
            {
                string dateNumbers = date[i];
                if (dateNumbers[0].Equals('0'))
                {
                    dateNumbers = dateNumbers.Remove(0, 1);
                    date[i] = dateNumbers;
                }

                int num = Convert.ToInt32(date[i]);
                numArray[i] = num;
            }
            return numArray;
        }

        public static bool isWeekend(int[] numArray)
        {
            bool itsWeekend = false;
            DateTime dateValue = new DateTime(numArray[0], numArray[1], numArray[2]);
            int day = (int)dateValue.DayOfWeek;
            //Console.WriteLine(day);
            if (day == 6 || day == 0)
            {
                itsWeekend = true;
            }
            //Console.WriteLine(weekend);
            return itsWeekend;
        }
    }

}
