# csharp-transactionFeeCalculator

Read transaction strings from file, based on transaction sum calculate transaction fee.
Transaction fee depends on:
  1) if it's the weekend there's no transaction fee.
  2) if the merchant is Telia apply 10% discount.
  3) if the merchant is Circle K apply 20% discount.
  4) if the merchant made atleast 10 transactions all following transactions get another 20% discount.
Write the date, merchant and transaction fee to file I.E: 2018-09-01 7-ELEVEN 0.50
