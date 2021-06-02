using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands.Sala;

namespace UI.ViewModel
{
	public class AddPredstavaToSalaViewModel : BindableBase
	{
		private int ID_Sale, ID_Pozorista;

		private BindingList<Predstava> dostupnePredstave;
		public BindingList<Predstava> DostupnePredstave
		{
			get { return dostupnePredstave; }
			set { SetProperty(ref dostupnePredstave, value); }
		}

		private BindingList<Predstava> trenutnePredstave;
		public BindingList<Predstava> TrenutnePredstave
		{
			get { return trenutnePredstave; }
			set { SetProperty(ref trenutnePredstave, value); }
		}

		public Predstava SelectedTrenutnaPredstava { get; set; }
		public Predstava SelectedDostupnaPredstava { get; set; }


		public ICommand AddPredstavaToSalaCommand { get; set; }
		public ICommand RemovePredstavaFromSalaCommand { get; set; }

		public bool CanAddPredstava { get => SelectedDostupnaPredstava != null; }
		public bool CanDeletePredstava { get => SelectedTrenutnaPredstava != null; }

		public AddPredstavaToSalaViewModel(int id_sale, int id_pozorista)
		{
			ID_Sale = id_sale;
			ID_Pozorista = id_pozorista;
			TrenutnePredstave = SalaManager.Instance.RetrieveAllPredstaveFrom(id_sale, id_pozorista);
			DostupnePredstave = SalaManager.Instance.RetrieveAllPredstaveNOTFrom(id_sale, id_pozorista);

			AddPredstavaToSalaCommand = new AddPredstavaToSalaCommand(this);
			RemovePredstavaFromSalaCommand = new RemovePredstavaFromSalaCommand(this);
		}

		internal void AddPredstava()
		{
			SalaManager.Instance.AddPredstava(ID_Sale, ID_Pozorista, SelectedDostupnaPredstava.ID_Predstave);
			TrenutnePredstave.Add(SelectedDostupnaPredstava);
			DostupnePredstave.Remove(SelectedDostupnaPredstava);
			//SelectedDostupnaPredstava = DostupnePredstave.Count > 0 ? DostupnePredstave[0] : null;
			SelectedDostupnaPredstava = null;
		}

		internal void DeletePredstava()
		{
			SalaManager.Instance.DeletePredstava(ID_Sale, ID_Pozorista, SelectedDostupnaPredstava.ID_Predstave);
			DostupnePredstave.Add(SelectedTrenutnaPredstava);
			TrenutnePredstave.Remove(SelectedTrenutnaPredstava);
			//SelectedTrenutnaPredstava = TrenutnePredstave.Count > 0 ? TrenutnePredstave[0] : null;
			SelectedTrenutnaPredstava = null;
		}
	}
}
