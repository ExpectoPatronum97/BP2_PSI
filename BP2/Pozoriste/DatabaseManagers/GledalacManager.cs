using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DatabaseManagers
{
	public class GledalacManager
	{
		#region Singleton
		private GledalacManager() { }
		private static GledalacManager instance = null;
		public static GledalacManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new GledalacManager();
				}
				return instance;
			}
		}
		#endregion

		// Create
		public bool AddGledalac(Gledalac s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					db.Gledaoci.Add(s);
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
		public Gledalac RetrieveGledalac(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return db.Gledaoci.FirstOrDefault(x => x.RBR == id);
				}
				catch (Exception)
				{
					return null;
				}
			}
		}

		// Update
		public bool UpdateGledalac(Gledalac s)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Gledalac temp = db.Gledaoci.FirstOrDefault(x => x.RBR == s.RBR);
					if (temp != null)
					{
						temp.ID_Clana = s.ID_Clana;
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
		public bool DeleteGledalac(int id)
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					Gledalac temp = db.Gledaoci.SingleOrDefault(x => x.RBR == id);
					if (temp != null)
					{
						db.Gledaoci.Remove(temp);
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

		public BindingList<Gledalac> RetrieveAll()
		{
			using (var db = new PozoristeDbContainer())
			{
				try
				{
					return new BindingList<Gledalac>(db.Gledaoci.ToList());
				}
				catch
				{
					return null;
				}
			}
		}
	}
}
