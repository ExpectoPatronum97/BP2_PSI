using DatabaseModel;
using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands.Scenarista;

namespace UI.ViewModel
{
	public class AddScenarioViewModel : BindableBase
	{
		private int ID_Scenariste;

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


		public ICommand AddScenarioToScenaristaCommand { get; set; }
		public ICommand RemoveScenarioFromScenaristaCommand { get; set; }

		public bool CanAddScenario { get => SelectedDostupnaPredstava != null; }
		public bool CanDeleteScenario { get => SelectedTrenutnaPredstava != null; }

		public AddScenarioViewModel(int id_scenariste)
		{
			ID_Scenariste = id_scenariste;
			TrenutnePredstave = ScenaristaManager.Instance.RetrieveAllScenarioFrom(id_scenariste);
			DostupnePredstave = ScenaristaManager.Instance.RetrieveAllScenarioNOTFrom(id_scenariste);

			AddScenarioToScenaristaCommand = new AddScenarioToScenaristaCommand(this);
			RemoveScenarioFromScenaristaCommand = new RemoveScenarioFromScenaristaCommand(this);
		}

		internal void AddScenario()
		{
			ScenaristaManager.Instance.AddScenario(ID_Scenariste, SelectedDostupnaPredstava.ID_Predstave);
			TrenutnePredstave.Add(SelectedDostupnaPredstava);
			DostupnePredstave.Remove(SelectedDostupnaPredstava);
			//SelectedDostupnaPredstava = DostupnePredstave.Count > 0 ? DostupnePredstave[0] : null;
			SelectedDostupnaPredstava = null;
		}

		internal void DeleteScenario()
		{
			ScenaristaManager.Instance.DeleteScenario(ID_Scenariste, SelectedTrenutnaPredstava.ID_Predstave);
			DostupnePredstave.Add(SelectedTrenutnaPredstava);
			TrenutnePredstave.Remove(SelectedTrenutnaPredstava);
			//SelectedTrenutnaPredstava = TrenutnePredstave.Count > 0 ? TrenutnePredstave[0] : null;
			SelectedTrenutnaPredstava = null;
		}
	}

}
