using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using fmCalculationLibrary;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation
{
    public enum fmUnitsSchema
    {
        [Description("Industrial")]
        Industrial,
        [Description("Pilot")]
        Pilot,
        [Description("Laboratory")]
        Laboratory
    }

    public class fmParametersToDisplay
    {
        public fmFilterSimMachineType.FilterCycleType AssignedSchema = fmFilterSimMachineType.FilterCycleType.ContinuousFilters;

        public List<fmGlobalParameter> ParametersList = new List<fmGlobalParameter>();

        public fmParametersToDisplay()
        {
        }

        public fmParametersToDisplay(fmParametersToDisplay other)
        {
            AssignedSchema = other.AssignedSchema;
            ParametersList = new List<fmGlobalParameter>(other.ParametersList);
        }

        public fmParametersToDisplay(fmFilterSimMachineType.FilterCycleType schema, IEnumerable<fmGlobalParameter> parameters)
        {
            AssignedSchema = schema;
            ParametersList = new List<fmGlobalParameter>(parameters);
        }
    }
}
