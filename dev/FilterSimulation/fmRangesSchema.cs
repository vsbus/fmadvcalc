using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using FilterSimulation.fmFilterObjects;
using fmCalculationLibrary;

namespace FilterSimulation
{
    public class fmRangesConfiguration
    {
        public fmFilterSimMachineType AssignedMachineType = fmFilterSimMachineType.RotaryVacuumFilter;

        public Dictionary<fmGlobalParameter, fmDefaultParameterRange> Ranges = new Dictionary<fmGlobalParameter, fmDefaultParameterRange>();

        public fmRangesConfiguration()
        {
        }

        public fmRangesConfiguration(fmRangesConfiguration other)
        {
            AssignedMachineType = other.AssignedMachineType;
            Ranges = new Dictionary<fmGlobalParameter, fmDefaultParameterRange>(other.Ranges);
        }
    }
}
