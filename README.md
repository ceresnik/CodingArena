# CodingArena
A game for programmers to compete against each other to show best skills for creativity, fast writing and more by implementing bot artificial intelligence to fight against other bots.

### Language
Current version will only supports C# programming language.

### Match
Bots are qualified at the start of the each round if players' implementations (assemblies) are present at the server's location from which the game server loads the assemblies and tries to create bots. Round results are accumulated at match level.

### Rounds
Match consists from multiple rounds. Each round bots fights against each other and gain points for destroying other bots. 

### Turn
Every turn each bot chooses one turn action to be performed for specified input parameters (your bot, enemies, battlefield).

### TurnAction
A bot chooses turn action (e.g. move, attack, idle). 

| Turn Action           | Result       | Energy Cost |
|:----------------------|-------------:|------------:|
| Move                  | 1 place      |           5 |
| Attack (Max Range 10) | 0-100 damage |          10 |
| Recharge.Shield       | +20 SP       |          20 |
| Recharge.Energy       | +20 EP       |           5 |
| Idle                  | nothing      |           0 |

#### Order of TurnActions (not implemented yet)
Turn actions are ordered by the bot age:
> Oldest assembly file that contains implementation of bot AI goes first, newest goes last.

### Bot AI
Player (a programmer) implements artificial intelligence for their bot to fight against other bots to kill most of enemies.

### Bot
Bot acts based on the Bot AI (implemented by a player) with following starting properties:

| Max HP | Max SP | Max EP |
|-------:|-------:|-------:|
|   1000 |   1000 |   1000 |

> HP = Health Points  
> SP = Shield Points  
> EP = Energy Points

### Battlefield

A battlefield is area where bots fight against each other.
Configured battlefield size is `100 x 100`.

### Game Rules
1. Don't use `System.Console`.
2. Don't use reflection.
3. Don't try to beat the game.
