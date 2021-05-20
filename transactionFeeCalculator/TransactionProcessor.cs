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

                    string[] words = transaction.Split(" ");
                    string[] date = words[0].Split("-");
                    int[] nums = new int[3];
                    string merchant = words[1].ToUpper();
                    double additionalDiscount = 0;
                    double merchantDiscount = 0;
                    bool weekend = false;
                    //Console.WriteLine(merchant);

                    if (transactionCount < 10)
                    {
                        transactionCount++;
                    }
                    else
                    {
                        additionalDiscount = 0.2;
                    }

                    if (merchant == "CIRCLE_K")
                    {
                        merchantDiscount = 0.2;
                    }
                    else if (merchant == "TELIA")
                    {
                        merchantDiscount = 0.1;
                    }
                    //Console.WriteLine($"{merchant} {discount}");

                    for (int i = 0; i < date.Length; i++)
                    {
                        string dateNums = date[i];
                        if (dateNums[0].Equals('0'))
                        {
                            dateNums = dateNums.Remove(0, 1);
                            date[i] = dateNums;
                        }

                        int num = Convert.ToInt32(date[i]);
                        nums[i] = num;
                    }

                    DateTime dateValue = new DateTime(nums[0], nums[1], nums[2]);
                    int day = (int)dateValue.DayOfWeek;
                    //Console.WriteLine(day);

                    if (day == 6 || day == 0)
                    {
                        weekend = true;
                    }
                    //Console.WriteLine(weekend);

                    double cost = Convert.ToDouble(words[2]);
                    double fee = cost * 0.01;
                    fee -= (fee * merchantDiscount);
                    fee -= (fee * additionalDiscount);
                    if (weekend)
                    {
                        fee = 0.00;
                    }
                    fee = Math.Round(fee, 2);
                    //Console.WriteLine(fee);

                    writer.WriteLine($"{words[0]} {words[1]} {fee}");
                }
            }
        }
    }


}
