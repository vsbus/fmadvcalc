using System;
using System.Collections.Generic;
using System.Text;
using fmCalculationLibrary;
using fmCalculationLibrary.Equations;

namespace fmCalculatorsLibrary
{
    public class fmSremTettaAdAgDHRmMmoleFPeqCalculator : fmBaseCalculator
    {
        public fmSremTettaAdAgDHRmMmoleFPeqCalculator(IEnumerable<fmCalculationBaseParameter> parameterList) : base(parameterList) { }
        override public void DoCalculations()
        {
            var peq = variables[fmGlobalParameter.peq] as fmCalculationVariableParameter;
            var DH = variables[fmGlobalParameter.DH] as fmCalculationVariableParameter;
            var Mmole = variables[fmGlobalParameter.Mmole] as fmCalculationVariableParameter;
            var Tetta = variables[fmGlobalParameter.Tetta] as fmCalculationVariableParameter;
            var Tetta_boil = variables[fmGlobalParameter.Tetta_boil] as fmCalculationVariableParameter;
            
            var pke = variables[fmGlobalParameter.pke] as fmCalculationConstantParameter;
            var rhof = variables[fmGlobalParameter.rho_f] as fmCalculationConstantParameter;

            fmValue T = fmPeqEquations.Eval_T_From_Tetta(Tetta.value);
            fmValue Tboil = fmPeqEquations.Eval_T_From_Tetta(Tetta_boil.value);

            peq.value = fmPeqEquations.Eval_peq_From_DH_Mmole_T_Tboil_pke_rhof(DH.value, Mmole.value, T, Tboil, pke.value, rhof.value);
        }
    }
}
