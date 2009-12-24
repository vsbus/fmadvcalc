using System;
using System.Drawing;
using System.Windows.Forms;
using fmCalculationLibrary.MeasureUnits;

namespace FilterSimulation
{
    public partial class FilterSimulation
    {
        void CreateEps0Kappa0Pc0Rc0Alpha0Rm0HceTable()
        {
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { null, null });   // for simulation Guid
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows[0].Visible = false;

            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "eps0", "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "kappa0", "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "ne", "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "Pc0", "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "rc0", "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "a0", "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "nc", "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "hce", "" });
            eps0Kappa0Pc0Rc0Alpha0DataGrid.Rows.Add(new object[] { "Rm0", "" });
        }
        void CreateLiquidTable()
        {
            liquidDataGrid.Rows.Add(new object[] { null, null });    // for simulation Guid
            liquidDataGrid.Rows[0].Visible = false;

            liquidDataGrid.Rows.Add(new object[] { "eta_f", fmUnitFamily.ViscosityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { "rho_f", fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { "rho_s", fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { "rho_sus", fmUnitFamily.DensityFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { "Cm", fmUnitFamily.ConcentrationFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { "Cv", fmUnitFamily.ConcentrationFamily.CurrentUnit.Name });
            liquidDataGrid.Rows.Add(new object[] { "C", fmUnitFamily.ConcentrationCFamily.CurrentUnit.Name });
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

        private void SetRowFontStyle(DataGridViewRow row, FontStyle fs)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.Font = new Font(cell.DataGridView.Font, fs);
            }
        }
    }
}
