using System;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalcBlocksLibrary.Blocks;
using fmCalculationLibrary;
using System.Collections.Generic;
using fmCalculatorsLibrary;
using System.Xml;
using FilterSimulation.fmFilterObjects.Interfaces;

namespace FilterSimulation.fmFilterObjects
{
    public class fmFilterSimulationData
    {
        public string name;
        public string comments;
        public Dictionary<fmGlobalParameter, fmCalculationBaseParameter> parameters = new Dictionary<fmGlobalParameter, fmCalculationBaseParameter>();
        public fmFilterMachiningCalculator.fmFilterMachiningCalculationOption filterMachiningCalculationOption = fmFilterMachiningCalculator.fmFilterMachiningCalculationOption.PLAIN_DP_CONST;
        public fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption deliquoringUsedCalculationOption = fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption.Used;
        public fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption gasFlowrateUsedCalculationOption = fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption.Consider;
        public fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption evaporationUsedCalculationOption = fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption.NotConsider;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption hcdEpsdCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption.CalculatedFromCakeFormation;
        public fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption dpdInputCalculationOption = fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption.CalculatedFromCakeFormation;
        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption rhoDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption.EqualToRhoF;
        public fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption PcDCalculationOption = fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption.Calculated;
        public fmSuspensionCalculator.fmSuspensionCalculationOptions suspensionCalculationOption = fmSuspensionCalculator.fmSuspensionCalculationOptions.RHOSUS_CALCULATED;

