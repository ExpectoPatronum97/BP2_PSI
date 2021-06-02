using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.Commands.Scenarista;

namespace UI.ViewModel
{
	public class NewScenaristaViewModel
	{
		private Window window;

		public bool IsNew { get; set; } = true;
		public bool IsEdit { get; set; } = false;
		public Scenarista Scenarista { get; set; }

		public ICommand AddScenaristaCommand { get; set; }
		public ICommand EditScenaristaCommand { get; set; }
		public bool CanAddScenarista
		{
			get => !string.IsNullOrWhiteSpace(Scenarista.Ime) &&
					!string.IsNullOrWhiteSpace(Scenarista.Prezime) &&
					Scenarista.Broj_predstava > 0;
		}

		public NewScenaristaViewModel(Window w, Scenarista p)
		{
			window = w;
			if (p == null)
			{
				Scenarista = new Scenarista();
				IsNew = true;
				IsEdit = false;
			}
			else
			{
				Scenarista = p;
				IsNew = false;
				IsEdit = true;
			}
			AddScenaristaCommand = new AddScenaristaCommand(this);
			EditScenaristaCommand = new EditScenaristaCommand(this);
		}


		internal void AddScenarista()
		{
			try
			{
				if (ScenaristaManager.Instance.AddScenarista(Scenarista))
				{
					var res = MessageBox.Show("Scenarista uspešno dodan!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Scenarista već postoji.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}

		internal void EditScenarista()
		{
			try
			{
				if (ScenaristaManager.Instance.UpdateScenarista(Scenarista))
				{
					var res = MessageBox.Show("Scenarista uspešno izmenjen!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Scenarista nije uspešno izmenjen.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}
	}

}
