using fmCalculationLibrary;
using System.Collections.Generic;

namespace fmCalculatorsLibrary
{
    abstract public class fmBaseCalculator
    {
        protected Dictionary<fmGlobalParameter, fmCalculationBaseParameter> variables;
        abstract public void DoCalculations();

        protected fmBaseCalculator(IEnumerable<fmCalculationBaseParameter> parameterList)
        {
            variables = new Dictionary<fmGlobalParameter,fmCalculationBaseParameter>();
            if (parameterList != null)
                foreach (var p in parameterList)
                    variables[p.globalParameter] = p;
        }
    }
}
