using System.Collections.Generic;
using System.Windows.Forms;
using fmCalcBlocksLibrary.BlockParameter;
using fmCalculationLibrary;
using System.Drawing;

namespace fmCalcBlocksLibrary.Blocks
{
    abstract public class fmBaseBlock
    {
        protected List<fmBlockVariableParameter> parameters = new List<fmBlockVariableParameter>();
        protected List<fmBlockConstantParameter> constantParameters = new List<fmBlockConstantParameter>();
        private bool m_processOnChange;
        public int debugCounter = 0;
        protected bool processOnChange
        {
            get 
            { 
                return m_processOnChange; 
            }
            set 
            {
                ++debugCounter;
                m_processOnChange = value; 
            }
        }

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
                var result = new List<fmCalculatorsLibrary.fmCalculationBaseParameter>();
                foreach (fmBlockVariableParameter p in parameters) result.Add(p);
                foreach (fmBlockConstantParameter p in constantParameters) result.Add(p);
                return result;
            }
        }

        public event Event ValuesChanged;
        public event fmBlockParameterEventHandler ValuesChangedByUser;

        abstract public void DoCalculations();
        virtual public void DoCalculationsLimitsClue()
        {
            DoCalculations();
        }
        virtual public List<fmBlockVariableParameter> GetClueParamsList() 
        {
            return new List<fmBlockVariableParameter>();
        }

        virtual protected void ReWriteParameters()
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
            if (enteredParameter != null)
                foreach (fmBlockVariableParameter p in parameters)
                    if (p.group != null && p.group == enteredParameter.group)
                        p.IsInputed = p == enteredParameter;
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
                var dataGrid = sender as fmDataGrid.fmDataGrid;

                if (dataGrid != null)
                {
                    int parameterIndex;
                    fmBlockVariableParameter enteredParameter = FindEnteredParameter(dataGrid.CurrentCell, out parameterIndex);

                    if (enteredParameter != null)
                    {
                        UpdateIsInputed(enteredParameter);
                        enteredParameter.value = fmValue.ObjectToValue(dataGrid.CurrentCell.Value) * enteredParameter.globalParameter.unitFamily.CurrentUnit.Coef;
                    
                        if (ValuesChangedByUser != null)
                            ValuesChangedByUser(this, new fmBlockParameterEventArgs(parameterIndex));
                    
                        DoCalculations();
                        ReWriteParameters();
                    }
                }
            }
        }

        protected void AddParameter(
            ref fmBlockVariableParameter p,
            fmGlobalParameter globalParameter,
            DataGridViewCell cell,
            bool isInputedDefault)
        {
            p = new fmBlockVariableParameter(globalParameter, isInputedDefault);
            AssignCell(p, cell);
            parameters.Add(p);
        }

        public void AssignCell(fmBlockVariableParameter p, DataGridViewCell cell)
        {
            p.cell = cell;
            
            if (cell != null)
            {
                var dataGrid = cell.DataGridView as fmDataGrid.fmDataGrid;
                if (dataGrid != null)
                {
                    dataGrid.CellValueChangedByUser -= CellValueChanged;
                    dataGrid.CellValueChangedByUser += CellValueChanged;
                }
            }
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

        public void UpdateCellsBackColor()
        {
            foreach (fmBlockVariableParameter p in parameters)
            {
                if (p.cell != null)
                {
                    Color color = p.group == null
                                     ? Color.White
                                     : p.group.color;
                    p.cell.Style.BackColor = color;
                }
            }
        }
    }
}