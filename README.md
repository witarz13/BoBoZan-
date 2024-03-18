# BoBoZan-
game in Unity


The game operates on a 4-second loop, divided into distinct phases:

Preparation Period (First 2 seconds): During this phase, players can interact with the game by pressing a button on the screen or the space bar on the keyboard. This action triggers a sound effect.

Decision Period (Third second): In this phase, players can choose one of three actions:

1 Gain Energy: Press 'Q' or click the left icon to gain 1 point of energy. This energy can be used to attack the enemy in the next round.
2 Use Shield: Press 'W' or click the middle icon to use a shield point and block any incoming attacks for that round. This action is only available if you have a shield point. Players automatically gain a shield point in rounds where the shield is not used.
3 Attack: Press 'E' or click the right icon to use all your accumulated energy to attack the enemy. This action is only available when you have energy.
Result Period (Fourth second): The outcomes are determined based on the actions taken. Players lose 1 HP (Health Point) in two scenarios:

If they are attacked while attempting to gain energy.
If both the player and the enemy decide to attack, but the player has less energy than the enemy.
Remember to impleme
