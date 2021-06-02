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
using UI.Commands.Sala;
using UI.View.Sala;

namespace UI.ViewModel
{
	public class SalaViewModel : BindableBase
	{
		private BindingList<Sala> sale;
		public BindingList<Sala> Sale
		{
			get { return sale; }
			set { SetProperty(ref sale, value); }
		}

		public Sala SelectedSala { get; set; }

		public ICommand NewSalaCommand { get; set; }
		public ICommand UpdateSalaCommand { get; set; }
		public ICommand DeleteSalaCommand { get; set; }
		public ICommand RefreshCommand { get; set; }
		public ICommand ShowOdrzavanjaCommand { get; set; }
		public bool CanUpdateSala { get => SelectedSala != null; }
		public bool CanDeleteSala { get => SelectedSala != null; }


		public SalaViewModel()
		{
			Sale = SalaManager.Instance.RetrieveAll();
			NewSalaCommand = new NewSalaCommand(this);
			UpdateSalaCommand = new UpdateSalaCommand(this);
			DeleteSalaCommand = new DeleteSalaCommand(this);
			RefreshCommand = new RefreshSalaCommand(this);
			ShowOdrzavanjaCommand = new ShowOdrzavanjaCommand(this);
			//SelectedSala = null;
		}

		internal void NewSala()
		{
			new NewSalaView().ShowDialog();
			Refresh();
		}
		internal void UpdateSala()
		{
			new NewSalaView(SelectedSala).ShowDialog();
			Refresh();
		}

		internal void DeleteSala()
		{
			var res = MessageBox.Show($"Jeste li sigurni da želite obrisati salu {SelectedSala.ID_Sale}?",
				"Potvdra", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (res == MessageBoxResult.Yes)
			{
				try
				{
					if (SalaManager.Instance.DeleteSala(SelectedSala.ID_Sale))
					{
						MessageBox.Show("Uspešno obrisana sala " + SelectedSala.ID_Sale);
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
			Sale = SalaManager.Instance.RetrieveAll();
		}

		internal void ShowOdrzavanja()
		{
			new AddPredstavaToSalaView(SelectedSala.ID_Sale, SelectedSala.ID_Pozorista).ShowDialog();
			Refresh();
		}
	}
	public class IDtoNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return PozoristeManager.Instance.RetrievePozoriste(int.Parse(value.ToString())).Naziv;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return DependencyProperty.UnsetValue; // according to documentation
		}
	}

}
