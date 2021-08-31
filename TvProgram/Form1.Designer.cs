namespace TvProgram
{
	partial class Form1
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
			this.SuspendLayout();
			// 
			// btnRechercher
			// 
			this.btnRechercher.Location = new System.Drawing.Point(891, 3);
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
			this.tbSource.Size = new System.Drawing.Size(983, 86);
			this.tbSource.TabIndex = 2;
			// 
			// lvResutat
			// 
			this.lvResutat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNom,
            this.columnHeaderUrl,
            this.columnHeaderNoteTL});
			this.lvResutat.HideSelection = false;
			this.lvResutat.Location = new System.Drawing.Point(12, 139);
			this.lvResutat.Name = "lvResutat";
			this.lvResutat.Size = new System.Drawing.Size(983, 420);
			this.lvResutat.TabIndex = 3;
			this.lvResutat.UseCompatibleStateImageBehavior = false;
			this.lvResutat.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderNom
			// 
			this.columnHeaderNom.Text = "Nom";
			this.columnHeaderNom.Width = 276;
			// 
			// columnHeaderUrl
			// 
			this.columnHeaderUrl.Text = "URL";
			this.columnHeaderUrl.Width = 628;
			// 
			// columnHeaderNoteTL
			// 
			this.columnHeaderNoteTL.Text = "Note TL";
			this.columnHeaderNoteTL.Width = 58;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1007, 571);
			this.Controls.Add(this.lvResutat);
			this.Controls.Add(this.tbSource);
			this.Controls.Add(this.dateTimePicker);
			this.Controls.Add(this.btnRechercher);
			this.Name = "Form1";
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
	}
}

