using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.Commands.Glumac;

namespace UI.ViewModel
{
	public class NewGlumacViewModel
	{
		private Window window;

		public bool IsNew { get; set; } = true;
		public bool IsEdit { get; set; } = false;
		public Glumac Glumac { get; set; }

		public ICommand AddGlumacCommand { get; set; }
		public ICommand EditGlumacCommand { get; set; }
		public bool CanAddGlumac
		{
			get => !string.IsNullOrWhiteSpace(Glumac.Ime) &&
					!string.IsNullOrWhiteSpace(Glumac.Prezime) &&
					!string.IsNullOrWhiteSpace(Glumac.Ime_lika);
		}

		public NewGlumacViewModel(Window w, Glumac p)
		{
			window = w;
			if (p == null)
			{
				Glumac = new Glumac();
				IsNew = true;
				IsEdit = false;
			}
			else
			{
				Glumac = p;
				IsNew = false;
				IsEdit = true;
			}
			AddGlumacCommand = new AddGlumacCommand(this);
			EditGlumacCommand = new EditGlumacCommand(this);
		}


		internal void AddGlumac()
		{
			try
			{
				if (GlumacManager.Instance.AddGlumac(Glumac))
				{
					var res = MessageBox.Show("Glumac uspešno dodan!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Glumac već postoji.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}

		internal void EditGlumac()
		{
			try
			{
				if (GlumacManager.Instance.UpdateGlumac(Glumac))
				{
					var res = MessageBox.Show("Glumac uspešno izmenjen!");
					window.Close();
				}
				else
				{
					MessageBox.Show("Glumac nije uspešno izmenjen.");
				}
			}
			catch
			{
				MessageBox.Show("Connection error.", "Error", MessageBoxButton.OK);
			}
		}
	}

}
