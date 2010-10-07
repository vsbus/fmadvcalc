using System;
using System.Drawing;
using System.Windows.Forms;
using fmCalculationLibrary;
using fmCalculationLibrary.MeasureUnits;

namespace FilterSimulation
{
    public partial class fmFilterSimulationControl
    {
        void CreateEps0Kappa0Pc0Rc0Alpha0Rm0HceTable()
        {
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { null, null });   // for simulation Guid
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows[0].Visible = false;

            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.eps0.name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.kappa0.name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.ne.name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.Pc0.name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.rc0.name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.a0.name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.nc.name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.hce0.name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.Rm0.name, "" });
        }
        void CreateLiquidTable()
        {
            liquidDataGrid.Rows.Add(new object[] { null, null });    // for simulation Guid
            liquidDataGrid.Rows[0].Visible = false;

            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.eta_f.name, fmUnitFamily.ViscosityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.rho_f.name, fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.rho_s.name, fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.rho_sus.name, fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.Cm.name, fmUnitFamily.ConcentrationFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.Cv.name, fmUnitFamily.ConcentrationFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.C.name, fmUnitFamily.ConcentrationCFamily.CurrentUnit.Name });
        }

        private void ResizeAllPanels()
        {
            machinePanel_Resize(null, new EventArgs());
        }

        private void machinePanel_Resize(object sender, EventArgs e)
        {
            machineTypesDataGrid.Width = machinePanel.Width;
            machineTypesDataGrid.Height = machinePanel.Height - machineTypesDataGrid.Top - 3;
        }

        private void SetRowFontBoldOrRegular(DataGridViewRow row, FontStyle fs)
        {
            if (fs != FontStyle.Bold && fs != FontStyle.Regular)
            {
                throw new Exception("font style used in SetRowFontBoldOrRegular in not bold and not regular");
            }

            Font newFont = new Font(row.DataGridView.Font, fs);
            if (row.Cells[0].Style.Font == null || row.Cells[0].Style.Font.Style != fs)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Font = newFont;
                }
            }
        }
    }
}
