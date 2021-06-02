-- Prikazuje Ime i prezime loyalty clana koji je pogledao bar neku predstavu u pozoristu u mestu koji se prosledi kao paramtar
CREATE or 
ALTER procedure [dbo].[ShowAllFromMesto](@mesto nvarchar(max))
  as
  declare PROJECT_CURSOR cursor
  for select distinct LoyaltyClanovi.Ime, LoyaltyClanovi.Prezime from 
	(((Gledaoci inner join LoyaltyClanovi on Gledaoci.ID_Clana = LoyaltyClanovi.ID_Clana)
	inner join Karte on Karte.GledalacRBR = Gledaoci.RBR)
	inner join Pozorista on Pozorista.ID_Pozorista = Karte.ID_Pozorista)
	where Mesto = @mesto

	declare @Ime nvarchar(max), @Prezime nvarchar(max);
	begin

	open PROJECT_CURSOR;
	fetch next from PROJECT_CURSOR INTO @Ime, @Prezime
	while @@FETCH_STATUS = 0
		begin
			print @Ime + ' ' + @prezime
			fetch next from PROJECT_CURSOR INTO  @Ime, @Prezime; 
		end;
	close PROJECT_CURSOR;
	deallocate PROJECT_CURSOR;

end
go

/*
declare @mesto nvarchar(max)
select @mesto = 'Novi Sad';

exec [ShowAllFromMesto] @mesto
go
*/
