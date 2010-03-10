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
        protected List<fmBlockParameter> parameters = new List<fmBlockParameter>();
        protected List<fmBlockConstantParameter> constantParameters = new List<fmBlockConstantParameter>();
        protected bool processOnChange;

        public List<fmBlockParameter> Parameters
        {
            get { return parameters; }
        }
        public List<fmBlockConstantParameter> ConstantParameters
        {
            get { return constantParameters; }
        }
        public fmBlockParameter GetParameterByName(string parameterName)
        {
            foreach (fmBlockParameter parameter in parameters)
                if (parameter.name == parameterName)
                    return parameter;
            return null;
        }

        protected void ReWriteParameters()
        {
            if (processOnChange)
            {
                processOnChange = false;

                for (int i = 0; i < parameters.Count; ++i)
                {
                    string newVal = (parameters[i].value / parameters[i].unitFamily.CurrentUnit.Coef).ToString();
                    if (parameters[i].cell != null)
                    {
                        parameters[i].cell.Value = newVal;
                    }
                }

                if (ValuesChanged != null)
                    ValuesChanged(this);

                processOnChange = true;
            }
        }       
        public void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (processOnChange)
            {
                fmDataGrid.fmDataGrid dataGrid = sender as fmDataGrid.fmDataGrid;

                int parameterIndex;
                fmBlockParameter enteredParameter = FindEnteredParameter(dataGrid.CurrentCell, out parameterIndex);

                if (enteredParameter != null)
                {
                    UpdateIsInputed(enteredParameter);
                    enteredParameter.value = fmValue.ObjectToValue(dataGrid.CurrentCell.Value) * enteredParameter.unitFamily.CurrentUnit.Coef;
                    
                    if (ValuesChangedByUser != null)
                        ValuesChangedByUser(this, new fmBlockParameterEvetArgs(parameterIndex));
                    
                    DoCalculations();
                    ReWriteParameters();
                }
            }
        }

        private fmBlockParameter FindEnteredParameter(DataGridViewCell cell, out int parameterIndex)
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

        protected void AddParameter(
            ref fmBlockParameter p,
            fmGlobalParameter globalParameter,
            DataGridViewCell cell,
            bool isInputedDefault)
        {
            p = new fmBlockParameter(globalParameter, cell, isInputedDefault);
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

        public void StopProcessing()
        {
            processOnChange = false;
        }

        public void ResumeProcessing()
        {
            processOnChange = true;
        }

        public void CalculateAndDisplay()
        {
            DoCalculations();
            ReWriteParameters();
        }
        
        public event Event ValuesChanged;
        public event fmBlockParameterEventHandler ValuesChangedByUser;

        abstract public void DoCalculations();

        public void UpdateIsInputed(fmBlockParameter enteredParameter)
        {
            foreach (fmBlockParameter p in parameters)
            {
                if (p.group != null 
                    && p.group == enteredParameter.group)
                {
                    p.isInputed = p == enteredParameter;
                }
            }
        }
        
        protected void SetParameterCellBackColor(fmBlockParameter parameter, Color backColor)
        {
            if (parameter.cell != null)
            {
                parameter.cell.Style.BackColor = backColor;
            }
        }
    }
}