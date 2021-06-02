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
using UI.Commands.Glumac;
using UI.View.Glumac;

namespace UI.ViewModel
{
	public class GlumacViewModel : BindableBase
	{
		private BindingList<Glumac> glumci;
		public BindingList<Glumac> Glumci
		{
			get { return glumci; }
			set { SetProperty(ref glumci, value); }
		}

		public Glumac SelectedGlumac { get; set; }

		public ICommand NewGlumacCommand { get; set; }
		public ICommand UpdateGlumacCommand { get; set; }
		public ICommand DeleteGlumacCommand { get; set; }
		public ICommand RefreshCommand { get; set; }
		public ICommand ShowUlogeCommand { get; set; }

		public bool CanUpdateGlumac { get => SelectedGlumac != null; }
		public bool CanDeleteGlumac { get => SelectedGlumac != null; }


		public GlumacViewModel()
		{
			Glumci = GlumacManager.Instance.RetrieveAll();
			NewGlumacCommand = new NewGlumacCommand(this);
			UpdateGlumacCommand = new UpdateGlumacCommand(this);
			DeleteGlumacCommand = new DeleteGlumacCommand(this);
			RefreshCommand = new RefreshGlumacCommand(this);
			ShowUlogeCommand = new ShowUlogeCommand(this);
			//SelectedGlumac = null;
		}

		internal void NewGlumac()
		{
			new NewGlumacView().ShowDialog();
			Refresh();
		}
		internal void UpdateGlumac()
		{
			new NewGlumacView(SelectedGlumac).ShowDialog();
			Refresh();
		}

		internal void DeleteGlumac()
		{
			var res = MessageBox.Show($"Jeste li sigurni da želite obrisati glumca {SelectedGlumac.Ime} + {SelectedGlumac.Prezime}?",
				"Potvdra", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes)
			{
				try
				{
					if (GlumacManager.Instance.DeleteGlumac(SelectedGlumac.ID_Glumca))
					{
						MessageBox.Show($"Uspešno obrisan Glumac {SelectedGlumac.Ime} + {SelectedGlumac.Prezime}");
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
			Glumci = GlumacManager.Instance.RetrieveAll();
		}

		internal void ShowUloge()
		{
			new AddUlogeView(SelectedGlumac.ID_Glumca).ShowDialog();
			Refresh();
		}

	}
	public class UlogaConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return GlumacManager.Instance.GetUlogaCount(int.Parse(value.ToString()));
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return DependencyProperty.UnsetValue; // according to documentation
		}
	}

}
