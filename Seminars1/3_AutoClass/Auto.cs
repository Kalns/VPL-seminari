using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClass
{
    class Auto
    {
       
        private int motoraJauda { get; set; }
        private int motoraTilpums { get; set; }
        private String marka { get; set; }
        private String modelis { get; set; }

        public Auto() { }

        public void pritnParam()
        {
            Console.WriteLine("Marka: " + marka + ", Modelis: " + modelis + ", Motora jauda: " + motoraJauda + ", Motora tilpums: "+ motoraTilpums);
        }

        public double calcHorsepower() {
            return motoraJauda * 1.36;
        }

        public double calcAvgFuel()
        {
            return Math.Sqrt(motoraTilpums) * 6.7 / 100;
        }

        public double calcStoppingDistanceWetAsphalt(double speed)
        { double speedMPS = speed * 5 / 18;
            return (speedMPS * speedMPS) / 2 * 9.81 * 0.55;
        }

        public double calcStoppingDistanceDryAsphalt(double speed)
        {
            double speedMPS = speed * 5 / 18;
            return (speedMPS * speedMPS) / 2 * 9.81 * 0.75;
        }


    }
}
