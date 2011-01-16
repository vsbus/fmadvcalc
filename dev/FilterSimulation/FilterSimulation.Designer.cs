namespace FilterSimulation
{
    public partial class fmFilterSimulationControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmFilterSimulationControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.byCheckingProjectsCheckBox = new System.Windows.Forms.CheckBox();
            this.byCheckingSuspensionsCheckBox = new System.Windows.Forms.CheckBox();
            this.byCheckingSimSeriesCheckBox = new System.Windows.Forms.CheckBox();
            this.fullSimulationInfoCheckBox = new System.Windows.Forms.CheckBox();
            this.byCheckingSimulationsCheckBox = new System.Windows.Forms.CheckBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.suspensionParametersAndCalcOptionsPanel = new System.Windows.Forms.Panel();
            this.suspensionParametersPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.calculateLimitsCheckBox = new System.Windows.Forms.CheckBox();
            this.commonCalcBlockDataGrid = new fmDataGrid.fmDataGrid();
            this.commonCalcBlockParameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonCalcBlockUnitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonCalcBlockMinAbsColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.commonCalcBlockMinLocalColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.commonCalcBlockParameterValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.commonCalcBlockMaxLocalColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.commonCalcBlockMaxAbsColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.deliquoringMaterialParametersDataGrid = new fmDataGrid.fmDataGrid();
            this.deliquoringMaterialParametersParameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliquoringMaterialParametersUnitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMaterialParameters = new System.Windows.Forms.Panel();
            this.calculationOptionChangeButton = new System.Windows.Forms.Button();
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid = new fmDataGrid.fmDataGrid();
            this.epsKappaParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epsKappaUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liquidDataGrid = new fmDataGrid.fmDataGrid();
            this.liquidParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liquidParameterUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSimSerSusInput = new System.Windows.Forms.Panel();
            this.meterialInputSuspensionRadioButton = new System.Windows.Forms.RadioButton();
            this.meterialInputSerieRadioButton = new System.Windows.Forms.RadioButton();
            this.meterialInputSimualationRadioButton = new System.Windows.Forms.RadioButton();
            this.splitter6 = new System.Windows.Forms.Splitter();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.secondFromTopPanel = new System.Windows.Forms.Panel();
            this.simSeriesPanel = new System.Windows.Forms.Panel();
            this.simSeriesDataGrid = new fmDataGrid.fmDataGrid();
            this.simSeriesCheckedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.simSeriesGuidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simSeriesNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simSeriesProjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simSeriesSuspensionNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simSeriesFilterMediumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simSeriesMachineTypeNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simSeriesMachineNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simSeriesLastModifiedDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.simSeriesDeleteButton = new System.Windows.Forms.Button();
            this.simSeriesRestoreButton = new System.Windows.Forms.Button();
            this.simSeriesKeepButton = new System.Windows.Forms.Button();
            this.simSeriesDuplicateButton = new System.Windows.Forms.Button();
            this.simSeriesCreateButton = new System.Windows.Forms.Button();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.topPanel = new System.Windows.Forms.Panel();
            this.suspensionPanel = new System.Windows.Forms.Panel();
            this.suspensionDataGrid = new fmDataGrid.fmDataGrid();
            this.suspensionGuidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suspensionCheckedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.suspensionMaterialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suspensionCustomerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suspensionNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.suspensionDeleteButton = new System.Windows.Forms.Button();
            this.suspensionRestoreButton = new System.Windows.Forms.Button();
            this.suspensionKeepButton = new System.Windows.Forms.Button();
            this.suspensionCreateButton = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.machinePanel = new System.Windows.Forms.Panel();
            this.machineTypesDataGrid = new fmDataGrid.fmDataGrid();
            this.machineTypeCheckedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.machineTypeSymbolColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineTypeNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectPanel = new System.Windows.Forms.Panel();
            this.projectDataGrid = new fmDataGrid.fmDataGrid();
            this.projectGuidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectCheckedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.projectNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.projectDeleteButton = new System.Windows.Forms.Button();
            this.projectRestoreButton = new System.Windows.Forms.Button();
            this.projectKeepButton = new System.Windows.Forms.Button();
            this.projectCreateButton = new System.Windows.Forms.Button();
            this.simulationPanel = new System.Windows.Forms.Panel();
            this.simulationDataGrid = new fmDataGrid.fmDataGrid();
            this.simulationGuidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationCheckedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.simulationProjectColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationSuspensionNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationFilterMediumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationMachineTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationMachineNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationSimSeriesNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationFilterAreaColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulationFilterDiameterColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_DpColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_sfColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_srColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_nColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_tcColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_tfColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_trColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_hc_over_tfColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_dhc_over_dtColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_hcColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_MfColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_VfColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_MsusColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_VsusColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_MsColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_VsColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_McColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_VcColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_mf_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_vf_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_msus_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_vsus_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_ms_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_vs_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_mc_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_vc_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_QsusColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_Qsus_dColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_QmsusColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_Qmsus_dColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_QmsColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_Qms_dColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_QmfColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_Qmf_dColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_QmcColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_Qmc_dColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_QfColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_Qf_dColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_QsColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_Qs_dColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_QcColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_Qc_dColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qf_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qf_d_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qsus_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qsus_d_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qs_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qs_d_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qc_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qc_d_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qmf_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qmf_d_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qmsus_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qmsus_d_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qms_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qms_d_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qmc_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_qmc_d_Column = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_epsColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_kappaColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_PcColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_rcColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.simulation_aColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.simulationDeleteButton = new System.Windows.Forms.Button();
            this.simulationRestoreButton = new System.Windows.Forms.Button();
            this.simulationKeepButton = new System.Windows.Forms.Button();
            this.simulationDuplicateButton = new System.Windows.Forms.Button();
            this.simulationCreateButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitter5 = new System.Windows.Forms.Splitter();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonDeliquoringSimulationBlockDataGrid = new fmDataGrid.fmDataGrid();
            this.commonDeliquoringSimulationBlockParameterNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonDeliquoringSimulationBlockUnitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonDeliquoringSimulationBlockParameterValueColumn = new fmDataGrid.fmDataGridViewNumericalTextBoxColumn();
            this.panelLeft.SuspendLayout();
            this.suspensionParametersAndCalcOptionsPanel.SuspendLayout();
            this.suspensionParametersPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonCalcBlockDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliquoringMaterialParametersDataGrid)).BeginInit();
            this.panelMaterialParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eps0Kappa0Pc0Rc0Alpha0DataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liquidDataGrid)).BeginInit();
            this.panelSimSerSusInput.SuspendLayout();
            this.secondFromTopPanel.SuspendLayout();
            this.simSeriesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simSeriesDataGrid)).BeginInit();
            this.panel3.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.suspensionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suspensionDataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.machinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.machineTypesDataGrid)).BeginInit();
            this.projectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.simulationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simulationDataGrid)).BeginInit();
            this.panel5.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonDeliquoringSimulationBlockDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // byCheckingProjectsCheckBox
            // 
            this.byCheckingProjectsCheckBox.AutoSize = true;
            this.byCheckingProjectsCheckBox.Checked = true;
            this.byCheckingProjectsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.byCheckingProjectsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.byCheckingProjectsCheckBox.Location = new System.Drawing.Point(0, 0);
            this.byCheckingProjectsCheckBox.Name = "byCheckingProjectsCheckBox";
            this.byCheckingProjectsCheckBox.Size = new System.Drawing.Size(85, 20);
            this.byCheckingProjectsCheckBox.TabIndex = 0;
            this.byCheckingProjectsCheckBox.Text = "by Checking";
            this.byCheckingProjectsCheckBox.UseVisualStyleBackColor = true;
            this.byCheckingProjectsCheckBox.CheckedChanged += new System.EventHandler(this.byCheckingProjectsCheckBox_CheckedChanged);
            // 
            // byCheckingSuspensionsCheckBox
            // 
            this.byCheckingSuspensionsCheckBox.AutoSize = true;
            this.byCheckingSuspensionsCheckBox.Checked = true;
            this.byCheckingSuspensionsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.byCheckingSuspensionsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.byCheckingSuspensionsCheckBox.Location = new System.Drawing.Point(0, 0);
            this.byCheckingSuspensionsCheckBox.Name = "byCheckingSuspensionsCheckBox";
            this.byCheckingSuspensionsCheckBox.Size = new System.Drawing.Size(85, 20);
            this.byCheckingSuspensionsCheckBox.TabIndex = 1;
            this.byCheckingSuspensionsCheckBox.Text = "by Checking";
            this.byCheckingSuspensionsCheckBox.UseVisualStyleBackColor = true;
            this.byCheckingSuspensionsCheckBox.CheckedChanged += new System.EventHandler(this.byCheckingSuspensionsCheckBox_CheckedChanged);
            // 
            // byCheckingSimSeriesCheckBox
            // 
            this.byCheckingSimSeriesCheckBox.AutoSize = true;
            this.byCheckingSimSeriesCheckBox.Checked = true;
            this.byCheckingSimSeriesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.byCheckingSimSeriesCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.byCheckingSimSeriesCheckBox.Location = new System.Drawing.Point(0, 0);
            this.byCheckingSimSeriesCheckBox.Name = "byCheckingSimSeriesCheckBox";
            this.byCheckingSimSeriesCheckBox.Size = new System.Drawing.Size(85, 20);
            this.byCheckingSimSeriesCheckBox.TabIndex = 1;
            this.byCheckingSimSeriesCheckBox.Text = "by Checking";
            this.byCheckingSimSeriesCheckBox.UseVisualStyleBackColor = true;
            this.byCheckingSimSeriesCheckBox.CheckedChanged += new System.EventHandler(this.byCheckingSimSeriesCheckBox_CheckedChanged);
            // 
            // fullSimulationInfoCheckBox
            // 
            this.fullSimulationInfoCheckBox.AutoSize = true;
            this.fullSimulationInfoCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.fullSimulationInfoCheckBox.Location = new System.Drawing.Point(0, 0);
            this.fullSimulationInfoCheckBox.Name = "fullSimulationInfoCheckBox";
            this.fullSimulationInfoCheckBox.Size = new System.Drawing.Size(63, 20);
            this.fullSimulationInfoCheckBox.TabIndex = 6;
            this.fullSimulationInfoCheckBox.Text = "Full Info";
            this.fullSimulationInfoCheckBox.UseVisualStyleBackColor = true;
            this.fullSimulationInfoCheckBox.CheckedChanged += new System.EventHandler(this.fullSimulationInfoCheckBox_CheckedChanged);
            // 
            // byCheckingSimulationsCheckBox
            // 
            this.byCheckingSimulationsCheckBox.AutoSize = true;
            this.byCheckingSimulationsCheckBox.Checked = true;
            this.byCheckingSimulationsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.byCheckingSimulationsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.byCheckingSimulationsCheckBox.Location = new System.Drawing.Point(63, 0);
            this.byCheckingSimulationsCheckBox.Name = "byCheckingSimulationsCheckBox";
            this.byCheckingSimulationsCheckBox.Size = new System.Drawing.Size(85, 20);
            this.byCheckingSimulationsCheckBox.TabIndex = 1;
            this.byCheckingSimulationsCheckBox.Text = "by Checking";
            this.byCheckingSimulationsCheckBox.UseVisualStyleBackColor = true;
            this.byCheckingSimulationsCheckBox.CheckedChanged += new System.EventHandler(this.byCheckingSimulationsCheckBox_CheckedChanged);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.suspensionParametersAndCalcOptionsPanel);
            this.panelLeft.Controls.Add(this.splitter4);
            this.panelLeft.Controls.Add(this.secondFromTopPanel);
            this.panelLeft.Controls.Add(this.splitter3);
            this.panelLeft.Controls.Add(this.topPanel);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(980, 432);
            this.panelLeft.TabIndex = 31;
            // 
            // suspensionParametersAndCalcOptionsPanel
            // 
            this.suspensionParametersAndCalcOptionsPanel.Controls.Add(this.suspensionParametersPanel);
            this.suspensionParametersAndCalcOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suspensionParametersAndCalcOptionsPanel.Location = new System.Drawing.Point(0, 184);
            this.suspensionParametersAndCalcOptionsPanel.Name = "suspensionParametersAndCalcOptionsPanel";
            this.suspensionParametersAndCalcOptionsPanel.Size = new System.Drawing.Size(980, 248);
            this.suspensionParametersAndCalcOptionsPanel.TabIndex = 7;
            // 
            // suspensionParametersPanel
            // 
            this.suspensionParametersPanel.Controls.Add(this.panel6);
            this.suspensionParametersPanel.Controls.Add(this.splitter6);
            this.suspensionParametersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suspensionParametersPanel.Location = new System.Drawing.Point(0, 0);
            this.suspensionParametersPanel.Name = "suspensionParametersPanel";
            this.suspensionParametersPanel.Size = new System.Drawing.Size(980, 248);
            this.suspensionParametersPanel.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.commonDeliquoringSimulationBlockDataGrid);
            this.panel6.Controls.Add(this.calculateLimitsCheckBox);
            this.panel6.Controls.Add(this.commonCalcBlockDataGrid);
            this.panel6.Controls.Add(this.deliquoringMaterialParametersDataGrid);
            this.panel6.Controls.Add(this.panelMaterialParameters);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(977, 248);
            this.panel6.TabIndex = 17;
            // 
            // calculateLimitsCheckBox
            // 
            this.calculateLimitsCheckBox.AutoSize = true;
            this.calculateLimitsCheckBox.Location = new System.Drawing.Point(666, 4);
            this.calculateLimitsCheckBox.Name = "calculateLimitsCheckBox";
            this.calculateLimitsCheckBox.Size = new System.Drawing.Size(52, 17);
            this.calculateLimitsCheckBox.TabIndex = 14;
            this.calculateLimitsCheckBox.Text = "Limits";
            this.calculateLimitsCheckBox.UseVisualStyleBackColor = true;
            this.calculateLimitsCheckBox.CheckedChanged += new System.EventHandler(this.calculateLimitsCheckBox_CheckedChanged);
            // 
            // commonCalcBlockDataGrid
            // 
            this.commonCalcBlockDataGrid.AllowUserToAddRows = false;
            this.commonCalcBlockDataGrid.AllowUserToDeleteRows = false;
            this.commonCalcBlockDataGrid.AllowUserToResizeRows = false;
            this.commonCalcBlockDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.commonCalcBlockDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commonCalcBlockDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commonCalcBlockDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commonCalcBlockParameterNameColumn,
            this.commonCalcBlockUnitColumn,
            this.commonCalcBlockMinAbsColumn,
            this.commonCalcBlockMinLocalColumn,
            this.commonCalcBlockParameterValueColumn,
            this.commonCalcBlockMaxLocalColumn,
            this.commonCalcBlockMaxAbsColumn});
            this.commonCalcBlockDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonCalcBlockDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.commonCalcBlockDataGrid.HighLightCurrentRow = false;
            this.commonCalcBlockDataGrid.Location = new System.Drawing.Point(410, 0);
            this.commonCalcBlockDataGrid.Name = "commonCalcBlockDataGrid";
            this.commonCalcBlockDataGrid.RowHeadersVisible = false;
            this.commonCalcBlockDataGrid.RowTemplate.Height = 16;
            this.commonCalcBlockDataGrid.Size = new System.Drawing.Size(292, 244);
            this.commonCalcBlockDataGrid.TabIndex = 13;
            // 
            // commonCalcBlockParameterNameColumn
            // 
            this.commonCalcBlockParameterNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.commonCalcBlockParameterNameColumn.HeaderText = "Parameter";
            this.commonCalcBlockParameterNameColumn.Name = "commonCalcBlockParameterNameColumn";
            this.commonCalcBlockParameterNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.commonCalcBlockParameterNameColumn.Width = 61;
            // 
            // commonCalcBlockUnitColumn
            // 
            this.commonCalcBlockUnitColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.commonCalcBlockUnitColumn.HeaderText = "Units";
            this.commonCalcBlockUnitColumn.Name = "commonCalcBlockUnitColumn";
            this.commonCalcBlockUnitColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.commonCalcBlockUnitColumn.Width = 37;
            // 
            // commonCalcBlockMinAbsColumn
            // 
            this.commonCalcBlockMinAbsColumn.HeaderText = "MinAbs";
            this.commonCalcBlockMinAbsColumn.Name = "commonCalcBlockMinAbsColumn";
            this.commonCalcBlockMinAbsColumn.ReadOnly = true;
            this.commonCalcBlockMinAbsColumn.Visible = false;
            this.commonCalcBlockMinAbsColumn.Width = 50;
            // 
            // commonCalcBlockMinLocalColumn
            // 
            this.commonCalcBlockMinLocalColumn.HeaderText = "Min";
            this.commonCalcBlockMinLocalColumn.Name = "commonCalcBlockMinLocalColumn";
            this.commonCalcBlockMinLocalColumn.ReadOnly = true;
            this.commonCalcBlockMinLocalColumn.Width = 50;
            // 
            // commonCalcBlockParameterValueColumn
            // 
            this.commonCalcBlockParameterValueColumn.HeaderText = "Value";
            this.commonCalcBlockParameterValueColumn.Name = "commonCalcBlockParameterValueColumn";
            this.commonCalcBlockParameterValueColumn.Width = 50;
            // 
            // commonCalcBlockMaxLocalColumn
            // 
            this.commonCalcBlockMaxLocalColumn.HeaderText = "Max";
            this.commonCalcBlockMaxLocalColumn.Name = "commonCalcBlockMaxLocalColumn";
            this.commonCalcBlockMaxLocalColumn.ReadOnly = true;
            this.commonCalcBlockMaxLocalColumn.Width = 50;
            // 
            // commonCalcBlockMaxAbsColumn
            // 
            this.commonCalcBlockMaxAbsColumn.HeaderText = "MaxAbs";
            this.commonCalcBlockMaxAbsColumn.Name = "commonCalcBlockMaxAbsColumn";
            this.commonCalcBlockMaxAbsColumn.ReadOnly = true;
            this.commonCalcBlockMaxAbsColumn.Visible = false;
            this.commonCalcBlockMaxAbsColumn.Width = 50;
            // 
            // deliquoringMaterialParametersDataGrid
            // 
            this.deliquoringMaterialParametersDataGrid.AllowUserToAddRows = false;
            this.deliquoringMaterialParametersDataGrid.AllowUserToDeleteRows = false;
            this.deliquoringMaterialParametersDataGrid.AllowUserToResizeColumns = false;
            this.deliquoringMaterialParametersDataGrid.AllowUserToResizeRows = false;
            this.deliquoringMaterialParametersDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.deliquoringMaterialParametersDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deliquoringMaterialParametersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deliquoringMaterialParametersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deliquoringMaterialParametersParameterNameColumn,
            this.deliquoringMaterialParametersUnitsColumn});
            this.deliquoringMaterialParametersDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.deliquoringMaterialParametersDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.deliquoringMaterialParametersDataGrid.HighLightCurrentRow = false;
            this.deliquoringMaterialParametersDataGrid.Location = new System.Drawing.Point(205, 0);
            this.deliquoringMaterialParametersDataGrid.Name = "deliquoringMaterialParametersDataGrid";
            this.deliquoringMaterialParametersDataGrid.RowHeadersVisible = false;
            this.deliquoringMaterialParametersDataGrid.RowTemplate.Height = 16;
            this.deliquoringMaterialParametersDataGrid.Size = new System.Drawing.Size(205, 244);
            this.deliquoringMaterialParametersDataGrid.TabIndex = 16;
            // 
            // deliquoringMaterialParametersParameterNameColumn
            // 
            this.deliquoringMaterialParametersParameterNameColumn.HeaderText = "Parameter";
            this.deliquoringMaterialParametersParameterNameColumn.Name = "deliquoringMaterialParametersParameterNameColumn";
            this.deliquoringMaterialParametersParameterNameColumn.Width = 61;
            // 
            // deliquoringMaterialParametersUnitsColumn
            // 
            this.deliquoringMaterialParametersUnitsColumn.HeaderText = "Units";
            this.deliquoringMaterialParametersUnitsColumn.Name = "deliquoringMaterialParametersUnitsColumn";
            this.deliquoringMaterialParametersUnitsColumn.Width = 65;
            // 
            // panelMaterialParameters
            // 
            this.panelMaterialParameters.Controls.Add(this.calculationOptionChangeButton);
            this.panelMaterialParameters.Controls.Add(this.eps0Kappa0Pc0Rc0Alpha0DataGrid);
            this.panelMaterialParameters.Controls.Add(this.liquidDataGrid);
            this.panelMaterialParameters.Controls.Add(this.panelSimSerSusInput);
            this.panelMaterialParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMaterialParameters.Location = new System.Drawing.Point(0, 0);
            this.panelMaterialParameters.Name = "panelMaterialParameters";
            this.panelMaterialParameters.Size = new System.Drawing.Size(205, 244);
            this.panelMaterialParameters.TabIndex = 15;
            // 
            // calculationOptionChangeButton
            // 
            this.calculationOptionChangeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.calculationOptionChangeButton.Location = new System.Drawing.Point(0, 328);
            this.calculationOptionChangeButton.Name = "calculationOptionChangeButton";
            this.calculationOptionChangeButton.Size = new System.Drawing.Size(205, 23);
            this.calculationOptionChangeButton.TabIndex = 15;
            this.calculationOptionChangeButton.Text = "Calculation Option";
            this.calculationOptionChangeButton.UseVisualStyleBackColor = true;
            this.calculationOptionChangeButton.Click += new System.EventHandler(this.calculationOptionChangeButton_Click);
            // 
            // eps0Kappa0Pc0Rc0Alpha0DataGrid
            // 
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.AllowUserToAddRows = false;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.AllowUserToDeleteRows = false;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.AllowUserToResizeColumns = false;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.AllowUserToResizeRows = false;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.epsKappaParameterName,
            this.epsKappaUnits});
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.HighLightCurrentRow = false;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.Location = new System.Drawing.Point(0, 160);
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.Name = "eps0Kappa0Pc0Rc0Alpha0DataGrid";
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.RowHeadersVisible = false;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.RowTemplate.Height = 16;
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.Size = new System.Drawing.Size(205, 168);
            this.eps0Kappa0Pc0Rc0Alpha0DataGrid.TabIndex = 12;
            // 
            // epsKappaParameterName
            // 
            this.epsKappaParameterName.HeaderText = "Parameter";
            this.epsKappaParameterName.Name = "epsKappaParameterName";
            this.epsKappaParameterName.ReadOnly = true;
            this.epsKappaParameterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.epsKappaParameterName.Width = 61;
            // 
            // epsKappaUnits
            // 
            this.epsKappaUnits.HeaderText = "Units";
            this.epsKappaUnits.Name = "epsKappaUnits";
            this.epsKappaUnits.ReadOnly = true;
            this.epsKappaUnits.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.epsKappaUnits.Width = 65;
            // 
            // liquidDataGrid
            // 
            this.liquidDataGrid.AllowUserToAddRows = false;
            this.liquidDataGrid.AllowUserToDeleteRows = false;
            this.liquidDataGrid.AllowUserToResizeColumns = false;
            this.liquidDataGrid.AllowUserToResizeRows = false;
            this.liquidDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.liquidDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.liquidDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.liquidDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.liquidParameterName,
            this.liquidParameterUnits});
            this.liquidDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.liquidDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.liquidDataGrid.HighLightCurrentRow = false;
            this.liquidDataGrid.Location = new System.Drawing.Point(0, 21);
            this.liquidDataGrid.Name = "liquidDataGrid";
            this.liquidDataGrid.RowHeadersVisible = false;
            this.liquidDataGrid.RowTemplate.Height = 16;
            this.liquidDataGrid.Size = new System.Drawing.Size(205, 139);
            this.liquidDataGrid.TabIndex = 5;
            // 
            // liquidParameterName
            // 
            this.liquidParameterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.liquidParameterName.HeaderText = "Parameter";
            this.liquidParameterName.Name = "liquidParameterName";
            this.liquidParameterName.ReadOnly = true;
            this.liquidParameterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.liquidParameterName.Width = 61;
            // 
            // liquidParameterUnits
            // 
            this.liquidParameterUnits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.liquidParameterUnits.HeaderText = "Units";
            this.liquidParameterUnits.Name = "liquidParameterUnits";
            this.liquidParameterUnits.ReadOnly = true;
            this.liquidParameterUnits.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.liquidParameterUnits.Width = 65;
            // 
            // panelSimSerSusInput
            // 
            this.panelSimSerSusInput.Controls.Add(this.meterialInputSuspensionRadioButton);
            this.panelSimSerSusInput.Controls.Add(this.meterialInputSerieRadioButton);
            this.panelSimSerSusInput.Controls.Add(this.meterialInputSimualationRadioButton);
            this.panelSimSerSusInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSimSerSusInput.Location = new System.Drawing.Point(0, 0);
            this.panelSimSerSusInput.Name = "panelSimSerSusInput";
            this.panelSimSerSusInput.Size = new System.Drawing.Size(205, 21);
            this.panelSimSerSusInput.TabIndex = 0;
            // 
            // meterialInputSuspensionRadioButton
            // 
            this.meterialInputSuspensionRadioButton.AutoSize = true;
            this.meterialInputSuspensionRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meterialInputSuspensionRadioButton.Location = new System.Drawing.Point(87, 0);
            this.meterialInputSuspensionRadioButton.Name = "meterialInputSuspensionRadioButton";
            this.meterialInputSuspensionRadioButton.Size = new System.Drawing.Size(118, 21);
            this.meterialInputSuspensionRadioButton.TabIndex = 2;
            this.meterialInputSuspensionRadioButton.Text = "suspension";
            this.meterialInputSuspensionRadioButton.UseVisualStyleBackColor = true;
            // 
            // meterialInputSerieRadioButton
            // 
            this.meterialInputSerieRadioButton.AutoSize = true;
            this.meterialInputSerieRadioButton.Checked = true;
            this.meterialInputSerieRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.meterialInputSerieRadioButton.Location = new System.Drawing.Point(40, 0);
            this.meterialInputSerieRadioButton.Name = "meterialInputSerieRadioButton";
            this.meterialInputSerieRadioButton.Size = new System.Drawing.Size(47, 21);
            this.meterialInputSerieRadioButton.TabIndex = 1;
            this.meterialInputSerieRadioButton.TabStop = true;
            this.meterialInputSerieRadioButton.Text = "serie";
            this.meterialInputSerieRadioButton.UseVisualStyleBackColor = true;
            // 
            // meterialInputSimualationRadioButton
            // 
            this.meterialInputSimualationRadioButton.AutoSize = true;
            this.meterialInputSimualationRadioButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.meterialInputSimualationRadioButton.Location = new System.Drawing.Point(0, 0);
            this.meterialInputSimualationRadioButton.Name = "meterialInputSimualationRadioButton";
            this.meterialInputSimualationRadioButton.Size = new System.Drawing.Size(40, 21);
            this.meterialInputSimualationRadioButton.TabIndex = 0;
            this.meterialInputSimualationRadioButton.Text = "sim";
            this.meterialInputSimualationRadioButton.UseVisualStyleBackColor = true;
            // 
            // splitter6
            // 
            this.splitter6.Location = new System.Drawing.Point(0, 0);
            this.splitter6.Name = "splitter6";
            this.splitter6.Size = new System.Drawing.Size(3, 248);
            this.splitter6.TabIndex = 16;
            this.splitter6.TabStop = false;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(0, 181);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(980, 3);
            this.splitter4.TabIndex = 6;
            this.splitter4.TabStop = false;
            // 
            // secondFromTopPanel
            // 
            this.secondFromTopPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.secondFromTopPanel.Controls.Add(this.simSeriesPanel);
            this.secondFromTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.secondFromTopPanel.Location = new System.Drawing.Point(0, 84);
            this.secondFromTopPanel.Name = "secondFromTopPanel";
            this.secondFromTopPanel.Size = new System.Drawing.Size(980, 97);
            this.secondFromTopPanel.TabIndex = 4;
            // 
            // simSeriesPanel
            // 
            this.simSeriesPanel.Controls.Add(this.simSeriesDataGrid);
            this.simSeriesPanel.Controls.Add(this.panel3);
            this.simSeriesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simSeriesPanel.Location = new System.Drawing.Point(0, 0);
            this.simSeriesPanel.Name = "simSeriesPanel";
            this.simSeriesPanel.Size = new System.Drawing.Size(976, 93);
            this.simSeriesPanel.TabIndex = 8;
            // 
            // simSeriesDataGrid
            // 
            this.simSeriesDataGrid.AllowUserToAddRows = false;
            this.simSeriesDataGrid.AllowUserToResizeRows = false;
            this.simSeriesDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.simSeriesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.simSeriesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simSeriesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.simSeriesCheckedColumn,
            this.simSeriesGuidColumn,
            this.simSeriesNameColumn,
            this.simSeriesProjectColumn,
            this.simSeriesSuspensionNameColumn,
            this.simSeriesFilterMediumColumn,
            this.simSeriesMachineTypeNameColumn,
            this.simSeriesMachineNameColumn,
            this.simSeriesLastModifiedDateColumn});
            this.simSeriesDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simSeriesDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.simSeriesDataGrid.HighLightCurrentRow = true;
            this.simSeriesDataGrid.Location = new System.Drawing.Point(0, 20);
            this.simSeriesDataGrid.Name = "simSeriesDataGrid";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.simSeriesDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.simSeriesDataGrid.RowHeadersVisible = false;
            this.simSeriesDataGrid.RowTemplate.Height = 18;
            this.simSeriesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.simSeriesDataGrid.Size = new System.Drawing.Size(976, 73);
            this.simSeriesDataGrid.TabIndex = 0;
            this.simSeriesDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.simSeriesDataGrid_CellValueChanged);
            this.simSeriesDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.simSeriesDataGrid_CellEndEdit);
            this.simSeriesDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.simSeriesDataGrid_CellClick);
            this.simSeriesDataGrid.CurrentCellChanged += new System.EventHandler(this.simSeriesDataGrid_CurrentCellChanged);
            // 
            // simSeriesCheckedColumn
            // 
            this.simSeriesCheckedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.simSeriesCheckedColumn.HeaderText = "";
            this.simSeriesCheckedColumn.Name = "simSeriesCheckedColumn";
            this.simSeriesCheckedColumn.Width = 5;
            // 
            // simSeriesGuidColumn
            // 
            this.simSeriesGuidColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.simSeriesGuidColumn.HeaderText = "Guid";
            this.simSeriesGuidColumn.Name = "simSeriesGuidColumn";
            this.simSeriesGuidColumn.ReadOnly = true;
            this.simSeriesGuidColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.simSeriesGuidColumn.Visible = false;
            // 
            // simSeriesNameColumn
            // 
            this.simSeriesNameColumn.HeaderText = "Series Name";
            this.simSeriesNameColumn.Name = "simSeriesNameColumn";
            this.simSeriesNameColumn.Width = 75;
            // 
            // simSeriesProjectColumn
            // 
            this.simSeriesProjectColumn.HeaderText = "Project";
            this.simSeriesProjectColumn.Name = "simSeriesProjectColumn";
            this.simSeriesProjectColumn.ReadOnly = true;
            this.simSeriesProjectColumn.Width = 75;
            // 
            // simSeriesSuspensionNameColumn
            // 
            this.simSeriesSuspensionNameColumn.HeaderText = "Suspension";
            this.simSeriesSuspensionNameColumn.Name = "simSeriesSuspensionNameColumn";
            this.simSeriesSuspensionNameColumn.ReadOnly = true;
            this.simSeriesSuspensionNameColumn.Width = 150;
            // 
            // simSeriesFilterMediumColumn
            // 
            this.simSeriesFilterMediumColumn.HeaderText = "Filter Medium";
            this.simSeriesFilterMediumColumn.Name = "simSeriesFilterMediumColumn";
            this.simSeriesFilterMediumColumn.Width = 75;
            // 
            // simSeriesMachineTypeNameColumn
            // 
            this.simSeriesMachineTypeNameColumn.HeaderText = "Machine Type";
            this.simSeriesMachineTypeNameColumn.Name = "simSeriesMachineTypeNameColumn";
            this.simSeriesMachineTypeNameColumn.ReadOnly = true;
            this.simSeriesMachineTypeNameColumn.Width = 75;
            // 
            // simSeriesMachineNameColumn
            // 
            this.simSeriesMachineNameColumn.HeaderText = "Machine Name";
            this.simSeriesMachineNameColumn.Name = "simSeriesMachineNameColumn";
            this.simSeriesMachineNameColumn.Visible = false;
            this.simSeriesMachineNameColumn.Width = 75;
            // 
            // simSeriesLastModifiedDateColumn
            // 
            this.simSeriesLastModifiedDateColumn.HeaderText = "Last Modified Date";
            this.simSeriesLastModifiedDateColumn.Name = "simSeriesLastModifiedDateColumn";
            this.simSeriesLastModifiedDateColumn.ReadOnly = true;
            this.simSeriesLastModifiedDateColumn.Width = 130;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.simSeriesDeleteButton);
            this.panel3.Controls.Add(this.simSeriesRestoreButton);
            this.panel3.Controls.Add(this.simSeriesKeepButton);
            this.panel3.Controls.Add(this.simSeriesDuplicateButton);
            this.panel3.Controls.Add(this.simSeriesCreateButton);
            this.panel3.Controls.Add(this.byCheckingSimSeriesCheckBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 20);
            this.panel3.TabIndex = 7;
            // 
            // simSeriesDeleteButton
            // 
            this.simSeriesDeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simSeriesDeleteButton.FlatAppearance.BorderSize = 0;
            this.simSeriesDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simSeriesDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("simSeriesDeleteButton.Image")));
            this.simSeriesDeleteButton.Location = new System.Drawing.Point(165, 0);
            this.simSeriesDeleteButton.Name = "simSeriesDeleteButton";
            this.simSeriesDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.simSeriesDeleteButton.TabIndex = 5;
            this.simSeriesDeleteButton.Text = " ";
            this.simSeriesDeleteButton.UseVisualStyleBackColor = true;
            this.simSeriesDeleteButton.Click += new System.EventHandler(this.simSeriesDeleteButton_Click);
            // 
            // simSeriesRestoreButton
            // 
            this.simSeriesRestoreButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simSeriesRestoreButton.FlatAppearance.BorderSize = 0;
            this.simSeriesRestoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simSeriesRestoreButton.Image = ((System.Drawing.Image)(resources.GetObject("simSeriesRestoreButton.Image")));
            this.simSeriesRestoreButton.Location = new System.Drawing.Point(145, 0);
            this.simSeriesRestoreButton.Name = "simSeriesRestoreButton";
            this.simSeriesRestoreButton.Size = new System.Drawing.Size(20, 20);
            this.simSeriesRestoreButton.TabIndex = 4;
            this.simSeriesRestoreButton.Text = " ";
            this.simSeriesRestoreButton.UseVisualStyleBackColor = true;
            this.simSeriesRestoreButton.Click += new System.EventHandler(this.simSeriesRestoreButton_Click);
            // 
            // simSeriesKeepButton
            // 
            this.simSeriesKeepButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simSeriesKeepButton.FlatAppearance.BorderSize = 0;
            this.simSeriesKeepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simSeriesKeepButton.Image = ((System.Drawing.Image)(resources.GetObject("simSeriesKeepButton.Image")));
            this.simSeriesKeepButton.Location = new System.Drawing.Point(125, 0);
            this.simSeriesKeepButton.Name = "simSeriesKeepButton";
            this.simSeriesKeepButton.Size = new System.Drawing.Size(20, 20);
            this.simSeriesKeepButton.TabIndex = 3;
            this.simSeriesKeepButton.Text = " ";
            this.simSeriesKeepButton.UseVisualStyleBackColor = true;
            this.simSeriesKeepButton.Click += new System.EventHandler(this.simSeriesKeepButton_Click);
            // 
            // simSeriesDuplicateButton
            // 
            this.simSeriesDuplicateButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simSeriesDuplicateButton.FlatAppearance.BorderSize = 0;
            this.simSeriesDuplicateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simSeriesDuplicateButton.Image = global::FilterSimulation.Properties.Resources.page_white_copy;
            this.simSeriesDuplicateButton.Location = new System.Drawing.Point(105, 0);
            this.simSeriesDuplicateButton.Name = "simSeriesDuplicateButton";
            this.simSeriesDuplicateButton.Size = new System.Drawing.Size(20, 20);
            this.simSeriesDuplicateButton.TabIndex = 6;
            this.simSeriesDuplicateButton.UseVisualStyleBackColor = true;
            this.simSeriesDuplicateButton.Click += new System.EventHandler(this.duplicateSerieButton_Click);
            // 
            // simSeriesCreateButton
            // 
            this.simSeriesCreateButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simSeriesCreateButton.FlatAppearance.BorderSize = 0;
            this.simSeriesCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simSeriesCreateButton.Image = ((System.Drawing.Image)(resources.GetObject("simSeriesCreateButton.Image")));
            this.simSeriesCreateButton.Location = new System.Drawing.Point(85, 0);
            this.simSeriesCreateButton.Name = "simSeriesCreateButton";
            this.simSeriesCreateButton.Size = new System.Drawing.Size(20, 20);
            this.simSeriesCreateButton.TabIndex = 2;
            this.simSeriesCreateButton.Text = " ";
            this.simSeriesCreateButton.UseVisualStyleBackColor = true;
            this.simSeriesCreateButton.Click += new System.EventHandler(this.simSerieCreate_Click);
            // 
            // splitter3
            // 
            this.splitter3.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 81);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(980, 3);
            this.splitter3.TabIndex = 1;
            this.splitter3.TabStop = false;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.suspensionPanel);
            this.topPanel.Controls.Add(this.splitter2);
            this.topPanel.Controls.Add(this.splitter1);
            this.topPanel.Controls.Add(this.machinePanel);
            this.topPanel.Controls.Add(this.projectPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(980, 81);
            this.topPanel.TabIndex = 0;
            // 
            // suspensionPanel
            // 
            this.suspensionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.suspensionPanel.Controls.Add(this.suspensionDataGrid);
            this.suspensionPanel.Controls.Add(this.panel2);
            this.suspensionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suspensionPanel.Location = new System.Drawing.Point(173, 0);
            this.suspensionPanel.Name = "suspensionPanel";
            this.suspensionPanel.Size = new System.Drawing.Size(690, 81);
            this.suspensionPanel.TabIndex = 2;
            // 
            // suspensionDataGrid
            // 
            this.suspensionDataGrid.AllowUserToAddRows = false;
            this.suspensionDataGrid.AllowUserToResizeRows = false;
            this.suspensionDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.suspensionDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.suspensionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suspensionDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.suspensionGuidColumn,
            this.suspensionCheckedColumn,
            this.suspensionMaterialColumn,
            this.suspensionCustomerColumn,
            this.suspensionNameColumn});
            this.suspensionDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suspensionDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.suspensionDataGrid.HighLightCurrentRow = true;
            this.suspensionDataGrid.Location = new System.Drawing.Point(0, 20);
            this.suspensionDataGrid.Name = "suspensionDataGrid";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.suspensionDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.suspensionDataGrid.RowHeadersVisible = false;
            this.suspensionDataGrid.RowTemplate.Height = 18;
            this.suspensionDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.suspensionDataGrid.Size = new System.Drawing.Size(686, 57);
            this.suspensionDataGrid.TabIndex = 0;
            this.suspensionDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.suspensionDataGrid_CellValueChanged);
            this.suspensionDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.suspensionDataGrid_CellEndEdit);
            this.suspensionDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.suspensionDataGrid_CellClick);
            this.suspensionDataGrid.CurrentCellChanged += new System.EventHandler(this.suspensionDataGrid_CurrentCellChanged);
            // 
            // suspensionGuidColumn
            // 
            this.suspensionGuidColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.suspensionGuidColumn.HeaderText = "Guid";
            this.suspensionGuidColumn.Name = "suspensionGuidColumn";
            this.suspensionGuidColumn.ReadOnly = true;
            this.suspensionGuidColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.suspensionGuidColumn.Visible = false;
            // 
            // suspensionCheckedColumn
            // 
            this.suspensionCheckedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.suspensionCheckedColumn.HeaderText = "";
            this.suspensionCheckedColumn.Name = "suspensionCheckedColumn";
            this.suspensionCheckedColumn.Width = 5;
            // 
            // suspensionMaterialColumn
            // 
            this.suspensionMaterialColumn.HeaderText = "Material";
            this.suspensionMaterialColumn.Name = "suspensionMaterialColumn";
            this.suspensionMaterialColumn.Width = 70;
            // 
            // suspensionCustomerColumn
            // 
            this.suspensionCustomerColumn.HeaderText = "Customer";
            this.suspensionCustomerColumn.Name = "suspensionCustomerColumn";
            this.suspensionCustomerColumn.Width = 70;
            // 
            // suspensionNameColumn
            // 
            this.suspensionNameColumn.HeaderText = "Suspension Name";
            this.suspensionNameColumn.Name = "suspensionNameColumn";
            this.suspensionNameColumn.Width = 120;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.suspensionDeleteButton);
            this.panel2.Controls.Add(this.suspensionRestoreButton);
            this.panel2.Controls.Add(this.suspensionKeepButton);
            this.panel2.Controls.Add(this.suspensionCreateButton);
            this.panel2.Controls.Add(this.byCheckingSuspensionsCheckBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 20);
            this.panel2.TabIndex = 6;
            // 
            // suspensionDeleteButton
            // 
            this.suspensionDeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.suspensionDeleteButton.FlatAppearance.BorderSize = 0;
            this.suspensionDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suspensionDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("suspensionDeleteButton.Image")));
            this.suspensionDeleteButton.Location = new System.Drawing.Point(145, 0);
            this.suspensionDeleteButton.Name = "suspensionDeleteButton";
            this.suspensionDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.suspensionDeleteButton.TabIndex = 5;
            this.suspensionDeleteButton.Text = " ";
            this.suspensionDeleteButton.UseVisualStyleBackColor = true;
            this.suspensionDeleteButton.Click += new System.EventHandler(this.suspensionDeleteButton_Click);
            // 
            // suspensionRestoreButton
            // 
            this.suspensionRestoreButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.suspensionRestoreButton.FlatAppearance.BorderSize = 0;
            this.suspensionRestoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suspensionRestoreButton.Image = ((System.Drawing.Image)(resources.GetObject("suspensionRestoreButton.Image")));
            this.suspensionRestoreButton.Location = new System.Drawing.Point(125, 0);
            this.suspensionRestoreButton.Name = "suspensionRestoreButton";
            this.suspensionRestoreButton.Size = new System.Drawing.Size(20, 20);
            this.suspensionRestoreButton.TabIndex = 4;
            this.suspensionRestoreButton.Text = " ";
            this.suspensionRestoreButton.UseVisualStyleBackColor = true;
            this.suspensionRestoreButton.Click += new System.EventHandler(this.suspensionRestoreButton_Click);
            // 
            // suspensionKeepButton
            // 
            this.suspensionKeepButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.suspensionKeepButton.FlatAppearance.BorderSize = 0;
            this.suspensionKeepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suspensionKeepButton.Image = ((System.Drawing.Image)(resources.GetObject("suspensionKeepButton.Image")));
            this.suspensionKeepButton.Location = new System.Drawing.Point(105, 0);
            this.suspensionKeepButton.Name = "suspensionKeepButton";
            this.suspensionKeepButton.Size = new System.Drawing.Size(20, 20);
            this.suspensionKeepButton.TabIndex = 3;
            this.suspensionKeepButton.Text = " ";
            this.suspensionKeepButton.UseVisualStyleBackColor = true;
            this.suspensionKeepButton.Click += new System.EventHandler(this.keepSuspensionButton_Click);
            // 
            // suspensionCreateButton
            // 
            this.suspensionCreateButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.suspensionCreateButton.FlatAppearance.BorderSize = 0;
            this.suspensionCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.suspensionCreateButton.Image = ((System.Drawing.Image)(resources.GetObject("suspensionCreateButton.Image")));
            this.suspensionCreateButton.Location = new System.Drawing.Point(85, 0);
            this.suspensionCreateButton.Name = "suspensionCreateButton";
            this.suspensionCreateButton.Size = new System.Drawing.Size(20, 20);
            this.suspensionCreateButton.TabIndex = 2;
            this.suspensionCreateButton.Text = " ";
            this.suspensionCreateButton.UseVisualStyleBackColor = true;
            this.suspensionCreateButton.Click += new System.EventHandler(this.suspensionCreateButton_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(863, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 81);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(170, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 81);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // machinePanel
            // 
            this.machinePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.machinePanel.Controls.Add(this.machineTypesDataGrid);
            this.machinePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.machinePanel.Location = new System.Drawing.Point(866, 0);
            this.machinePanel.Name = "machinePanel";
            this.machinePanel.Size = new System.Drawing.Size(114, 81);
            this.machinePanel.TabIndex = 3;
            this.machinePanel.Resize += new System.EventHandler(this.machinePanel_Resize);
            // 
            // machineTypesDataGrid
            // 
            this.machineTypesDataGrid.AllowUserToAddRows = false;
            this.machineTypesDataGrid.AllowUserToDeleteRows = false;
            this.machineTypesDataGrid.AllowUserToResizeRows = false;
            this.machineTypesDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.machineTypesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.machineTypesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.machineTypesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.machineTypeCheckedColumn,
            this.machineTypeSymbolColumn,
            this.machineTypeNameColumn});
            this.machineTypesDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.machineTypesDataGrid.HighLightCurrentRow = false;
            this.machineTypesDataGrid.Location = new System.Drawing.Point(-1, 20);
            this.machineTypesDataGrid.Name = "machineTypesDataGrid";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.machineTypesDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.machineTypesDataGrid.RowHeadersVisible = false;
            this.machineTypesDataGrid.RowTemplate.Height = 18;
            this.machineTypesDataGrid.Size = new System.Drawing.Size(113, 56);
            this.machineTypesDataGrid.TabIndex = 2;
            // 
            // machineTypeCheckedColumn
            // 
            this.machineTypeCheckedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.machineTypeCheckedColumn.HeaderText = "";
            this.machineTypeCheckedColumn.Name = "machineTypeCheckedColumn";
            this.machineTypeCheckedColumn.Width = 5;
            // 
            // machineTypeSymbolColumn
            // 
            this.machineTypeSymbolColumn.HeaderText = "Machine Type Symbol";
            this.machineTypeSymbolColumn.Name = "machineTypeSymbolColumn";
            this.machineTypeSymbolColumn.Visible = false;
            // 
            // machineTypeNameColumn
            // 
            this.machineTypeNameColumn.HeaderText = "Machine Type";
            this.machineTypeNameColumn.Name = "machineTypeNameColumn";
            this.machineTypeNameColumn.ReadOnly = true;
            // 
            // projectPanel
            // 
            this.projectPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.projectPanel.Controls.Add(this.projectDataGrid);
            this.projectPanel.Controls.Add(this.panel1);
            this.projectPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.projectPanel.Location = new System.Drawing.Point(0, 0);
            this.projectPanel.Name = "projectPanel";
            this.projectPanel.Size = new System.Drawing.Size(170, 81);
            this.projectPanel.TabIndex = 0;
            // 
            // projectDataGrid
            // 
            this.projectDataGrid.AllowUserToAddRows = false;
            this.projectDataGrid.AllowUserToResizeRows = false;
            this.projectDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.projectDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.projectDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.projectGuidColumn,
            this.projectCheckedColumn,
            this.projectNameColumn});
            this.projectDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.projectDataGrid.HighLightCurrentRow = true;
            this.projectDataGrid.Location = new System.Drawing.Point(0, 20);
            this.projectDataGrid.Name = "projectDataGrid";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.projectDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.projectDataGrid.RowHeadersVisible = false;
            this.projectDataGrid.RowTemplate.Height = 18;
            this.projectDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.projectDataGrid.Size = new System.Drawing.Size(166, 57);
            this.projectDataGrid.TabIndex = 0;
            this.projectDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectDataGrid_CellValueChanged);
            this.projectDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectDataGrid_CellEndEdit);
            this.projectDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectDataGrid_CellClick);
            this.projectDataGrid.CurrentCellChanged += new System.EventHandler(this.projectDataGrid_CurrentCellChanged);
            // 
            // projectGuidColumn
            // 
            this.projectGuidColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.projectGuidColumn.HeaderText = "Guid";
            this.projectGuidColumn.Name = "projectGuidColumn";
            this.projectGuidColumn.ReadOnly = true;
            this.projectGuidColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.projectGuidColumn.Visible = false;
            // 
            // projectCheckedColumn
            // 
            this.projectCheckedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.projectCheckedColumn.HeaderText = "";
            this.projectCheckedColumn.Name = "projectCheckedColumn";
            this.projectCheckedColumn.Width = 5;
            // 
            // projectNameColumn
            // 
            this.projectNameColumn.HeaderText = "Project Name";
            this.projectNameColumn.Name = "projectNameColumn";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.projectDeleteButton);
            this.panel1.Controls.Add(this.projectRestoreButton);
            this.panel1.Controls.Add(this.projectKeepButton);
            this.panel1.Controls.Add(this.projectCreateButton);
            this.panel1.Controls.Add(this.byCheckingProjectsCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 20);
            this.panel1.TabIndex = 6;
            // 
            // projectDeleteButton
            // 
            this.projectDeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.projectDeleteButton.FlatAppearance.BorderSize = 0;
            this.projectDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("projectDeleteButton.Image")));
            this.projectDeleteButton.Location = new System.Drawing.Point(145, 0);
            this.projectDeleteButton.Name = "projectDeleteButton";
            this.projectDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.projectDeleteButton.TabIndex = 5;
            this.projectDeleteButton.UseVisualStyleBackColor = true;
            this.projectDeleteButton.Click += new System.EventHandler(this.projectDelete_Click);
            // 
            // projectRestoreButton
            // 
            this.projectRestoreButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.projectRestoreButton.FlatAppearance.BorderSize = 0;
            this.projectRestoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectRestoreButton.Image = ((System.Drawing.Image)(resources.GetObject("projectRestoreButton.Image")));
            this.projectRestoreButton.Location = new System.Drawing.Point(125, 0);
            this.projectRestoreButton.Name = "projectRestoreButton";
            this.projectRestoreButton.Size = new System.Drawing.Size(20, 20);
            this.projectRestoreButton.TabIndex = 3;
            this.projectRestoreButton.UseVisualStyleBackColor = true;
            this.projectRestoreButton.Click += new System.EventHandler(this.projectRestore_Click);
            // 
            // projectKeepButton
            // 
            this.projectKeepButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.projectKeepButton.FlatAppearance.BorderSize = 0;
            this.projectKeepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectKeepButton.Image = ((System.Drawing.Image)(resources.GetObject("projectKeepButton.Image")));
            this.projectKeepButton.Location = new System.Drawing.Point(105, 0);
            this.projectKeepButton.Name = "projectKeepButton";
            this.projectKeepButton.Size = new System.Drawing.Size(20, 20);
            this.projectKeepButton.TabIndex = 2;
            this.projectKeepButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.projectKeepButton.UseVisualStyleBackColor = true;
            this.projectKeepButton.Click += new System.EventHandler(this.keepProject_Click);
            // 
            // projectCreateButton
            // 
            this.projectCreateButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.projectCreateButton.FlatAppearance.BorderSize = 0;
            this.projectCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectCreateButton.Image = ((System.Drawing.Image)(resources.GetObject("projectCreateButton.Image")));
            this.projectCreateButton.Location = new System.Drawing.Point(85, 0);
            this.projectCreateButton.Name = "projectCreateButton";
            this.projectCreateButton.Size = new System.Drawing.Size(20, 20);
            this.projectCreateButton.TabIndex = 1;
            this.projectCreateButton.Tag = "";
            this.projectCreateButton.UseVisualStyleBackColor = true;
            this.projectCreateButton.Click += new System.EventHandler(this.projectCreateButton_Click);
            // 
            // simulationPanel
            // 
            this.simulationPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.simulationPanel.Controls.Add(this.simulationDataGrid);
            this.simulationPanel.Controls.Add(this.panel5);
            this.simulationPanel.Controls.Add(this.button4);
            this.simulationPanel.Controls.Add(this.button3);
            this.simulationPanel.Controls.Add(this.button2);
            this.simulationPanel.Controls.Add(this.button1);
            this.simulationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulationPanel.Location = new System.Drawing.Point(0, 435);
            this.simulationPanel.Name = "simulationPanel";
            this.simulationPanel.Size = new System.Drawing.Size(980, 180);
            this.simulationPanel.TabIndex = 9;
            // 
            // simulationDataGrid
            // 
            this.simulationDataGrid.AllowUserToAddRows = false;
            this.simulationDataGrid.AllowUserToOrderColumns = true;
            this.simulationDataGrid.AllowUserToResizeRows = false;
            this.simulationDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.simulationDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.simulationDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simulationDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.simulationGuidColumn,
            this.simulationCheckedColumn,
            this.simulationProjectColumn,
            this.simulationSuspensionNameColumn,
            this.simulationFilterMediumColumn,
            this.simulationMachineTypeColumn,
            this.simulationMachineNameColumn,
            this.simulationSimSeriesNameColumn,
            this.simulationNameColumn,
            this.simulationFilterAreaColumn,
            this.simulationFilterDiameterColumn,
            this.simulation_DpColumn,
            this.simulation_sfColumn,
            this.simulation_srColumn,
            this.simulation_nColumn,
            this.simulation_tcColumn,
            this.simulation_tfColumn,
            this.simulation_trColumn,
            this.simulation_hc_over_tfColumn,
            this.simulation_dhc_over_dtColumn,
            this.simulation_hcColumn,
            this.simulation_MfColumn,
            this.simulation_VfColumn,
            this.simulation_MsusColumn,
            this.simulation_VsusColumn,
            this.simulation_MsColumn,
            this.simulation_VsColumn,
            this.simulation_McColumn,
            this.simulation_VcColumn,
            this.simulation_mf_Column,
            this.simulation_vf_Column,
            this.simulation_msus_Column,
            this.simulation_vsus_Column,
            this.simulation_ms_Column,
            this.simulation_vs_Column,
            this.simulation_mc_Column,
            this.simulation_vc_Column,
            this.simulation_QsusColumn,
            this.simulation_Qsus_dColumn,
            this.simulation_QmsusColumn,
            this.simulation_Qmsus_dColumn,
            this.simulation_QmsColumn,
            this.simulation_Qms_dColumn,
            this.simulation_QmfColumn,
            this.simulation_Qmf_dColumn,
            this.simulation_QmcColumn,
            this.simulation_Qmc_dColumn,
            this.simulation_QfColumn,
            this.simulation_Qf_dColumn,
            this.simulation_QsColumn,
            this.simulation_Qs_dColumn,
            this.simulation_QcColumn,
            this.simulation_Qc_dColumn,
            this.simulation_qf_Column,
            this.simulation_qf_d_Column,
            this.simulation_qsus_Column,
            this.simulation_qsus_d_Column,
            this.simulation_qs_Column,
            this.simulation_qs_d_Column,
            this.simulation_qc_Column,
            this.simulation_qc_d_Column,
            this.simulation_qmf_Column,
            this.simulation_qmf_d_Column,
            this.simulation_qmsus_Column,
            this.simulation_qmsus_d_Column,
            this.simulation_qms_Column,
            this.simulation_qms_d_Column,
            this.simulation_qmc_Column,
            this.simulation_qmc_d_Column,
            this.simulation_epsColumn,
            this.simulation_kappaColumn,
            this.simulation_PcColumn,
            this.simulation_rcColumn,
            this.simulation_aColumn});
            this.simulationDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulationDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.simulationDataGrid.HighLightCurrentRow = true;
            this.simulationDataGrid.Location = new System.Drawing.Point(0, 20);
            this.simulationDataGrid.Name = "simulationDataGrid";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.simulationDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.simulationDataGrid.RowHeadersVisible = false;
            this.simulationDataGrid.RowTemplate.Height = 18;
            this.simulationDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.simulationDataGrid.Size = new System.Drawing.Size(976, 156);
            this.simulationDataGrid.TabIndex = 0;
            this.simulationDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.simulationDataGrid_CellValueChanged);
            this.simulationDataGrid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.simulationDataGrid_SortCompare);
            this.simulationDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.simulationDataGrid_CellEndEdit);
            this.simulationDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.simulationDataGrid_CellClick);
            this.simulationDataGrid.CurrentCellChanged += new System.EventHandler(this.simulationDataGrid_CurrentCellChanged);
            // 
            // simulationGuidColumn
            // 
            this.simulationGuidColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.simulationGuidColumn.HeaderText = "Guid";
            this.simulationGuidColumn.Name = "simulationGuidColumn";
            this.simulationGuidColumn.ReadOnly = true;
            this.simulationGuidColumn.Visible = false;
            // 
            // simulationCheckedColumn
            // 
            this.simulationCheckedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.simulationCheckedColumn.HeaderText = "";
            this.simulationCheckedColumn.MinimumWidth = 20;
            this.simulationCheckedColumn.Name = "simulationCheckedColumn";
            this.simulationCheckedColumn.Width = 20;
            // 
            // simulationProjectColumn
            // 
            this.simulationProjectColumn.HeaderText = "Project";
            this.simulationProjectColumn.Name = "simulationProjectColumn";
            this.simulationProjectColumn.ReadOnly = true;
            // 
            // simulationSuspensionNameColumn
            // 
            this.simulationSuspensionNameColumn.HeaderText = "Suspension";
            this.simulationSuspensionNameColumn.Name = "simulationSuspensionNameColumn";
            this.simulationSuspensionNameColumn.ReadOnly = true;
            this.simulationSuspensionNameColumn.Width = 150;
            // 
            // simulationFilterMediumColumn
            // 
            this.simulationFilterMediumColumn.HeaderText = "Filter Medium";
            this.simulationFilterMediumColumn.Name = "simulationFilterMediumColumn";
            this.simulationFilterMediumColumn.ReadOnly = true;
            // 
            // simulationMachineTypeColumn
            // 
            this.simulationMachineTypeColumn.HeaderText = "Machine Type";
            this.simulationMachineTypeColumn.Name = "simulationMachineTypeColumn";
            this.simulationMachineTypeColumn.ReadOnly = true;
            // 
            // simulationMachineNameColumn
            // 
            this.simulationMachineNameColumn.HeaderText = "Machine Name";
            this.simulationMachineNameColumn.Name = "simulationMachineNameColumn";
            this.simulationMachineNameColumn.ReadOnly = true;
            // 
            // simulationSimSeriesNameColumn
            // 
            this.simulationSimSeriesNameColumn.HeaderText = "SimSeries";
            this.simulationSimSeriesNameColumn.Name = "simulationSimSeriesNameColumn";
            this.simulationSimSeriesNameColumn.ReadOnly = true;
            // 
            // simulationNameColumn
            // 
            this.simulationNameColumn.HeaderText = "Simulation Name";
            this.simulationNameColumn.Name = "simulationNameColumn";
            // 
            // simulationFilterAreaColumn
            // 
            this.simulationFilterAreaColumn.HeaderText = "Filter Area";
            this.simulationFilterAreaColumn.Name = "simulationFilterAreaColumn";
            this.simulationFilterAreaColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulationFilterDiameterColumn
            // 
            this.simulationFilterDiameterColumn.HeaderText = "d0";
            this.simulationFilterDiameterColumn.Name = "simulationFilterDiameterColumn";
            this.simulationFilterDiameterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_DpColumn
            // 
            this.simulation_DpColumn.HeaderText = "Dp";
            this.simulation_DpColumn.Name = "simulation_DpColumn";
            this.simulation_DpColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_sfColumn
            // 
            this.simulation_sfColumn.HeaderText = "sf";
            this.simulation_sfColumn.Name = "simulation_sfColumn";
            this.simulation_sfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_srColumn
            // 
            this.simulation_srColumn.HeaderText = "sr";
            this.simulation_srColumn.Name = "simulation_srColumn";
            this.simulation_srColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_nColumn
            // 
            this.simulation_nColumn.HeaderText = "n";
            this.simulation_nColumn.Name = "simulation_nColumn";
            this.simulation_nColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_tcColumn
            // 
            this.simulation_tcColumn.HeaderText = "tc";
            this.simulation_tcColumn.Name = "simulation_tcColumn";
            this.simulation_tcColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_tfColumn
            // 
            this.simulation_tfColumn.HeaderText = "tf";
            this.simulation_tfColumn.Name = "simulation_tfColumn";
            this.simulation_tfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_trColumn
            // 
            this.simulation_trColumn.HeaderText = "tr";
            this.simulation_trColumn.Name = "simulation_trColumn";
            this.simulation_trColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_hc_over_tfColumn
            // 
            this.simulation_hc_over_tfColumn.HeaderText = "hc/tf";
            this.simulation_hc_over_tfColumn.Name = "simulation_hc_over_tfColumn";
            this.simulation_hc_over_tfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_dhc_over_dtColumn
            // 
            this.simulation_dhc_over_dtColumn.HeaderText = "dhc/dt";
            this.simulation_dhc_over_dtColumn.Name = "simulation_dhc_over_dtColumn";
            this.simulation_dhc_over_dtColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_hcColumn
            // 
            this.simulation_hcColumn.HeaderText = "hc";
            this.simulation_hcColumn.Name = "simulation_hcColumn";
            this.simulation_hcColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_MfColumn
            // 
            this.simulation_MfColumn.HeaderText = "Mf";
            this.simulation_MfColumn.Name = "simulation_MfColumn";
            this.simulation_MfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_VfColumn
            // 
            this.simulation_VfColumn.HeaderText = "Vf";
            this.simulation_VfColumn.Name = "simulation_VfColumn";
            // 
            // simulation_MsusColumn
            // 
            this.simulation_MsusColumn.HeaderText = "Msus";
            this.simulation_MsusColumn.Name = "simulation_MsusColumn";
            this.simulation_MsusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_VsusColumn
            // 
            this.simulation_VsusColumn.HeaderText = "Vsus";
            this.simulation_VsusColumn.Name = "simulation_VsusColumn";
            this.simulation_VsusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_MsColumn
            // 
            this.simulation_MsColumn.HeaderText = "Ms";
            this.simulation_MsColumn.Name = "simulation_MsColumn";
            this.simulation_MsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_VsColumn
            // 
            this.simulation_VsColumn.HeaderText = "Vs";
            this.simulation_VsColumn.Name = "simulation_VsColumn";
            this.simulation_VsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_McColumn
            // 
            this.simulation_McColumn.HeaderText = "Mc";
            this.simulation_McColumn.Name = "simulation_McColumn";
            this.simulation_McColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_VcColumn
            // 
            this.simulation_VcColumn.HeaderText = "Vc";
            this.simulation_VcColumn.Name = "simulation_VcColumn";
            this.simulation_VcColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_mf_Column
            // 
            this.simulation_mf_Column.HeaderText = "mf";
            this.simulation_mf_Column.Name = "simulation_mf_Column";
            // 
            // simulation_vf_Column
            // 
            this.simulation_vf_Column.HeaderText = "vf";
            this.simulation_vf_Column.Name = "simulation_vf_Column";
            // 
            // simulation_msus_Column
            // 
            this.simulation_msus_Column.HeaderText = "msus";
            this.simulation_msus_Column.Name = "simulation_msus_Column";
            // 
            // simulation_vsus_Column
            // 
            this.simulation_vsus_Column.HeaderText = "vsus";
            this.simulation_vsus_Column.Name = "simulation_vsus_Column";
            // 
            // simulation_ms_Column
            // 
            this.simulation_ms_Column.HeaderText = "ms";
            this.simulation_ms_Column.Name = "simulation_ms_Column";
            // 
            // simulation_vs_Column
            // 
            this.simulation_vs_Column.HeaderText = "vs";
            this.simulation_vs_Column.Name = "simulation_vs_Column";
            // 
            // simulation_mc_Column
            // 
            this.simulation_mc_Column.HeaderText = "mc";
            this.simulation_mc_Column.Name = "simulation_mc_Column";
            // 
            // simulation_vc_Column
            // 
            this.simulation_vc_Column.HeaderText = "vc";
            this.simulation_vc_Column.Name = "simulation_vc_Column";
            // 
            // simulation_QsusColumn
            // 
            this.simulation_QsusColumn.HeaderText = "Qsus";
            this.simulation_QsusColumn.Name = "simulation_QsusColumn";
            this.simulation_QsusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_Qsus_dColumn
            // 
            this.simulation_Qsus_dColumn.HeaderText = "Qsus,d";
            this.simulation_Qsus_dColumn.Name = "simulation_Qsus_dColumn";
            this.simulation_Qsus_dColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_QmsusColumn
            // 
            this.simulation_QmsusColumn.HeaderText = "Qmsus";
            this.simulation_QmsusColumn.Name = "simulation_QmsusColumn";
            this.simulation_QmsusColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_Qmsus_dColumn
            // 
            this.simulation_Qmsus_dColumn.HeaderText = "Qmsus,d";
            this.simulation_Qmsus_dColumn.Name = "simulation_Qmsus_dColumn";
            this.simulation_Qmsus_dColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_QmsColumn
            // 
            this.simulation_QmsColumn.HeaderText = "Qms";
            this.simulation_QmsColumn.Name = "simulation_QmsColumn";
            this.simulation_QmsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_Qms_dColumn
            // 
            this.simulation_Qms_dColumn.HeaderText = "Qms,d";
            this.simulation_Qms_dColumn.Name = "simulation_Qms_dColumn";
            this.simulation_Qms_dColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_QmfColumn
            // 
            this.simulation_QmfColumn.HeaderText = "Qmf";
            this.simulation_QmfColumn.Name = "simulation_QmfColumn";
            this.simulation_QmfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_Qmf_dColumn
            // 
            this.simulation_Qmf_dColumn.HeaderText = "Qmf,d";
            this.simulation_Qmf_dColumn.Name = "simulation_Qmf_dColumn";
            this.simulation_Qmf_dColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_QmcColumn
            // 
            this.simulation_QmcColumn.HeaderText = "Qmc";
            this.simulation_QmcColumn.Name = "simulation_QmcColumn";
            this.simulation_QmcColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_Qmc_dColumn
            // 
            this.simulation_Qmc_dColumn.HeaderText = "Qmc,d";
            this.simulation_Qmc_dColumn.Name = "simulation_Qmc_dColumn";
            this.simulation_Qmc_dColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_QfColumn
            // 
            this.simulation_QfColumn.HeaderText = "Qf";
            this.simulation_QfColumn.Name = "simulation_QfColumn";
            this.simulation_QfColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_Qf_dColumn
            // 
            this.simulation_Qf_dColumn.HeaderText = "Qf,d";
            this.simulation_Qf_dColumn.Name = "simulation_Qf_dColumn";
            this.simulation_Qf_dColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_QsColumn
            // 
            this.simulation_QsColumn.HeaderText = "Qs";
            this.simulation_QsColumn.Name = "simulation_QsColumn";
            this.simulation_QsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_Qs_dColumn
            // 
            this.simulation_Qs_dColumn.HeaderText = "Qs,d";
            this.simulation_Qs_dColumn.Name = "simulation_Qs_dColumn";
            this.simulation_Qs_dColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_QcColumn
            // 
            this.simulation_QcColumn.HeaderText = "Qc";
            this.simulation_QcColumn.Name = "simulation_QcColumn";
            this.simulation_QcColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_Qc_dColumn
            // 
            this.simulation_Qc_dColumn.HeaderText = "Qc,d";
            this.simulation_Qc_dColumn.Name = "simulation_Qc_dColumn";
            this.simulation_Qc_dColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qf_Column
            // 
            this.simulation_qf_Column.HeaderText = "qf";
            this.simulation_qf_Column.Name = "simulation_qf_Column";
            this.simulation_qf_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qf_d_Column
            // 
            this.simulation_qf_d_Column.HeaderText = "qf,d";
            this.simulation_qf_d_Column.Name = "simulation_qf_d_Column";
            this.simulation_qf_d_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qsus_Column
            // 
            this.simulation_qsus_Column.HeaderText = "qsus";
            this.simulation_qsus_Column.Name = "simulation_qsus_Column";
            this.simulation_qsus_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qsus_d_Column
            // 
            this.simulation_qsus_d_Column.HeaderText = "qsus,d";
            this.simulation_qsus_d_Column.Name = "simulation_qsus_d_Column";
            this.simulation_qsus_d_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qs_Column
            // 
            this.simulation_qs_Column.HeaderText = "qs";
            this.simulation_qs_Column.Name = "simulation_qs_Column";
            this.simulation_qs_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qs_d_Column
            // 
            this.simulation_qs_d_Column.HeaderText = "qs,d";
            this.simulation_qs_d_Column.Name = "simulation_qs_d_Column";
            this.simulation_qs_d_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qc_Column
            // 
            this.simulation_qc_Column.HeaderText = "qc";
            this.simulation_qc_Column.Name = "simulation_qc_Column";
            this.simulation_qc_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qc_d_Column
            // 
            this.simulation_qc_d_Column.HeaderText = "qc,d";
            this.simulation_qc_d_Column.Name = "simulation_qc_d_Column";
            this.simulation_qc_d_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qmf_Column
            // 
            this.simulation_qmf_Column.HeaderText = "qmf";
            this.simulation_qmf_Column.Name = "simulation_qmf_Column";
            this.simulation_qmf_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qmf_d_Column
            // 
            this.simulation_qmf_d_Column.HeaderText = "qmf,d";
            this.simulation_qmf_d_Column.Name = "simulation_qmf_d_Column";
            this.simulation_qmf_d_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qmsus_Column
            // 
            this.simulation_qmsus_Column.HeaderText = "qmsus";
            this.simulation_qmsus_Column.Name = "simulation_qmsus_Column";
            this.simulation_qmsus_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qmsus_d_Column
            // 
            this.simulation_qmsus_d_Column.HeaderText = "qmsus,d";
            this.simulation_qmsus_d_Column.Name = "simulation_qmsus_d_Column";
            this.simulation_qmsus_d_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qms_Column
            // 
            this.simulation_qms_Column.HeaderText = "qms";
            this.simulation_qms_Column.Name = "simulation_qms_Column";
            this.simulation_qms_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qms_d_Column
            // 
            this.simulation_qms_d_Column.HeaderText = "qms,d";
            this.simulation_qms_d_Column.Name = "simulation_qms_d_Column";
            this.simulation_qms_d_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qmc_Column
            // 
            this.simulation_qmc_Column.HeaderText = "qmc";
            this.simulation_qmc_Column.Name = "simulation_qmc_Column";
            this.simulation_qmc_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_qmc_d_Column
            // 
            this.simulation_qmc_d_Column.HeaderText = "qmc,d";
            this.simulation_qmc_d_Column.Name = "simulation_qmc_d_Column";
            this.simulation_qmc_d_Column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_epsColumn
            // 
            this.simulation_epsColumn.HeaderText = "eps";
            this.simulation_epsColumn.Name = "simulation_epsColumn";
            this.simulation_epsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_kappaColumn
            // 
            this.simulation_kappaColumn.HeaderText = "kappa";
            this.simulation_kappaColumn.Name = "simulation_kappaColumn";
            this.simulation_kappaColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_PcColumn
            // 
            this.simulation_PcColumn.HeaderText = "Pc";
            this.simulation_PcColumn.Name = "simulation_PcColumn";
            this.simulation_PcColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_rcColumn
            // 
            this.simulation_rcColumn.HeaderText = "rc";
            this.simulation_rcColumn.Name = "simulation_rcColumn";
            this.simulation_rcColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // simulation_aColumn
            // 
            this.simulation_aColumn.HeaderText = "a";
            this.simulation_aColumn.Name = "simulation_aColumn";
            this.simulation_aColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.simulationDeleteButton);
            this.panel5.Controls.Add(this.simulationRestoreButton);
            this.panel5.Controls.Add(this.simulationKeepButton);
            this.panel5.Controls.Add(this.simulationDuplicateButton);
            this.panel5.Controls.Add(this.simulationCreateButton);
            this.panel5.Controls.Add(this.byCheckingSimulationsCheckBox);
            this.panel5.Controls.Add(this.fullSimulationInfoCheckBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(976, 20);
            this.panel5.TabIndex = 11;
            // 
            // simulationDeleteButton
            // 
            this.simulationDeleteButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simulationDeleteButton.FlatAppearance.BorderSize = 0;
            this.simulationDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simulationDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("simulationDeleteButton.Image")));
            this.simulationDeleteButton.Location = new System.Drawing.Point(228, 0);
            this.simulationDeleteButton.Name = "simulationDeleteButton";
            this.simulationDeleteButton.Size = new System.Drawing.Size(20, 20);
            this.simulationDeleteButton.TabIndex = 10;
            this.simulationDeleteButton.Text = " ";
            this.simulationDeleteButton.UseVisualStyleBackColor = true;
            this.simulationDeleteButton.Click += new System.EventHandler(this.simulationDeleteButton_Click);
            // 
            // simulationRestoreButton
            // 
            this.simulationRestoreButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simulationRestoreButton.FlatAppearance.BorderSize = 0;
            this.simulationRestoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simulationRestoreButton.Image = ((System.Drawing.Image)(resources.GetObject("simulationRestoreButton.Image")));
            this.simulationRestoreButton.Location = new System.Drawing.Point(208, 0);
            this.simulationRestoreButton.Name = "simulationRestoreButton";
            this.simulationRestoreButton.Size = new System.Drawing.Size(20, 20);
            this.simulationRestoreButton.TabIndex = 9;
            this.simulationRestoreButton.Text = " ";
            this.simulationRestoreButton.UseVisualStyleBackColor = true;
            this.simulationRestoreButton.Click += new System.EventHandler(this.simulationRestoreButton_Click);
            // 
            // simulationKeepButton
            // 
            this.simulationKeepButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simulationKeepButton.FlatAppearance.BorderSize = 0;
            this.simulationKeepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simulationKeepButton.Image = ((System.Drawing.Image)(resources.GetObject("simulationKeepButton.Image")));
            this.simulationKeepButton.Location = new System.Drawing.Point(188, 0);
            this.simulationKeepButton.Name = "simulationKeepButton";
            this.simulationKeepButton.Size = new System.Drawing.Size(20, 20);
            this.simulationKeepButton.TabIndex = 8;
            this.simulationKeepButton.Text = " ";
            this.simulationKeepButton.UseVisualStyleBackColor = true;
            this.simulationKeepButton.Click += new System.EventHandler(this.simulationKeepButton_Click);
            // 
            // simulationDuplicateButton
            // 
            this.simulationDuplicateButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simulationDuplicateButton.FlatAppearance.BorderSize = 0;
            this.simulationDuplicateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simulationDuplicateButton.Image = global::FilterSimulation.Properties.Resources.page_white_copy;
            this.simulationDuplicateButton.Location = new System.Drawing.Point(168, 0);
            this.simulationDuplicateButton.Name = "simulationDuplicateButton";
            this.simulationDuplicateButton.Size = new System.Drawing.Size(20, 20);
            this.simulationDuplicateButton.TabIndex = 7;
            this.simulationDuplicateButton.Text = " ";
            this.simulationDuplicateButton.UseVisualStyleBackColor = true;
            this.simulationDuplicateButton.Click += new System.EventHandler(this.simulationDuplicateButton_Click);
            // 
            // simulationCreateButton
            // 
            this.simulationCreateButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.simulationCreateButton.FlatAppearance.BorderSize = 0;
            this.simulationCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.simulationCreateButton.Image = global::FilterSimulation.Properties.Resources.page_white;
            this.simulationCreateButton.Location = new System.Drawing.Point(148, 0);
            this.simulationCreateButton.Name = "simulationCreateButton";
            this.simulationCreateButton.Size = new System.Drawing.Size(20, 20);
            this.simulationCreateButton.TabIndex = 11;
            this.simulationCreateButton.UseVisualStyleBackColor = true;
            this.simulationCreateButton.Click += new System.EventHandler(this.simulationCreateButton_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(500, -437);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 5;
            this.button4.Text = " ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.suspensionDeleteButton_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(424, -438);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(20, 20);
            this.button3.TabIndex = 3;
            this.button3.Text = " ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.keepSuspensionButton_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(462, -438);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = " ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.suspensionRestoreButton_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(386, -438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = " ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.suspensionCreateButton_Click);
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 432);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(980, 0);
            this.panelRight.TabIndex = 8;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelRight);
            this.panelTop.Controls.Add(this.panelLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(980, 432);
            this.panelTop.TabIndex = 34;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.simulationPanel);
            this.panelMain.Controls.Add(this.splitter5);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(980, 615);
            this.panelMain.TabIndex = 35;
            // 
            // splitter5
            // 
            this.splitter5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter5.Location = new System.Drawing.Point(0, 432);
            this.splitter5.Name = "splitter5";
            this.splitter5.Size = new System.Drawing.Size(980, 3);
            this.splitter5.TabIndex = 35;
            this.splitter5.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "Guid";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Project Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.HeaderText = "Guid";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Material";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Suspension Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 160;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Machine Type Symbol";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Machine Type Name";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn9.HeaderText = "Guid";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Series Name";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Machine Name";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Filter Medium";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Last Modified Date";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn14.HeaderText = "Guid";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Simulation Name";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "SimSeries";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Suspension";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Filter Medium";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Visible = false;
            // 
            // commonDeliquoringSimulationBlockDataGrid
            // 
            this.commonDeliquoringSimulationBlockDataGrid.AllowUserToAddRows = false;
            this.commonDeliquoringSimulationBlockDataGrid.AllowUserToDeleteRows = false;
            this.commonDeliquoringSimulationBlockDataGrid.AllowUserToResizeRows = false;
            this.commonDeliquoringSimulationBlockDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.commonDeliquoringSimulationBlockDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commonDeliquoringSimulationBlockDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commonDeliquoringSimulationBlockDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commonDeliquoringSimulationBlockParameterNameColumn,
            this.commonDeliquoringSimulationBlockUnitColumn,
            this.commonDeliquoringSimulationBlockParameterValueColumn});
            this.commonDeliquoringSimulationBlockDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonDeliquoringSimulationBlockDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.commonDeliquoringSimulationBlockDataGrid.HighLightCurrentRow = false;
            this.commonDeliquoringSimulationBlockDataGrid.Location = new System.Drawing.Point(702, 0);
            this.commonDeliquoringSimulationBlockDataGrid.Name = "commonDeliquoringSimulationBlockDataGrid";
            this.commonDeliquoringSimulationBlockDataGrid.RowHeadersVisible = false;
            this.commonDeliquoringSimulationBlockDataGrid.RowTemplate.Height = 18;
            this.commonDeliquoringSimulationBlockDataGrid.Size = new System.Drawing.Size(292, 244);
            this.commonDeliquoringSimulationBlockDataGrid.TabIndex = 17;
            // 
            // commonDeliquoringSimulationBlockParameterNameColumn
            // 
            this.commonDeliquoringSimulationBlockParameterNameColumn.HeaderText = "Parameter";
            this.commonDeliquoringSimulationBlockParameterNameColumn.Name = "commonDeliquoringSimulationBlockParameterNameColumn";
            this.commonDeliquoringSimulationBlockParameterNameColumn.ReadOnly = true;
            this.commonDeliquoringSimulationBlockParameterNameColumn.Width = 61;
            // 
            // commonDeliquoringSimulationBlockUnitColumn
            // 
            this.commonDeliquoringSimulationBlockUnitColumn.HeaderText = "Units";
            this.commonDeliquoringSimulationBlockUnitColumn.Name = "commonDeliquoringSimulationBlockUnitColumn";
            this.commonDeliquoringSimulationBlockUnitColumn.ReadOnly = true;
            this.commonDeliquoringSimulationBlockUnitColumn.Width = 37;
            // 
            // commonDeliquoringSimulationBlockParameterValueColumn
            // 
            this.commonDeliquoringSimulationBlockParameterValueColumn.HeaderText = "Value";
            this.commonDeliquoringSimulationBlockParameterValueColumn.Name = "commonDeliquoringSimulationBlockParameterValueColumn";
            this.commonDeliquoringSimulationBlockParameterValueColumn.Width = 50;
            // 
            // fmFilterSimulationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Name = "fmFilterSimulationControl";
            this.Size = new System.Drawing.Size(980, 615);
            this.Load += new System.EventHandler(this.FilterSimulation_Load);
            this.panelLeft.ResumeLayout(false);
            this.suspensionParametersAndCalcOptionsPanel.ResumeLayout(false);
            this.suspensionParametersPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonCalcBlockDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliquoringMaterialParametersDataGrid)).EndInit();
            this.panelMaterialParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eps0Kappa0Pc0Rc0Alpha0DataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liquidDataGrid)).EndInit();
            this.panelSimSerSusInput.ResumeLayout(false);
            this.panelSimSerSusInput.PerformLayout();
            this.secondFromTopPanel.ResumeLayout(false);
            this.simSeriesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.simSeriesDataGrid)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.suspensionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.suspensionDataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.machinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.machineTypesDataGrid)).EndInit();
            this.projectPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.simulationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.simulationDataGrid)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonDeliquoringSimulationBlockDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected fmDataGrid.fmDataGrid projectDataGrid;
        protected fmDataGrid.fmDataGrid suspensionDataGrid;
        protected fmDataGrid.fmDataGrid machineTypesDataGrid;
        protected fmDataGrid.fmDataGrid simSeriesDataGrid;
        protected System.Windows.Forms.Button suspensionKeepButton;
        protected System.Windows.Forms.Button projectCreateButton;
        protected System.Windows.Forms.Button suspensionCreateButton;
        protected System.Windows.Forms.Button simSeriesCreateButton;
        protected System.Windows.Forms.Button projectKeepButton;
        protected System.Windows.Forms.Button projectRestoreButton;
        protected System.Windows.Forms.Button projectDeleteButton;
        protected System.Windows.Forms.Button suspensionRestoreButton;
        protected System.Windows.Forms.Button suspensionDeleteButton;
        protected fmDataGrid.fmDataGrid simulationDataGrid;
        protected System.Windows.Forms.Button simSeriesKeepButton;
        protected System.Windows.Forms.Button simSeriesRestoreButton;
        protected System.Windows.Forms.Button simSeriesDeleteButton;
        protected System.Windows.Forms.Button simulationDuplicateButton;
        protected System.Windows.Forms.Button simulationKeepButton;
        protected System.Windows.Forms.Button simulationRestoreButton;
        protected System.Windows.Forms.Button simulationDeleteButton;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        protected System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        protected fmDataGrid.fmDataGrid liquidDataGrid;
        protected System.Windows.Forms.CheckBox byCheckingProjectsCheckBox;
        protected System.Windows.Forms.CheckBox byCheckingSuspensionsCheckBox;
        protected System.Windows.Forms.CheckBox byCheckingSimSeriesCheckBox;
        protected System.Windows.Forms.CheckBox byCheckingSimulationsCheckBox;
        protected System.Windows.Forms.DataGridViewCheckBoxColumn machineTypeCheckedColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn machineTypeSymbolColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn machineTypeNameColumn;
        protected System.Windows.Forms.CheckBox fullSimulationInfoCheckBox;
        protected System.Windows.Forms.Panel panelLeft;
        protected System.Windows.Forms.Panel topPanel;
        protected System.Windows.Forms.Panel projectPanel;
        protected System.Windows.Forms.Panel suspensionPanel;
        protected System.Windows.Forms.Splitter splitter2;
        protected System.Windows.Forms.Panel machinePanel;
        protected System.Windows.Forms.Splitter splitter1;
        protected System.Windows.Forms.Splitter splitter3;
        protected System.Windows.Forms.Panel secondFromTopPanel;
        protected System.Windows.Forms.Panel suspensionParametersPanel;
        protected System.Windows.Forms.Splitter splitter4;
        protected System.Windows.Forms.Button simSeriesDuplicateButton;
        protected fmDataGrid.fmDataGrid eps0Kappa0Pc0Rc0Alpha0DataGrid;
        protected System.Windows.Forms.RadioButton meterialInputSerieRadioButton;
        protected System.Windows.Forms.RadioButton meterialInputSimualationRadioButton;
        protected System.Windows.Forms.RadioButton meterialInputSuspensionRadioButton;
        protected System.Windows.Forms.Panel suspensionParametersAndCalcOptionsPanel;
        protected System.Windows.Forms.Panel simulationPanel;
        protected System.Windows.Forms.Panel panelRight;
        protected System.Windows.Forms.Panel panelTop;
        protected System.Windows.Forms.Panel panelMain;
        protected System.Windows.Forms.Splitter splitter5;
        protected System.Windows.Forms.DataGridViewTextBoxColumn suspensionGuidColumn;
        protected System.Windows.Forms.DataGridViewCheckBoxColumn suspensionCheckedColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn suspensionMaterialColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn suspensionCustomerColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn suspensionNameColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn projectGuidColumn;
        protected System.Windows.Forms.DataGridViewCheckBoxColumn projectCheckedColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn projectNameColumn;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Button button4;
        protected System.Windows.Forms.Button button3;
        protected System.Windows.Forms.Button button2;
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.ToolTip toolTip;
        protected System.Windows.Forms.Button simulationCreateButton;
        protected System.Windows.Forms.DataGridViewCheckBoxColumn simSeriesCheckedColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simSeriesGuidColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simSeriesNameColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simSeriesProjectColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simSeriesSuspensionNameColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simSeriesFilterMediumColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simSeriesMachineTypeNameColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simSeriesMachineNameColumn;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simSeriesLastModifiedDateColumn;
        protected System.Windows.Forms.Panel simSeriesPanel;
        private System.Windows.Forms.Button calculationOptionChangeButton;
        private System.Windows.Forms.Panel panelSimSerSusInput;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter6;
        protected fmDataGrid.fmDataGrid commonCalcBlockDataGrid;
        protected System.Windows.Forms.DataGridViewTextBoxColumn commonCalcBlockParameterNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commonCalcBlockUnitColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn commonCalcBlockMinAbsColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn commonCalcBlockMinLocalColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn commonCalcBlockParameterValueColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn commonCalcBlockMaxLocalColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn commonCalcBlockMaxAbsColumn;
        private System.Windows.Forms.CheckBox calculateLimitsCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn epsKappaParameterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn epsKappaUnits;
        protected System.Windows.Forms.DataGridViewTextBoxColumn simulationGuidColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn simulationCheckedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationProjectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationSuspensionNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationFilterMediumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationMachineTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationMachineNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationSimSeriesNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationNameColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulationFilterAreaColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulationFilterDiameterColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_DpColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_sfColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_srColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_nColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_tcColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_tfColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_trColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_hc_over_tfColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_dhc_over_dtColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_hcColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_MfColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_VfColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_MsusColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_VsusColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_MsColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_VsColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_McColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_VcColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_mf_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_vf_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_msus_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_vsus_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_ms_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_vs_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_mc_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_vc_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_QsusColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_Qsus_dColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_QmsusColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_Qmsus_dColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_QmsColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_Qms_dColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_QmfColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_Qmf_dColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_QmcColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_Qmc_dColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_QfColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_Qf_dColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_QsColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_Qs_dColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_QcColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_Qc_dColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qf_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qf_d_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qsus_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qsus_d_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qs_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qs_d_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qc_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qc_d_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qmf_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qmf_d_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qmsus_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qmsus_d_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qms_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qms_d_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qmc_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_qmc_d_Column;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_epsColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_kappaColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_PcColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_rcColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn simulation_aColumn;
        private System.Windows.Forms.Panel panelMaterialParameters;
        private System.Windows.Forms.DataGridViewTextBoxColumn liquidParameterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn liquidParameterUnits;
        private fmDataGrid.fmDataGrid deliquoringMaterialParametersDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliquoringMaterialParametersParameterNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliquoringMaterialParametersUnitsColumn;
        protected fmDataGrid.fmDataGrid commonDeliquoringSimulationBlockDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn commonDeliquoringSimulationBlockParameterNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commonDeliquoringSimulationBlockUnitColumn;
        private fmDataGrid.fmDataGridViewNumericalTextBoxColumn commonDeliquoringSimulationBlockParameterValueColumn;
    }
}
