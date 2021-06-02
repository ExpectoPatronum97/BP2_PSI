using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands
{
	public class NavigationCommand : ICommand
	{
		private MainWindowViewModel viewModel;
		public NavigationCommand(MainWindowViewModel viewModel)
		{
			this.viewModel = viewModel;
		}
		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}


		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			string param = parameter as string;
			if (param.Equals("Pozorista"))
			{
				viewModel.CurrentViewModel = new PozoristeViewModel();
			}
			else if (param.Equals("Predstave"))
			{
				viewModel.CurrentViewModel = new PredstavaViewModel();
			}
			else if (param.Equals("Sale"))
			{
				viewModel.CurrentViewModel = new SalaViewModel();
			}
			else if (param.Equals("Glumci"))
			{
				viewModel.CurrentViewModel = new GlumacViewModel();
			}
			else if (param.Equals("Scenaristi"))
			{
				viewModel.CurrentViewModel = new ScenaristaViewModel();
			}
			else if (param.Equals("Loyalty"))
			{
				viewModel.CurrentViewModel = new LoyaltyClanViewModel();
			}
			else if (param.Equals("Karte"))
			{
				viewModel.CurrentViewModel = new KartaViewModel();
			}
		}
	}
}
