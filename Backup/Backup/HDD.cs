using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    class HDD : Storage
    {
        public double HddSpeedMbs { get; private set; } = 480; // 1saniyeye 480 mbayt
        public double HddMemoryGb { get; set; } // Gb
        public HDD(string name, string model,double hddMemoryGb) : base(name, model)
        {
            HddMemoryGb = hddMemoryGb;
        }
        public override double Capacity() => HddMemoryGb;
        public override void Copy()
        {
            var NeedTime = (int)(AllFilesVolume / HddSpeedMbs);
            var NeedCountMedia = (int)(AllFilesVolume / (HddMemoryGb * 1024));
            Console.WriteLine($"Media Count: {NeedCountMedia}");
            int hour = NeedTime / 60 / 60;
            int minute = (NeedTime / 60) - (hour * 60);
            int second = NeedTime - (((int)(NeedTime / 60)) * 60);
            Console.WriteLine($"Time: {hour}:{minute}:{second}");
        }
        public override double FreeMemory()
        {
            int mediaCount = (int)(AllFilesVolume / (HddMemoryGb * 1024));
            return AllFilesVolume - (mediaCount * HddMemoryGb * 1024);
        }
        public override void PrintDeviceInfo()
        {
            Console.WriteLine("-------- HDD Info --------");
            base.PrintDeviceInfo();
            Console.WriteLine($"Speed: {HddSpeedMbs} mb/s");
            Console.WriteLine($"Memory: {HddMemoryGb} gb");
        }
    }
}
