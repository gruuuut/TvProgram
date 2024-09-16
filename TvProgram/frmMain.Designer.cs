namespace TvProgram
{
	partial class frmMain
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnRechercher = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.lvResutat = new System.Windows.Forms.ListView();
            this.columnHeaderNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNoteTL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResultatRecherche = new System.Windows.Forms.Label();
            this.lblChargement = new System.Windows.Forms.Label();
            this.btnParcourir = new System.Windows.Forms.Button();
            this.lblProgression = new System.Windows.Forms.Label();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDateFavori = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnRechercher
            // 
            this.btnRechercher.Location = new System.Drawing.Point(749, 3);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(104, 26);
            this.btnRechercher.TabIndex = 0;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.RightToLeftLayout = true;
            this.dateTimePicker.Size = new System.Drawing.Size(163, 20);
            this.dateTimePicker.TabIndex = 1;
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(12, 35);
            this.tbSource.Multiline = true;
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(841, 86);
            this.tbSource.TabIndex = 2;
            // 
            // lvResutat
            // 
            this.lvResutat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderUrl,
            this.columnHeaderNom,
            this.columnHeaderDateFavori,
            this.columnHeaderNoteTL});
            this.lvResutat.HideSelection = false;
            this.lvResutat.Location = new System.Drawing.Point(11, 147);
            this.lvResutat.Name = "lvResutat";
            this.lvResutat.Size = new System.Drawing.Size(842, 405);
            this.lvResutat.TabIndex = 3;
            this.lvResutat.UseCompatibleStateImageBehavior = false;
            this.lvResutat.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNom
            // 
            this.columnHeaderNom.DisplayIndex = 0;
            this.columnHeaderNom.Text = "Nom";
            this.columnHeaderNom.Width = 276;
            // 
            // columnHeaderUrl
            // 
            this.columnHeaderUrl.Text = "URL";
            this.columnHeaderUrl.Width = 328;
            // 
            // columnHeaderNoteTL
            // 
            this.columnHeaderNoteTL.Text = "Note TL";
            this.columnHeaderNoteTL.Width = 56;
            // 
            // lblResultatRecherche
            // 
            this.lblResultatRecherche.AutoSize = true;
            this.lblResultatRecherche.Location = new System.Drawing.Point(445, 9);
            this.lblResultatRecherche.Name = "lblResultatRecherche";
            this.lblResultatRecherche.Size = new System.Drawing.Size(0, 13);
            this.lblResultatRecherche.TabIndex = 4;
            // 
            // lblChargement
            // 
            this.lblChargement.AutoSize = true;
            this.lblChargement.Location = new System.Drawing.Point(411, 255);
            this.lblChargement.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChargement.Name = "lblChargement";
            this.lblChargement.Size = new System.Drawing.Size(0, 13);
            this.lblChargement.TabIndex = 5;
            // 
            // btnParcourir
            // 
            this.btnParcourir.Location = new System.Drawing.Point(673, 4);
            this.btnParcourir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnParcourir.Name = "btnParcourir";
            this.btnParcourir.Size = new System.Drawing.Size(71, 26);
            this.btnParcourir.TabIndex = 6;
            this.btnParcourir.Text = "Parcourir...";
            this.btnParcourir.UseVisualStyleBackColor = true;
            this.btnParcourir.Click += new System.EventHandler(this.btnParcourir_Click);
            // 
            // lblProgression
            // 
            this.lblProgression.AutoSize = true;
            this.lblProgression.Location = new System.Drawing.Point(216, 131);
            this.lblProgression.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgression.Name = "lblProgression";
            this.lblProgression.Size = new System.Drawing.Size(0, 13);
            this.lblProgression.TabIndex = 7;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            this.columnHeaderId.Width = 31;
            // 
            // columnHeaderDateFavori
            // 
            this.columnHeaderDateFavori.Text = "Date favori";
            this.columnHeaderDateFavori.Width = 82;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 526);
            this.Controls.Add(this.lblProgression);
            this.Controls.Add(this.btnParcourir);
            this.Controls.Add(this.lblChargement);
            this.Controls.Add(this.lblResultatRecherche);
            this.Controls.Add(this.lvResutat);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.btnRechercher);
            this.Name = "frmMain";
            this.Text = "Fenêtre principale";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRechercher;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.TextBox tbSource;
		private System.Windows.Forms.ListView lvResutat;
		private System.Windows.Forms.ColumnHeader columnHeaderNom;
		private System.Windows.Forms.ColumnHeader columnHeaderUrl;
		private System.Windows.Forms.ColumnHeader columnHeaderNoteTL;
        private System.Windows.Forms.Label lblResultatRecherche;

        private void frmMain_Load()
        {

        }

        private System.Windows.Forms.Label lblChargement;
        private System.Windows.Forms.Button btnParcourir;
        private System.Windows.Forms.Label lblProgression;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderDateFavori;
    }
}

