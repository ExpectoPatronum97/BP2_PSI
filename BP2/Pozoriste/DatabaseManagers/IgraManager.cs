using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class IgraManager
	{
		#region Singleton
		private IgraManager() { }
		private static IgraManager instance = null;
		public static IgraManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new IgraManager();
				}
				return instance;
			}
		}
		#endregion

		// Create
		public bool AddIgra(Igra s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.IgraN.Add(s);
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
		/*
		public Igra RetrieveIgra(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.IgraN.FirstOrDefault(x => x.ID_Pozorista == ID_Pozorista
													&& x.ID_Predstave == s.ID_Predstave
													&& x.ID_Sale == s.ID_Sale);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		// Update
		public bool UpdateIgra(Igra s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Igra temp = db.IgraN.FirstOrDefault(x => x.ID_Pozorista == s.ID_Pozorista 
														  && x.ID_Predstave == s.ID_Predstave
														  && x.ID_Sale == s.ID_Sale);
					if (temp != null)
					{
						//temp.I
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
		public bool DeleteIgra(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Igra temp = db.IgraN.SingleOrDefault(x => x.RBR == id);
					if (temp != null)
					{
						db.IgraN.Remove(temp);
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
		*/
		public BindingList<Igra> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<Igra>(db.IgraN.ToList());
				}
				catch
				{
					return null;
				}
			}
		}
	}

}
