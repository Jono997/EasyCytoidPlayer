# Easy Cytoid Player

## What is Easy Cytoid Player?
Easy Cytoid Player is an application that acts as a wrapper around Cytoid Player by TigerHix, a chart preview program for the rhythm game Cytoid, also by TigerHix, that makes Cytoid Player easier to use.

## How to set up Easy Cytoid Player
To set up Easy Cytoid Player, first open it. All options should be greyed out except for the "Settings" button in the bottom right of the window. Clicking that opens up the settings window where you must point Easy Cytoid Player to where you have installed Cytoid Player to. If you don't want to type out the entire path, you can instead press the button next to the text box in order to navigate to it that way.

Once you've done that, click the "Save" button and the settings window will close. If the text box at the top of the main window is not greyed out, you've successfully set up Easy Cytoid Player.

## How to use Easy Cytoid Player
To use Easy Cytoid Player, you must first go through the setup. That process is detailed above.

To use Easy Cytoid Player, first covert the chart's audio to wav format. The recommended way to do this is by importing it into Audacity and exporting it into wav format with the same filename as the original audio file (for example, naming the file "audio.wav" if the original was "audio.mp3".

Once you've done that. Open Easy Cytoid Player and point it to the chart folder. You can do this by either copy-pasting the path or clicking the button next to the text box and navigating there manually.

Finally, select the chart difficulty and click the "Open in Cytoid Player" button.

## How does Easy Cytoid Player work?
Easy Cytoid Player works by automatically copying the chart files into the folder Cytoid Player checks when it opens and modifies the level.json file in that directory to only contain the chart you want it to play (if all of them are in there, it picks the first one in there and plays that) and to point to a wav format audio file.

## How do I build Easy Cytoid Player?
To build your own version of Easy Cytoid Player you must have Microsoft Visual Studio installed. Easy Cytoid Player is made using the Community 2019 Preview, but the 2017 versions should work just fine. You will also need the .NET Framework version 4.7.2 SDK installed. Simply clone the repository, open the EasyCytoidPlayer.sln file and then build it from there.

NOTE: Currently, Easy Cytoid Player is only compatible with Windows devices due to relying on .NET Framework. Plans are to port Easy Cytoid Player to .NET Core 3 once it releases in order to be built on Windows and Mac devices.