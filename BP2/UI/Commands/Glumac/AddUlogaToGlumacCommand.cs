using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands.Glumac
{
	public class AddUlogaToGlumacCommand : ICommand
	{
		private AddUlogeViewModel viewModel;

		public AddUlogaToGlumacCommand(AddUlogeViewModel viewModel)
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
			return viewModel.CanAddUloga;
		}

		public void Execute(object parameter)
		{
			viewModel.AddUloga();
		}
	}
}
