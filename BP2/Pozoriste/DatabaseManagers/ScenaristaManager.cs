using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class ScenaristaManager
	{
		#region Singleton
		private ScenaristaManager() { }
		private static ScenaristaManager instance = null;
		public static ScenaristaManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ScenaristaManager();
				}
				return instance;
			}
		}
		#endregion

		// Create
		public bool AddScenarista(Scenarista s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.Scenaristi.Add(s);
					db.SaveChanges();
					return true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}
		}
		// Read
		public Scenarista RetrieveScenarista(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.Scenaristi.FirstOrDefault(x => x.ID_Scenariste == id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		// Update
		public bool UpdateScenarista(Scenarista s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Scenarista temp = db.Scenaristi.FirstOrDefault(x => x.ID_Scenariste == s.ID_Scenariste);
					if (temp != null)
					{
						temp.Ime = s.Ime;
						temp.Prezime = s.Prezime;
						temp.Broj_predstava = s.Broj_predstava;
						db.SaveChanges();
						return true;
					}
					else
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
			}
		}

		// Delete
		public bool DeleteScenarista(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Scenarista temp = db.Scenaristi.SingleOrDefault(x => x.ID_Scenariste == id);
					if (temp != null)
					{
						db.Scenaristi.Remove(temp);
						db.SaveChanges();
						return true;
					}
					else
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
			}
		}

		public BindingList<Scenarista> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<Scenarista>(db.Scenaristi.ToList());
				}
				catch
				{
					return null;
				}
			}
		}

		public bool AddScenario(int id_scenariste, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Napisao o = new Napisao
					{
						ID_Scenariste = id_scenariste,
						ID_Predstave = id_predstave
					};
					db.NapisaoN.Add(o);
					db.SaveChanges();

					// mozda triger?
					Scenarista s = RetrieveScenarista(id_scenariste);
					s.Broj_predstava++;
					UpdateScenarista(s);
					db.SaveChanges();
					return true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return false;
				}
			}
		}


		public bool IsScenario(int id_scenariste, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.NapisaoN.Any(x => x.ID_Predstave == id_predstave && x.ID_Scenariste == id_scenariste);
				}
				catch
				{
					return false;
				}
			}
		}

		public bool DeleteScenario(int id_scenariste, int id_predstave)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Napisao temp = db.NapisaoN.SingleOrDefault(x => x.ID_Predstave == id_predstave && x.ID_Scenariste == id_scenariste);
					if (temp != null)
					{
						db.NapisaoN.Remove(temp);
						db.SaveChanges();
						// mozda triger?
						Scenarista s = RetrieveScenarista(id_scenariste);
						s.Broj_predstava--;
						UpdateScenarista(s);
						db.SaveChanges();
						return true;
					}
					else
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
			}
		}

		public BindingList<Predstava> RetrieveAllScenarioFrom(int id_scenariste)
		{
			using (var db = new PozoristeDbContainer())
			{
				BindingList<Predstava> predstave = PredstavaManager.Instance.RetrieveAll();
				var q = from p in predstave
						where db.NapisaoN.Any(x => x.ID_Scenariste == id_scenariste && x.ID_Predstave == p.ID_Predstave)
						select p;
				return new BindingList<Predstava>(q.ToList());
			}
		}

		public BindingList<Predstava> RetrieveAllScenarioNOTFrom(int id_scenariste)
		{
			using (var db = new PozoristeDbContainer())
			{
				BindingList<Predstava> predstave = PredstavaManager.Instance.RetrieveAll();
				var q = from p in predstave
						where !db.NapisaoN.Any(x => x.ID_Scenariste == id_scenariste && x.ID_Predstave == p.ID_Predstave)
						select p;
				return new BindingList<Predstava>(q.ToList());
			}
		}
	}

}
