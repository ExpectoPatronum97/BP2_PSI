using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.Commands.Scenarista;
using UI.View.Scenarista;

namespace UI.ViewModel
{
	public class ScenaristaViewModel : BindableBase
	{
		private BindingList<Scenarista> scenaristi;
		public BindingList<Scenarista> Scenaristi
		{
			get { return scenaristi; }
			set { SetProperty(ref scenaristi, value); }
		}

		public Scenarista SelectedScenarista { get; set; }

		public ICommand NewScenaristaCommand { get; set; }
		public ICommand UpdateScenaristaCommand { get; set; }
		public ICommand DeleteScenaristaCommand { get; set; }
		public ICommand RefreshCommand { get; set; }
		public ICommand ShowScenariosCommand { get; set; }
		public bool CanUpdateScenarista { get => SelectedScenarista != null; }
		public bool CanDeleteScenarista { get => SelectedScenarista != null; }


		public ScenaristaViewModel()
		{
			Scenaristi = ScenaristaManager.Instance.RetrieveAll();
			NewScenaristaCommand = new NewScenaristaCommand(this);
			UpdateScenaristaCommand = new UpdateScenaristaCommand(this);
			DeleteScenaristaCommand = new DeleteScenaristaCommand(this);
			RefreshCommand = new RefreshScenaristaCommand(this);
			ShowScenariosCommand = new ShowScenariosCommand(this);
			//SelectedScenarista = null;
		}

		internal void NewScenarista()
		{
			new NewScenaristaView().ShowDialog();
			Refresh();
		}
		internal void UpdateScenarista()
		{
			new NewScenaristaView(SelectedScenarista).ShowDialog();
			Refresh();
		}

		internal void DeleteScenarista()
		{
			var res = MessageBox.Show($"Jeste li sigurni da želite obrisati scenaristu {SelectedScenarista.Ime} + {SelectedScenarista.Prezime}?",
				"Potvdra", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes)
			{
				try
				{
					if (ScenaristaManager.Instance.DeleteScenarista(SelectedScenarista.ID_Scenariste))
					{
						MessageBox.Show($"Uspešno obrisan scenarista {SelectedScenarista.Ime} + {SelectedScenarista.Prezime}");
					}
					else
					{
						MessageBox.Show("Brisanje nije uspelo.", "Error", MessageBoxButton.OK);
					}

				}
				catch
				{
					MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
				}
			}
			Refresh();
		}

		internal void Refresh()
		{
			Scenaristi = ScenaristaManager.Instance.RetrieveAll();
		}

		internal void ShowScenarios()
		{
			new AddScenarioView(SelectedScenarista.ID_Scenariste).ShowDialog();
			Refresh();
		}

	}

}
