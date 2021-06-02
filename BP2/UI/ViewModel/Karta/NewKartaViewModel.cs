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
using UI.Commands.Karta;

namespace UI.ViewModel
{
	public class NewKartaViewModel : BindableBase
	{
		private Window window;

		private BindingList<Sala> sale;
		public BindingList<Sala> Sale
		{
			get { return sale; }
			set { SetProperty(ref sale, value); }
		}

		private BindingList<Pozoriste> pozorista;
		public BindingList<Pozoriste> Pozorista
		{
			get { return pozorista; }
			set { SetProperty(ref pozorista, value); }
		}

		private BindingList<Predstava> predstave;
		public BindingList<Predstava> Predstave
		{
			get { return predstave; }
			set { SetProperty(ref predstave, value); }
		}

		private Pozoriste selectedPozoriste;
		public Pozoriste SelectedPozoriste
		{
			get { return selectedPozoriste; }
			set 
			{ 
				SetProperty(ref selectedPozoriste, value);
				Predstave = PozoristeManager.Instance.RetrieveAllPredstaveFrom(selectedPozoriste.ID_Pozorista);
				Sale = PozoristeManager.Instance.RetrieveAllSaleFrom(selectedPozoriste.ID_Pozorista);
			}
		}
		private Sala selectedSala;
		public Sala SelectedSala
		{
			get { return selectedSala; }
			set 
			{ 
				SetProperty(ref selectedSala, value);
				Predstave = SalaManager.Instance.RetrieveAllPredstaveFrom(selectedSala.ID_Sale, selectedPozoriste.ID_Pozorista);
			}
		}
		private Predstava selectedPredstava;
		public Predstava SelectedPredstava
		{
			get { return selectedPredstava; }
			set { SetProperty(ref selectedPredstava, value); }
		}

		private BindingList<string> redovi, sedista;
		public BindingList<string> Redovi
		{
			get { return redovi; }
			set { SetProperty(ref redovi, value); }
		}
		public BindingList<string> Sedista
		{
			get { return sedista; }
			set { SetProperty(ref sedista, value); }
		}

		public bool IsNew { get; set; } = true;
		public bool IsEdit { get; set; } = false;
		public Karta Karta { get; set; }

		public ICommand AddKartaCommand { get; set; }
		public ICommand EditKartaCommand { get; set; }
		public bool CanAddKarta
		{
			get => SelectedPozoriste != null &&
				SelectedSala != null &&
				SelectedPredstava != null &&
				!string.IsNullOrWhiteSpace(Karta.Red) &&
				!string.IsNullOrWhiteSpace(Karta.Sediste);

		}

		public NewKartaViewModel(Window w, Karta p)
		{
			window = w;
			Pozorista = PozoristeManager.Instance.RetrieveAll();
			Sale = SalaManager.Instance.RetrieveAll();
			Predstave = PredstavaManager.Instance.RetrieveAll();
			Redovi = new BindingList<string>();
			Sedista = new BindingList<string>();
			for (int i = 0; i < 32; i++)
			{
				Sedista.Add((i + 1).ToString());
				if (i % 8 == 0)
				{
					Redovi.Add(new string((char)('A' + (i/8)), 1));
				}
			}
			if (p == null)
			{
				Karta = new Karta
				{
					Datum = DateTime.Now
				};
				IsNew = true;
				IsEdit = false;
			}
			else
			{
				Karta = p;
				SelectedPozoriste = PozoristeManager.Instance.RetrievePozoriste(Karta.ID_Pozorista);
				SelectedSala = SalaManager.Instance.RetrieveSala(Karta.ID_Sale);
				SelectedPredstava = PredstavaManager.Instance.RetrievePredstava(Karta.ID_Predstave);
				IsNew = false;
				IsEdit = true;
			}
			AddKartaCommand = new AddKartaCommand(this);
			EditKartaCommand = new EditKartaCommand(this);
		}


		internal void AddKarta()
		{
			try
			{
				Karta.ID_Pozorista = SelectedPozoriste.ID_Pozorista;
				Karta.ID_Sale = SelectedSala.ID_Sale;
				Karta.ID_Predstave = selectedPredstava.ID_Predstave;

				if (KartaManager.Instance.AddKarta(Karta))
				{
					var res = MessageBox.Show("Karta uspešno dodana!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Karta već postoji.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}

		internal void EditKarta()
		{
			try
			{
				if (KartaManager.Instance.UpdateKarta(Karta))
				{
					var res = MessageBox.Show("Karta uspešno izmenjena!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Karta nije uspešno izmenjena.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}
	}

}
