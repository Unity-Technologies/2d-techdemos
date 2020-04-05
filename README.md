# 2d-techdemos

2d-techdemos is a repository containing helpful examples of 2D features with scenes and assets. It contains the asset implementions of the scripts available in its sister repository, [2d-extras](https://github.com/Unity-Technologies/2d-extras).

All items in the repository are grouped by use for a feature and are listed below.

## How to use this

This repository is a Unity project which you can open using Unity. To view the examples in an existing Unity project, please copy the contents in the Assets folder to the Assets folder of your existing project as well as the manifest.json file in the Packages folder.

As this repository contains the scripts from 2d-extras as a package, you do not need to include the files from the 2d-extras repository to this.

## Features

### Tilemap

- **Brick** - A Breakout style game using Tilemap and Physics 2D. This example makes use of the Physics2D collision contacts to determine which cell in the Tilemap is hit when there is a collision. Open the scene Brick to get started. Run this example to start playing.

- **Destructible** - A demo using Tilemap and Scripted Tiles showing how Tilemaps can changed in the Runtime. Open the scene Destructible to get started. Run this example by playing it and click on a location to cause an explosion and watch the after-effects. 

- **Brushes** - The Scripted Brushes can be selected from the dropdown at the bottom of the Tile Palette. Choose the Brush you want to paint with and start painting. Pull up the Brush dropdown bar to view additional parameters for the chosen Brush.
 
- **Tiles** - Tile Palettes have been set up for each of the different types of Scripted Tiles. Choose the Tile Palette containing the Tile asset that you want. To find out more on how the Tile asset is set up: 
    - Select the Tile in the Tile Palette
    - Right-click on the Tile Palette
    - Click on Select Tile Asset

For use with Unity 2019.3.7f1 onwards.