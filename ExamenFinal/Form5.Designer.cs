namespace ExamenFinal
{
    partial class Form5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarTicket = new System.Windows.Forms.TextBox();
            this.btnBuscarTicket = new System.Windows.Forms.Button();
            this.btnLimpiarBusqueda = new System.Windows.Forms.Button();
            this.dgvResultadoTicket = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnImprimirConstancia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadoTicket)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(27, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el Código del Ticket";
            // 
            // txtBuscarTicket
            // 
            this.txtBuscarTicket.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscarTicket.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarTicket.Location = new System.Drawing.Point(3, 10);
            this.txtBuscarTicket.Multiline = true;
            this.txtBuscarTicket.Name = "txtBuscarTicket";
            this.txtBuscarTicket.Size = new System.Drawing.Size(184, 21);
            this.txtBuscarTicket.TabIndex = 1;
            // 
            // btnBuscarTicket
            // 
            this.btnBuscarTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnBuscarTicket.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscarTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarTicket.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTicket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscarTicket.Location = new System.Drawing.Point(544, 84);
            this.btnBuscarTicket.Name = "btnBuscarTicket";
            this.btnBuscarTicket.Size = new System.Drawing.Size(118, 55);
            this.btnBuscarTicket.TabIndex = 2;
            this.btnBuscarTicket.Text = "Buscar";
            this.btnBuscarTicket.UseVisualStyleBackColor = false;
            this.btnBuscarTicket.Click += new System.EventHandler(this.btnBuscarTicket_Click);
            // 
            // btnLimpiarBusqueda
            // 
            this.btnLimpiarBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnLimpiarBusqueda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiarBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusqueda.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiarBusqueda.Location = new System.Drawing.Point(690, 84);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.Size = new System.Drawing.Size(118, 55);
            this.btnLimpiarBusqueda.TabIndex = 3;
            this.btnLimpiarBusqueda.Text = "Limpiar Búsqueda";
            this.btnLimpiarBusqueda.UseVisualStyleBackColor = false;
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            // 
            // dgvResultadoTicket
            // 
            this.dgvResultadoTicket.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultadoTicket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResultadoTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResultadoTicket.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvResultadoTicket.EnableHeadersVisualStyles = false;
            this.dgvResultadoTicket.Location = new System.Drawing.Point(30, 177);
            this.dgvResultadoTicket.Name = "dgvResultadoTicket";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResultadoTicket.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvResultadoTicket.RowHeadersVisible = false;
            this.dgvResultadoTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultadoTicket.Size = new System.Drawing.Size(918, 397);
            this.dgvResultadoTicket.TabIndex = 4;
            this.dgvResultadoTicket.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultadoTicket_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.txtBuscarTicket);
            this.panel1.Location = new System.Drawing.Point(275, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 42);
            this.panel1.TabIndex = 5;
            // 
            // btnImprimirConstancia
            // 
            this.btnImprimirConstancia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.btnImprimirConstancia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImprimirConstancia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirConstancia.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirConstancia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImprimirConstancia.Location = new System.Drawing.Point(830, 84);
            this.btnImprimirConstancia.Name = "btnImprimirConstancia";
            this.btnImprimirConstancia.Size = new System.Drawing.Size(118, 55);
            this.btnImprimirConstancia.TabIndex = 6;
            this.btnImprimirConstancia.Text = "Imprimir Constancia";
            this.btnImprimirConstancia.UseVisualStyleBackColor = false;
            this.btnImprimirConstancia.Click += new System.EventHandler(this.btnImprimirConstancia_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(973, 600);
            this.Controls.Add(this.btnImprimirConstancia);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvResultadoTicket);
            this.Controls.Add(this.btnLimpiarBusqueda);
            this.Controls.Add(this.btnBuscarTicket);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultadoTicket)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarTicket;
        private System.Windows.Forms.Button btnBuscarTicket;
        private System.Windows.Forms.Button btnLimpiarBusqueda;
        private System.Windows.Forms.DataGridView dgvResultadoTicket;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnImprimirConstancia;
    }
}