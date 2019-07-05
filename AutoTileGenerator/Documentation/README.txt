AutoTileset Generator 1.0
by Revision3

# Introduction

A simple utility allowing users to take a RPG Maker style AutoTile sprite sheet / atlas and turn it into the 46 different transitions.


# Usage Instructions

There is no demo scene, as this asset is a purely GUI utility.

To test the asset after importing, go through this process using the included autotile128.png atlas file : 

1. Open the window located at "Window > AutoTileset Generator"
2. From this GUI, set your "Tile Size". The default value is 128 and will therefore create tiles of 128x128. Atlas should be twice the width and three times the height.
3. Select the AutoTile atlas file to build autotiles from. Make sure the import settings are as shown in the "ImportSettings" documentation image.
4. Click "Build Tileset To Folder" and select the folder in which you want to build your tileset. 

AssetDatabase will be refreshed to ensure the new files are immediately shown in the event that you want to save the files directly to your project folder.

That's it! You should now have a folder filled with the different possibilities for AutoTiles. 
Make sure you go through those files and correctly set the import settings as shown in the screenshot.


# How the asset works

While the asset has no code customization potential, here is an in depth explanation of how the system works. 

The autotile system used by this asset takes the input atlas image file and automatically builds transition tiles using segments of the atlas.

AutoTile atlas files must always be of width 2 x Tile Size, while the height must be 3 x Tile Size.

The main system is within the "AutoTileUtilities.cs" script. This script is responsible for the bit masking process.

GetAutoTile() and GetAutoTileCollection() are the two functions used to generate autotile files.

This process essentially takes in a 3x3 tile neighborhood and returns a bit mask value from 0 to 255 representing the type of transition needed.

The two TileNeighborhoodToAutoTileValue() functions are used to take this 3x3 neighborhood and turn it into the unique bit mask value.

AutoTileValueToFragments() is then used to translate the auto tile value into a 2x2 collection of "AutoTile Fragments" or segments of your atlas file.

In fact, the atlas file contains 5 different types of fragments used to build transition tiles : 

	- Concave Corner
	- Convex Corner
	- Vertical Side
	- Horizontal Side
	- Full Tile

Each of those fragments are represented for the four possible segments making up a complete tile. Fragments of a 128x128 tile are therefore 64x64 pixels in size.

Starting from top left and ending at the bottom right, the fragment positions are labeled A B C and D.

Last step before the program is ready to generate the AutoTileset is to turn Fragment Position & Fragment Type into Atlas Offset Values.

This process happens inside the BakePositions() function, taking the two previous variables and using them to find the correct fragment.

All of the utilities inside this script can be used for other things. The AutoTileValueToTileTypeOffset() function can return a value from 0 to 45
which represents all the possible AutoTile combinations as an offset value. In your game, define a tile type value as being the "Start" of an autotile collection.
Then it becomes very easy to automatically to gather your autotile sprites from resources by saving them using their TileType index value as the name.
The "Start" autotile type value is added to the TileTypeOffset for the current autotile to create an unique range of tile type values which represent the autotiles.


# File Encoding Details

I have personally had some issues with file encoding. Specifically, by saving files with the program "Paint.NET" as PNGs, colors would be slightly off after import.

Therefore, if you have graphical issues similar to this, it is crucial to make sure the atlas is saved as a PNG in RGBA 32 bit ( 8 bit per color ).

Using the free image editing program GIMP, it is possible to set much more detailed file encoding parameters, which completely removes the problem.

# Support

If you have any issues, questions, suggestions or simply want to talk to me about the asset, please use the email address below!

r3eckon@gmail.com