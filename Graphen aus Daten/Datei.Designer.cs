namespace Graphen_aus_Daten
{
    partial class Datei
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
            this.btn_offnen = new System.Windows.Forms.Button();
            this.btn_speichern = new System.Windows.Forms.Button();
            this.btn_speichern_unter = new System.Windows.Forms.Button();
            this.rbn_uber = new System.Windows.Forms.RadioButton();
            this.rbn_hinzu = new System.Windows.Forms.RadioButton();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btn_offnen
            // 
            this.btn_offnen.Location = new System.Drawing.Point(13, 13);
            this.btn_offnen.Name = "btn_offnen";
            this.btn_offnen.Size = new System.Drawing.Size(101, 23);
            this.btn_offnen.TabIndex = 0;
            this.btn_offnen.Text = "Öffnen";
            this.btn_offnen.UseVisualStyleBackColor = true;
            this.btn_offnen.Click += new System.EventHandler(this.btn_offnen_Click);
            // 
            // btn_speichern
            // 
            this.btn_speichern.Location = new System.Drawing.Point(12, 42);
            this.btn_speichern.Name = "btn_speichern";
            this.btn_speichern.Size = new System.Drawing.Size(102, 23);
            this.btn_speichern.TabIndex = 0;
            this.btn_speichern.Text = "Speichern";
            this.btn_speichern.UseVisualStyleBackColor = true;
            // 
            // btn_speichern_unter
            // 
            this.btn_speichern_unter.Location = new System.Drawing.Point(12, 71);
            this.btn_speichern_unter.Name = "btn_speichern_unter";
            this.btn_speichern_unter.Size = new System.Drawing.Size(102, 23);
            this.btn_speichern_unter.TabIndex = 0;
            this.btn_speichern_unter.Text = "Speichern unter";
            this.btn_speichern_unter.UseVisualStyleBackColor = true;
            this.btn_speichern_unter.Click += new System.EventHandler(this.btn_speichern_unter_Click);
            // 
            // rbn_uber
            // 
            this.rbn_uber.AutoSize = true;
            this.rbn_uber.Location = new System.Drawing.Point(128, 45);
            this.rbn_uber.Name = "rbn_uber";
            this.rbn_uber.Size = new System.Drawing.Size(94, 17);
            this.rbn_uber.TabIndex = 1;
            this.rbn_uber.Text = "Überschreiben";
            this.rbn_uber.UseVisualStyleBackColor = true;
            // 
            // rbn_hinzu
            // 
            this.rbn_hinzu.AutoSize = true;
            this.rbn_hinzu.Checked = true;
            this.rbn_hinzu.Location = new System.Drawing.Point(128, 16);
            this.rbn_hinzu.Name = "rbn_hinzu";
            this.rbn_hinzu.Size = new System.Drawing.Size(79, 17);
            this.rbn_hinzu.TabIndex = 1;
            this.rbn_hinzu.TabStop = true;
            this.rbn_hinzu.Text = "Hinzufügen";
            this.rbn_hinzu.UseVisualStyleBackColor = true;
            // 
            // ofd
            // 
            this.ofd.FileName = "Daten";
            this.ofd.Filter = "Text_Dateien|*.txt";
            // 
            // sfd
            // 
            this.sfd.Filter = "Text_Dateien|*.txt";
            // 
            // Datei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 112);
            this.Controls.Add(this.rbn_hinzu);
            this.Controls.Add(this.rbn_uber);
            this.Controls.Add(this.btn_speichern_unter);
            this.Controls.Add(this.btn_speichern);
            this.Controls.Add(this.btn_offnen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Datei";
            this.Text = "Datei";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Datei_FormClosing);
            this.Load += new System.EventHandler(this.Datei_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_offnen;
        private System.Windows.Forms.Button btn_speichern;
        private System.Windows.Forms.Button btn_speichern_unter;
        private System.Windows.Forms.RadioButton rbn_uber;
        private System.Windows.Forms.RadioButton rbn_hinzu;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}