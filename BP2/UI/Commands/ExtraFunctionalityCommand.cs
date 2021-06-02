using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands
{
	public class ExtraFunctionalityCommand : ICommand
	{
		private MainWindowViewModel viewModel;
		public ExtraFunctionalityCommand(MainWindowViewModel viewModel)
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
			if (param.Equals("FnMostViewed"))
			{
				viewModel.FnMostViewed();
			}
			else if (param.Equals("FnTotalNumber"))
			{
				viewModel.FnTotalNumber();
			}
			else if (param.Equals("ProcShowFromMesto"))
			{
				viewModel.ProcShowFromMesto();
			}
			else if (param.Equals("ProcShowViewers"))
			{
				viewModel.ProcShowViewers();
			}
		}
	}
}
