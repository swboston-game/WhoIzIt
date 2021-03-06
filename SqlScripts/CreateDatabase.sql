/****** Object:  Table [dbo].[GamePieces]    Script Date: 05/13/2012 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GamePieces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacebookId] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[Game_Id] [int] NULL,
 CONSTRAINT [PK_GamePieces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [IX_Game_Id] ON [dbo].[GamePieces] 
(
	[Game_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 05/13/2012 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[Game_Id] [int] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [IX_Game_Id] ON [dbo].[Questions] 
(
	[Game_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[Games]    Script Date: 05/13/2012 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[Challenger_Id] [int] NULL,
	[Opponent_Id] [int] NULL,
	[ChallengerSelection_Id] [int] NULL,
	[OpponenetSelection_Id] [int] NULL,
	[Winner_Id] [int] NULL,
	[PlayersMove_Id] [int] NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [IX_Challenger_Id] ON [dbo].[Games] 
(
	[Challenger_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE NONCLUSTERED INDEX [IX_ChallengerSelection_Id] ON [dbo].[Games] 
(
	[ChallengerSelection_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE NONCLUSTERED INDEX [IX_OpponenetSelection_Id] ON [dbo].[Games] 
(
	[OpponenetSelection_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE NONCLUSTERED INDEX [IX_Opponent_Id] ON [dbo].[Games] 
(
	[Opponent_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE NONCLUSTERED INDEX [IX_PlayersMove_Id] ON [dbo].[Games] 
(
	[PlayersMove_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE NONCLUSTERED INDEX [IX_Winner_Id] ON [dbo].[Games] 
(
	[Winner_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[Players]    Script Date: 05/13/2012 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[FaceBookId] [nvarchar](max) NULL,
	[Streak] [int] NOT NULL,
	[Wins] [int] NOT NULL,
	[Loses] [int] NOT NULL,
	[TotalPoints] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Invites]    Script Date: 05/13/2012 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[Challenger_Id] [int] NULL,
	[Opponent_Id] [int] NULL,
 CONSTRAINT [PK_Invites] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [IX_Challenger_Id] ON [dbo].[Invites] 
(
	[Challenger_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
CREATE NONCLUSTERED INDEX [IX_Opponent_Id] ON [dbo].[Invites] 
(
	[Opponent_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[Badges]    Script Date: 05/13/2012 11:02:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Badges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[WindsNeeded] [int] NOT NULL,
	[StreakNeeded] [int] NOT NULL,
	[LosesNeeded] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[Player_Id] [int] NULL,
 CONSTRAINT [PK_Badges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
CREATE NONCLUSTERED INDEX [IX_Player_Id] ON [dbo].[Badges] 
(
	[Player_Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  ForeignKey [FK_GamePieces_Games_Game_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[GamePieces]  WITH CHECK ADD  CONSTRAINT [FK_GamePieces_Games_Game_Id] FOREIGN KEY([Game_Id])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[GamePieces] CHECK CONSTRAINT [FK_GamePieces_Games_Game_Id]
GO
/****** Object:  ForeignKey [FK_Questions_Games_Game_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Games_Game_Id] FOREIGN KEY([Game_Id])
REFERENCES [dbo].[Games] ([Id])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Games_Game_Id]
GO
/****** Object:  ForeignKey [FK_Games_GamePieces_ChallengerSelection_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_GamePieces_ChallengerSelection_Id] FOREIGN KEY([ChallengerSelection_Id])
REFERENCES [dbo].[GamePieces] ([Id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_GamePieces_ChallengerSelection_Id]
GO
/****** Object:  ForeignKey [FK_Games_GamePieces_OpponenetSelection_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_GamePieces_OpponenetSelection_Id] FOREIGN KEY([OpponenetSelection_Id])
REFERENCES [dbo].[GamePieces] ([Id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_GamePieces_OpponenetSelection_Id]
GO
/****** Object:  ForeignKey [FK_Games_Players_Challenger_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Players_Challenger_Id] FOREIGN KEY([Challenger_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Players_Challenger_Id]
GO
/****** Object:  ForeignKey [FK_Games_Players_Opponent_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Players_Opponent_Id] FOREIGN KEY([Opponent_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Players_Opponent_Id]
GO
/****** Object:  ForeignKey [FK_Games_Players_PlayersMove_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Players_PlayersMove_Id] FOREIGN KEY([PlayersMove_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Players_PlayersMove_Id]
GO
/****** Object:  ForeignKey [FK_Games_Players_Winner_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Players_Winner_Id] FOREIGN KEY([Winner_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Players_Winner_Id]
GO
/****** Object:  ForeignKey [FK_Invites_Players_Challenger_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Invites]  WITH CHECK ADD  CONSTRAINT [FK_Invites_Players_Challenger_Id] FOREIGN KEY([Challenger_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Invites] CHECK CONSTRAINT [FK_Invites_Players_Challenger_Id]
GO
/****** Object:  ForeignKey [FK_Invites_Players_Opponent_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Invites]  WITH CHECK ADD  CONSTRAINT [FK_Invites_Players_Opponent_Id] FOREIGN KEY([Opponent_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Invites] CHECK CONSTRAINT [FK_Invites_Players_Opponent_Id]
GO
/****** Object:  ForeignKey [FK_Badges_Players_Player_Id]    Script Date: 05/13/2012 11:02:48 ******/
ALTER TABLE [dbo].[Badges]  WITH CHECK ADD  CONSTRAINT [FK_Badges_Players_Player_Id] FOREIGN KEY([Player_Id])
REFERENCES [dbo].[Players] ([Id])
GO
ALTER TABLE [dbo].[Badges] CHECK CONSTRAINT [FK_Badges_Players_Player_Id]
GO
