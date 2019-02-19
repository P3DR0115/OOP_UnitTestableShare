using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_UnitTestableShare
{
    public class AirConditioner
    {
        public bool TurnedOn;
        public float Temperature;

        private float minimumTemp = 60f;
        private float maximumTemp = 80f;

        public AirConditioner()
        {

        }

        public string About()
        {
            return "";
        }

        public string ToggleOn()
        {

            return "";

        }

        public string changeTemp(float argument)
        {
            return "";
        }
    }
}
