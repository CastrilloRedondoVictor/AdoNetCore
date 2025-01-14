namespace AdoNetCore
{
    partial class Form04EliminarPlantilla
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
            lstPlantilla = new ListBox();
            txtId = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnEliminar = new Button();
            SuspendLayout();
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(399, 112);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(265, 244);
            lstPlantilla.TabIndex = 9;
            lstPlantilla.SelectedValueChanged += lstPlantilla_SelectedValueChanged;
            // 
            // txtId
            // 
            txtId.Location = new Point(137, 112);
            txtId.Name = "txtId";
            txtId.Size = new Size(124, 23);
            txtId.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(399, 94);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 7;
            label2.Text = "Plantilla";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 94);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 6;
            label1.Text = "ID Empleado";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(137, 141);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(124, 37);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar plantilla";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form04EliminarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstPlantilla);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEliminar);
            Name = "Form04EliminarPlantilla";
            Text = "Form04EliminarPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstPlantilla;
        private TextBox txtId;
        private Label label2;
        private Label label1;
        private Button btnEliminar;
    }
}