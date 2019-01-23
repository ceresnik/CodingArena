# CodingArena.Game
A game for programmers to compete against each other to show best skills for creativity, fast writing, testing and more.

### Language
Current version will only supports C# programming language.

### Bot
Implement bot AI which wins against other bots implemented by other players - programmers.

### Match
Bots are qualified at the start of the match if player's implementations (assemblies) are present at the server's location from which the game engine loads the assemblies and tries to create bot strategy objects.

### Rounds
Game consists from repeating rounds. Each round bot which remains last gain points. Player with most points wins a match.

### Turn
Each bot chooses which turn action will perform that turn

### TurnAction
A bot chooses turn action (e.g. move, attack, idle). 

| Turn Action     | Result       | Energy Cost |
|:----------------|-------------:|------------:|
| Move            | 1 place      |           5 |
| Attack          | 0-100 damage |          10 |
| Recharge.Shield | +50 SP       |          50 |
| Recharge.Energy | +20 EP       |           5 |

#### Order of TurnActions
Turn actions are ordered by the bot age:
> Oldest assembly file that contains implementation of bot AI goes first, newest goes last.

### Bot AI
Player (a programmer) implements strategy for their bot to fight against other bot and survive as last to win the round.

### Bot
Bot acts based on the Bot AI (implemented by a player) with following starting properties:

| Max HP | Max SP | Max EP |
|-------:|-------:|-------:|
|   1000 |   1000 |   1000 |

> HP = Health Points  
> SP = Shield Points  
> EP = Energy Points

### Weapons

| Weapon      | Max Range  | Energy Cost  | Damage   | Notes                            |
|:------------|-----------:|-------------:|---------:|----------------------------------|
| Machine Gun | 10         | 5            |    0-100 | damage depends on range, default |

### Battlefield

A battlefield is area where automatas (bots) fight against each other.
Battlefield size is `100 x 100`

### Game Rules
1. Don't use `System.Console`.
2. Don't try to beat the game.
