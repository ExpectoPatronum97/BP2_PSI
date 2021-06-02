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
using UI.Commands.Sala;

namespace UI.ViewModel
{
	public class NewSalaViewModel : BindableBase
	{
		private Window window;

		public bool IsNew { get; set; } = true;
		public bool IsEdit { get; set; } = false;
		public Sala Sala { get; set; }


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
		public ICommand AddSalaCommand { get; set; }
		public ICommand EditSalaCommand { get; set; }
		public bool CanAddSala
		{
			get => Sala.Broj_sedista > 0 && SelectedPozoriste != null;
		}

		public NewSalaViewModel(Window w, Sala p)
		{
			window = w;
			Pozorista = PozoristeManager.Instance.RetrieveAll();
			if (p == null)
			{
				Sala = new Sala();
				IsNew = true;
				IsEdit = false;
			}
			else
			{
				Sala = p;
				SelectedPozoriste = Pozorista.SingleOrDefault(x => x.ID_Pozorista == p.ID_Pozorista);
				IsNew = false;
				IsEdit = true;
			}
			AddSalaCommand = new AddSalaCommand(this);
			EditSalaCommand = new EditSalaCommand(this);
		}


		internal void AddSala()
		{
			try
			{
				Sala.ID_Pozorista = SelectedPozoriste.ID_Pozorista; // ne bi trebalo nikad biti null
				if (SalaManager.Instance.AddSala(Sala))
				{
					var res = MessageBox.Show("Sala uspešno dodana!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Sala već postoji.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}

		internal void EditSala()
		{
			try
			{
				if (SalaManager.Instance.UpdateSala(Sala))
				{
					var res = MessageBox.Show("Sala uspešno izmenjena!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Sala nije uspešno izmenjena.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}
	}

}
