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
using UI.Commands.LoyaltyClan;

namespace UI.ViewModel
{
	public class NewLoyaltyClanViewModel : BindableBase
	{
		private Window window;

		private string selectedTip;
		public string SelectedTip
		{
			get { return selectedTip; }
			set 
			{ 
				SetProperty(ref selectedTip, value);
				LoyaltyLabelContent = selectedTip == "VIP" ? "Popust" : "BPO";
			}
		}

		private BindingList<string> tipovi;
		public BindingList<string> Tipovi
		{
			get { return tipovi; }
			set { SetProperty(ref tipovi, value); }
		}

		private string loyaltyLabelContent;
		public string LoyaltyLabelContent
		{
			get { return selectedTip=="VIP" ? "Popust" : "BPO"; }
			set { SetProperty(ref loyaltyLabelContent, value); }
		}

		private string selectedExtra;
		public string SelectedExtra
		{
			get { return selectedExtra; }
			set { SetProperty(ref selectedExtra, value); }
		}

		public bool IsNew { get; set; } = true;
		public bool IsEdit { get; set; } = false;
		public LoyaltyClan LoyaltyClan { get; set; }

		public ICommand AddLoyaltyClanCommand { get; set; }
		public ICommand EditLoyaltyClanCommand { get; set; }
		public bool CanAddLoyaltyClan
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(LoyaltyClan.Ime) &&
					!string.IsNullOrWhiteSpace(LoyaltyClan.Prezime) &&
					!string.IsNullOrWhiteSpace(LoyaltyClan.JMBG) &&
					!string.IsNullOrWhiteSpace(SelectedExtra) && 
					(LoyaltyClan.JMBG.Length == 13) && !LoyaltyClan.JMBG.Any(x=>x<'0'||x>'9'))
				{

					if (SelectedTip == "VIP")
					{
						if (int.TryParse(SelectedExtra, out int popust))
						{
							return popust >= 0 && popust <= 50;
						}
					}
					else
						return true;
				}
				return false;
			}
		}

		public NewLoyaltyClanViewModel(Window w, LoyaltyClan p, bool shouldWriteGledalac)
		{
			window = w;
			Tipovi = new BindingList<string> { "VIP", "Senior" };
			SelectedTip = Tipovi[0];
			if (p == null)
			{
				LoyaltyClan = new LoyaltyClan();
				IsNew = true;
				IsEdit = false;
			}
			else
			{
				LoyaltyClan = p;
				if (p is VIP)
				{
					SelectedExtra = ((VIP)p).Popust.ToString();
					SelectedTip = "VIP";
				}
				else if (p is Senior)
				{
					SelectedExtra = ((Senior)p).BPO;
					SelectedTip = "Senior";
				}
				IsNew = false;
				IsEdit = true;
			}
			AddLoyaltyClanCommand = new AddLoyaltyClanCommand(this);
			EditLoyaltyClanCommand = new EditLoyaltyClanCommand(this);
		}


		internal void AddLoyaltyClan()
		{
			try
			{
				if (SelectedTip == "VIP")
				{
					VIP clan = new VIP
					{
						Ime = LoyaltyClan.Ime,
						Prezime = LoyaltyClan.Prezime,
						JMBG = LoyaltyClan.JMBG,
						Popust = int.Parse(SelectedExtra)
					};
					if (LoyaltyClanManager.Instance.AddLoyaltyClan(clan))
					{
						var res = MessageBox.Show("Član uspešno dodan!");
						window.Close();
					}
					else
					{
						MessageBox.Show("Član već postoji.");
					}
				}
				else if (SelectedTip == "Senior")
				{
					Senior clan = new Senior
					{
						Ime = LoyaltyClan.Ime,
						Prezime = LoyaltyClan.Prezime,
						JMBG = LoyaltyClan.JMBG,
						BPO = SelectedExtra
					};
					if (LoyaltyClanManager.Instance.AddLoyaltyClan(clan))
					{
						var res = MessageBox.Show("Član uspešno dodan!");
						window.Close();
					}
					else
					{
						MessageBox.Show("Član već postoji.");
					}
				}
				
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}

		internal void EditLoyaltyClan()
		{
			try
			{
				if (LoyaltyClanManager.Instance.UpdateLoyaltyClan(LoyaltyClan))
				{
					var res = MessageBox.Show("Član uspešno izmenjen!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Član nije uspešno izmenjen.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}
	}

}
