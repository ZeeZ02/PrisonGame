using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonGame
{
    public class Box
    {
        public int number { get; set; }
        public int numberInside { get; set; }
        public bool taken { get; set; } = false;


        public Box(int boxNumber)
        {
            this.number = boxNumber;
            taken = false;
        }

        public Box()
        {

        }

    }
}
