-- Funkcija vraca ime grada sa najvise pogledanih predstava

set ansi_nulls on
go
set quoted_identifier on
go

create or alter function MostViewedCity() 
returns nvarchar(max)
as
begin
    declare @retval as nvarchar(max);

    select top 1 @retval = Pozorista.Mesto from
			((((Scenaristi inner join NapisaoN on Scenaristi.ID_Scenariste = NapisaoN.ID_Scenariste)
			inner join Predstave on Predstave.ID_Predstave = NapisaoN.ID_Predstave)
			inner join Karte on Karte.ID_Predstave = Predstave.ID_Predstave)
			inner join Pozorista on Pozorista.ID_Pozorista = Karte.ID_Pozorista)
			where GledalacRBR is not null
			group by Pozorista.Mesto
			order by count(*) DESC
    return @retval;
    end;
go


