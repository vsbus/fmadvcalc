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

    public class fmParametersToDisplay
    {
        public fmShowHideSchema AssignedSchema = fmShowHideSchema.ContinuousFilters;

        public List<fmGlobalParameter> ParametersList = new List<fmGlobalParameter>(new fmGlobalParameter[]
                                                                                             {
                                                                                                 fmGlobalParameter.A,
                                                                                                 fmGlobalParameter.Dp,
                                                                                                 fmGlobalParameter.sf,
                                                                                                 fmGlobalParameter.tc,
                                                                                                 fmGlobalParameter.hc,
                                                                                                 fmGlobalParameter.Msus,
                                                                                                 fmGlobalParameter.Qmsus,

                                                                                                 fmGlobalParameter.Dp_d,
                                                                                                 fmGlobalParameter.eps_d,
                                                                                                 fmGlobalParameter.rho_d,
                                                                                                 fmGlobalParameter.eta_d,
                                                                                                 fmGlobalParameter.sigma,
                                                                                                 fmGlobalParameter.pke0,
                                                                                                 fmGlobalParameter.pke,
                                                                                                 fmGlobalParameter.pc_d,
                                                                                                 fmGlobalParameter.rc_d,
                                                                                                 fmGlobalParameter.alpha_d,
                                                                                                 fmGlobalParameter.Srem,
                                                                                                 fmGlobalParameter.ad1,
                                                                                                 fmGlobalParameter.ad2,
                                                                                                 fmGlobalParameter.Tetta,
                                                                                                 fmGlobalParameter.eta_g,
                                                                                                 fmGlobalParameter.ag1,
                                                                                                 fmGlobalParameter.ag2,
                                                                                                 fmGlobalParameter.ag3,

                                                                                                 fmGlobalParameter.sd,
                                                                                                 fmGlobalParameter.td,
                                                                                                 fmGlobalParameter.K,
                                                                                                 fmGlobalParameter.S,
                                                                                                 fmGlobalParameter.Rf,
                                                                                                 fmGlobalParameter.Qgi,
                                                                                                 fmGlobalParameter.Qg
                                                                                             });

        public fmParametersToDisplay (fmParametersToDisplay other)
        {
            AssignedSchema = other.AssignedSchema;
            ParametersList = new List<fmGlobalParameter>(other.ParametersList);
        }

        public fmParametersToDisplay ()
        {
        }

        public fmParametersToDisplay(fmShowHideSchema schema, IEnumerable<fmGlobalParameter> parameters)
        {
            AssignedSchema = schema;
            ParametersList = new List<fmGlobalParameter>(parameters);
        }
    }
}
