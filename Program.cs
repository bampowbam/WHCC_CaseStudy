using System;
using System.Globalization;
using System.Collections.Generic;

namespace WHCC_CaseStudy
{
  class Program
  {
    static void Main(string[] args)
    {
      while (true)
      {
        try
        {
          TryCatch();
        }
        catch (FormatException)
        {
          Console.WriteLine("You must enter a purely numeric/decimal value with no additional symbols");
          continue;
        }
      }
    }

    private static void TryCatch()
    {
      try
      {
        Console.WriteLine("Enter your amount of money(USD):");
        NumberFormatInfo current = NumberFormatInfo.CurrentInfo;
        int currency = Decimal.ToInt32(Convert.ToDecimal(Console.ReadLine(), current) * 100);
        Dictionary<string, int> wallet = new Dictionary<string, int>();
        int minCoinsNeeded = 0;

        wallet = MinCountNeeded(currency);

        minCoinsNeeded = wallet["dollars"] + wallet["quarters"] + wallet["dimes"] + wallet["nickels"] + wallet["pennies"];
        Console.WriteLine(String.Format("Min Number of coins needed: {0}", minCoinsNeeded));
        Console.WriteLine("Dollars: {0} needed", wallet["dollars"]);
        Console.WriteLine("Quarters: {0} needed", wallet["quarters"]);
        Console.WriteLine("Dimes: {0} needed", wallet["dimes"]);
        Console.WriteLine("Nickel: {0} needed", wallet["nickels"]);
        Console.WriteLine("Pennies: {0} needed", wallet["pennies"]);
        Console.ReadLine();
      }
      catch (FormatException)
      {
        Console.WriteLine("You must enter a purely numeric/decimal value with no additional symbols");
        Console.WriteLine("Enter your amount of money(USD):");
        NumberFormatInfo current = NumberFormatInfo.CurrentInfo;
        int currency = Decimal.ToInt32(Convert.ToDecimal(Console.ReadLine(), current) * 100);
        Dictionary<string, int> wallet = new Dictionary<string, int>();
        int minCoinsNeeded = 0;

        wallet = MinCountNeeded(currency);

        minCoinsNeeded = wallet["dollars"] + wallet["quarters"] + wallet["dimes"] + wallet["nickels"] + wallet["pennies"];
        Console.WriteLine(String.Format("Min Number of coins needed: {0}", minCoinsNeeded));
        Console.WriteLine("Dollars: {0} needed", wallet["dollars"]);
        Console.WriteLine("Quarters: {0} needed", wallet["quarters"]);
        Console.WriteLine("Dimes: {0} needed", wallet["dimes"]);
        Console.WriteLine("Nickel: {0} needed", wallet["nickels"]);
        Console.WriteLine("Pennies: {0} needed", wallet["pennies"]);
        Console.ReadLine();
      }
    }
    private static Dictionary<string, int> MinCountNeeded(int currency)
    {
      int minPenniesNeeded = 0;
      int minNickelsNeeded = 0;
      int minDimesNeeded = 0;
      int minQuartersNeeded = 0;
      int minDollarsNeeded = 0;
      Dictionary<string, int> wallet = new Dictionary<string, int>();
      while (currency > 0)
      {
        if (currency >= 100)
        {
          minDollarsNeeded = currency / 100;
          currency = currency - minDollarsNeeded * 100;
        }
        else if (currency >= 25 && currency < 100)
        {
          minQuartersNeeded = System.Math.DivRem(currency, 25, out minQuartersNeeded);
          currency = currency - minQuartersNeeded * 25;
        }
        else if (currency >= 10 && currency < 25)
        {
          minDimesNeeded = System.Math.DivRem(currency, 10, out minDimesNeeded);
          currency = currency - minDimesNeeded * 10;
        }
        else if (currency >= 5 && currency < 10)
        {
          minNickelsNeeded = System.Math.DivRem(currency, 5, out minNickelsNeeded);
          currency = currency - minNickelsNeeded * 5;
        }
        else if (currency >= 1 && currency < 5)
        {
          minPenniesNeeded = System.Math.DivRem(currency, 1, out minPenniesNeeded);
          currency = currency - minPenniesNeeded * 1;
        }
      }
      wallet.Add("dollars", minDollarsNeeded);
      wallet.Add("quarters", minQuartersNeeded);
      wallet.Add("dimes", minDimesNeeded);
      wallet.Add("nickels", minNickelsNeeded);
      wallet.Add("pennies", minPenniesNeeded);
      return wallet;
    }
  }
}

