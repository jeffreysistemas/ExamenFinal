namespace ExamenFinal
{
    partial class Form6
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartTipoTramite = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartEstados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartTipoTramite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstados)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartTipoTramite
            // 
            this.chartTipoTramite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            chartArea1.Name = "ChartArea1";
            this.chartTipoTramite.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTipoTramite.Legends.Add(legend1);
            this.chartTipoTramite.Location = new System.Drawing.Point(648, 77);
            this.chartTipoTramite.Name = "chartTipoTramite";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTipoTramite.Series.Add(series1);
            this.chartTipoTramite.Size = new System.Drawing.Size(348, 456);
            this.chartTipoTramite.TabIndex = 0;
            this.chartTipoTramite.Text = "chart1";
            // 
            // chartEstados
            // 
            chartArea2.Name = "ChartArea1";
            this.chartEstados.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartEstados.Legends.Add(legend2);
            this.chartEstados.Location = new System.Drawing.Point(12, 206);
            this.chartEstados.Name = "chartEstados";
            series2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            series2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkUpwardDiagonal;
            series2.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            series2.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartEstados.Series.Add(series2);
            this.chartEstados.Size = new System.Drawing.Size(622, 177);
            this.chartEstados.TabIndex = 1;
            this.chartEstados.Text = "chart2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(38, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 138);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(42, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "\"Total Expedientes\", \"Licencias\", \"Reclamos\", \"Solicitudes\"";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(38, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 138);
            this.panel2.TabIndex = 3;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1008, 619);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartEstados);
            this.Controls.Add(this.chartTipoTramite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartTipoTramite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartTipoTramite;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEstados;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}