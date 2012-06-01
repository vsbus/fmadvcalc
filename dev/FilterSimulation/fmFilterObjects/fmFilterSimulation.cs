using System;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;
using fmCalculatorsLibrary;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimulationData
    {
        public string name;
        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> parameters = new Dictionary<fmGlobalParameter, fmCalculationBaseParameter>();
        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_DP_CONST;
        public fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption deliquoringUsedCalculationOption = fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
        public fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption gasFlowrateUsedCalculationOption = fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation;
        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.EqualToRhoF;
        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.Calculated;
        public fmSuspensionCalculator.fmSuspensionCalculationOptions suspensionCalculationOption;

        public void CopyFrom(fmFilterSimulationData from)
        {
            name = from.name;
            filterMachiningCalculationOption = from.filterMachiningCalculationOption;
            deliquoringUsedCalculationOption = from.deliquoringUsedCalculationOption;
            gasFlowrateUsedCalculationOption = from.gasFlowrateUsedCalculationOption;
            hcdEpsdCalculationOption = from.hcdEpsdCalculationOption;
            rhoDCalculationOption = from.rhoDCalculationOption;
            PcDCalculationOption = from.PcDCalculationOption;
            suspensionCalculationOption = from.suspensionCalculationOption;
            CopyValuesFrom(from);
            CopyIsInputedFrom(from);
        }

        public void CopyValuesFrom(fmFilterSimulationData from)
        {
            foreach (fmGlobalParameter p in from.parameters.Keys)
            {
                parameters[p].value = from.parameters[p].value;
            }
        }

        public void CopyMaterialParametersValuesFrom(fmFilterSimulationData from)
        {
            var materialParametersList = new[]
                                                             {
                                                                 fmGlobalParameter.eta_f, fmGlobalParameter.rho_f,
                                                                 fmGlobalParameter.rho_s, fmGlobalParameter.rho_sus,
                                                                 fmGlobalParameter.Cm, fmGlobalParameter.Cv,
                                                                 fmGlobalParameter.C, fmGlobalParameter.eps0,
                                                                 fmGlobalParameter.kappa0, fmGlobalParameter.ne,
                                                                 fmGlobalParameter.Pc0, fmGlobalParameter.rc0,
                                                                 fmGlobalParameter.a0, fmGlobalParameter.nc,
                                                                 fmGlobalParameter.hce0, fmGlobalParameter.Rm0
                                                             };
            foreach (fmGlobalParameter p in materialParametersList)
            {
                parameters[p].value = from.parameters[p].value;
            }
        }

        public void CopyIsInputedFrom(fmFilterSimulationData from)
        {
            foreach (fmGlobalParameter p in from.parameters.Keys)
            {
                if (parameters[p] is fmCalculationVariableParameter)
                {
                    ((fmCalculationVariableParameter) parameters[p]).isInputed =
                        ((fmCalculationVariableParameter) from.parameters[p]).isInputed;
                }
            }
        }

        private void AddParameter(fmCalculationBaseParameter parameter)
        {
            parameters[parameter.globalParameter] = parameter;
        }

        public fmFilterSimulationData()
        {
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eta_f, true));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rho_f, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rho_s, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rho_sus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Cm, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Cv));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.C));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eps0, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.kappa0));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ne, true));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Pc0, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rc0));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.a0));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.nc, true));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hce0, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Rm0));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.A, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.d0, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Dp, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.sf, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.sr));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.n));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tc, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.tr));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hc));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Ms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Msus));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qsus));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eps));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.kappa));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Pc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.a));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vsus));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hc_over_tf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.dhc_over_dt));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qf_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qs));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qs_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qsus_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmsus_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qms_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmf_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qf_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qs));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qs_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qsus_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmsus_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qms_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmf_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.mf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vs));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.msus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.mc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vs));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.t1));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.h1));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.t1_over_tf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.h1_over_hc));

            #region Deliquoring
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Dp_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eps_d));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eta_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rho_d));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.sigma));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.pke0));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.pke));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.pc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rc_d));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.alpha_d));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Srem));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ad1));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ad2));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Tetta));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.eta_g));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ag1));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ag2));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.ag3));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Tetta_boil));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.DH));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mmole));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.f));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.peq));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.hcd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.sd, true));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.td));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.K));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Smech));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.S));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Rfmech));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Rf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qgi));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qg));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.vg));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mfd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vfd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mlcd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vlcd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mcd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vcd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.rho_bulk));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmfid));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qfid));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmcd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qcd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmfid));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qfid));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmcd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qcd));

            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qgt));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vg));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Mev));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Vev));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmftd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmfd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qftd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qfd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmevi));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmevt));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmev));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qevi));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qevt));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qev));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmftd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmfd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qftd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qfd));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmevi));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmevt));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmev));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qevi));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qevt));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qev));
            #endregion
        }                                         

        public List<fmGlobalParameter> GetParametersThatCanBeInputedList()
        {
            var result = new List<fmGlobalParameter> {fmGlobalParameter.eta_f};

            var suspensionParametersList = new List<fmGlobalParameter>();
            if (suspensionCalculationOption != fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOF_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_f);
            if (suspensionCalculationOption != fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOS_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_s);
            if (suspensionCalculationOption != fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOSUS_CALCULATED)
                suspensionParametersList.Add(fmGlobalParameter.rho_sus);
            if (suspensionCalculationOption != fmSuspensionCalculator.fmSuspensionCalculationOptions.CM_CV_C_CALCULATED)
            {
                suspensionParametersList.Add(fmGlobalParameter.Cm);
                suspensionParametersList.Add(fmGlobalParameter.Cv);
                suspensionParametersList.Add(fmGlobalParameter.C);
            }
            result.AddRange(suspensionParametersList);
            
            result.Add(fmGlobalParameter.eps0);
            result.Add(fmGlobalParameter.kappa0);
            result.Add(fmGlobalParameter.ne);

            result.Add(fmGlobalParameter.Pc0);
            result.Add(fmGlobalParameter.rc0);
            result.Add(fmGlobalParameter.a0);
            result.Add(fmGlobalParameter.nc);

            result.Add(fmGlobalParameter.Rm0);
            result.Add(fmGlobalParameter.hce0);
            
            List<fmGlobalParameter> filterMachiningParametersList = fmCalculationOptionHelper.GetParametersListThatCanBeInput(filterMachiningCalculationOption);
            result.AddRange(filterMachiningParametersList);

            {
                var deliqBlock = new fmDeliquoringSimualtionBlock();
                foreach (fmBlockVariableParameter p in deliqBlock.Parameters)
                {
                    if (p.group != null)
                    {
                        result.Add(p.globalParameter);
                    }
                }
            }

            return result;
        }

        public static void CopyVariableParametersFromSimulationToBlock(fmFilterSimulationData simData, fmBaseBlock block)
        {
            foreach (fmBlockVariableParameter p in block.Parameters)
            {
                p.value = simData.parameters[p.globalParameter].value;
                p.IsInputed = ((fmCalculationVariableParameter) simData.parameters[p.globalParameter]).isInputed;
            }
        }

        public static void CopyConstantParametersFromSimulationToBlock(fmFilterSimulationData simData, fmBaseBlock block)
        {
            foreach (fmBlockConstantParameter p in block.ConstantParameters)
            {
                p.value = simData.parameters[p.globalParameter].value;
            }
        }

        public static void CopyAllParametersFromSimulationToBlock(fmFilterSimulationData simData, fmBaseBlock block)
        {
            CopyVariableParametersFromSimulationToBlock(simData, block);
            CopyConstantParametersFromSimulationToBlock(simData, block);
        }

        public static void CopyAllParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulationData simData)
        {
            CopyConstantParametersFromBlockToSimulation(block, simData);
            CopyVariableParametersFromBlockToSimulation(block, simData);
        }

        public static void CopyConstantParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulationData simData)
        {
            foreach (fmBlockConstantParameter p in block.ConstantParameters)
            {
                simData.parameters[p.globalParameter].value = p.value;
            }
        }

        public static void CopyVariableParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulationData simData)
        {
            foreach (fmBlockVariableParameter p in block.Parameters)
            {
                simData.parameters[p.globalParameter].value = p.value;
                ((fmCalculationVariableParameter) simData.parameters[p.globalParameter]).isInputed = p.IsInputed;
            }
        }

        private void UpdateIsInputedInParametersFromBlock(fmBaseBlock block, fmGlobalParameter inputedParameter)
        {
            CopyAllParametersFromSimulationToBlock(this, block);
            block.UpdateIsInputed(block.GetParameterByName(inputedParameter.name));
            CopyAllParametersFromBlockToSimulation(block, this);
        }

        public void UpdateIsInputed(fmGlobalParameter inputedParameter)
        {
            var deliqSim = new fmDeliquoringSimualtionBlock(); 
            UpdateIsInputedInParametersFromBlock(deliqSim, inputedParameter);

            var fmb = new fmFilterMachiningBlock
                          {
                              filterMachiningCalculationOption = filterMachiningCalculationOption,
                              deliquoringUsedCalculationOption = deliquoringUsedCalculationOption,
                              gasFlowrateUsedCalculationOption = gasFlowrateUsedCalculationOption
                          };
            fmb.UpdateGroups();
            UpdateIsInputedInParametersFromBlock(fmb, inputedParameter);

            var susb = new fmSuspensionBlock
                           {
                               calculationOption = suspensionCalculationOption
                           };
            UpdateIsInputedInParametersFromBlock(susb, inputedParameter);

            var epskappab = new fmEps0Kappa0Block();
            UpdateIsInputedInParametersFromBlock(epskappab, inputedParameter);

            var pcrcab = new fmPc0Rc0A0Block();
            UpdateIsInputedInParametersFromBlock(pcrcab, inputedParameter);

            var rmhceb = new fmRm0HceBlock();
            UpdateIsInputedInParametersFromBlock(rmhceb, inputedParameter);
        }

        private static class fmFilterSimulationDataSerializeTags
        {
            public const string Begin = "FilterSimulationData Begin";
            public const string End = "FilterSimulationData End";
            // ReSharper disable InconsistentNaming
            public const string name = "name";
            public const string parametersSize = "parametersSize";
            public const string filterMachiningCalculationOption = "filterMachiningCalculationOption";
            public const string deliquoringUsedCalculationOption = "deliquoringUsedCalculationOption";
            public const string gasFlowrateUsedCalculationOption = "gasFlowrateUsedCalculationOption";
            public const string hcdCalculationOption = "hcdCalculationOption";
            public const string rhoDetaDCalculationOption = "rhoDetaDCalculationOption";
            public const string PcDCalculationOption = "PcDCalculationOption";
            public const string suspensionCalculationOption = "suspensionCalculationOption";
            // ReSharper restore InconsistentNaming
        }

        private static class fmParameterSerializeTags
        {
            public const string Begin = "Parameter Begin";
            public const string End = "Parameter End";
            // ReSharper disable InconsistentNaming
            public const string name = "name";
            public const string typeName = "typeName";
            public const string isInputed = "isInputed";
            public const string defined = "defined";
            public const string value = "value";
            // ReSharper restore InconsistentNaming
        }

        internal void SerializeCalculationBaseParameter(System.IO.TextWriter output, fmCalculationBaseParameter p)
        {
            output.WriteLine("                                " + fmParameterSerializeTags.Begin);
            fmSerializeTools.SerializeProperty(output, fmParameterSerializeTags.name, p.globalParameter.name, 9);
            fmSerializeTools.SerializeProperty(output, fmParameterSerializeTags.typeName, p.GetType().Name, 9);
            if (p is fmCalculationVariableParameter)
            {
                fmSerializeTools.SerializeProperty(output, fmParameterSerializeTags.isInputed, (p as fmCalculationVariableParameter).isInputed, 9);
            }
            fmSerializeTools.SerializeProperty(output, fmParameterSerializeTags.defined, p.value.defined, 9);
            fmSerializeTools.SerializeProperty(output, fmParameterSerializeTags.value, p.value.value, 9);
            output.WriteLine("                                " + fmParameterSerializeTags.End);
        }

        private static fmCalculationBaseParameter DeserializeCalculationBaseParameter(System.IO.TextReader input)
        {
            input.ReadLine();
            fmCalculationBaseParameter parameter;
            string name = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmParameterSerializeTags.name));
            string typeName = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmParameterSerializeTags.typeName));
            if (typeName == typeof(fmCalculationVariableParameter).Name)
            {
                var varParam = new fmCalculationVariableParameter(fmGlobalParameter.parametersByName[name]);
                varParam.isInputed = Convert.ToBoolean(fmSerializeTools.DeserializeProperty(input, fmParameterSerializeTags.isInputed));
                parameter = varParam;
            }
            else
            {
                parameter = new fmCalculationConstantParameter(fmGlobalParameter.parametersByName[name]);
            }
            bool defined = Convert.ToBoolean(fmSerializeTools.DeserializeProperty(input, fmParameterSerializeTags.defined));
            double value = fmSerializeTools.ToDouble(fmSerializeTools.DeserializeProperty(input, fmParameterSerializeTags.value));
            parameter.value = new fmValue(value, defined);
            input.ReadLine();
            return parameter;
        }

        internal void Serialize(System.IO.TextWriter output)
        {
            output.WriteLine("                            " + fmFilterSimulationDataSerializeTags.Begin);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.name, name, 8);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.filterMachiningCalculationOption, filterMachiningCalculationOption, 8);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.deliquoringUsedCalculationOption, deliquoringUsedCalculationOption, 8);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.gasFlowrateUsedCalculationOption, gasFlowrateUsedCalculationOption, 8);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.hcdCalculationOption, hcdEpsdCalculationOption, 8);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.rhoDetaDCalculationOption, rhoDCalculationOption, 8);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.PcDCalculationOption, PcDCalculationOption, 8);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.suspensionCalculationOption, suspensionCalculationOption, 8);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationDataSerializeTags.parametersSize, parameters.Count, 8);
            foreach (var p in parameters.Values)
            {
                SerializeCalculationBaseParameter(output, p);
            }
            output.WriteLine("                            " + fmFilterSimulationDataSerializeTags.End);
        }

        static object StringToEnum(string s, Type t)
        {
            foreach (var field in t.GetFields())
            {
                if (field.Name == s)
                {
                    return field.GetValue(null);
                }
            }
            throw new Exception("There is no field " + s + " in enum " + t.Name);
        }

        internal static fmFilterSimulationData Deserialize(System.IO.TextReader input)
        {
            input.ReadLine();
            fmFilterSimulationData simData = new fmFilterSimulationData();
            simData.name = Convert.ToString(fmSerializeTools.DeserializeProperty(input, fmFilterSimulationDataSerializeTags.name));
            simData.filterMachiningCalculationOption =
                (fmFilterMachiningCalculator.fmFilterMachiningCalculationOption)
                StringToEnum(
                    fmSerializeTools.DeserializeProperty(input,
                                                         fmFilterSimulationDataSerializeTags.
                                                             filterMachiningCalculationOption).ToString(),
                    typeof(fmFilterMachiningCalculator.fmFilterMachiningCalculationOption));
            simData.deliquoringUsedCalculationOption =
                (fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption)
                StringToEnum(
                    fmSerializeTools.DeserializeProperty(input,
                                                         fmFilterSimulationDataSerializeTags.
                                                             deliquoringUsedCalculationOption).ToString(),
                    typeof(fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption));
            simData.gasFlowrateUsedCalculationOption =
                (fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption)
                StringToEnum(
                    fmSerializeTools.DeserializeProperty(input,
                                                         fmFilterSimulationDataSerializeTags.
                                                             gasFlowrateUsedCalculationOption).ToString(),
                    typeof(fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption));
            simData.hcdEpsdCalculationOption =
                (fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption)
                StringToEnum(
                    fmSerializeTools.DeserializeProperty(input,
                                                         fmFilterSimulationDataSerializeTags.
                                                             hcdCalculationOption).ToString(),
                    typeof(fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption));
            simData.rhoDCalculationOption =
                (fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption)
                StringToEnum(
                    fmSerializeTools.DeserializeProperty(input,
                                                         fmFilterSimulationDataSerializeTags.
                                                             rhoDetaDCalculationOption).ToString(),
                    typeof(fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption));
            simData.PcDCalculationOption =
                (fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption)
                StringToEnum(
                    fmSerializeTools.DeserializeProperty(input,
                                                         fmFilterSimulationDataSerializeTags.
                                                             PcDCalculationOption).ToString(),
                    typeof(fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption));
            simData.suspensionCalculationOption = (fmSuspensionCalculator.fmSuspensionCalculationOptions)
                StringToEnum(
                    fmSerializeTools.DeserializeProperty(input,
                                                         fmFilterSimulationDataSerializeTags.
                                                             suspensionCalculationOption).ToString(),
                    typeof(fmSuspensionCalculator.fmSuspensionCalculationOptions));
            int parametersCount = Convert.ToInt32(fmSerializeTools.DeserializeProperty(input, fmFilterSimulationDataSerializeTags.parametersSize));
            for (int i = 0; i < parametersCount; ++i)
            {
                fmCalculationBaseParameter p = DeserializeCalculationBaseParameter(input);
                simData.parameters[p.globalParameter] = p;
            }
            input.ReadLine();
            return simData;
        }
    }

    public class fmFilterSimulation
    {
        private fmFilterSimSerie m_parentSerie;
        private readonly fmFilterSimulationData m_data = new fmFilterSimulationData();
        private readonly fmFilterSimulationData m_backupData = new fmFilterSimulationData();
        private bool m_modified;
        private bool m_checked = true;

        public fmSuspensionWithEtafBlock susBlock;
        public fmEps0Kappa0WithneBlock eps0Kappa0Block;
        public fmPc0Rc0A0WithncBlock pc0Rc0A0Block;
        public fmRm0HceBlock rm0HceBlock;
        public fmFilterMachiningBlock filterMachiningBlock;
        public fmEps0dNedEpsdBlock deliquoringEps0NeEpsBlock;
        public fmSigmaPke0PkePcdRcdAlphadBlock deliquoringSigmaPkeBlock;
        public fmSremTettaAdAgDHRmMmoleFPeqBlock deliquoringSremTettaAdAgDHMmoleFPeqBlock;
        
        public Guid Guid { get; set; }

        public string Name
        {
            get { return m_data.name; }
            set 
            {
                if (m_data.name != value)
                {
                    Modified = true;
                }
                m_data.name = value;
            }
        }
        public bool Modified
        {
            get { return m_modified; }
            set
            {
                m_modified = value;
                if (value && m_parentSerie != null)
                {
                    m_parentSerie.Modified = true;
                }
            }
        }
        public bool Checked
        {
            get { return m_checked; }
            set { m_checked = value; }
        }
        public fmFilterSimSerie Parent
        {
            get { return m_parentSerie; }
            set { m_parentSerie = value; }
        }
        public fmFilterSimulationData Data
        {
            get { return m_data; }
        }

        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> Parameters
        {
            get { return m_data.parameters; }
        }

        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption FilterMachiningCalculationOption
        {
            get { return m_data.filterMachiningCalculationOption; }
            set 
            {
                if (m_data.filterMachiningCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.filterMachiningCalculationOption = value; 
            }
        }

        public fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption DeliquoringUsedCalculationOption
        {
            get { return m_data.deliquoringUsedCalculationOption; }
            set
            {
                if (m_data.deliquoringUsedCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.deliquoringUsedCalculationOption = value;
            }
        }

        public fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption GasFlowrateUsedCalculationOption
        {
            get { return m_data.gasFlowrateUsedCalculationOption; }
            set
            {
                if (m_data.gasFlowrateUsedCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.gasFlowrateUsedCalculationOption = value;
            }
        }

        public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption HcdEpsdCalculationOption
        {
            get { return m_data.hcdEpsdCalculationOption; }
            set
            {
                if (m_data.hcdEpsdCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.hcdEpsdCalculationOption = value;
            }
        }

        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption RhoDetaDCalculationOption
        {
            get
            {
                return m_data.rhoDCalculationOption;
            }
            set
            {
                if (m_data.rhoDCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.rhoDCalculationOption = value;
            }
        }

        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption PcDCalculationOption
        {
            get { return m_data.PcDCalculationOption; }
            set
            {
                if (m_data.PcDCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.PcDCalculationOption = value;
            }
        }

        public fmSuspensionCalculator.fmSuspensionCalculationOptions SuspensionCalculationOption
        {
            get { return m_data.suspensionCalculationOption; }
            set
            {
                if (m_data.suspensionCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.suspensionCalculationOption = value;
            }
        }

        public fmFilterSimulation()
        {
            Guid = Guid.NewGuid();
        }
        public fmFilterSimulation(fmFilterSimSerie parentSerie, string name)
        {
            Guid = Guid.NewGuid();
            if (parentSerie != null)
            {
                m_parentSerie = parentSerie;
                parentSerie.AddSimulation(this);
            }
            m_data.name = name;

            var voidBlock = new fmFilterMachiningBlock();
            voidBlock.SetCalculationOptionAndRewriteData(Data.filterMachiningCalculationOption);
            voidBlock.SetCalculationOptionAndRewriteData(Data.deliquoringUsedCalculationOption);
            voidBlock.SetCalculationOptionAndRewriteData(Data.gasFlowrateUsedCalculationOption);
            foreach (fmBlockVariableParameter var in voidBlock.Parameters)
            {
                ((fmCalculationVariableParameter) Data.parameters[var.globalParameter]).isInputed = var.isInputed;
            }

            Keep();
        }

        public fmFilterSimulation(fmFilterSimSerie parentSerie, fmFilterSimulation toCopy)
        {
            if (parentSerie != null)
            {
                m_parentSerie = parentSerie;
                parentSerie.AddSimulation(this);
            }
            
            CopyFrom(toCopy);
            Guid = Guid.NewGuid();
            Keep();
        }
        
        public void Keep()
        {
            m_backupData.CopyFrom(m_data);
            Modified = false;
        }
        public void Restore()
        {
            m_data.CopyFrom(m_backupData);
            Modified = false;
        }
        public void Delete()
        {
            //filterMachiningBlock.calculationOptionView.Dispose();
            m_parentSerie.RemoveSimulation(this);
        }
        public void CopyFrom(fmFilterSimulation sim)
        {
            m_data.CopyFrom(sim.m_data);
            m_backupData.CopyFrom(sim.m_backupData);
            Modified = sim.Modified;
        }

        internal void CopySuspensionParameters(fmFilterSimulation simulation)
        {
            Parameters[fmGlobalParameter.eta_f] = simulation.Parameters[fmGlobalParameter.eta_f];

            Parameters[fmGlobalParameter.rho_f] = simulation.Parameters[fmGlobalParameter.rho_f];
            Parameters[fmGlobalParameter.rho_s] = simulation.Parameters[fmGlobalParameter.rho_s];
            Parameters[fmGlobalParameter.rho_sus] = simulation.Parameters[fmGlobalParameter.rho_sus];

            Parameters[fmGlobalParameter.Cm] = simulation.Parameters[fmGlobalParameter.Cm];
            Parameters[fmGlobalParameter.Cv] = simulation.Parameters[fmGlobalParameter.Cv];
            Parameters[fmGlobalParameter.C] = simulation.Parameters[fmGlobalParameter.C];
            
            Parameters[fmGlobalParameter.eps0] = simulation.Parameters[fmGlobalParameter.eps0];
            Parameters[fmGlobalParameter.kappa0] = simulation.Parameters[fmGlobalParameter.kappa0];
            
            Parameters[fmGlobalParameter.nc] = simulation.Parameters[fmGlobalParameter.nc];
            
            Parameters[fmGlobalParameter.Pc0] = simulation.Parameters[fmGlobalParameter.Pc0];
            Parameters[fmGlobalParameter.rc0] = simulation.Parameters[fmGlobalParameter.rc0];
            Parameters[fmGlobalParameter.a0] = simulation.Parameters[fmGlobalParameter.a0];
            
            Parameters[fmGlobalParameter.ne] = simulation.Parameters[fmGlobalParameter.ne];
            
            Parameters[fmGlobalParameter.hce0] = simulation.Parameters[fmGlobalParameter.hce0];
            Parameters[fmGlobalParameter.Rm0] = simulation.Parameters[fmGlobalParameter.Rm0];
        }

        public static void CopyVariableParametersFromSimulationToBlock(fmFilterSimulation sim, fmBaseBlock block)
        {
            foreach (fmBlockVariableParameter p in block.Parameters)
            {
                p.value = sim.Parameters[p.globalParameter].value;
                p.IsInputed = ((fmCalculationVariableParameter) sim.Parameters[p.globalParameter]).isInputed;
            }
        }

        public static void CopyConstantParametersFromSimulationToBlock(fmFilterSimulation sim, fmBaseBlock block)
        {
            foreach (fmBlockConstantParameter p in block.ConstantParameters)
            {
                p.value = sim.Parameters[p.globalParameter].value;
            }
        }

        public static void CopyAllParametersFromSimulationToBlock(fmFilterSimulation sim, fmBaseBlock block)
        {
            CopyVariableParametersFromSimulationToBlock(sim, block);
            CopyConstantParametersFromSimulationToBlock(sim, block);
        }

        public static void CopyAllParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulation sim)
        {
            CopyConstantParametersFromBlockToSimulation(block, sim);
            CopyVariableParametersFromBlockToSimulation(block, sim);
        }

        public static void CopyConstantParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulation sim)
        {
            foreach (fmBlockConstantParameter p in block.ConstantParameters)
            {
                if (sim.Parameters[p.globalParameter].value != p.value)
                {
                    sim.Modified = true;
                }
                sim.Parameters[p.globalParameter].value = p.value;
            }
        }

        public static void CopyVariableParametersFromBlockToSimulation(fmBaseBlock block, fmFilterSimulation sim)
        {
            foreach (fmBlockVariableParameter p in block.Parameters)
            {
                if (fmValue.EpsCompare(sim.Parameters[p.globalParameter].value.value, p.value.value, 1e-9) != 0
                    || ((fmCalculationVariableParameter) sim.Parameters[p.globalParameter]).isInputed != p.IsInputed)
                {
                    sim.Modified = true;
                }
                sim.Parameters[p.globalParameter].value = p.value;
                ((fmCalculationVariableParameter) sim.Parameters[p.globalParameter]).isInputed = p.IsInputed;
            }
        }

        private static class fmFilterSimulationSerializeTags
        {
            public const string Begin = "FilterSimulation Begin";
            public const string End = "FilterSimulation End";
            // ReSharper disable InconsistentNaming
            public const string m_checked = "m_checked";
            // ReSharper restore InconsistentNaming
        }

        internal void Serialize(System.IO.TextWriter output)
        {
            output.WriteLine("                        " + fmFilterSimulationSerializeTags.Begin);
            fmSerializeTools.SerializeProperty(output, fmFilterSimulationSerializeTags.m_checked, m_checked, 7);
            m_data.Serialize(output);
            output.WriteLine("                        " + fmFilterSimulationSerializeTags.End);
        }

        internal static fmFilterSimulation Deserialize(System.IO.TextReader input, fmFilterSimSerie parentSerie)
        {
            input.ReadLine();
            fmFilterSimulation sim = new fmFilterSimulation(parentSerie, "_noname");
            sim.m_checked = Convert.ToBoolean(fmSerializeTools.DeserializeProperty(input, fmFilterSimulationSerializeTags.m_checked));
            fmFilterSimulationData simData = fmFilterSimulationData.Deserialize(input);
            sim.Name = simData.name;
            sim.FilterMachiningCalculationOption = simData.filterMachiningCalculationOption;
            sim.DeliquoringUsedCalculationOption = simData.deliquoringUsedCalculationOption;
            sim.GasFlowrateUsedCalculationOption = simData.gasFlowrateUsedCalculationOption;
            sim.HcdEpsdCalculationOption = simData.hcdEpsdCalculationOption;
            sim.RhoDetaDCalculationOption = simData.rhoDCalculationOption;
            sim.PcDCalculationOption = simData.PcDCalculationOption;
            sim.SuspensionCalculationOption = simData.suspensionCalculationOption;
            foreach (var p in simData.parameters.Values)
            {
                sim.Parameters[p.globalParameter] = p;
            }
            input.ReadLine();
            return sim;
        }
    }
}