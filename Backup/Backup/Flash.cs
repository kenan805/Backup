using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    class Flash : Storage
    {
        public double FlashSpeedMbS { get; private set; } = 625; // 1saniyeye 625 mbayt
        public double FlashMemoryGb { get; set; } // Gb
        public Flash(string name, string model, double flashMemoryGb) : base(name, model)
        {
            FlashMemoryGb = flashMemoryGb;
        }
        public override void Copy()
        {
            var NeedTime = (int)(AllFilesVolume / FlashSpeedMbS);
            var NeedCountMedia = (int)(AllFilesVolume / (FlashMemoryGb * 1024));
            Console.WriteLine($"Media Count: {NeedCountMedia}");
            int hour = NeedTime / 60 / 60;
            int minute = (NeedTime / 60) - (hour * 60);
            int second = NeedTime - (((int)(NeedTime / 60)) * 60);
            Console.WriteLine($"Time: {hour}:{minute}:{second}");
        }
        public override double FreeMemory()
        {
            int mediaCount = (int)(AllFilesVolume / (FlashMemoryGb * 1024));
            return AllFilesVolume - (mediaCount * FlashMemoryGb * 1024);
        }
        public override double Capacity() => FlashMemoryGb;
        public override void PrintDeviceInfo()
        {
            Console.WriteLine("-------- Flash Info --------");
            base.PrintDeviceInfo();
            Console.WriteLine($"Speed: {FlashSpeedMbS} mb/s");
            Console.WriteLine($"Memory: {FlashMemoryGb} gb");
        }
    }
}
