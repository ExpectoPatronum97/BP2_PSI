create or alter TRIGGER ClanJMBGChecker
on dbo.LoyaltyClanovi
after insert
as

	declare @jmbg nvarchar(max);
	select @jmbg = JMBG from inserted;
	if (select Count(JMBG) from LoyaltyClanovi where JMBG like @jmbg) > 1
	begin
		rollback;
		raiserror ('JMBG vec postoji', 16, 1);
	end

--drop trigger ClanJMBGChecker