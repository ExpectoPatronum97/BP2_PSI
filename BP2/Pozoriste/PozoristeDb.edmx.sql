
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 17:17:21
-- Generated from EDMX file: C:\Users\jovan\source\repos\BP2\Pozoriste\PozoristeDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BP2_Pozoriste];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PozoristeOrganizuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizujeN] DROP CONSTRAINT [FK_PozoristeOrganizuje];
GO
IF OBJECT_ID(N'[dbo].[FK_PredstavaOrganizuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrganizujeN] DROP CONSTRAINT [FK_PredstavaOrganizuje];
GO
IF OBJECT_ID(N'[dbo].[FK_SalaPozoriste]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sale] DROP CONSTRAINT [FK_SalaPozoriste];
GO
IF OBJECT_ID(N'[dbo].[FK_IgraSala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IgraN] DROP CONSTRAINT [FK_IgraSala];
GO
IF OBJECT_ID(N'[dbo].[FK_PredstavaIgra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IgraN] DROP CONSTRAINT [FK_PredstavaIgra];
GO
IF OBJECT_ID(N'[dbo].[FK_ScenaristaNapisao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NapisaoN] DROP CONSTRAINT [FK_ScenaristaNapisao];
GO
IF OBJECT_ID(N'[dbo].[FK_PredstavaNapisao]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NapisaoN] DROP CONSTRAINT [FK_PredstavaNapisao];
GO
IF OBJECT_ID(N'[dbo].[FK_GlumioGlumac]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GlumioN] DROP CONSTRAINT [FK_GlumioGlumac];
GO
IF OBJECT_ID(N'[dbo].[FK_PredstavaGlumio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GlumioN] DROP CONSTRAINT [FK_PredstavaGlumio];
GO
IF OBJECT_ID(N'[dbo].[FK_IgraKarta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Karte] DROP CONSTRAINT [FK_IgraKarta];
GO
IF OBJECT_ID(N'[dbo].[FK_GledalacLoyaltyClan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gledaoci] DROP CONSTRAINT [FK_GledalacLoyaltyClan];
GO
IF OBJECT_ID(N'[dbo].[FK_GledalacKarta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Karte] DROP CONSTRAINT [FK_GledalacKarta];
GO
IF OBJECT_ID(N'[dbo].[FK_VIP_inherits_LoyaltyClan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoyaltyClanovi_VIP] DROP CONSTRAINT [FK_VIP_inherits_LoyaltyClan];
GO
IF OBJECT_ID(N'[dbo].[FK_Senior_inherits_LoyaltyClan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoyaltyClanovi_Senior] DROP CONSTRAINT [FK_Senior_inherits_LoyaltyClan];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Pozorista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pozorista];
GO
IF OBJECT_ID(N'[dbo].[Predstave]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Predstave];
GO
IF OBJECT_ID(N'[dbo].[OrganizujeN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizujeN];
GO
IF OBJECT_ID(N'[dbo].[Sale]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sale];
GO
IF OBJECT_ID(N'[dbo].[IgraN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IgraN];
GO
IF OBJECT_ID(N'[dbo].[Scenaristi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Scenaristi];
GO
IF OBJECT_ID(N'[dbo].[Glumci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Glumci];
GO
IF OBJECT_ID(N'[dbo].[NapisaoN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NapisaoN];
GO
IF OBJECT_ID(N'[dbo].[GlumioN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GlumioN];
GO
IF OBJECT_ID(N'[dbo].[Karte]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Karte];
GO
IF OBJECT_ID(N'[dbo].[LoyaltyClanovi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoyaltyClanovi];
GO
IF OBJECT_ID(N'[dbo].[Gledaoci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gledaoci];
GO
IF OBJECT_ID(N'[dbo].[LoyaltyClanovi_VIP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoyaltyClanovi_VIP];
GO
IF OBJECT_ID(N'[dbo].[LoyaltyClanovi_Senior]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoyaltyClanovi_Senior];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pozorista'
CREATE TABLE [dbo].[Pozorista] (
    [ID_Pozorista] int IDENTITY(1,1) NOT NULL,
    [Mesto] nvarchar(max)  NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Predstave'
CREATE TABLE [dbo].[Predstave] (
    [ID_Predstave] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Trajanje] int  NOT NULL
);
GO

-- Creating table 'OrganizujeN'
CREATE TABLE [dbo].[OrganizujeN] (
    [ID_Pozorista] int  NOT NULL,
    [ID_Predstave] int  NOT NULL
);
GO

-- Creating table 'Sale'
CREATE TABLE [dbo].[Sale] (
    [ID_Sale] int IDENTITY(1,1) NOT NULL,
    [Broj_sedista] int  NOT NULL,
    [ID_Pozorista] int  NOT NULL
);
GO

-- Creating table 'IgraN'
CREATE TABLE [dbo].[IgraN] (
    [ID_Sale] int  NOT NULL,
    [ID_Pozorista] int  NOT NULL,
    [ID_Predstave] int  NOT NULL
);
GO

-- Creating table 'Scenaristi'
CREATE TABLE [dbo].[Scenaristi] (
    [ID_Scenariste] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Broj_predstava] int  NOT NULL
);
GO

-- Creating table 'Glumci'
CREATE TABLE [dbo].[Glumci] (
    [ID_Glumca] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Ime_lika] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NapisaoN'
CREATE TABLE [dbo].[NapisaoN] (
    [ID_Scenariste] int  NOT NULL,
    [ID_Predstave] int  NOT NULL
);
GO

-- Creating table 'GlumioN'
CREATE TABLE [dbo].[GlumioN] (
    [ID_Glumca] int  NOT NULL,
    [ID_Predstave] int  NOT NULL
);
GO

-- Creating table 'Karte'
CREATE TABLE [dbo].[Karte] (
    [ID_Karte] int IDENTITY(1,1) NOT NULL,
    [Sediste] nvarchar(max)  NOT NULL,
    [Red] nvarchar(max)  NOT NULL,
    [Datum] datetime  NOT NULL,
    [Cena] float  NOT NULL,
    [ID_Sale] int  NOT NULL,
    [ID_Pozorista] int  NOT NULL,
    [ID_Predstave] int  NOT NULL,
    [GledalacRBR] int  NULL
);
GO

-- Creating table 'LoyaltyClanovi'
CREATE TABLE [dbo].[LoyaltyClanovi] (
    [ID_Clana] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [JMBG] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Gledaoci'
CREATE TABLE [dbo].[Gledaoci] (
    [RBR] int IDENTITY(1,1) NOT NULL,
    [ID_Clana] int  NULL
);
GO

-- Creating table 'LoyaltyClanovi_VIP'
CREATE TABLE [dbo].[LoyaltyClanovi_VIP] (
    [Popust] int  NOT NULL,
    [ID_Clana] int  NOT NULL
);
GO

-- Creating table 'LoyaltyClanovi_Senior'
CREATE TABLE [dbo].[LoyaltyClanovi_Senior] (
    [BPO] nvarchar(max)  NOT NULL,
    [ID_Clana] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID_Pozorista] in table 'Pozorista'
ALTER TABLE [dbo].[Pozorista]
ADD CONSTRAINT [PK_Pozorista]
    PRIMARY KEY CLUSTERED ([ID_Pozorista] ASC);
GO

-- Creating primary key on [ID_Predstave] in table 'Predstave'
ALTER TABLE [dbo].[Predstave]
ADD CONSTRAINT [PK_Predstave]
    PRIMARY KEY CLUSTERED ([ID_Predstave] ASC);
GO

-- Creating primary key on [ID_Pozorista], [ID_Predstave] in table 'OrganizujeN'
ALTER TABLE [dbo].[OrganizujeN]
ADD CONSTRAINT [PK_OrganizujeN]
    PRIMARY KEY CLUSTERED ([ID_Pozorista], [ID_Predstave] ASC);
GO

-- Creating primary key on [ID_Sale], [ID_Pozorista] in table 'Sale'
ALTER TABLE [dbo].[Sale]
ADD CONSTRAINT [PK_Sale]
    PRIMARY KEY CLUSTERED ([ID_Sale], [ID_Pozorista] ASC);
GO

-- Creating primary key on [ID_Sale], [ID_Pozorista], [ID_Predstave] in table 'IgraN'
ALTER TABLE [dbo].[IgraN]
ADD CONSTRAINT [PK_IgraN]
    PRIMARY KEY CLUSTERED ([ID_Sale], [ID_Pozorista], [ID_Predstave] ASC);
GO

-- Creating primary key on [ID_Scenariste] in table 'Scenaristi'
ALTER TABLE [dbo].[Scenaristi]
ADD CONSTRAINT [PK_Scenaristi]
    PRIMARY KEY CLUSTERED ([ID_Scenariste] ASC);
GO

-- Creating primary key on [ID_Glumca] in table 'Glumci'
ALTER TABLE [dbo].[Glumci]
ADD CONSTRAINT [PK_Glumci]
    PRIMARY KEY CLUSTERED ([ID_Glumca] ASC);
GO

-- Creating primary key on [ID_Predstave], [ID_Scenariste] in table 'NapisaoN'
ALTER TABLE [dbo].[NapisaoN]
ADD CONSTRAINT [PK_NapisaoN]
    PRIMARY KEY CLUSTERED ([ID_Predstave], [ID_Scenariste] ASC);
GO

-- Creating primary key on [ID_Glumca], [ID_Predstave] in table 'GlumioN'
ALTER TABLE [dbo].[GlumioN]
ADD CONSTRAINT [PK_GlumioN]
    PRIMARY KEY CLUSTERED ([ID_Glumca], [ID_Predstave] ASC);
GO

-- Creating primary key on [ID_Karte] in table 'Karte'
ALTER TABLE [dbo].[Karte]
ADD CONSTRAINT [PK_Karte]
    PRIMARY KEY CLUSTERED ([ID_Karte] ASC);
GO

-- Creating primary key on [ID_Clana] in table 'LoyaltyClanovi'
ALTER TABLE [dbo].[LoyaltyClanovi]
ADD CONSTRAINT [PK_LoyaltyClanovi]
    PRIMARY KEY CLUSTERED ([ID_Clana] ASC);
GO

-- Creating primary key on [RBR] in table 'Gledaoci'
ALTER TABLE [dbo].[Gledaoci]
ADD CONSTRAINT [PK_Gledaoci]
    PRIMARY KEY CLUSTERED ([RBR] ASC);
GO

-- Creating primary key on [ID_Clana] in table 'LoyaltyClanovi_VIP'
ALTER TABLE [dbo].[LoyaltyClanovi_VIP]
ADD CONSTRAINT [PK_LoyaltyClanovi_VIP]
    PRIMARY KEY CLUSTERED ([ID_Clana] ASC);
GO

-- Creating primary key on [ID_Clana] in table 'LoyaltyClanovi_Senior'
ALTER TABLE [dbo].[LoyaltyClanovi_Senior]
ADD CONSTRAINT [PK_LoyaltyClanovi_Senior]
    PRIMARY KEY CLUSTERED ([ID_Clana] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ID_Pozorista] in table 'OrganizujeN'
ALTER TABLE [dbo].[OrganizujeN]
ADD CONSTRAINT [FK_PozoristeOrganizuje]
    FOREIGN KEY ([ID_Pozorista])
    REFERENCES [dbo].[Pozorista]
        ([ID_Pozorista])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_Predstave] in table 'OrganizujeN'
ALTER TABLE [dbo].[OrganizujeN]
ADD CONSTRAINT [FK_PredstavaOrganizuje]
    FOREIGN KEY ([ID_Predstave])
    REFERENCES [dbo].[Predstave]
        ([ID_Predstave])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PredstavaOrganizuje'
CREATE INDEX [IX_FK_PredstavaOrganizuje]
ON [dbo].[OrganizujeN]
    ([ID_Predstave]);
GO

-- Creating foreign key on [ID_Pozorista] in table 'Sale'
ALTER TABLE [dbo].[Sale]
ADD CONSTRAINT [FK_SalaPozoriste]
    FOREIGN KEY ([ID_Pozorista])
    REFERENCES [dbo].[Pozorista]
        ([ID_Pozorista])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalaPozoriste'
CREATE INDEX [IX_FK_SalaPozoriste]
ON [dbo].[Sale]
    ([ID_Pozorista]);
GO

-- Creating foreign key on [ID_Sale], [ID_Pozorista] in table 'IgraN'
ALTER TABLE [dbo].[IgraN]
ADD CONSTRAINT [FK_IgraSala]
    FOREIGN KEY ([ID_Sale], [ID_Pozorista])
    REFERENCES [dbo].[Sale]
        ([ID_Sale], [ID_Pozorista])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_Predstave] in table 'IgraN'
ALTER TABLE [dbo].[IgraN]
ADD CONSTRAINT [FK_PredstavaIgra]
    FOREIGN KEY ([ID_Predstave])
    REFERENCES [dbo].[Predstave]
        ([ID_Predstave])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PredstavaIgra'
CREATE INDEX [IX_FK_PredstavaIgra]
ON [dbo].[IgraN]
    ([ID_Predstave]);
GO

-- Creating foreign key on [ID_Scenariste] in table 'NapisaoN'
ALTER TABLE [dbo].[NapisaoN]
ADD CONSTRAINT [FK_ScenaristaNapisao]
    FOREIGN KEY ([ID_Scenariste])
    REFERENCES [dbo].[Scenaristi]
        ([ID_Scenariste])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScenaristaNapisao'
CREATE INDEX [IX_FK_ScenaristaNapisao]
ON [dbo].[NapisaoN]
    ([ID_Scenariste]);
GO

-- Creating foreign key on [ID_Predstave] in table 'NapisaoN'
ALTER TABLE [dbo].[NapisaoN]
ADD CONSTRAINT [FK_PredstavaNapisao]
    FOREIGN KEY ([ID_Predstave])
    REFERENCES [dbo].[Predstave]
        ([ID_Predstave])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_Glumca] in table 'GlumioN'
ALTER TABLE [dbo].[GlumioN]
ADD CONSTRAINT [FK_GlumioGlumac]
    FOREIGN KEY ([ID_Glumca])
    REFERENCES [dbo].[Glumci]
        ([ID_Glumca])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_Predstave] in table 'GlumioN'
ALTER TABLE [dbo].[GlumioN]
ADD CONSTRAINT [FK_PredstavaGlumio]
    FOREIGN KEY ([ID_Predstave])
    REFERENCES [dbo].[Predstave]
        ([ID_Predstave])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PredstavaGlumio'
CREATE INDEX [IX_FK_PredstavaGlumio]
ON [dbo].[GlumioN]
    ([ID_Predstave]);
GO

-- Creating foreign key on [ID_Sale], [ID_Pozorista], [ID_Predstave] in table 'Karte'
ALTER TABLE [dbo].[Karte]
ADD CONSTRAINT [FK_IgraKarta]
    FOREIGN KEY ([ID_Sale], [ID_Pozorista], [ID_Predstave])
    REFERENCES [dbo].[IgraN]
        ([ID_Sale], [ID_Pozorista], [ID_Predstave])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IgraKarta'
CREATE INDEX [IX_FK_IgraKarta]
ON [dbo].[Karte]
    ([ID_Sale], [ID_Pozorista], [ID_Predstave]);
GO

-- Creating foreign key on [ID_Clana] in table 'Gledaoci'
ALTER TABLE [dbo].[Gledaoci]
ADD CONSTRAINT [FK_GledalacLoyaltyClan]
    FOREIGN KEY ([ID_Clana])
    REFERENCES [dbo].[LoyaltyClanovi]
        ([ID_Clana])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GledalacLoyaltyClan'
CREATE INDEX [IX_FK_GledalacLoyaltyClan]
ON [dbo].[Gledaoci]
    ([ID_Clana]);
GO

-- Creating foreign key on [GledalacRBR] in table 'Karte'
ALTER TABLE [dbo].[Karte]
ADD CONSTRAINT [FK_GledalacKarta]
    FOREIGN KEY ([GledalacRBR])
    REFERENCES [dbo].[Gledaoci]
        ([RBR])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GledalacKarta'
CREATE INDEX [IX_FK_GledalacKarta]
ON [dbo].[Karte]
    ([GledalacRBR]);
GO

-- Creating foreign key on [ID_Clana] in table 'LoyaltyClanovi_VIP'
ALTER TABLE [dbo].[LoyaltyClanovi_VIP]
ADD CONSTRAINT [FK_VIP_inherits_LoyaltyClan]
    FOREIGN KEY ([ID_Clana])
    REFERENCES [dbo].[LoyaltyClanovi]
        ([ID_Clana])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_Clana] in table 'LoyaltyClanovi_Senior'
ALTER TABLE [dbo].[LoyaltyClanovi_Senior]
ADD CONSTRAINT [FK_Senior_inherits_LoyaltyClan]
    FOREIGN KEY ([ID_Clana])
    REFERENCES [dbo].[LoyaltyClanovi]
        ([ID_Clana])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------