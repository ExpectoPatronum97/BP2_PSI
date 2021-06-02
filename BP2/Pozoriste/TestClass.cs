using DatabaseModel.DatabaseManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
	public class TestClass
	{
		public TestClass()
		{

		}

		public void GenerateData()
		{
			using (var db = new PozoristeDbContainer())
			{
				for (int i = 0; i < 17; i++)
				{
					Karta k = new Karta
					{
						Cena = 30,
						Datum = new DateTime(2021, 6, 5, 18, 30, 0),
						Sediste = (i % 5 + 1).ToString(),
						Red = new string((char)('A' + (i / 5)), 1),
						ID_Pozorista = 1,
						ID_Sale = 1,
						ID_Predstave = 1,
						//GledalacRBR = i%2==0?4:5
					};
					KartaManager.Instance.AddKarta(k);
					db.SaveChanges();
				}
			}
		}
	}
}
