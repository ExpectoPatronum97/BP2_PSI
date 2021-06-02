-- Funkcija vraca ukupan broj ljudi koji su pogledali predstavu koju je napisao scenarista PARAMETAR

set ansi_nulls on
go
set quoted_identifier on
go

create or alter function TotalNumberOfViewers(@ime_sc nvarchar(max), @prezime_sc nvarchar(max)) 
returns decimal
as
begin
    declare @retval as decimal;

    select @retval = count(*) from
			(((Scenaristi inner join NapisaoN on Scenaristi.ID_Scenariste = NapisaoN.ID_Scenariste)
			inner join Predstave on Predstave.ID_Predstave = NapisaoN.ID_Predstave)
			inner join Karte on Karte.ID_Predstave = Predstave.ID_Predstave)
			where GledalacRBR is not null and Scenaristi.Ime = @ime_sc and Scenaristi.Prezime = @prezime_sc;
    return @retval;
    end;
go





