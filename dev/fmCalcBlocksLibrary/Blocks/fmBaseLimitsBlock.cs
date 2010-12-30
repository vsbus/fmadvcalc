using System;
using System.Collections.Generic;
using System.Text;
using fmCalcBlocksLibrary.BlockParameter;
using System.Windows.Forms;
using fmCalculationLibrary;
using System.Drawing;

namespace fmCalcBlocksLibrary.Blocks
{
    abstract public class fmBaseLimitsBlock
    {
        protected List<fmBlockLimitsParameter> parameters = new List<fmBlockLimitsParameter>();
        protected bool processOnChange;

        public List<fmBlockLimitsParameter> Parameters
        {
            get { return parameters; }
        }

        private void WriteParameterToCell(fmBlockLimitParameter parameter, fmGlobalParameter globalParameter)
        {
            string newVal = (parameter.value / globalParameter.unitFamily.CurrentUnit.Coef).ToString();
            if (parameter.cell != null)
                parameter.cell.Value = newVal;
        }

        virtual protected void ReWriteParameters()
        {
            if (processOnChange)
            {
                processOnChange = false;
                for (int i = 0; i < parameters.Count; ++i)
                {
                    WriteParameterToCell(parameters[i].pMin, parameters[i].globalParameter);
                    WriteParameterToCell(parameters[i].pMax, parameters[i].globalParameter);
                }
                processOnChange = true;
            }
        }

        public void Display()
        {
            ReWriteParameters();
        }

        public void UpdateIsInputed(fmBlockLimitsParameter enteredParameter)
        {
            if (enteredParameter != null)
                foreach (var p in parameters)
                    if (p.group != null && p.group == enteredParameter.group)
                        p.IsInputed = p == enteredParameter;
        }

        private fmBlockLimitsParameter FindEnteredParameter(DataGridViewCell cell, out int parameterIndex)
        {
            for (int i = 0; i < parameters.Count; ++i)
                if (parameters[i].pMin.cell == cell || parameters[i].pMax.cell == cell)
                {
                    parameterIndex = i;
                    return parameters[i];
                }
            parameterIndex = -1;
            return null;
        }

        public void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (processOnChange)
            {
                var dataGrid = sender as fmDataGrid.fmDataGrid;

                if (dataGrid != null)
                {
                    int parameterIndex;
                    var enteredParameter = FindEnteredParameter(dataGrid.CurrentCell, out parameterIndex);

                    if (enteredParameter != null)
                    {
                        UpdateIsInputed(enteredParameter);
                        ((enteredParameter.pMin.cell == dataGrid.CurrentCell) 
                            ? enteredParameter.pMin 
                            : enteredParameter.pMax
                            ).value = fmValue.ObjectToValue(dataGrid.CurrentCell.Value) * enteredParameter.globalParameter.unitFamily.CurrentUnit.Coef;
                        
                        ReWriteParameters();
                    }
                }
            }
        }

        protected void AddParameter(
            ref fmBlockLimitsParameter p,
            fmGlobalParameter globalParameter,
            DataGridViewCell cellMin,
            DataGridViewCell cellMax,
            bool isInputedDefault)
        {
            p = new fmBlockLimitsParameter(globalParameter);
            AssignCell(p.pMin, cellMin);
            AssignCell(p.pMax, cellMax);
            p.IsInputed = isInputedDefault;
            parameters.Add(p);
        }

        public void AssignCell(fmBlockLimitParameter p, DataGridViewCell cell)
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

        public fmBlockLimitsParameter GetParameterByName(string parameterName)
        {
            foreach (var parameter in parameters)
                if (parameter.globalParameter.name == parameterName)
                    return parameter;
            return null;
        }

        public void UpdateCellBackColor(DataGridViewCell cell, fmBlockParameterGroup group)
        {
            if (cell != null && group != null && group.transparent == false)
            {
                cell.Style.BackColor = group.color;
            }
        }

        public void UpdateCellsBackColor()
        {
            foreach (var p in parameters)
            {
                UpdateCellBackColor(p.pMin.cell, p.group);
                UpdateCellBackColor(p.pMax.cell, p.group);
            }
        }
    }
}
