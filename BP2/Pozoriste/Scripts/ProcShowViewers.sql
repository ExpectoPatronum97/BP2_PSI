-- Prikazuje informacije o loyalty clanu koji je pogledao neku predstavu u kojoj je glumio PARAMETAR
CREATE or 
ALTER procedure [dbo].[ShowViewers](@ime_glumca nvarchar(max), @prezime_glumca nvarchar(max))
  as
  declare PROJECT_CURSOR cursor
  for select distinct LoyaltyClanovi.Ime, LoyaltyClanovi.Prezime, LoyaltyClanovi.JMBG from 
	(((((Gledaoci inner join LoyaltyClanovi on Gledaoci.ID_Clana = LoyaltyClanovi.ID_Clana)
	inner join Karte on Karte.GledalacRBR = Gledaoci.RBR)
	inner join Predstave on Predstave.ID_Predstave = Karte.ID_Predstave)
	inner join GlumioN on Predstave.ID_Predstave = GlumioN.ID_Predstave)
	inner join Glumci on Glumci.ID_Glumca = GlumioN.ID_Glumca)
	where Glumci.Ime = @ime_glumca and Glumci.Prezime = @prezime_glumca;

	declare @ime nvarchar(max), @prezime nvarchar(max), @jmbg nvarchar(max);
	begin

	open PROJECT_CURSOR;
	fetch next from PROJECT_CURSOR INTO @ime, @prezime, @jmbg
	while @@FETCH_STATUS = 0
		begin
			print @ime + ' ' + @prezime + ' ' + @jmbg;
			fetch next from PROJECT_CURSOR INTO  @ime, @prezime, @jmbg;
		end;
	close PROJECT_CURSOR;
	deallocate PROJECT_CURSOR;

end

/*
declare @ime nvarchar(max), @prezime nvarchar(max)
select @ime = 'Alan';
select @prezime = 'Rickman'

exec [ShowViewers] @ime, @prezime
go
*/
