using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class PredstavaManager
	{
		#region Singleton
		private PredstavaManager() { }
		private static PredstavaManager instance = null;
		public static PredstavaManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new PredstavaManager();
				}
				return instance;
			}
		}
		#endregion

		// Create
		public bool AddPredstava(Predstava p)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.Predstave.Add(p);
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
		public Predstava RetrievePredstava(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.Predstave.FirstOrDefault(x => x.ID_Predstave == id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		// Update
		public bool UpdatePredstava(Predstava p)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Predstava temp = db.Predstave.Find(p.ID_Predstave);
					if (temp != null)
					{
						temp.Naziv = p.Naziv;
						temp.Trajanje = p.Trajanje;
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
		public bool DeletePredstava(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Predstava temp = db.Predstave.Find(id);
					if (temp != null)
					{
						db.Predstave.Remove(temp);
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


		public BindingList<Predstava> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<Predstava>(db.Predstave.ToList());
				}
				catch
				{
					return null;
				}
			}
		}
	}
}
