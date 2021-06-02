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
using UI.Commands.Predstava;

namespace UI.ViewModel
{
	public class NewPredstavaViewModel : BindableBase
	{
		private Window window;

		public bool IsNew { get; set; } = true;
		public bool IsEdit { get; set; } = false;
		public Predstava Predstava { get; set; }

		private Pozoriste selectedPozoriste;
		public Pozoriste SelectedPozoriste
		{
			get { return selectedPozoriste; }
			set { SetProperty(ref selectedPozoriste, value); }
		}

		private BindingList<Pozoriste> pozorista;
		public BindingList<Pozoriste> Pozorista
		{
			get { return pozorista; }
			set { SetProperty(ref pozorista, value); }
		}

		public ICommand AddPredstavaCommand { get; set; }
		public ICommand EditPredstavaCommand { get; set; }
		public bool CanAddPredstava
		{
			get => !string.IsNullOrWhiteSpace(Predstava.Naziv);
		}

		public NewPredstavaViewModel(Window w, Predstava p)
		{
			window = w;
			Pozorista = PozoristeManager.Instance.RetrieveAll();
			if (p == null)
			{
				Predstava = new Predstava();
				IsNew = true;
				IsEdit = false;
			}
			else
			{
				Predstava = p;
				IsNew = false;
				IsEdit = true;
			}
			AddPredstavaCommand = new AddPredstavaCommand(this);
			EditPredstavaCommand = new EditPredstavaCommand(this);
		}


		internal void AddPredstava()
		{
			try
			{
				if (PredstavaManager.Instance.AddPredstava(Predstava))
				{
					var res = MessageBox.Show("Predstava uspešno dodana!");
					if (SelectedPozoriste != null)
					{
						PozoristeManager.Instance.AddOrganizuje(SelectedPozoriste.ID_Pozorista, Predstava.ID_Predstave);
					}
					window.Close();
				}
				else
				{
					MessageBox.Show("Predstava već postoji.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}

		internal void EditPredstava()
		{
			try
			{
				if (PredstavaManager.Instance.UpdatePredstava(Predstava))
				{
					var res = MessageBox.Show("Predstava uspešno izmenjena!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Predstava nije uspešno izmenjena.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}
	}

}
