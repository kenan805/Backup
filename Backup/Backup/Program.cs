using System;

namespace Backup
{
    class Program
    {
        static void Main(string[] args)
        {
            //Flash
            Flash flash = new("Flash", "Centon MP Valuepack", 8);
            flash.PrintDeviceInfo();
            Console.WriteLine($"Flash capacity: {flash.Capacity()} gb");
            flash.Copy();
            Console.WriteLine($"Flash free memory: {flash.FreeMemory()} mb");

            //Hdd
            HDD hdd = new("HDD", "Western digital", 500);
            hdd.PrintDeviceInfo();
            Console.WriteLine($"Hdd capacity: {hdd.Capacity()} gb");
            hdd.Copy();
            Console.WriteLine($"Hdd free memory: {hdd.FreeMemory()} mb");

            //DVD
            DVD dvd = new("DVD", "Sony",false);
            dvd.PrintDeviceInfo();
            Console.WriteLine($"Hdd capacity: {dvd.Capacity()} gb");
            dvd.Copy();
            Console.WriteLine($"Hdd free memory: {dvd.FreeMemory()} mb");
        }
    }
}
    