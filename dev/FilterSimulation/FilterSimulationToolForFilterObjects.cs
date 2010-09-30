using System;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl
    {
        private fmFilterSimMachineType GetCurrentMachine()
        {
            if (machineTypesDataGrid.CurrentRow != null)
            {
                if (machineTypesDataGrid.CurrentCell.RowIndex == -1
                    || machineTypesDataGrid.CurrentCell.ColumnIndex == -1
                    || machineTypesDataGrid.CurrentRow.Cells["machineTypeSymbolColumn"].Value == null)
                {
                    return null;
                }
                return m_fSolution.FindMachineType(Convert.ToString(machineTypesDataGrid.CurrentRow.Cells["machineTypeSymbolColumn"].Value));
            }
            return null;
        }

        static public fmFilterSimSuspension GetFirstChild(fmFilterSimProject prj)
        {
            return CurrentObjectsStruct.GetFirstChild(prj);
        }
        static public fmFilterSimSerie GetFirstChild(fmFilterSimSuspension sus)
        {
            return CurrentObjectsStruct.GetFirstChild(sus);
        }
        static public fmFilterSimulation GetFirstChild(fmFilterSimSerie serie)
        {
            return CurrentObjectsStruct.GetFirstChild(serie);
        }
    }
}