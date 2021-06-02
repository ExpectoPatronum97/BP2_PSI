using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using UI.Commands.Karta;
using UI.View.Karta;

namespace UI.ViewModel
{
	public class KartaViewModel : BindableBase
	{
		private BindingList<Karta> karte;
		public BindingList<Karta> Karte
		{
			get { return karte; }
			set { SetProperty(ref karte, value); }
		}

		private BindingList<LoyaltyClan> clanovi;
		public BindingList<LoyaltyClan> Clanovi
		{
			get { return clanovi; }
			set { SetProperty(ref clanovi, value); }
		}

		public Karta SelectedKarta { get; set; }
		public LoyaltyClan SelectedClan { get; set; }
		public ICommand NewKartaCommand { get; set; }
		public ICommand UpdateKartaCommand { get; set; }
		public ICommand DeleteKartaCommand { get; set; }
		public ICommand BuyTicketCommand { get; set; }
		public ICommand BuyTicketAsLoyaltyCommand { get; set; }
		public bool CanBuyKarta { get => SelectedKarta != null && SelectedKarta.GledalacRBR == null; }
		public bool CanBuyAsLoyalty { get => CanBuyKarta && SelectedClan != null; }
		public bool CanUpdateKarta { get => SelectedKarta != null; }
		public bool CanDeleteKarta { get => SelectedKarta != null; }


		public KartaViewModel()
		{
			Karte = KartaManager.Instance.RetrieveAll();
			Clanovi = LoyaltyClanManager.Instance.RetrieveAll();

			NewKartaCommand = new NewKartaCommand(this);
			UpdateKartaCommand = new UpdateKartaCommand(this);
			DeleteKartaCommand = new DeleteKartaCommand(this);
			BuyTicketCommand = new BuyTicketCommand(this);
			BuyTicketAsLoyaltyCommand = new BuyTicketAsLoyaltyCommand(this);
			//SelectedKarta = null;
		}

		internal void NewKarta()
		{
			new NewKartaView().ShowDialog();
			Refresh();
		}
		internal void UpdateKarta()
		{
			new NewKartaView(SelectedKarta).ShowDialog();
			Refresh();
		}

		internal void DeleteKarta()
		{
			var res = MessageBox.Show($"Jeste li sigurni da želite obrisati kartu {SelectedKarta.ID_Karte}",
				"Potvdra", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes)
			{
				try
				{
					if (KartaManager.Instance.DeleteKarta(SelectedKarta.ID_Karte))
					{
						MessageBox.Show($"Uspešno obrisana karta {SelectedKarta.ID_Karte}");
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
			Karte = KartaManager.Instance.RetrieveAll();
		}

		internal void BuyTicket() 
		{
			if (SelectedKarta != null) 
			{
				Gledalac g = new Gledalac();
				GledalacManager.Instance.AddGledalac(g);
				SelectedKarta.GledalacRBR = g.RBR;
				KartaManager.Instance.UpdateKarta(SelectedKarta);
				Refresh();
			}
		}

		internal void BuyTicketAsLoyalty()
		{
			if (SelectedKarta != null && SelectedClan != null) // A TREBALO BI DA JE UVIJEK
			{
				Gledalac g = new Gledalac
				{
					ID_Clana = SelectedClan.ID_Clana
				};
				GledalacManager.Instance.AddGledalac(g);
				SelectedKarta.GledalacRBR = g.RBR;
				KartaManager.Instance.UpdateKarta(SelectedKarta);
				Refresh();
			}
		}
	}

	public class KartaConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string param = parameter.ToString();
			if (param == "Predstava")
			{
				return PredstavaManager.Instance.RetrievePredstava(int.Parse(value.ToString())).Naziv;
			}
			else if (param == "Pozoriste")
			{
				return PozoristeManager.Instance.RetrievePozoriste(int.Parse(value.ToString())).Naziv;
			}
			else if (param == "Gledalac")
			{
				if (value != null)
				{
					int rbr = int.Parse(value.ToString());
					if (rbr > 0)
					{
						Gledalac g = GledalacManager.Instance.RetrieveGledalac(rbr);
						if (g.ID_Clana != null)
						{
							LoyaltyClan lc = LoyaltyClanManager.Instance.RetrieveLoyaltyClan(g.ID_Clana.Value);
							return lc.Ime +" "+ lc.Prezime;
						}
						else
						{
							return "RBR. " + g.RBR.ToString();
						}
					}
				}
			}
			return "/";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return DependencyProperty.UnsetValue; // according to documentation
		}
	}

}
