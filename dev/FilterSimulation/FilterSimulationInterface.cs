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

            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.eps0.Name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.kappa0.Name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.ne.Name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.Pc0.Name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.rc0.Name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.a0.Name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.nc.Name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.hce0.Name, "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { fmGlobalParameter.Rm0.Name, "" });
        }
        void CreateLiquidTable()
        {
            liquidDataGrid.Rows.Add(new object[] { null, null });    // for simulation Guid
            liquidDataGrid.Rows[0].Visible = false;

            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.eta_f.Name, fmUnitFamily.ViscosityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.rho_f.Name, fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.rho_s.Name, fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.rho_sus.Name, fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.Cm.Name, fmUnitFamily.ConcentrationFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.Cv.Name, fmUnitFamily.ConcentrationFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { fmGlobalParameter.C.Name, fmUnitFamily.ConcentrationCFamily.CurrentUnit.Name });
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
            bool isRegular = row.Cells[0].Style.Font == null || row.Cells[0].Style.Font.Style != FontStyle.Regular;
            if (isRegular != (fs == FontStyle.Regular))
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.Font = newFont;
                }
            }
        }
    }
}
