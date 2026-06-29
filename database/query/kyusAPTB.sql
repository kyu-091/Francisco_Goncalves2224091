USE [kyusAPTB]
GO
/****** Object:  Table [dbo].[customPokemon]    Script Date: 6/29/2026 1:19:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customPokemon](
	[pokemonID] [int] IDENTITY(1,1) NOT NULL,
	[pokedexID] [int] NOT NULL,
	[teamID] [int] NOT NULL,
	[nickname] [varchar](50) NOT NULL,
	[item] [varchar](50) NULL,
	[ability] [varchar](50) NOT NULL,
	[nature] [varchar](50) NOT NULL,
	[move1] [varchar](50) NOT NULL,
	[move2] [varchar](50) NOT NULL,
	[move3] [varchar](50) NOT NULL,
	[move4] [varchar](50) NOT NULL,
	[hp] [int] NULL,
	[atk] [int] NULL,
	[def] [int] NULL,
	[spatk] [int] NULL,
	[spdef] [int] NULL,
	[speed] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[pokemonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[moves]    Script Date: 6/29/2026 1:19:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[moves](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[type] [varchar](50) NULL,
	[category] [varchar](50) NULL,
	[power] [int] NULL,
	[accuracy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pokemonMoves]    Script Date: 6/29/2026 1:19:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pokemonMoves](
	[pokemonID] [int] NOT NULL,
	[moveID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pokemonID] ASC,
	[moveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pokemons]    Script Date: 6/29/2026 1:19:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pokemons](
	[pokedexID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[height] [float] NOT NULL,
	[weight] [float] NOT NULL,
	[type1] [varchar](50) NULL,
	[type2] [varchar](50) NULL,
	[species] [varchar](50) NULL,
	[ability1] [varchar](50) NULL,
	[ability2] [varchar](50) NULL,
	[hiddenAbility] [varchar](50) NULL,
	[hp] [int] NOT NULL,
	[atk] [int] NOT NULL,
	[def] [int] NOT NULL,
	[spa] [int] NOT NULL,
	[spd] [int] NOT NULL,
	[speed] [int] NOT NULL,
	[total] [int] NOT NULL,
	[stage] [int] NOT NULL,
	[preEvolution] [varchar](50) NULL,
	[nextEvolution] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[pokedexID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teams]    Script Date: 6/29/2026 1:19:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teams](
	[userID] [int] NOT NULL,
	[pokemon1] [int] NULL,
	[pokemon2] [int] NULL,
	[pokemon3] [int] NULL,
	[pokemon4] [int] NULL,
	[pokemon5] [int] NULL,
	[pokemon6] [int] NULL,
	[teamID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 6/29/2026 1:19:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[pokemonMoves]  WITH CHECK ADD FOREIGN KEY([moveID])
REFERENCES [dbo].[moves] ([id])
GO
ALTER TABLE [dbo].[pokemonMoves]  WITH CHECK ADD FOREIGN KEY([pokemonID])
REFERENCES [dbo].[pokemons] ([pokedexID])
GO
ALTER TABLE [dbo].[teams]  WITH CHECK ADD FOREIGN KEY([pokemon1])
REFERENCES [dbo].[customPokemon] ([pokemonID])
GO
ALTER TABLE [dbo].[teams]  WITH CHECK ADD FOREIGN KEY([pokemon2])
REFERENCES [dbo].[customPokemon] ([pokemonID])
GO
ALTER TABLE [dbo].[teams]  WITH CHECK ADD FOREIGN KEY([pokemon3])
REFERENCES [dbo].[customPokemon] ([pokemonID])
GO
ALTER TABLE [dbo].[teams]  WITH CHECK ADD FOREIGN KEY([pokemon4])
REFERENCES [dbo].[customPokemon] ([pokemonID])
GO
ALTER TABLE [dbo].[teams]  WITH CHECK ADD FOREIGN KEY([pokemon5])
REFERENCES [dbo].[customPokemon] ([pokemonID])
GO
ALTER TABLE [dbo].[teams]  WITH CHECK ADD FOREIGN KEY([pokemon6])
REFERENCES [dbo].[customPokemon] ([pokemonID])
GO
ALTER TABLE [dbo].[teams]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[users] ([UserID])
GO
