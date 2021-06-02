using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using UI.Commands.Pozoriste;

namespace UI.ViewModel
{
	public class NewPozoristeViewModel
	{
		private Window window;

		public bool IsNew { get; set; } = true;
		public bool IsEdit { get; set; } = false;
		public Pozoriste Pozoriste { get; set; }

		public ICommand AddPozoristeCommand { get; set; }
		public ICommand EditPozoristeCommand { get; set; }
		public bool CanAddPozoriste
		{
			get => !string.IsNullOrWhiteSpace(Pozoriste.Naziv) &&
					!string.IsNullOrWhiteSpace(Pozoriste.Ulica) &&
					!string.IsNullOrWhiteSpace(Pozoriste.Mesto);
		}

		public NewPozoristeViewModel(Window w, Pozoriste p)
		{
			window = w;
			if (p == null)
			{
				Pozoriste = new Pozoriste();
				IsNew = true;
				IsEdit = false;
			}
			else
			{
				Pozoriste = p;
				IsNew = false;
				IsEdit = true;
			}
			AddPozoristeCommand = new AddPozoristeCommand(this);
			EditPozoristeCommand = new EditPozoristeCommand(this);
		}

		internal void AddPozoriste()
		{
			try
			{
				if (PozoristeManager.Instance.AddPozoriste(Pozoriste))
				{
					var res = MessageBox.Show("Pozorište uspešno dodano!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Pozorište već postoji.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}

		internal void EditPozoriste()
		{
			try
			{
				if (PozoristeManager.Instance.UpdatePozoriste(Pozoriste))
				{
					var res = MessageBox.Show("Pozorište uspešno izmenjeno!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Pozorište nije uspešno izmenjeno.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}
	}
}
