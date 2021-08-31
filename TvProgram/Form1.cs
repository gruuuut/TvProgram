using System;
using System.Windows.Forms;
using TvProgram.Service;

namespace TvProgram
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnRechercher_Click(object sender, EventArgs e)
		{
			TeleLoisirsService teleLoisirsService = new TeleLoisirsService();
			
			//string result = teleLoisirsService.GetCodeSource(DateTime.Now, new System.Collections.Generic.List<Entities.Chaine>());
			
			tbSource.Text = teleLoisirsService.GetCodeSource(DateTime.Now, new System.Collections.Generic.List<Entities.Chaine>());

			foreach (var url in teleLoisirsService.GetUrlFilms())
			{
				lvResutat.Items.Add(url);
			}
		}
	}
}
