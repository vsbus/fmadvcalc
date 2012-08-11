using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using fmCalculationLibrary;

namespace FilterSimulation
{
    public enum fmRangesSchema
    {
        [Description("Rotary Vacuum Filters")]
        RotaryVacuumFilters,
        [Description("Rotary Pressure Filters")]
        RotaryPressureFilters
    }

    public class fmRangesConfiguration
    {
        public fmRangesSchema AssignedSchema = fmRangesSchema.RotaryVacuumFilters;

        public Dictionary<fmGlobalParameter, fmDefaultParameterRange> Ranges = new Dictionary<fmGlobalParameter, fmDefaultParameterRange>();

        public fmRangesConfiguration()
        {
        }

        public fmRangesConfiguration(fmRangesConfiguration other)
        {
            AssignedSchema = other.AssignedSchema;
            Ranges = new Dictionary<fmGlobalParameter, fmDefaultParameterRange>(other.Ranges);
        }
    }
}
