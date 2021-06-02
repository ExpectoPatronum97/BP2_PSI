using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.ViewModel;

namespace UI.Commands.Karta
{
	public class BuyTicketCommand : ICommand
	{
		private KartaViewModel viewModel;

		public BuyTicketCommand(KartaViewModel viewModel)
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
			return viewModel.SelectedKarta != null && viewModel.SelectedKarta.GledalacRBR == null;
		}

		public void Execute(object parameter)
		{
			viewModel.BuyTicket();
		}
	}
}
