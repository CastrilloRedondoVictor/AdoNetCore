namespace AdoNetCore
{
    partial class Form03EliminarEnfermos
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
            btnEliminar = new Button();
            label1 = new Label();
            label2 = new Label();
            txtInscripcion = new TextBox();
            lstEnfermos = new ListBox();
            SuspendLayout();
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(59, 80);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(124, 37);
            btnEliminar.TabIndex = 0;
            btnEliminar.Text = "Eliminar enfermo";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 33);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Inscripción";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(321, 33);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Enfermos";
            // 
            // txtInscripcion
            // 
            txtInscripcion.Location = new Point(59, 51);
            txtInscripcion.Name = "txtInscripcion";
            txtInscripcion.Size = new Size(124, 23);
            txtInscripcion.TabIndex = 3;
            // 
            // lstEnfermos
            // 
            lstEnfermos.FormattingEnabled = true;
            lstEnfermos.Location = new Point(321, 51);
            lstEnfermos.Name = "lstEnfermos";
            lstEnfermos.Size = new Size(265, 244);
            lstEnfermos.TabIndex = 4;
            // 
            // Form03EliminarEnfermos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstEnfermos);
            Controls.Add(txtInscripcion);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEliminar);
            Name = "Form03EliminarEnfermos";
            Text = "Form03EliminarEnfermos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminar;
        private Label label1;
        private Label label2;
        private TextBox txtInscripcion;
        private ListBox lstEnfermos;
    }
}