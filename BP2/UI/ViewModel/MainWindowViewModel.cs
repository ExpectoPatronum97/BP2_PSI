using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModel
{
	public class MainWindowViewModel : BindableBase
	{
		private Window window;
		public ICommand NavigationCommand { get; set; }
		public ICommand ExtraFunctionalityCommand { get; set; }
		private BindableBase currentViewModel;
		public BindableBase CurrentViewModel
		{
			get { return currentViewModel; }
			set { SetProperty(ref currentViewModel, value); }
		}
		
		public MainWindowViewModel(Window w)
		{
			window = w;
			NavigationCommand = new NavigationCommand(this);
			CurrentViewModel = new PozoristeViewModel();
			ExtraFunctionalityCommand = new ExtraFunctionalityCommand(this);
			//TestClass ts = new TestClass();
			//ts.GenerateData();
		}

		internal void ProcShowFromMesto()
		{
			string mesto = "Novi Sad";
			var temp = ExtraFunctionalityManager.Instance.ProcShowAllFromMesto(mesto);
			MessageBox.Show(temp.Count.ToString());
		}

		internal void ProcShowViewers()
		{
			string ime = "Alan";
			string prezime = "Rickman";
			var temp = ExtraFunctionalityManager.Instance.ProcShowViewers(ime, prezime);
			MessageBox.Show(temp.Count.ToString());
		}

		internal void FnTotalNumber()
		{
			// nemam vremena, vec je 23:45 :(
			string ime = "Jovan";
			string prezime = "Jovanovic";
			int ret = ExtraFunctionalityManager.Instance.FnTotalNumberOfViewers(ime, prezime);
			MessageBox.Show($"Ukupan broj gledalaca za scenaristu {ime} {prezime} je {ret}");
		}

		internal void FnMostViewed()
		{
			string str = ExtraFunctionalityManager.Instance.FnMostViewedCity();
			MessageBox.Show("Najposeceniji grad je " + str);
		}
	}

}
