create or alter TRIGGER CascadeDeleteClan
on dbo.LoyaltyClanovi
instead of delete
as

	delete from Karte
	where GledalacRBR in (select RBR from Gledaoci where ID_Clana in (select ID_Clana from deleted))

	delete from Gledaoci
	where ID_Clana in (SELECT ID_Clana from deleted)

	delete from LoyaltyClanovi
	where ID_Clana in (SELECT ID_Clana from deleted)