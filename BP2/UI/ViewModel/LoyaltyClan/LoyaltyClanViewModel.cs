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
using UI.Commands.LoyaltyClan;
using UI.View.LoyaltyClan;

namespace UI.ViewModel
{
	public class LoyaltyClanViewModel : BindableBase
	{
		private BindingList<LoyaltyClan> clanovi;
		public BindingList<LoyaltyClan> Clanovi
		{
			get { return clanovi; }
			set { SetProperty(ref clanovi, value); }
		}

		public LoyaltyClan SelectedLoyaltyClan { get; set; }

		public ICommand NewLoyaltyClanCommand { get; set; }
		public ICommand UpdateLoyaltyClanCommand { get; set; }
		public ICommand DeleteLoyaltyClanCommand { get; set; }
		public ICommand RefreshCommand { get; set; }

		public bool CanUpdateLoyaltyClan { get => SelectedLoyaltyClan != null; }
		public bool CanDeleteLoyaltyClan { get => SelectedLoyaltyClan != null; }


		public LoyaltyClanViewModel()
		{
			Clanovi = LoyaltyClanManager.Instance.RetrieveAll();
			NewLoyaltyClanCommand = new NewLoyaltyClanCommand(this);
			UpdateLoyaltyClanCommand = new UpdateLoyaltyClanCommand(this);
			DeleteLoyaltyClanCommand = new DeleteLoyaltyClanCommand(this);
			RefreshCommand = new RefreshLoyaltyClanCommand(this);
			//SelectedLoyaltyClan = null;
		}

		internal void NewLoyaltyClan()
		{
			new NewLoyaltyClanView(false).ShowDialog();
			Refresh();
		}
		internal void UpdateLoyaltyClan()
		{
			new NewLoyaltyClanView(false, SelectedLoyaltyClan).ShowDialog();
			Refresh();
		}

		internal void DeleteLoyaltyClan()
		{
			var res = MessageBox.Show($"Jeste li sigurni da želite obrisati člana {SelectedLoyaltyClan.Ime} {SelectedLoyaltyClan.Prezime}?",
				"Potvdra", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes)
			{
				try
				{
					if (LoyaltyClanManager.Instance.DeleteLoyaltyClan(SelectedLoyaltyClan.ID_Clana))
					{
						MessageBox.Show($"Uspešno obrisan član {SelectedLoyaltyClan.Ime} {SelectedLoyaltyClan.Prezime}");
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
			Clanovi = LoyaltyClanManager.Instance.RetrieveAll();
		}


	}

	public class LoyaltyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			LoyaltyClan clan = LoyaltyClanManager.Instance.RetrieveLoyaltyClan(int.Parse(value.ToString()));
			string param = parameter.ToString();
			if (clan is VIP)
			{
				if (param == "Tip")
					return "VIP";
				else if (param == "Popust")
					return ((VIP)clan).Popust.ToString() + "%";
			}
			else if (clan is Senior)
			{
				if (param == "Tip")
					return "Senior";
				else if (param == "BPO")
					return ((Senior)clan).BPO.ToString();
			}
			return "/";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return DependencyProperty.UnsetValue; // according to documentation
		}
	}

}
