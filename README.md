# CodingArena.Game

A game for programmers to compete against each other to show best skills for creativity, fast writing, testing and more.

### Language
Current version will only supports C# programming language.

### Bot
Implement bot (robot) which wins against other bots implemented by other players - programmers.

### Match
Bots are qualified at the start of the match if player's implementations (assemblies) are present at the server's location from which the game engine loads the assemblies and tries to create bot strategy objects.

### Rounds
Game consists from repeating rounds. Each round bot which remains last gain points. Player with most points wins a match.

### Turn
Each bot chooses which turn action will perform that turn

### TurnAction
A bot chooses turn action (e.g. move, attack, idle). 

#### Order of TurnActions
Turn is divided into three phases: pre, main, post phase. 
* Move is performed in pre phase
* Attack is performed in main phase
* Idle is performed in post phase

or...

Turn actions are ordered by the bot positions in battlefield (e.g. closer to the middle sooner bot do the action)

### Bot AI
Player (a programmer) implements strategy for their bot to fight against other bot and survive as last to win the round.

### Automata
> A mechanical figure or contrivance constructed to act as if by its own motive power; robot.  
Automata is a robot which act based on the Bot AI (implemented by a player) with following starting properties:

| Max HP | Max SP | Max EP |
|-------:|-------:|-------:|
|   1000 |   1000 |   1000 |

> HP = Health Points  
> SP = Shield Points  
> EP = Energy Points

### Weapons

| Weapon      | Max Range  | Energy Cost  | Damage   | Notes                           |
|:------------|-----------:|-------------:|---------:|---------------------------------|
| Machine Gun | 10         | 5            |    0-100 | damage depend on range, default |

