using fmCalculationLibrary;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    abstract public class fmBaseCalculator
    {
        protected Dictionary<fmGlobalParameter, fmCalculationBaseParameter> variables;
        abstract public void DoCalculations();
        public fmBaseCalculator(IEnumerable<fmCalculationBaseParameter> parameterList)
        {
            variables = new Dictionary<fmGlobalParameter,fmCalculationBaseParameter>();
            if (parameterList != null)
                foreach (fmCalculationBaseParameter p in parameterList)
                    variables[p.globalParameter] = p;
        }
    }
}
