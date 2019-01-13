# CodingArena.Game

A game for programmers to compete against each other to show best skills for creativity, fast writing, testing and more.

### Bot
Implement bot (robot) which wins against other bots implemented by other players - programmers.

### Match

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

### Bot Strategy
Player (a programmer) implements strategy for their bot to fight against other bot and survive as last to win the round.
