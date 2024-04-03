SET IDENTITY_INSERT [dbo].[Utilisateur] ON
INSERT INTO [dbo].[Utilisateur] ([IdUtilisateur], [NomUser], [Email], [MDP]) VALUES (1, 'Supipi', 'supipi@gmail.com', 123)
INSERT INTO [dbo].[Utilisateur] ([IdUtilisateur], [NomUser], [Email], [MDP]) VALUES (2, 'Boya', 'boya@gmail.com', 321)
SET IDENTITY_INSERT [dbo].[Utilisateur] OFF
