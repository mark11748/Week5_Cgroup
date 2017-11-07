# _Epicodus Space_  :office:
By Mark Woodward, Emily Wells Jimenez, Jessie Waite, James Osborn

## :small_red_triangle_down: _Description_  
Epicodus Space is a grid based "dungeon crawler" that takes place in an office setting. The player begins in the lobby of their new school, and they are tasked with finding their classroom and computer. The player moves through a grid pattern of many different rooms, selecting adjacent open rooms to move to. Along the way they can pick up various items that they can use to interact with the world.

## :small_red_triangle_down: _Installation_

-Plug into the Matrix.  
-Learn Kung Fu.  
-Go nuts.

## :small_red_triangle_down: _Technologies Used_
Git  
GitHub  
Atom  
C#  
MySQL  
JavaScript  
BootStrap  
CSS  
HTML  

## :small_red_triangle_down: _Development Specs_

|Behavior|Input|Output|
|---|:---:|---:|  
|(GAME START)|(Load page)|Start page is displayed with 3 options: New Game, Load, and Instructions|
|user wants to start a new game|click [New Game]|Page redirected directly to game.|
|player wishes to load a saved game|click [Load Game]|Page redirected to save/load screen|
|Player views Save/Load screen from Start Page|click [Load Game]|Player sees two options for 1) Load Game, 2) Delete Save|
|Loading game resumes player progress|click [Load Game]>[Load Save]|Player is taken to the point in the game where they previously saved.|
|Deleting a save removes save progress|click [Load Game]>[Delete Save]|Player progress is deleted, they no longer have they option to load their saved game.|
|Saving the game records progress|While in-game, player clicks on [Save Game]|Player progress is recorded with player location, player items, player stats|
|Player would like to view the game rules.|click [Controls]|Short description: User moves by clicking grid spaces. User can use items. User stats effect gameplay.|
|New game displays game UI|click [New Game]|Game page UI is displayed, including 1) Text Window, 2) Control Grid 3) Items panel 4) Player stats panel 5) Save/load buttons|
|Player is able to move throughout the grid|Player clicks on adjacent highlighted cell|Player moves to new cell, visually represented by moving on the grid and getting new cell description text.|
|Player is unable to move to inaccessible cells|Player clicks on adjacent non-highlighted cell|Player is unable to move to a new cell, receives a custom message|
|Player is unable to move to non-adjacent cells|Player clicks somewhere on the map that's not touching their current cell|Player cannot move to non-adjacent cell|
|Player encounters immovable/fixed item/landmark|click on [S-item]|dropdown menus of available actions (i.e use) appears bellow [S-item] in interaction menu|
|player preforms actions on [S-item]|click on option in dropdown menu|action is preform|
|Player encounters collectable item/landmark|click on [D-item]|dropdown menus of available actions (i.e pick up) appears bellow [D-item] in interaction menu|
|player preforms actions on [D-item]|click on option in dropdown menu|action is preform|
|When player reaches final cell, they are given a message for winning.|Player enters final cell|Player gets win condition message.|

## :small_red_triangle_down: _Known Bugs_
No known bugs at this time.

## :small_red_triangle_down: _Support and Contact Details_   
Contact the developer if you find a way to monetize this product, or with bug reports or feedback. <markwood117@gmail.com>  

## :small_red_triangle_down: _License_
This program uses an MIT license.
