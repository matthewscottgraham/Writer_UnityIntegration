# Writer_UnityIntegration

### The Pitch
An interactive writing tool designed to take a game narrative from initial
white-box all the way to the final story. Users will write in plain text with
minimal markup, and the tool should automatically organize items, characters,
non-linear sequences of dialogue, cutscenes, and interaction events. It should
also prepare tables for localization. The resulting data should be exported
directly to a game engine, enabling the creation of new level block-outs or
updating existing data.

### Current Progress
#### Prototype
This is the unity integration of the Writer tool. It can be found here:
https://github.com/matthewscottgraham/writer

The unity tool will take the data exported from the Writer tool, and add 
interactable objects to a scene that will trigger when a player touches them.

<p align="center">
	<img src="images/screenshotA.jpg" alt="Screenshot A" height="300"/>

[![See it in action](https://raw.githubusercontent.com/matthewscottgraham/Writer_UnityIntegration/main/images/thumbnailA.jpg)]
(https://raw.githubusercontent.com/matthewscottgraham/Writer_UnityIntegration/main/images/videoA.m4v)
</p>

### Should I use this in my project?
No.
Use https://www.inklestudios.com/ink/ or https://twinery.org/ instead.
This tool is very much a proof of concept, lacks many features, and is primarily
built for me, because I wanted to.

### How to Use
* Import data
  * Create a subdirectory called 'Writer' in the 'Streaming Assets' directory of your 
  Unity Project.
  * Add the exported json files from the Writer tool to this directory.
  * In the program menu bar, under the Writer menu, choose 'Import'
  * This will create scriptable objects for all scenes, sequences, characters and items
  in the resources folder of the Unity Project.
* Set up Scene
  * Add the Scene Setup prefab to your scene. It can be found in the Writer/Prefabs directory
  * Add the SceneInfo scriptable object from Resources/Scenes that you wish to use into the 
  Scene Info field of the Scene Setup component.
  * Press the 'Setup' button on the Scene Setup component. This will create triggers for the
  sequences contained within the SceneInfo object.