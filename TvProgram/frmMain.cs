using System;
using System.Windows.Forms;
using TvProgram.Service;

namespace TvProgram
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

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

			// TODO : ajouter une progress bar ou une patience pendant le chargement

			lblResultatRecherche.Text = $"Nb films trouvés : {lvResutat.Items.Count}";
		}
    }
}
