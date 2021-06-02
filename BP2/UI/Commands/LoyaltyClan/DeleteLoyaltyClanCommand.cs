using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands.LoyaltyClan
{
	public class DeleteLoyaltyClanCommand : ICommand
	{
		private LoyaltyClanViewModel viewModel;

		public DeleteLoyaltyClanCommand(LoyaltyClanViewModel viewModel)
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
			return viewModel.CanDeleteLoyaltyClan;
		}

		public void Execute(object parameter)
		{
			viewModel.DeleteLoyaltyClan();
		}
	}
}
