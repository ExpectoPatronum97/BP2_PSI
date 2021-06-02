using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Commands.Pozoriste;
using UI.Commands.Predstava;
using UI.View.Predstava;

namespace UI.ViewModel
{
	public class PredstavaViewModel : BindableBase
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
		public Predstava SelectedPredstava { get; set; }

		public ICommand NewPredstavaCommand { get; set; }
		public ICommand UpdatePredstavaCommand { get; set; }
		public ICommand DeletePredstavaCommand { get; set; }
		public ICommand RefreshCommand { get; set; }

		public ICommand ShowPozoristaCommand { get; set; }
		public bool CanUpdatePredstava { get => SelectedPredstava != null; }
		public bool CanDeletePredstava { get => SelectedPredstava != null; }


		public PredstavaViewModel()
		{
			Predstave = PredstavaManager.Instance.RetrieveAll();
			Pozorista = PozoristeManager.Instance.RetrieveAll();
			NewPredstavaCommand = new NewPredstavaCommand(this);
			UpdatePredstavaCommand = new UpdatePredstavaCommand(this);
			DeletePredstavaCommand = new DeletePredstavaCommand(this);
			RefreshCommand = new RefreshPredstavaCommand(this);
			ShowPozoristaCommand = new ShowPozoristaCommand(this);

			//SelectedPredstava = null;
		}

		internal void ShowPozorista()
		{
			string str = "Predstava se prikazuje u sledećim pozorištima:\n";
			int cnt = 0;
			foreach(Pozoriste p in pozorista)
			{
				if (PozoristeManager.Instance.IsOrganizuje(p.ID_Pozorista, SelectedPredstava.ID_Predstave))
				{
					str += $"{p.Naziv} <{p.Ulica}, {p.Mesto}>\n";
					++cnt;
				}
			}
			if (cnt == 0)
				str = "Predstava se ne prikazuje ni u jednom pozorištu.";
			MessageBox.Show(str);
		}
		internal void NewPredstava()
		{
			new NewPredstavaView().ShowDialog();
			Refresh();
		}
		internal void UpdatePredstava()
		{
			new NewPredstavaView(SelectedPredstava).ShowDialog();
			Refresh();
		}

		internal void DeletePredstava()
		{
			var res = MessageBox.Show($"Jeste li sigurni da želite obrisati predstavu {SelectedPredstava.Naziv}?",
				"Potvdra", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes)
			{
				try
				{
					if (PredstavaManager.Instance.DeletePredstava(SelectedPredstava.ID_Predstave))
					{
						MessageBox.Show("Uspešno obrisan " + SelectedPredstava.Naziv);
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
			Predstave = PredstavaManager.Instance.RetrieveAll();
		}
	}

}
