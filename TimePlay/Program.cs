using System;
using TimePlay;

class Program
{
    static void Main(string[] args)
    {
        //TimeZone.CurrentTimeZone.ToLocalTime();
        //Console.WriteLine(DateTime.Now);
        //long unixTimeInMillisec = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        //Console.WriteLine(unixTimeInMillisec);
        //DateTime d = FromUnixTime(unixTimeInMillisec);
        //Console.WriteLine(d);

        TimeRecharger timeRecharger = new TimeRecharger();
        Console.WriteLine($" 에너지 {timeRecharger.GetEnergy()}");
        for(int i=0; i < 20;i++)
        {
            timeRecharger.SpendEnergy();
        }
        ConsoleKeyInfo cki;
        while (true)
        {
            //cki = Console.ReadKey(true);
            //switch (cki.Key)
            //{
            //    case ConsoleKey.LeftArrow:
            //        break;
            //    case ConsoleKey.RightArrow:
            //        timeRecharger.SpendEnergy();
            //        Console.WriteLine($" 에너지 {timeRecharger.GetEnergy()}");
            //        break;
            //    case ConsoleKey.UpArrow:
            //        break;
            //    case ConsoleKey.DownArrow:
            //        break;
            //    case ConsoleKey.Q:
            //        return;
            //}
            Thread.Sleep(1000);
            Console.WriteLine($" 에너지 {timeRecharger.GetEnergy()} , {timeRecharger._Now} , {timeRecharger._timestamp}");
        }

    }

    static public DateTime FromUnixTime(long second)
    {
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return epoch.AddMilliseconds(second);
    }
}