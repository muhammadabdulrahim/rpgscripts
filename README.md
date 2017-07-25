# RPG Battle Entity Scripts

These are generic RPG battle entity scripts you can hack upon to use in your game.

## How to use

1. Copy all C# scripts into an appropriate folder
2. Create a new blank GameObject
3. Attach the Battle Entity script to the new object
4. Fill in the details--the user interface updates and is easy to use

## Visual walk-through

When you add the script to a fresh GameObject, you will see the following:

![Initial view of Battle Entity][rpg01]

As you can see, a warning is thrown since the name is not specified. Additionally, default values are present. The script will not allow you to specify a maxHP value below 1, nor a speed below 1, but you can edit this to suit the needs of your game. At the bottom you have a dropdown listing various player affinities. You can add onto this or remove it. A fully populated player looks like this:

![Populated Player][rpg02]

When you check the box to indicate an enemy, the player-specific properties hide in the inspector and reset in the object, and enemy-specific properties, like experience and gold, are revealed.

![Populated Enemy][rpg03]

It's very easy to save these as prefab objects. With this basic framework, you can set up a large number of enemies and players very quickly.

![Prefabs][rpg04]

Please note that no graphics code exists for this project. Graphics vary greatly from game-to-game, so it is out of the scope of this project to cover that. With what has been provided, it should be easy enough to add new properties as necessary.

[rpg01]: https://raw.githubusercontent.com/muhammadabdulrahim/rpgscripts/master/Screenshots/rpg01.PNG
[rpg02]: https://raw.githubusercontent.com/muhammadabdulrahim/rpgscripts/master/Screenshots/rpg02.PNG
[rpg03]: https://raw.githubusercontent.com/muhammadabdulrahim/rpgscripts/master/Screenshots/rpg03.PNG
[rpg04]: https://raw.githubusercontent.com/muhammadabdulrahim/rpgscripts/master/Screenshots/rpg04.PNG
