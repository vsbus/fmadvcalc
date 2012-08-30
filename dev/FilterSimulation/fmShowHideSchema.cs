using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using fmCalculationLibrary;

namespace FilterSimulation
{
    public enum fmShowHideSchema
    {
        [Description("Continuous Filters")]
        ContinuousFilters,
        [Description("Batch Filters")]
        BatchFilters
    }

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
        public fmShowHideSchema AssignedSchema = fmShowHideSchema.ContinuousFilters;

        public List<fmGlobalParameter> ParametersList = new List<fmGlobalParameter>();

        public fmParametersToDisplay()
        {
        }

        public fmParametersToDisplay(fmParametersToDisplay other)
        {
            AssignedSchema = other.AssignedSchema;
            ParametersList = new List<fmGlobalParameter>(other.ParametersList);
        }

        public fmParametersToDisplay(fmShowHideSchema schema, IEnumerable<fmGlobalParameter> parameters)
        {
            AssignedSchema = schema;
            ParametersList = new List<fmGlobalParameter>(parameters);
        }
    }
}
