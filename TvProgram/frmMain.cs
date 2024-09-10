﻿using System;
using System.Windows.Forms;
using TvProgram.Service;
using TvProgram.Sqlite;

namespace TvProgram
{
    public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clic sur le bouton Rechercher
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRechercher_Click(object sender, EventArgs e)
		{
            TeleLoisirsService teleLoisirsService = new TeleLoisirsService();

			tbSource.Text = teleLoisirsService.GetCodeSource(dateTimePicker.Value, new System.Collections.Generic.List<Entities.Chaine>());

			lvResutat.Items.Clear();
			foreach (var film in teleLoisirsService.GetUrlFilms(tbSource.Text))
			{
				ListViewItem listviewitem = new ListViewItem(new string[]{ film.Nom, film.Url });

				lvResutat.Items.Add(listviewitem);
			}

			lblResultatRecherche.Text = $"Nb films trouvés : {lvResutat.Items.Count}";
		}

		/// <summary>
		/// Clic sur le bouton Parcourir
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnParcourir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            if (!string.IsNullOrEmpty(dialog.FileName))
            {
				FileService fileService = new FileService();
				var favoris = fileService.LireFichierFavori(dialog.FileName);

				var repository = new FilmRepository();

                lblProgression.Text = "Insertion en BDD en cours...";
                bool isSuccess = repository.AjouterFilms(favoris);
				if (isSuccess)
				{
                    lblProgression.Text = "Insertion en BDD terminée avec succès.";
                }
				else
				{
                    lblProgression.Text = "Erreur lors de l'insertion en BDD.";
                }
            }
        }
    }
}
