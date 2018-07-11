namespace Graph_Lib
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonRun = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.textBoxKommentar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownVarv = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownSimulations = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMoving = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSpecial = new System.Windows.Forms.Button();
            this.numericUpDownInfection = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownRecovery = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownPopulation = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.charten = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVarv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSimulations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInfection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecovery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charten)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRun
            // 
            this.buttonRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRun.Location = new System.Drawing.Point(0, 307);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(119, 186);
            this.buttonRun.TabIndex = 1;
            this.buttonRun.Text = "RUN";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRun);
            this.panel1.Controls.Add(this.labelSize);
            this.panel1.Controls.Add(this.labelElapsedTime);
            this.panel1.Controls.Add(this.textBoxKommentar);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numericUpDownVarv);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numericUpDownSimulations);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDownMoving);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonSpecial);
            this.panel1.Controls.Add(this.numericUpDownInfection);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDownRecovery);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numericUpDownPopulation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 556);
            this.panel1.TabIndex = 3;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSize.Location = new System.Drawing.Point(0, 290);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(0, 17);
            this.labelSize.TabIndex = 11;
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.AutoSize = true;
            this.labelElapsedTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelElapsedTime.Location = new System.Drawing.Point(0, 273);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(0, 17);
            this.labelElapsedTime.TabIndex = 3;
            // 
            // textBoxKommentar
            // 
            this.textBoxKommentar.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxKommentar.Location = new System.Drawing.Point(0, 251);
            this.textBoxKommentar.Name = "textBoxKommentar";
            this.textBoxKommentar.Size = new System.Drawing.Size(119, 22);
            this.textBoxKommentar.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Kommentar";
            // 
            // numericUpDownVarv
            // 
            this.numericUpDownVarv.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownVarv.Location = new System.Drawing.Point(0, 212);
            this.numericUpDownVarv.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownVarv.Name = "numericUpDownVarv";
            this.numericUpDownVarv.Size = new System.Drawing.Size(119, 22);
            this.numericUpDownVarv.TabIndex = 13;
            this.numericUpDownVarv.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Varv";
            // 
            // numericUpDownSimulations
            // 
            this.numericUpDownSimulations.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownSimulations.Location = new System.Drawing.Point(0, 173);
            this.numericUpDownSimulations.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownSimulations.Name = "numericUpDownSimulations";
            this.numericUpDownSimulations.Size = new System.Drawing.Size(119, 22);
            this.numericUpDownSimulations.TabIndex = 9;
            this.numericUpDownSimulations.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Simulations";
            // 
            // numericUpDownMoving
            // 
            this.numericUpDownMoving.DecimalPlaces = 3;
            this.numericUpDownMoving.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownMoving.Location = new System.Drawing.Point(0, 134);
            this.numericUpDownMoving.Name = "numericUpDownMoving";
            this.numericUpDownMoving.Size = new System.Drawing.Size(119, 22);
            this.numericUpDownMoving.TabIndex = 15;
            this.numericUpDownMoving.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Rate of moving";
            // 
            // buttonSpecial
            // 
            this.buttonSpecial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSpecial.Location = new System.Drawing.Point(0, 493);
            this.buttonSpecial.Name = "buttonSpecial";
            this.buttonSpecial.Size = new System.Drawing.Size(119, 63);
            this.buttonSpecial.TabIndex = 12;
            this.buttonSpecial.Text = "SPECIAL";
            this.buttonSpecial.UseVisualStyleBackColor = true;
            this.buttonSpecial.Click += new System.EventHandler(this.ButtonSpecial_Click);
            // 
            // numericUpDownInfection
            // 
            this.numericUpDownInfection.DecimalPlaces = 3;
            this.numericUpDownInfection.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownInfection.Location = new System.Drawing.Point(0, 95);
            this.numericUpDownInfection.Name = "numericUpDownInfection";
            this.numericUpDownInfection.Size = new System.Drawing.Size(119, 22);
            this.numericUpDownInfection.TabIndex = 3;
            this.numericUpDownInfection.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rate of infection";
            // 
            // numericUpDownRecovery
            // 
            this.numericUpDownRecovery.DecimalPlaces = 3;
            this.numericUpDownRecovery.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownRecovery.Location = new System.Drawing.Point(0, 56);
            this.numericUpDownRecovery.Name = "numericUpDownRecovery";
            this.numericUpDownRecovery.Size = new System.Drawing.Size(119, 22);
            this.numericUpDownRecovery.TabIndex = 4;
            this.numericUpDownRecovery.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rate of recovery";
            // 
            // numericUpDownPopulation
            // 
            this.numericUpDownPopulation.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericUpDownPopulation.Location = new System.Drawing.Point(0, 17);
            this.numericUpDownPopulation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPopulation.Name = "numericUpDownPopulation";
            this.numericUpDownPopulation.Size = new System.Drawing.Size(119, 22);
            this.numericUpDownPopulation.TabIndex = 5;
            this.numericUpDownPopulation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Population";
            // 
            // charten
            // 
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            chartArea3.Name = "ChartArea3";
            chartArea4.Name = "ChartArea4";
            chartArea5.Name = "ChartArea5";
            chartArea6.Name = "ChartArea6";
            this.charten.ChartAreas.Add(chartArea1);
            this.charten.ChartAreas.Add(chartArea2);
            this.charten.ChartAreas.Add(chartArea3);
            this.charten.ChartAreas.Add(chartArea4);
            this.charten.ChartAreas.Add(chartArea5);
            this.charten.ChartAreas.Add(chartArea6);
            this.charten.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.charten.Legends.Add(legend1);
            this.charten.Location = new System.Drawing.Point(119, 0);
            this.charten.Name = "charten";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Average Size";
            series2.ChartArea = "ChartArea2";
            series2.Legend = "Legend1";
            series2.Name = "Percentage of Cliques Infected";
            series3.ChartArea = "ChartArea3";
            series3.Legend = "Legend1";
            series3.Name = "Total Movement";
            series4.ChartArea = "ChartArea4";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Standard diviation";
            series4.YValuesPerPoint = 3;
            series5.ChartArea = "ChartArea5";
            series5.Legend = "Legend1";
            series5.Name = "Average infected in cliques";
            series6.ChartArea = "ChartArea6";
            series6.Legend = "Legend1";
            series6.Name = "TimeOfCliqueInfected";
            series7.ChartArea = "ChartArea6";
            series7.Color = System.Drawing.Color.Crimson;
            series7.Legend = "Legend1";
            series7.Name = "TimeOfInfCliqueInf";
            series8.ChartArea = "ChartArea4";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Lime;
            series8.Legend = "Legend1";
            series8.Name = "MOAv.Inf.In.Cliq";
            series9.ChartArea = "ChartArea5";
            series9.Color = System.Drawing.Color.Purple;
            series9.Legend = "Legend1";
            series9.Name = "MoAv.InfP.In.Cliqu";
            series10.ChartArea = "ChartArea4";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.Yellow;
            series10.Legend = "Legend1";
            series10.Name = "CliqueIndexBySize";
            this.charten.Series.Add(series1);
            this.charten.Series.Add(series2);
            this.charten.Series.Add(series3);
            this.charten.Series.Add(series4);
            this.charten.Series.Add(series5);
            this.charten.Series.Add(series6);
            this.charten.Series.Add(series7);
            this.charten.Series.Add(series8);
            this.charten.Series.Add(series9);
            this.charten.Series.Add(series10);
            this.charten.Size = new System.Drawing.Size(594, 556);
            this.charten.TabIndex = 4;
            this.charten.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 556);
            this.Controls.Add(this.charten);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVarv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSimulations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInfection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecovery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charten)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelElapsedTime;
        private System.Windows.Forms.NumericUpDown numericUpDownInfection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownRecovery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownPopulation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart charten;
        private System.Windows.Forms.NumericUpDown numericUpDownSimulations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.Button buttonSpecial;
        private System.Windows.Forms.NumericUpDown numericUpDownVarv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownMoving;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxKommentar;
        private System.Windows.Forms.Label label7;
    }
}

