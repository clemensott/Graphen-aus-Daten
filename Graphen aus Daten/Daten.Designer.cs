namespace Graphen_aus_Daten
{
    partial class Daten
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
            this.components = new System.ComponentModel.Container();
            this.gbx_koor = new System.Windows.Forms.GroupBox();
            this.gbx_null = new System.Windows.Forms.GroupBox();
            this.gbx_m_x = new System.Windows.Forms.GroupBox();
            this.ckb_n_x_manuell = new System.Windows.Forms.CheckBox();
            this.tbx_null_x = new System.Windows.Forms.TextBox();
            this.gbx_m_y = new System.Windows.Forms.GroupBox();
            this.ckb_n_y_manuell = new System.Windows.Forms.CheckBox();
            this.tbx_null_y = new System.Windows.Forms.TextBox();
            this.gbx_einteilung = new System.Windows.Forms.GroupBox();
            this.gbx_e_x = new System.Windows.Forms.GroupBox();
            this.ckb_e_x_manuell = new System.Windows.Forms.CheckBox();
            this.tbx_x_achse = new System.Windows.Forms.TextBox();
            this.gbx_e_y = new System.Windows.Forms.GroupBox();
            this.ckb_e_y_manuell = new System.Windows.Forms.CheckBox();
            this.tbx_y_achse = new System.Windows.Forms.TextBox();
            this.gbx_bereich = new System.Windows.Forms.GroupBox();
            this.gbx_b_y = new System.Windows.Forms.GroupBox();
            this.ckb_y_grenz = new System.Windows.Forms.CheckBox();
            this.ckb_b_y_bis = new System.Windows.Forms.CheckBox();
            this.ckb_b_y_von = new System.Windows.Forms.CheckBox();
            this.tbx_y_bis = new System.Windows.Forms.TextBox();
            this.tbx_y_von = new System.Windows.Forms.TextBox();
            this.gbx_b_x = new System.Windows.Forms.GroupBox();
            this.ckb_x_grenz = new System.Windows.Forms.CheckBox();
            this.ckb_b_x_bis = new System.Windows.Forms.CheckBox();
            this.ckb_b_x_von = new System.Windows.Forms.CheckBox();
            this.tbx_x_bis = new System.Windows.Forms.TextBox();
            this.tbx_x_von = new System.Windows.Forms.TextBox();
            this.tbx_verhaltnis = new System.Windows.Forms.TextBox();
            this.ckb_x_y = new System.Windows.Forms.CheckBox();
            this.btn_sch = new System.Windows.Forms.Button();
            this.btn_neu = new System.Windows.Forms.Button();
            this.btn_loschen = new System.Windows.Forms.Button();
            this.tbx_contant = new System.Windows.Forms.TextBox();
            this.cbx_auto = new System.Windows.Forms.CheckBox();
            this.tbx_schritte = new System.Windows.Forms.TextBox();
            this.dgv_k = new System.Windows.Forms.DataGridView();
            this.x_w = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y_w = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_l = new System.Windows.Forms.DataGridView();
            this.tim = new System.Windows.Forms.Timer(this.components);
            this.G_an = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.g_art = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g_farbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_datei = new System.Windows.Forms.Button();
            this.gbx_koor.SuspendLayout();
            this.gbx_null.SuspendLayout();
            this.gbx_m_x.SuspendLayout();
            this.gbx_m_y.SuspendLayout();
            this.gbx_einteilung.SuspendLayout();
            this.gbx_e_x.SuspendLayout();
            this.gbx_e_y.SuspendLayout();
            this.gbx_bereich.SuspendLayout();
            this.gbx_b_y.SuspendLayout();
            this.gbx_b_x.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_k)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_l)).BeginInit();
            this.SuspendLayout();
            // 
            // gbx_koor
            // 
            this.gbx_koor.Controls.Add(this.gbx_null);
            this.gbx_koor.Controls.Add(this.gbx_einteilung);
            this.gbx_koor.Controls.Add(this.gbx_bereich);
            this.gbx_koor.Controls.Add(this.tbx_verhaltnis);
            this.gbx_koor.Controls.Add(this.ckb_x_y);
            this.gbx_koor.Location = new System.Drawing.Point(12, 12);
            this.gbx_koor.Name = "gbx_koor";
            this.gbx_koor.Size = new System.Drawing.Size(308, 244);
            this.gbx_koor.TabIndex = 132;
            this.gbx_koor.TabStop = false;
            this.gbx_koor.Text = "Koordinatensystem";
            // 
            // gbx_null
            // 
            this.gbx_null.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_null.Controls.Add(this.gbx_m_x);
            this.gbx_null.Controls.Add(this.gbx_m_y);
            this.gbx_null.Location = new System.Drawing.Point(6, 146);
            this.gbx_null.Name = "gbx_null";
            this.gbx_null.Size = new System.Drawing.Size(168, 92);
            this.gbx_null.TabIndex = 127;
            this.gbx_null.TabStop = false;
            this.gbx_null.Text = "Mittelpunkt";
            // 
            // gbx_m_x
            // 
            this.gbx_m_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_m_x.Controls.Add(this.ckb_n_x_manuell);
            this.gbx_m_x.Controls.Add(this.tbx_null_x);
            this.gbx_m_x.Location = new System.Drawing.Point(6, 19);
            this.gbx_m_x.Name = "gbx_m_x";
            this.gbx_m_x.Size = new System.Drawing.Size(75, 67);
            this.gbx_m_x.TabIndex = 122;
            this.gbx_m_x.TabStop = false;
            this.gbx_m_x.Text = "X-Achse";
            // 
            // ckb_n_x_manuell
            // 
            this.ckb_n_x_manuell.AutoSize = true;
            this.ckb_n_x_manuell.Location = new System.Drawing.Point(6, 18);
            this.ckb_n_x_manuell.Name = "ckb_n_x_manuell";
            this.ckb_n_x_manuell.Size = new System.Drawing.Size(63, 17);
            this.ckb_n_x_manuell.TabIndex = 19;
            this.ckb_n_x_manuell.Text = "Manuell";
            this.ckb_n_x_manuell.UseVisualStyleBackColor = true;
            this.ckb_n_x_manuell.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // tbx_null_x
            // 
            this.tbx_null_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_null_x.Enabled = false;
            this.tbx_null_x.Location = new System.Drawing.Point(6, 41);
            this.tbx_null_x.Name = "tbx_null_x";
            this.tbx_null_x.Size = new System.Drawing.Size(63, 20);
            this.tbx_null_x.TabIndex = 20;
            this.tbx_null_x.Text = "0";
            this.tbx_null_x.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // gbx_m_y
            // 
            this.gbx_m_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_m_y.Controls.Add(this.ckb_n_y_manuell);
            this.gbx_m_y.Controls.Add(this.tbx_null_y);
            this.gbx_m_y.Location = new System.Drawing.Point(87, 19);
            this.gbx_m_y.Name = "gbx_m_y";
            this.gbx_m_y.Size = new System.Drawing.Size(75, 67);
            this.gbx_m_y.TabIndex = 122;
            this.gbx_m_y.TabStop = false;
            this.gbx_m_y.Text = "Y-Achse";
            // 
            // ckb_n_y_manuell
            // 
            this.ckb_n_y_manuell.AutoSize = true;
            this.ckb_n_y_manuell.Location = new System.Drawing.Point(6, 18);
            this.ckb_n_y_manuell.Name = "ckb_n_y_manuell";
            this.ckb_n_y_manuell.Size = new System.Drawing.Size(63, 17);
            this.ckb_n_y_manuell.TabIndex = 21;
            this.ckb_n_y_manuell.Text = "Manuell";
            this.ckb_n_y_manuell.UseVisualStyleBackColor = true;
            this.ckb_n_y_manuell.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // tbx_null_y
            // 
            this.tbx_null_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_null_y.Enabled = false;
            this.tbx_null_y.Location = new System.Drawing.Point(6, 41);
            this.tbx_null_y.Name = "tbx_null_y";
            this.tbx_null_y.Size = new System.Drawing.Size(63, 20);
            this.tbx_null_y.TabIndex = 22;
            this.tbx_null_y.Text = "0";
            this.tbx_null_y.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // gbx_einteilung
            // 
            this.gbx_einteilung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_einteilung.Controls.Add(this.gbx_e_x);
            this.gbx_einteilung.Controls.Add(this.gbx_e_y);
            this.gbx_einteilung.Location = new System.Drawing.Point(6, 19);
            this.gbx_einteilung.Name = "gbx_einteilung";
            this.gbx_einteilung.Size = new System.Drawing.Size(168, 92);
            this.gbx_einteilung.TabIndex = 127;
            this.gbx_einteilung.TabStop = false;
            this.gbx_einteilung.Text = "Einteilungen";
            // 
            // gbx_e_x
            // 
            this.gbx_e_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_e_x.Controls.Add(this.ckb_e_x_manuell);
            this.gbx_e_x.Controls.Add(this.tbx_x_achse);
            this.gbx_e_x.Location = new System.Drawing.Point(6, 19);
            this.gbx_e_x.Name = "gbx_e_x";
            this.gbx_e_x.Size = new System.Drawing.Size(75, 67);
            this.gbx_e_x.TabIndex = 122;
            this.gbx_e_x.TabStop = false;
            this.gbx_e_x.Text = "X-Achse";
            // 
            // ckb_e_x_manuell
            // 
            this.ckb_e_x_manuell.AutoSize = true;
            this.ckb_e_x_manuell.Checked = true;
            this.ckb_e_x_manuell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_e_x_manuell.Location = new System.Drawing.Point(6, 17);
            this.ckb_e_x_manuell.Name = "ckb_e_x_manuell";
            this.ckb_e_x_manuell.Size = new System.Drawing.Size(63, 17);
            this.ckb_e_x_manuell.TabIndex = 15;
            this.ckb_e_x_manuell.Text = "Manuell";
            this.ckb_e_x_manuell.UseVisualStyleBackColor = true;
            this.ckb_e_x_manuell.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // tbx_x_achse
            // 
            this.tbx_x_achse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_x_achse.Location = new System.Drawing.Point(6, 40);
            this.tbx_x_achse.Name = "tbx_x_achse";
            this.tbx_x_achse.Size = new System.Drawing.Size(63, 20);
            this.tbx_x_achse.TabIndex = 16;
            this.tbx_x_achse.Text = "1";
            this.tbx_x_achse.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // gbx_e_y
            // 
            this.gbx_e_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_e_y.Controls.Add(this.ckb_e_y_manuell);
            this.gbx_e_y.Controls.Add(this.tbx_y_achse);
            this.gbx_e_y.Location = new System.Drawing.Point(87, 19);
            this.gbx_e_y.Name = "gbx_e_y";
            this.gbx_e_y.Size = new System.Drawing.Size(75, 67);
            this.gbx_e_y.TabIndex = 122;
            this.gbx_e_y.TabStop = false;
            this.gbx_e_y.Text = "Y-Achse";
            // 
            // ckb_e_y_manuell
            // 
            this.ckb_e_y_manuell.AutoSize = true;
            this.ckb_e_y_manuell.Checked = true;
            this.ckb_e_y_manuell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_e_y_manuell.Location = new System.Drawing.Point(6, 17);
            this.ckb_e_y_manuell.Name = "ckb_e_y_manuell";
            this.ckb_e_y_manuell.Size = new System.Drawing.Size(63, 17);
            this.ckb_e_y_manuell.TabIndex = 17;
            this.ckb_e_y_manuell.Text = "Manuell";
            this.ckb_e_y_manuell.UseVisualStyleBackColor = true;
            this.ckb_e_y_manuell.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // tbx_y_achse
            // 
            this.tbx_y_achse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_y_achse.Location = new System.Drawing.Point(6, 40);
            this.tbx_y_achse.Name = "tbx_y_achse";
            this.tbx_y_achse.Size = new System.Drawing.Size(63, 20);
            this.tbx_y_achse.TabIndex = 18;
            this.tbx_y_achse.Text = "1";
            this.tbx_y_achse.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // gbx_bereich
            // 
            this.gbx_bereich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_bereich.Controls.Add(this.gbx_b_y);
            this.gbx_bereich.Controls.Add(this.gbx_b_x);
            this.gbx_bereich.Location = new System.Drawing.Point(180, 19);
            this.gbx_bereich.Name = "gbx_bereich";
            this.gbx_bereich.Size = new System.Drawing.Size(122, 219);
            this.gbx_bereich.TabIndex = 127;
            this.gbx_bereich.TabStop = false;
            this.gbx_bereich.Text = "Bereich";
            // 
            // gbx_b_y
            // 
            this.gbx_b_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_b_y.Controls.Add(this.ckb_y_grenz);
            this.gbx_b_y.Controls.Add(this.ckb_b_y_bis);
            this.gbx_b_y.Controls.Add(this.ckb_b_y_von);
            this.gbx_b_y.Controls.Add(this.tbx_y_bis);
            this.gbx_b_y.Controls.Add(this.tbx_y_von);
            this.gbx_b_y.Location = new System.Drawing.Point(6, 119);
            this.gbx_b_y.Name = "gbx_b_y";
            this.gbx_b_y.Size = new System.Drawing.Size(110, 94);
            this.gbx_b_y.TabIndex = 122;
            this.gbx_b_y.TabStop = false;
            this.gbx_b_y.Text = "Y-Achse";
            // 
            // ckb_y_grenz
            // 
            this.ckb_y_grenz.AutoSize = true;
            this.ckb_y_grenz.Location = new System.Drawing.Point(6, 19);
            this.ckb_y_grenz.Name = "ckb_y_grenz";
            this.ckb_y_grenz.Size = new System.Drawing.Size(74, 17);
            this.ckb_y_grenz.TabIndex = 27;
            this.ckb_y_grenz.Text = "Grenzwert";
            this.ckb_y_grenz.UseVisualStyleBackColor = true;
            this.ckb_y_grenz.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // ckb_b_y_bis
            // 
            this.ckb_b_y_bis.AutoSize = true;
            this.ckb_b_y_bis.Location = new System.Drawing.Point(6, 70);
            this.ckb_b_y_bis.Name = "ckb_b_y_bis";
            this.ckb_b_y_bis.Size = new System.Drawing.Size(39, 17);
            this.ckb_b_y_bis.TabIndex = 29;
            this.ckb_b_y_bis.Text = "bis";
            this.ckb_b_y_bis.UseVisualStyleBackColor = true;
            this.ckb_b_y_bis.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // ckb_b_y_von
            // 
            this.ckb_b_y_von.AutoSize = true;
            this.ckb_b_y_von.Location = new System.Drawing.Point(6, 44);
            this.ckb_b_y_von.Name = "ckb_b_y_von";
            this.ckb_b_y_von.Size = new System.Drawing.Size(44, 17);
            this.ckb_b_y_von.TabIndex = 27;
            this.ckb_b_y_von.Text = "von";
            this.ckb_b_y_von.UseVisualStyleBackColor = true;
            this.ckb_b_y_von.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // tbx_y_bis
            // 
            this.tbx_y_bis.Enabled = false;
            this.tbx_y_bis.Location = new System.Drawing.Point(50, 68);
            this.tbx_y_bis.Name = "tbx_y_bis";
            this.tbx_y_bis.Size = new System.Drawing.Size(54, 20);
            this.tbx_y_bis.TabIndex = 30;
            this.tbx_y_bis.Text = "10";
            this.tbx_y_bis.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // tbx_y_von
            // 
            this.tbx_y_von.Enabled = false;
            this.tbx_y_von.Location = new System.Drawing.Point(50, 42);
            this.tbx_y_von.Name = "tbx_y_von";
            this.tbx_y_von.Size = new System.Drawing.Size(54, 20);
            this.tbx_y_von.TabIndex = 28;
            this.tbx_y_von.Text = "-10";
            this.tbx_y_von.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // gbx_b_x
            // 
            this.gbx_b_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbx_b_x.Controls.Add(this.ckb_x_grenz);
            this.gbx_b_x.Controls.Add(this.ckb_b_x_bis);
            this.gbx_b_x.Controls.Add(this.ckb_b_x_von);
            this.gbx_b_x.Controls.Add(this.tbx_x_bis);
            this.gbx_b_x.Controls.Add(this.tbx_x_von);
            this.gbx_b_x.Location = new System.Drawing.Point(6, 19);
            this.gbx_b_x.Name = "gbx_b_x";
            this.gbx_b_x.Size = new System.Drawing.Size(110, 94);
            this.gbx_b_x.TabIndex = 122;
            this.gbx_b_x.TabStop = false;
            this.gbx_b_x.Text = "X-Achse";
            // 
            // ckb_x_grenz
            // 
            this.ckb_x_grenz.AutoSize = true;
            this.ckb_x_grenz.Location = new System.Drawing.Point(6, 19);
            this.ckb_x_grenz.Name = "ckb_x_grenz";
            this.ckb_x_grenz.Size = new System.Drawing.Size(74, 17);
            this.ckb_x_grenz.TabIndex = 27;
            this.ckb_x_grenz.Text = "Grenzwert";
            this.ckb_x_grenz.UseVisualStyleBackColor = true;
            this.ckb_x_grenz.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // ckb_b_x_bis
            // 
            this.ckb_b_x_bis.AutoSize = true;
            this.ckb_b_x_bis.Location = new System.Drawing.Point(6, 70);
            this.ckb_b_x_bis.Name = "ckb_b_x_bis";
            this.ckb_b_x_bis.Size = new System.Drawing.Size(39, 17);
            this.ckb_b_x_bis.TabIndex = 25;
            this.ckb_b_x_bis.Text = "bis";
            this.ckb_b_x_bis.UseVisualStyleBackColor = true;
            this.ckb_b_x_bis.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // ckb_b_x_von
            // 
            this.ckb_b_x_von.AutoSize = true;
            this.ckb_b_x_von.Location = new System.Drawing.Point(6, 44);
            this.ckb_b_x_von.Name = "ckb_b_x_von";
            this.ckb_b_x_von.Size = new System.Drawing.Size(44, 17);
            this.ckb_b_x_von.TabIndex = 23;
            this.ckb_b_x_von.Text = "von";
            this.ckb_b_x_von.UseVisualStyleBackColor = true;
            this.ckb_b_x_von.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // tbx_x_bis
            // 
            this.tbx_x_bis.Enabled = false;
            this.tbx_x_bis.Location = new System.Drawing.Point(50, 68);
            this.tbx_x_bis.Name = "tbx_x_bis";
            this.tbx_x_bis.Size = new System.Drawing.Size(54, 20);
            this.tbx_x_bis.TabIndex = 26;
            this.tbx_x_bis.Text = "10";
            this.tbx_x_bis.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // tbx_x_von
            // 
            this.tbx_x_von.Enabled = false;
            this.tbx_x_von.Location = new System.Drawing.Point(50, 42);
            this.tbx_x_von.Name = "tbx_x_von";
            this.tbx_x_von.Size = new System.Drawing.Size(54, 20);
            this.tbx_x_von.TabIndex = 24;
            this.tbx_x_von.Text = "-10";
            this.tbx_x_von.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // tbx_verhaltnis
            // 
            this.tbx_verhaltnis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_verhaltnis.Enabled = false;
            this.tbx_verhaltnis.Location = new System.Drawing.Point(120, 117);
            this.tbx_verhaltnis.Name = "tbx_verhaltnis";
            this.tbx_verhaltnis.Size = new System.Drawing.Size(42, 20);
            this.tbx_verhaltnis.TabIndex = 32;
            this.tbx_verhaltnis.Text = "1";
            this.tbx_verhaltnis.Leave += new System.EventHandler(this.tbx_x_achse_Leave);
            // 
            // ckb_x_y
            // 
            this.ckb_x_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckb_x_y.AutoSize = true;
            this.ckb_x_y.Location = new System.Drawing.Point(18, 119);
            this.ckb_x_y.Name = "ckb_x_y";
            this.ckb_x_y.Size = new System.Drawing.Size(110, 17);
            this.ckb_x_y.TabIndex = 31;
            this.ckb_x_y.Text = "Einteilung: y = x * ";
            this.ckb_x_y.UseVisualStyleBackColor = true;
            this.ckb_x_y.CheckedChanged += new System.EventHandler(this.ckb_e_x_manuell_CheckedChanged);
            // 
            // btn_sch
            // 
            this.btn_sch.Location = new System.Drawing.Point(12, 262);
            this.btn_sch.Name = "btn_sch";
            this.btn_sch.Size = new System.Drawing.Size(75, 23);
            this.btn_sch.TabIndex = 133;
            this.btn_sch.Text = "Schließen";
            this.btn_sch.UseVisualStyleBackColor = true;
            this.btn_sch.Click += new System.EventHandler(this.btn_sch_Click);
            // 
            // btn_neu
            // 
            this.btn_neu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_neu.Location = new System.Drawing.Point(329, 317);
            this.btn_neu.Name = "btn_neu";
            this.btn_neu.Size = new System.Drawing.Size(110, 23);
            this.btn_neu.TabIndex = 135;
            this.btn_neu.Text = "Neu";
            this.btn_neu.UseVisualStyleBackColor = true;
            this.btn_neu.Click += new System.EventHandler(this.btn_neu_Click);
            // 
            // btn_loschen
            // 
            this.btn_loschen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_loschen.Enabled = false;
            this.btn_loschen.Location = new System.Drawing.Point(445, 317);
            this.btn_loschen.Name = "btn_loschen";
            this.btn_loschen.Size = new System.Drawing.Size(109, 23);
            this.btn_loschen.TabIndex = 135;
            this.btn_loschen.Text = "Löschen";
            this.btn_loschen.UseVisualStyleBackColor = true;
            this.btn_loschen.Click += new System.EventHandler(this.btn_loschen_Click);
            // 
            // tbx_contant
            // 
            this.tbx_contant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_contant.Location = new System.Drawing.Point(560, 319);
            this.tbx_contant.Name = "tbx_contant";
            this.tbx_contant.Size = new System.Drawing.Size(156, 20);
            this.tbx_contant.TabIndex = 136;
            this.tbx_contant.DoubleClick += new System.EventHandler(this.tbx_contant_DoubleClick);
            this.tbx_contant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbx_contant_KeyDown);
            this.tbx_contant.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_contant_KeyUp);
            // 
            // cbx_auto
            // 
            this.cbx_auto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_auto.AutoSize = true;
            this.cbx_auto.Location = new System.Drawing.Point(722, 321);
            this.cbx_auto.Name = "cbx_auto";
            this.cbx_auto.Size = new System.Drawing.Size(99, 17);
            this.cbx_auto.TabIndex = 137;
            this.cbx_auto.Text = "Auto    Schritte:";
            this.cbx_auto.UseVisualStyleBackColor = true;
            this.cbx_auto.CheckedChanged += new System.EventHandler(this.cbx_auto_CheckedChanged);
            // 
            // tbx_schritte
            // 
            this.tbx_schritte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_schritte.Enabled = false;
            this.tbx_schritte.Location = new System.Drawing.Point(815, 319);
            this.tbx_schritte.Name = "tbx_schritte";
            this.tbx_schritte.Size = new System.Drawing.Size(66, 20);
            this.tbx_schritte.TabIndex = 138;
            this.tbx_schritte.Text = "1";
            this.tbx_schritte.Leave += new System.EventHandler(this.tbx_schritte_Leave);
            // 
            // dgv_k
            // 
            this.dgv_k.AllowUserToAddRows = false;
            this.dgv_k.AllowUserToDeleteRows = false;
            this.dgv_k.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_k.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_k.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_k.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_k.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.x_w,
            this.y_w});
            this.dgv_k.Location = new System.Drawing.Point(560, 13);
            this.dgv_k.Name = "dgv_k";
            this.dgv_k.ReadOnly = true;
            this.dgv_k.RowHeadersVisible = false;
            this.dgv_k.Size = new System.Drawing.Size(321, 299);
            this.dgv_k.TabIndex = 139;
            this.dgv_k.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_k_CellClick);
            this.dgv_k.RowHeightChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_k_RowHeightChanged);
            this.dgv_k.SelectionChanged += new System.EventHandler(this.dgv_k_SelectionChanged);
            // 
            // x_w
            // 
            this.x_w.HeaderText = "X Werte";
            this.x_w.Name = "x_w";
            this.x_w.ReadOnly = true;
            this.x_w.Width = 159;
            // 
            // y_w
            // 
            this.y_w.HeaderText = "Y Werte";
            this.y_w.Name = "y_w";
            this.y_w.ReadOnly = true;
            this.y_w.Width = 159;
            // 
            // dgv_l
            // 
            this.dgv_l.AllowUserToAddRows = false;
            this.dgv_l.AllowUserToDeleteRows = false;
            this.dgv_l.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_l.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_l.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_l.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_l.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.G_an,
            this.g_art,
            this.g_name,
            this.g_farbe});
            this.dgv_l.Location = new System.Drawing.Point(329, 13);
            this.dgv_l.MultiSelect = false;
            this.dgv_l.Name = "dgv_l";
            this.dgv_l.ReadOnly = true;
            this.dgv_l.RowHeadersVisible = false;
            this.dgv_l.Size = new System.Drawing.Size(225, 299);
            this.dgv_l.TabIndex = 140;
            this.dgv_l.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_l_CellClick);
            this.dgv_l.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_l_CellContentClick);
            this.dgv_l.CurrentCellChanged += new System.EventHandler(this.dgv_l_CurrentCellChanged);
            this.dgv_l.RowHeightChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgv_l_RowHeightChanged);
            // 
            // tim
            // 
            this.tim.Interval = 200;
            this.tim.Tick += new System.EventHandler(this.tim_Tick);
            // 
            // G_an
            // 
            this.G_an.HeaderText = " ";
            this.G_an.Name = "G_an";
            this.G_an.ReadOnly = true;
            this.G_an.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.G_an.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.G_an.Width = 20;
            // 
            // g_art
            // 
            this.g_art.HeaderText = "Art";
            this.g_art.Name = "g_art";
            this.g_art.ReadOnly = true;
            this.g_art.Width = 50;
            // 
            // g_name
            // 
            this.g_name.HeaderText = "Name";
            this.g_name.Name = "g_name";
            this.g_name.ReadOnly = true;
            this.g_name.Width = 102;
            // 
            // g_farbe
            // 
            this.g_farbe.HeaderText = "Farbe";
            this.g_farbe.Name = "g_farbe";
            this.g_farbe.ReadOnly = true;
            this.g_farbe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.g_farbe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.g_farbe.Width = 50;
            // 
            // btn_datei
            // 
            this.btn_datei.Location = new System.Drawing.Point(245, 262);
            this.btn_datei.Name = "btn_datei";
            this.btn_datei.Size = new System.Drawing.Size(75, 23);
            this.btn_datei.TabIndex = 141;
            this.btn_datei.Text = "Datei";
            this.btn_datei.UseVisualStyleBackColor = true;
            this.btn_datei.Click += new System.EventHandler(this.btn_datei_Click);
            // 
            // Daten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 352);
            this.Controls.Add(this.btn_datei);
            this.Controls.Add(this.dgv_l);
            this.Controls.Add(this.dgv_k);
            this.Controls.Add(this.tbx_schritte);
            this.Controls.Add(this.cbx_auto);
            this.Controls.Add(this.tbx_contant);
            this.Controls.Add(this.btn_loschen);
            this.Controls.Add(this.btn_neu);
            this.Controls.Add(this.btn_sch);
            this.Controls.Add(this.gbx_koor);
            this.Name = "Daten";
            this.Text = "Daten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Daten_FormClosing);
            this.Load += new System.EventHandler(this.Daten_Load);
            this.SizeChanged += new System.EventHandler(this.Daten_SizeChanged);
            this.gbx_koor.ResumeLayout(false);
            this.gbx_koor.PerformLayout();
            this.gbx_null.ResumeLayout(false);
            this.gbx_m_x.ResumeLayout(false);
            this.gbx_m_x.PerformLayout();
            this.gbx_m_y.ResumeLayout(false);
            this.gbx_m_y.PerformLayout();
            this.gbx_einteilung.ResumeLayout(false);
            this.gbx_e_x.ResumeLayout(false);
            this.gbx_e_x.PerformLayout();
            this.gbx_e_y.ResumeLayout(false);
            this.gbx_e_y.PerformLayout();
            this.gbx_bereich.ResumeLayout(false);
            this.gbx_b_y.ResumeLayout(false);
            this.gbx_b_y.PerformLayout();
            this.gbx_b_x.ResumeLayout(false);
            this.gbx_b_x.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_k)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_l)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_koor;
        private System.Windows.Forms.GroupBox gbx_null;
        private System.Windows.Forms.GroupBox gbx_m_x;
        private System.Windows.Forms.CheckBox ckb_n_x_manuell;
        private System.Windows.Forms.TextBox tbx_null_x;
        private System.Windows.Forms.GroupBox gbx_m_y;
        private System.Windows.Forms.CheckBox ckb_n_y_manuell;
        private System.Windows.Forms.TextBox tbx_null_y;
        private System.Windows.Forms.GroupBox gbx_einteilung;
        private System.Windows.Forms.GroupBox gbx_e_x;
        private System.Windows.Forms.CheckBox ckb_e_x_manuell;
        private System.Windows.Forms.TextBox tbx_x_achse;
        private System.Windows.Forms.GroupBox gbx_e_y;
        private System.Windows.Forms.CheckBox ckb_e_y_manuell;
        private System.Windows.Forms.TextBox tbx_y_achse;
        private System.Windows.Forms.GroupBox gbx_bereich;
        private System.Windows.Forms.GroupBox gbx_b_y;
        private System.Windows.Forms.CheckBox ckb_b_y_bis;
        private System.Windows.Forms.CheckBox ckb_b_y_von;
        private System.Windows.Forms.TextBox tbx_y_bis;
        private System.Windows.Forms.TextBox tbx_y_von;
        private System.Windows.Forms.GroupBox gbx_b_x;
        private System.Windows.Forms.CheckBox ckb_b_x_bis;
        private System.Windows.Forms.CheckBox ckb_b_x_von;
        private System.Windows.Forms.TextBox tbx_x_bis;
        private System.Windows.Forms.TextBox tbx_x_von;
        private System.Windows.Forms.TextBox tbx_verhaltnis;
        private System.Windows.Forms.CheckBox ckb_x_y;
        private System.Windows.Forms.Button btn_sch;
        private System.Windows.Forms.Button btn_neu;
        private System.Windows.Forms.Button btn_loschen;
        private System.Windows.Forms.TextBox tbx_contant;
        private System.Windows.Forms.CheckBox cbx_auto;
        private System.Windows.Forms.TextBox tbx_schritte;
        private System.Windows.Forms.DataGridView dgv_k;
        public System.Windows.Forms.DataGridView dgv_l;
        private System.Windows.Forms.Timer tim;
        private System.Windows.Forms.CheckBox ckb_y_grenz;
        private System.Windows.Forms.CheckBox ckb_x_grenz;
        private System.Windows.Forms.DataGridViewTextBoxColumn x_w;
        private System.Windows.Forms.DataGridViewTextBoxColumn y_w;
        private System.Windows.Forms.DataGridViewCheckBoxColumn G_an;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_art;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn g_farbe;
        private System.Windows.Forms.Button btn_datei;
    }
}