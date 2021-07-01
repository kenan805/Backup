using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    class DVD : Storage
    {
        public double WriteSpeed { get; private set; } = 80; // mb/s
        public double ReadSpeed { get; private set; } = 1.4; // mb/s
        public double DvdMemory { get; set; }
        public bool Type { get; set; }
        public DVD(string name, string model, bool type) : base(name, model)
        {
            DvdMemory = Capacity();
            Type = type;
        }
        public override double Capacity() => Type == false ? 4.7 : 9;
        public override void Copy()
        {
            var NeedTime = (int)(AllFilesVolume / WriteSpeed);
            var NeedCountMedia = (int)(AllFilesVolume / (DvdMemory * 1024));
            Console.WriteLine($"Media Count: {NeedCountMedia}");
            int hour = NeedTime / 60 / 60;
            int minute = (NeedTime / 60) - (hour * 60);
            int second = NeedTime - (((int)(NeedTime / 60)) * 60);
            Console.WriteLine($"Time: {hour}:{minute}:{second}");
        }
        public override double FreeMemory()
        {
            int mediaCount = (int)(AllFilesVolume / (DvdMemory * 1024));
            return AllFilesVolume - (mediaCount * DvdMemory * 1024);
        }
        public override void PrintDeviceInfo()
        {
            Console.WriteLine("-------- DVD Info --------");
            base.PrintDeviceInfo();
            Console.WriteLine($"Memory: {DvdMemory}");
            Console.WriteLine($"Write speed: {WriteSpeed}");
            Console.WriteLine($"Read speed: {ReadSpeed}");
            Console.Write("Type: ");
            if (Type==false) Console.WriteLine("Single-layer");
            else Console.WriteLine("Double-layer");
        }
    }
}
