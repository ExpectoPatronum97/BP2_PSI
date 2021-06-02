using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands.Scenarista
{
	public class ShowScenariosCommand : ICommand
	{
		private ScenaristaViewModel viewModel;

		public ShowScenariosCommand(ScenaristaViewModel viewModel)
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
			return viewModel.SelectedScenarista != null;
		}

		public void Execute(object parameter)
		{
			viewModel.ShowScenarios();
		}
	}
}
