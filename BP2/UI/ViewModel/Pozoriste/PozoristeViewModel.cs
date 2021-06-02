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
using UI.Commands.Pozoriste;
using UI.Commands.Predstava;
using UI.View.Pozoriste;

namespace UI.ViewModel
{
	public class PozoristeViewModel : BindableBase
	{
		private BindingList<Predstava> predstave;
		public BindingList<Predstava> Predstave
		{
			get { return predstave; }
			set { SetProperty(ref predstave, value); }
		}

		private BindingList<Pozoriste> pozorista;
		public BindingList<Pozoriste> Pozorista
		{
			get { return pozorista; }
			set { SetProperty(ref pozorista, value); }
		}

		public Pozoriste SelectedPozoriste { get; set; }

		public ICommand NewPozoristeCommand { get; set; }
		public ICommand UpdatePozoristeCommand { get; set; }
		public ICommand DeletePozoristeCommand { get; set; }

		public ICommand RefreshCommand { get; set; }

		public ICommand ShowPredstaveCommand { get; set; }

		public bool CanUpdatePozoriste { get => SelectedPozoriste != null; }
		public bool CanDeletePozoriste { get => SelectedPozoriste != null; }


		public PozoristeViewModel()
		{
			Pozorista = PozoristeManager.Instance.RetrieveAll();
			Predstave = PredstavaManager.Instance.RetrieveAll();
			NewPozoristeCommand = new NewPozoristeCommand(this);
			UpdatePozoristeCommand = new UpdatePozoristeCommand(this);
			DeletePozoristeCommand = new DeletePozoristeCommand(this);
			RefreshCommand = new RefreshPozoristeCommand(this);
			ShowPredstaveCommand = new ShowPredstaveCommand(this);
			//SelectedPozoriste = null;
		}

		internal void NewPozoriste()
		{
			new NewPozoristeView().ShowDialog();
			Refresh();
		}
		internal void UpdatePozoriste()
		{
			new NewPozoristeView(SelectedPozoriste).ShowDialog();
			Refresh();
		}

		internal void DeletePozoriste()
		{
			var res = MessageBox.Show($"Jeste li sigurni da želite obrisati pozorište {SelectedPozoriste.Naziv}?",
				"Potvdra", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes)
			{
				try
				{
					if (PozoristeManager.Instance.DeletePozoriste(SelectedPozoriste.ID_Pozorista))
					{
						MessageBox.Show("Uspešno obrisan " + SelectedPozoriste.Naziv);
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
			Pozorista = PozoristeManager.Instance.RetrieveAll();
		}

		internal void ShowPredstave()
		{
			new AddPredstaveView(SelectedPozoriste.ID_Pozorista).ShowDialog();
		}

	}
}
