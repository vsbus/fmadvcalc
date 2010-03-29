using System.Collections.Generic;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;
using System.Drawing;

namespace fmCalcBlocksLibrary.Blocks
{
    abstract public class fmBaseBlock
    {
        protected List<fmBlockVariableParameter> parameters = new List<fmBlockVariableParameter>();
        protected List<fmBlockConstantParameter> constantParameters = new List<fmBlockConstantParameter>();
        protected bool processOnChange;

        public List<fmBlockVariableParameter> Parameters
        {
            get { return parameters; }
        }
        public List<fmBlockConstantParameter> ConstantParameters
        {
            get { return constantParameters; }
        }
        public List<fmCalculatorsLibrary.fmCalculationBaseParameter> AllParameters
        {
            get
            {
                List<fmCalculatorsLibrary.fmCalculationBaseParameter> result = new List<fmCalculatorsLibrary.fmCalculationBaseParameter>();
                foreach (fmBlockVariableParameter p in parameters) result.Add(p);
                foreach (fmBlockConstantParameter p in constantParameters) result.Add(p);
                return result;
            }
        }

        public event Event ValuesChanged;
        public event fmBlockParameterEventHandler ValuesChangedByUser;


        abstract public void DoCalculations();

        protected void ReWriteParameters()
        {
            if (processOnChange)
            {
                processOnChange = false;

                for (int i = 0; i < parameters.Count; ++i)
                {
                    string newVal = (parameters[i].value / parameters[i].globalParameter.unitFamily.CurrentUnit.Coef).ToString();
                    if (parameters[i].cell != null)
                        parameters[i].cell.Value = newVal;
                }
                CallValuesChanged();

                processOnChange = true;
            }
        }

        public void UpdateIsInputed(fmBlockVariableParameter enteredParameter)
        {
            foreach (fmBlockVariableParameter p in parameters)
                if (p.group != null
                        && p.group == enteredParameter.group)
                    p.isInputed = p == enteredParameter;
        }

        public void CalculateAndDisplay()
        {
            DoCalculations();
            ReWriteParameters();
        }

        public void StopProcessing()
        {
            processOnChange = false;
        }

        public void ResumeProcessing()
        {
            processOnChange = true;
        }
        
        public void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (processOnChange)
            {
                fmDataGrid.fmDataGrid dataGrid = sender as fmDataGrid.fmDataGrid;

                int parameterIndex;
                fmBlockVariableParameter enteredParameter = FindEnteredParameter(dataGrid.CurrentCell, out parameterIndex);

                if (enteredParameter != null)
                {
                    UpdateIsInputed(enteredParameter);
                    enteredParameter.value = fmValue.ObjectToValue(dataGrid.CurrentCell.Value) * enteredParameter.globalParameter.unitFamily.CurrentUnit.Coef;
                    
                    if (ValuesChangedByUser != null)
                        ValuesChangedByUser(this, new fmBlockParameterEvetArgs(parameterIndex));
                    
                    DoCalculations();
                    ReWriteParameters();
                }
            }
        }

        protected void AddParameter(
            ref fmBlockVariableParameter p,
            fmGlobalParameter globalParameter,
            DataGridViewCell cell,
            bool isInputedDefault)
        {
            p = new fmBlockVariableParameter(globalParameter, cell, isInputedDefault);
            if (cell != null)
            {
                fmDataGrid.fmDataGrid dataGrid = cell.DataGridView as fmDataGrid.fmDataGrid;
                dataGrid.CellValueChangedByUser -= CellValueChanged;
                dataGrid.CellValueChangedByUser += CellValueChanged;
            }
            parameters.Add(p);
        }

        protected void AddConstantParameter(
            ref fmBlockConstantParameter p,
            fmGlobalParameter globalParameter)
        {
            p = new fmBlockConstantParameter(globalParameter);
            constantParameters.Add(p);
        }

        public fmBlockVariableParameter GetParameterByName(string parameterName)
        {
            foreach (fmBlockVariableParameter parameter in parameters)
                if (parameter.globalParameter.name == parameterName)
                    return parameter;
            return null;
        }

        protected void CallValuesChanged()
        {
            if (ValuesChanged != null)
                ValuesChanged(this);
        }
        
        private fmBlockVariableParameter FindEnteredParameter(DataGridViewCell cell, out int parameterIndex)
        {
            for (int i = 0; i < parameters.Count; ++i)
                if (parameters[i].cell == cell)
                {
                    parameterIndex = i;
                    return parameters[i];
                }
            parameterIndex = -1;
            return null;
        }

        protected void SetParameterCellBackColor(fmBlockVariableParameter parameter, Color backColor)
        {
            if (parameter.cell != null)
                parameter.cell.Style.BackColor = backColor;
        }
    }
}