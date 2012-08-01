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
                return Solution.FindMachineType(Convert.ToString(machineTypesDataGrid.CurrentRow.Cells["machineTypeSymbolColumn"].Value));
            }
            return null;
        }

        static public fmFilterSimSuspension GetFirstChild(fmFilterSimProject prj)
        {
            return fmCurrentObjectsStruct.GetFirstChild(prj);
        }
        static public fmFilterSimSerie GetFirstChild(fmFilterSimSuspension sus)
        {
            return fmCurrentObjectsStruct.GetFirstChild(sus);
        }
        static public fmFilterSimulation GetFirstChild(fmFilterSimSerie serie)
        {
            return fmCurrentObjectsStruct.GetFirstChild(serie);
        }
    }
}