using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup
{
    abstract class Storage
    {
        public double AllFilesVolume { get; private set; } = 565 * 1024; //mb
        public string Name { get; set; }
        public string Model { get; set; }
        protected Storage(string name, string model)
        {
            Name = name;
            Model = model;
        }
        public abstract double Capacity();
        public abstract void Copy();
        public abstract double FreeMemory();
        public virtual void PrintDeviceInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Model: {Model}");
        }

    }
}
