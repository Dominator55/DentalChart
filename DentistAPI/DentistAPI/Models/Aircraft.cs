using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistAPI.Models
{
    public class Aircraft : EntityBase
    {
        public int BoxCapacity { get; set; }
        public double WeightCapacity { get; set; }
        public List<CargoBox> LoadedBoxes { get; set; }
        public double LoadedWeight { get; set; }

        private void CalculateWeight() {
            //sum all the loaded boxes weight and save it into LoadedWeight
        }

        public bool IsOverloaded()
        {
            return LoadedWeight > WeightCapacity ? true : false;
        }

        public void LoadBox(CargoBox box)
        {
            if (LoadedBoxes.Contains(box))
            {
                LoadedBoxes.Add(box);
                CalculateWeight();
            }
            else
            {
                //???
            }
        }

        public void RemoveBox(CargoBox box)
        {
            if (LoadedBoxes.Contains(box))
            {
                LoadedBoxes.Remove(box);
                CalculateWeight();
            }
            else
            {
                //???
            }
        }


    }
}
