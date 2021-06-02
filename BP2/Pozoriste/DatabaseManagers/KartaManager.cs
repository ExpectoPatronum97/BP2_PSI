using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class KartaManager
	{
		#region Singleton
		private KartaManager() { }
		private static KartaManager instance = null;
		public static KartaManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new KartaManager();
				}
				return instance;
			}
		}
		#endregion

		// Create
		public bool AddKarta(Karta s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.Karte.Add(s);
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
		public Karta RetrieveKarta(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.Karte.FirstOrDefault(x => x.ID_Karte == id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		// Update
		public bool UpdateKarta(Karta s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Karta temp = db.Karte.FirstOrDefault(x => x.ID_Karte == s.ID_Karte);
					if (temp != null)
					{
						temp.Sediste = s.Sediste;
						temp.Red = s.Red;
						temp.Datum = s.Datum;
						temp.Cena = s.Cena;
						temp.GledalacRBR = s.GledalacRBR;
						temp.ID_Pozorista = s.ID_Pozorista;
						temp.ID_Predstave = s.ID_Predstave;
						temp.ID_Sale = s.ID_Sale;
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
		public bool DeleteKarta(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Karta temp = db.Karte.SingleOrDefault(x => x.ID_Karte == id);
					if (temp != null)
					{
						db.Karte.Remove(temp);
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

		public BindingList<Karta> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<Karta>(db.Karte.ToList());
				}
				catch
				{
					return null;
				}
			}
		}
	}

}
