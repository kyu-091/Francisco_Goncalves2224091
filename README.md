\# kyusAPTB - Pokemon Team Builder Application



\## Overview



kyusAPTB is a Windows Forms desktop application for Pokemon enthusiasts to explore Pokemon data, build and manage teams, and track EV training. The application integrates with the PokeAPI for live Pokemon data and uses a local SQL Server database for persistent storage of teams and user data.



\## Features



\### User Authentication

\- User registration and login system

\- Session management to track current user

\- Secure password handling



\### Pokedex

\- Browse all 1025 Pokemon with search functionality

\- View detailed Pokemon information including:

&#x20; - Base stats (HP, Attack, Defense, Special Attack, Special Defense, Speed)

&#x20; - Abilities (including hidden abilities)

&#x20; - Types with visual display

&#x20; - Height and weight

&#x20; - Species and description

&#x20; - Type effectiveness (weaknesses, resistances, immunities, normal hits)

\- Real-time search filtering

\- Pokemon sprite display from official artwork



\### Team Builder

\- Create and manage up to 3 teams per user

\- Each team supports 6 Pokemon slots

\- Edit team members with nickname support

\- EV training with validation (max 252 per stat, 508 total)

\- Visual display of team Pokemon sprites

\- Save and load teams from database



\### Team Editing

\- Select Pokemon from the Pokedex

\- Choose items, abilities, natures, and moves

\- Set EV values for each stat

\- Auto-validate EV spreads

\- Persistent storage of all team data



\### Cyberpunk Theme

\- Dark terminal-style interface

\- Neon cyan accents

\- Monospace font throughout

\- Borderless window design

\- Consistent visual style across all forms



\## Technology Stack



\- \*\*Framework\*\*: .NET Framework 4.7.2 / Windows Forms

\- \*\*Language\*\*: C# 7.3

\- \*\*API\*\*: PokeApiNet (PokeAPI wrapper)

\- \*\*Database\*\*: Microsoft SQL Server

\- \*\*Data Access\*\*: ADO.NET with SqlClient



\## Usage



1\. Register a new account or login with existing credentials

2\. Use the Pokedex to explore Pokemon and learn about their stats and type matchups

3\. Navigate to Team Builder to create or edit teams

4\. Click Edit on any team to select Pokemon and customize EV spreads

5\. Save teams to persist your progress



\## License



This project is for educational purposes. Pokemon and related properties are owned by Nintendo, Game Freak, and The Pokemon Company.