        public void CopyFrom(fmFilterSimulationData from)
        {
            name = from.name;
            comments = from.comments;
            filterMachiningCalculationOption = from.filterMachiningCalculationOption;
            deliquoringUsedCalculationOption = from.deliquoringUsedCalculationOption;
            gasFlowrateUsedCalculationOption = from.gasFlowrateUsedCalculationOption;
            evaporationUsedCalculationOption = from.evaporationUsedCalculationOption;
            hcdEpsdCalculationOption = from.hcdEpsdCalculationOption;
            dpdInputCalculationOption = from.dpdInputCalculationOption;
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
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qf_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qs));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qs_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qc_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qp));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmsus_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qms_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmf_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.Qmc_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qf_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qs));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qs_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qc_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qp));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmsus));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmsus_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qms));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qms_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmf));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmf_i));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmc));
            AddParameter(new fmCalculationVariableParameter(fmGlobalParameter.qmc_i));
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
                var deliquoringBlocks = new fmBaseBlock[]
                                            {
                                                new fmEps0dNedEpsdBlock(),
                                                new fmSigmaPke0PkePcdRcdAlphadBlock(),
                                                new fmSremTettaAdAgDHRmMmoleFPeqBlock(),
                                                new fmDeliquoringSimualtionBlock()
                                            };

                foreach (fmBaseBlock deliquoringBlock in deliquoringBlocks)
                {
                    foreach (fmBlockVariableParameter p in deliquoringBlock.Parameters)
                    {
                        if (p.group != null)
                        {
                            result.Add(p.globalParameter);
                        }
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
            block.UpdateIsInputed(block.GetParameterByName(inputedParameter.Name));
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
                              gasFlowrateUsedCalculationOption = gasFlowrateUsedCalculationOption,
                              evaporationUsedCalculationOption = evaporationUsedCalculationOption
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

        public static class fmFilterSimulationDataSerializeTags
        {
            public const string FilterSimulationData = "FilterSimulationData";
            public const string Name = "name";
            public const string FilterMachiningCalculationOption = "filterMachiningCalculationOption";
            public const string DeliquoringUsedCalculationOption = "deliquoringUsedCalculationOption";
            public const string GasFlowrateUsedCalculationOption = "gasFlowrateUsedCalculationOption";
            public const string EvaporationUsedCalculationOption = "evaporationUsedCalculationOption";
            public const string HcdCalculationOption = "hcdCalculationOption";
            public const string DpdInputCalculationOption = "dpdInputCalculationOption";
            public const string RhoDetaDCalculationOption = "rhoDetaDCalculationOption";
            public const string PcDCalculationOption = "PcDCalculationOption";
            public const string SuspensionCalculationOption = "suspensionCalculationOption";
        }

        private static class fmParameterSerializeTags
        {
            public const string Name = "name";
            public const string IsInputed = "isInputed";
            public const string Defined = "defined";
            public const string Value = "value";
            public const string Parameter = "Parameter";
        }

        internal void SerializeCalculationBaseParameter(XmlWriter writer, fmCalculationBaseParameter p)
        {
            writer.WriteStartElement(fmParameterSerializeTags.Parameter);
            writer.WriteElementString(fmParameterSerializeTags.Name, p.globalParameter.Name);
            if (p is fmCalculationVariableParameter)
            {
                writer.WriteElementString(fmParameterSerializeTags.IsInputed, (p as fmCalculationVariableParameter).isInputed.ToString());
            }
            writer.WriteElementString(fmParameterSerializeTags.Defined, p.value.defined.ToString());
            writer.WriteElementString(fmParameterSerializeTags.Value, p.value.value.ToString());
            writer.WriteEndElement();
        }

        private static fmCalculationBaseParameter DeserializeCalculationBaseParameter(XmlNode xmlNode)
        {
            fmCalculationBaseParameter parameter;
            string name = xmlNode.SelectSingleNode(fmParameterSerializeTags.Name).InnerText;
            if (!fmGlobalParameter.ParametersByName.ContainsKey(name))
            {
                return null;
            }
            XmlNode isInputedNode = xmlNode.SelectSingleNode(fmParameterSerializeTags.IsInputed);
            if (isInputedNode != null)
            {
                var varParam = new fmCalculationVariableParameter(fmGlobalParameter.ParametersByName[name]);
                varParam.isInputed = Convert.ToBoolean(isInputedNode.InnerText);
                parameter = varParam;
            }
            else
            {
                parameter = new fmCalculationConstantParameter(fmGlobalParameter.ParametersByName[name]);
            }
            bool defined = Convert.ToBoolean(xmlNode.SelectSingleNode(fmParameterSerializeTags.Defined).InnerText);
            double value = fmSerializeTools.ToDouble(xmlNode.SelectSingleNode(fmParameterSerializeTags.Value).InnerText);
            parameter.value = new fmValue(value, defined);
            return parameter;
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmFilterSimulationDataSerializeTags.FilterSimulationData);
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.Name, name);
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.FilterMachiningCalculationOption, filterMachiningCalculationOption.ToString());
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.DeliquoringUsedCalculationOption, deliquoringUsedCalculationOption.ToString());
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.GasFlowrateUsedCalculationOption, gasFlowrateUsedCalculationOption.ToString());
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.EvaporationUsedCalculationOption, evaporationUsedCalculationOption.ToString());
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.HcdCalculationOption, hcdEpsdCalculationOption.ToString());
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.DpdInputCalculationOption, dpdInputCalculationOption.ToString());
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.RhoDetaDCalculationOption, rhoDCalculationOption.ToString());
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.PcDCalculationOption, PcDCalculationOption.ToString());
            writer.WriteElementString(fmFilterSimulationDataSerializeTags.SuspensionCalculationOption, suspensionCalculationOption.ToString());
            foreach (var p in parameters.Values)
            {
                SerializeCalculationBaseParameter(writer, p);
            }
            writer.WriteEndElement();
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

        internal static fmFilterSimulationData Deserialize(XmlNode xmlNode)
        {
            var simData = new fmFilterSimulationData
                              {
                                  name = xmlNode.SelectSingleNode(fmFilterSimulationDataSerializeTags.Name).InnerText,
                                  filterMachiningCalculationOption =
                                      (fmFilterMachiningCalculator.fmFilterMachiningCalculationOption)
                                      StringToEnum(
                                          xmlNode.SelectSingleNode(fmFilterSimulationDataSerializeTags.
                                                                       FilterMachiningCalculationOption).InnerText,
                                          typeof (fmFilterMachiningCalculator.fmFilterMachiningCalculationOption)),
                                  deliquoringUsedCalculationOption =
                                      (fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption)
                                      StringToEnum(
                                          xmlNode.SelectSingleNode(
                                              fmFilterSimulationDataSerializeTags.
                                                  DeliquoringUsedCalculationOption).InnerText,
                                          typeof (fmFilterMachiningCalculator.fmDeliquoringUsedCalculationOption)),
                                  gasFlowrateUsedCalculationOption =
                                      (fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption)
                                      StringToEnum(
                                          xmlNode.SelectSingleNode(
                                              fmFilterSimulationDataSerializeTags.
                                                  GasFlowrateUsedCalculationOption).InnerText,
                                          typeof (fmFilterMachiningCalculator.fmGasFlowrateUsedCalculationOption)),
                                  evaporationUsedCalculationOption =
                                      (fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption)
                                      StringToEnum(
                                          xmlNode.SelectSingleNode(
                                              fmFilterSimulationDataSerializeTags.
                                                  EvaporationUsedCalculationOption).InnerText,
                                          typeof (fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption)),
                                  hcdEpsdCalculationOption =
                                      (fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption)
                                      StringToEnum(
                                          xmlNode.SelectSingleNode(
                                              fmFilterSimulationDataSerializeTags.
                                                  HcdCalculationOption).InnerText,
                                          typeof (
                                              fmDeliquoringSimualtionCalculator.fmDeliquoringHcdEpsdCalculationOption)),
                                  dpdInputCalculationOption =
                                      (fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption)
                                      StringToEnum(
                                          xmlNode.SelectSingleNode(
                                              fmFilterSimulationDataSerializeTags.
                                                  DpdInputCalculationOption).InnerText,
                                          typeof (fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption)),
                                  rhoDCalculationOption =
                                      (fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption)
                                      StringToEnum(
                                          xmlNode.SelectSingleNode(
                                              fmFilterSimulationDataSerializeTags.
                                                  RhoDetaDCalculationOption).InnerText,
                                          typeof (fmSigmaPke0PkePcdRcdAlphadCalculator.fmRhoDEtaDCalculationOption)),
                                  PcDCalculationOption = (fmSigmaPke0PkePcdRcdAlphadCalculator.fmPcDCalculationOption)
                                                         StringToEnum(
                                                             xmlNode.SelectSingleNode(
                                                                 fmFilterSimulationDataSerializeTags.
                                                                     PcDCalculationOption).InnerText,
                                                             typeof (
                                                                 fmSigmaPke0PkePcdRcdAlphadCalculator.
                                                                 fmPcDCalculationOption)),
                                  suspensionCalculationOption = (fmSuspensionCalculator.fmSuspensionCalculationOptions)
                                                                StringToEnum(
                                                                    xmlNode.SelectSingleNode(
                                                                        fmFilterSimulationDataSerializeTags.
                                                                            SuspensionCalculationOption).InnerText,
                                                                    typeof (
                                                                        fmSuspensionCalculator.
                                                                        fmSuspensionCalculationOptions))
                              };
            XmlNodeList parameterList = xmlNode.SelectNodes(fmParameterSerializeTags.Parameter);
            foreach (XmlNode parameterNode in parameterList)
            {
                fmCalculationBaseParameter p = DeserializeCalculationBaseParameter(parameterNode);
                if (p != null)
                {
                    simData.parameters[p.globalParameter] = p;
                }
            }
            return simData;
        }
    }

    public class fmFilterSimulation : IComments
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

        public fmFilterMachiningCalculator.fmEvaporationUsedCalculationOption EvaporationUsedCalculationOption
        {
            get { return m_data.evaporationUsedCalculationOption; }
            set
            {
                if (m_data.evaporationUsedCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.evaporationUsedCalculationOption = value;
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

        public fmDeliquoringSimualtionCalculator.fmDeliquoringDpdInputOption DpdInputCalculationOption
        {
            get { return m_data.dpdInputCalculationOption; }
            set
            {
                if (m_data.dpdInputCalculationOption != value)
                {
                    Modified = true;
                }
                m_data.dpdInputCalculationOption = value;
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
            voidBlock.SetCalculationOptionAndRewriteData(Data.evaporationUsedCalculationOption);
            foreach (fmBlockVariableParameter var in voidBlock.Parameters)
            {
                ((fmCalculationVariableParameter) Data.parameters[var.globalParameter]).isInputed = var.isInputed;
            }

            Data.parameters[fmGlobalParameter.Tetta_boil].value = new fmValue(1000);
            Data.parameters[fmGlobalParameter.DH].value = new fmValue(1000);
            Data.parameters[fmGlobalParameter.Mmole].value = new fmValue(18e-3);
            Data.parameters[fmGlobalParameter.f].value = new fmValue(1);

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

        public static class fmFilterSimulationSerializeTags
        {
            public const string Simulation = "Simulation";
            public const string Checked = "m_checked";
            public const string Comments = "Comments";
        }

        internal void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement(fmFilterSimulationSerializeTags.Simulation);
            writer.WriteElementString(fmFilterSimulationSerializeTags.Checked, m_checked.ToString());
            writer.WriteElementString(fmFilterSimulationSerializeTags.Comments, GetComments());
            m_data.Serialize(writer);
            writer.WriteEndElement();
        }

        internal static fmFilterSimulation Deserialize(XmlNode xmlNode, fmFilterSimSerie parentSerie)
        {
            var sim = new fmFilterSimulation(parentSerie, "_noname");
            sim.m_checked = false;
            fmSerializeTools.DeserializeBoolProperty(ref sim.m_checked, xmlNode, fmFilterSimulationSerializeTags.Checked);

            fmFilterSimulationData simData =
                fmFilterSimulationData.Deserialize(
                    xmlNode.SelectSingleNode(
                        fmFilterSimulationData.fmFilterSimulationDataSerializeTags.FilterSimulationData));

            sim.SetName(simData.name);
            
            string comments = "";
            fmSerializeTools.DeserializeStringProperty(ref comments, xmlNode, fmFilterSimulationSerializeTags.Comments);
            sim.SetComments(comments);
            
            sim.FilterMachiningCalculationOption = simData.filterMachiningCalculationOption;
            sim.DeliquoringUsedCalculationOption = simData.deliquoringUsedCalculationOption;
            sim.GasFlowrateUsedCalculationOption = simData.gasFlowrateUsedCalculationOption;
            sim.EvaporationUsedCalculationOption = simData.evaporationUsedCalculationOption;
            sim.HcdEpsdCalculationOption = simData.hcdEpsdCalculationOption;
            sim.DpdInputCalculationOption = simData.dpdInputCalculationOption;
            sim.RhoDetaDCalculationOption = simData.rhoDCalculationOption;
            sim.PcDCalculationOption = simData.PcDCalculationOption;
            sim.SuspensionCalculationOption = simData.suspensionCalculationOption;
            foreach (var p in simData.parameters.Values)
            {
                sim.Parameters[p.globalParameter] = p;
            }
            return sim;
        }

        #region IComments Members

        public string GetComments()
        {
            return m_data.comments;
        }

        public void SetComments(string comments)
        {
            if (m_data.comments != comments)
            {
                Modified = true;
            }
            m_data.comments = comments;
        }

        #endregion

        #region IName Members

        public string GetName()
        {
            return m_data.name;
        }


        public void SetName(string name)
        {
            if (m_data.name != name)
            {
                Modified = true;
            }
            m_data.name = name;
        }

        #endregion
    }
}