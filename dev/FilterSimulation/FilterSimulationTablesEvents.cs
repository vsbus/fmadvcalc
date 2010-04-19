using System;
using System.Windows.Forms;
using System.Drawing;
using FilterSimulation.fmFilterObjects;

namespace FilterSimulation
{
    public partial class FilterSimulation
    {
        #region CellValueChenged
        private void projectDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!displayingSolution && e.RowIndex != -1)
            {
                DataGridViewRow row = (sender as fmDataGrid.fmDataGrid).Rows[e.RowIndex];
                object guidCellValue = row.Cells["projectGuidColumn"].Value;
                fmFilterSimProject prj;

                if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["projectNameColumn"].Index)
                {
                    SetRowFontBoldOrRegular(row, FontStyle.Bold);
                    prj = fSolution.FindProject((Guid)guidCellValue);
                    prj.Name = Convert.ToString(row.Cells["projectNameColumn"].Value);
                }
                else if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["projectCheckedColumn"].Index)
                {
                    if (guidCellValue != null)
                    {
                        prj = fSolution.FindProject((Guid)guidCellValue);
                        prj.Checked = (bool)row.Cells["projectCheckedColumn"].Value;
                    }
                }
                DisplaySolution(fSolution);

            }
        }
        private void suspensionDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!displayingSolution && e.RowIndex != -1)
            {
                DataGridViewRow row = (sender as fmDataGrid.fmDataGrid).Rows[e.RowIndex];
                object guidCellValue = row.Cells["suspensionGuidColumn"].Value;
                fmFilterSimSuspension sus;

                if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["suspensionNameColumn"].Index
                    || e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["suspensionMaterialColumn"].Index
                    || e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["suspensionCustomerColumn"].Index)
                {
                    SetRowFontBoldOrRegular(row, FontStyle.Bold);

                    sus = fSolution.FindSuspension((Guid)guidCellValue);

                    if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["suspensionNameColumn"].Index)
                        sus.Name = Convert.ToString(row.Cells["suspensionNameColumn"].Value);

                    if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["suspensionMaterialColumn"].Index)
                        sus.Material = Convert.ToString(row.Cells["suspensionMaterialColumn"].Value);

                    if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["suspensionCustomerColumn"].Index)
                        sus.Customer = Convert.ToString(row.Cells["suspensionCustomerColumn"].Value);
                }
                else if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["suspensionCheckedColumn"].Index)
                {
                    if (guidCellValue != null)
                    {
                        sus = fSolution.FindSuspension((Guid)guidCellValue);
                        sus.Checked = (bool)row.Cells["suspensionCheckedColumn"].Value;
                    }
                }

                DisplaySolution(fSolution);
            }
        }
        private void simSeriesDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!displayingSolution && e.RowIndex != -1)
            {
                DataGridViewRow row = (sender as fmDataGrid.fmDataGrid).Rows[e.RowIndex];
                object guidCellValue = row.Cells["simSeriesGuidColumn"].Value;
                fmFilterSimSerie serie;

                if (e.ColumnIndex != (sender as fmDataGrid.fmDataGrid).Columns["simSeriesCheckedColumn"].Index)
                {
                    SetRowFontBoldOrRegular(row, FontStyle.Bold);

                    serie = fSolution.FindSerie((Guid)guidCellValue);

                    if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["simSeriesNameColumn"].Index)
                        serie.Name = Convert.ToString(row.Cells["simSeriesNameColumn"].Value);

                    if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["simSeriesFilterMediumColumn"].Index)
                        serie.FilterMedium = Convert.ToString(row.Cells["simSeriesFilterMediumColumn"].Value);

                    if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["simSeriesMachineNameColumn"].Index)
                        serie.MachineName = Convert.ToString(row.Cells["simSeriesMachineNameColumn"].Value);
                }
                else if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["simSeriesCheckedColumn"].Index)
                {
                    if (guidCellValue != null)
                    {
                        serie = fSolution.FindSerie((Guid)guidCellValue);
                        serie.Checked = (bool)row.Cells["simSeriesCheckedColumn"].Value;
                    }
                }

                DisplaySolution(fSolution);
            }
        }
        private void simulationDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!displayingSolution && e.RowIndex != -1)
            {
                DataGridViewRow row = (sender as fmDataGrid.fmDataGrid).Rows[e.RowIndex];
                object guidCellValue = row.Cells["simulationGuidColumn"].Value;
                fmFilterSimulation sim;

                if (e.ColumnIndex != -1
                    && e.ColumnIndex != (sender as fmDataGrid.fmDataGrid).Columns["simulationGuidColumn"].Index
                    && e.ColumnIndex != (sender as fmDataGrid.fmDataGrid).Columns["simulationCheckedColumn"].Index)

                {
                    SetRowFontBoldOrRegular(row, FontStyle.Bold);

                    sim = fSolution.FindSimulation((Guid)guidCellValue);

                    if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["simulationNameColumn"].Index)
                        sim.Name = Convert.ToString(row.Cells["simulationNameColumn"].Value);
                    else
                        return;
                }
                else if (e.ColumnIndex == (sender as fmDataGrid.fmDataGrid).Columns["simulationCheckedColumn"].Index)
                {
                    if (guidCellValue != null)
                    {
                        sim = fSolution.FindSimulation((Guid)guidCellValue);
                        sim.Checked = (bool)row.Cells["simulationCheckedColumn"].Value;
                        (sender as fmDataGrid.fmDataGrid).EndEdit();
                    }
                }

                DisplaySolution(fSolution);
            }
        }
        #endregion

        #region CurrentCellChanged
        private void suspensionDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            UpdateCurrentObjectAndDisplaySolution((DataGridView)sender);
        }
        private void simSeriesDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            UpdateCurrentObjectAndDisplaySolution((DataGridView) sender);
        }
        private void simulationDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            UpdateCurrentObjectAndDisplaySolution((DataGridView)sender);
        }
        private void projectDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            UpdateCurrentObjectAndDisplaySolution((DataGridView)sender);
        }

        #endregion

        #region CellEndEdit
        private void projectDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != (sender as fmDataGrid.fmDataGrid).Columns["projectCheckedColumn"].Index)
            {
                DisplaySolution(fSolution);
            }
        }
        private void suspensionDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != (sender as fmDataGrid.fmDataGrid).Columns["suspensionCheckedColumn"].Index)
            {
                DisplaySolution(fSolution);
            }
        }
        private void simSeriesDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != (sender as fmDataGrid.fmDataGrid).Columns["simSeriesCheckedColumn"].Index)
            {
                DisplaySolution(fSolution);
            }
        }
        private void simulationDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != (sender as fmDataGrid.fmDataGrid).Columns["simulationCheckedColumn"].Index)
            {
                DisplaySolution(fSolution);
            }
        }
        #endregion

        private void suspensionDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCurrentObjectAndDisplaySolution((DataGridView)sender);
        }

        private void simSeriesDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCurrentObjectAndDisplaySolution((DataGridView)sender);
        }

        private void simulationDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCurrentObjectAndDisplaySolution((DataGridView)sender);
        }

        private void projectDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCurrentObjectAndDisplaySolution((DataGridView)sender);
        }

    }
}