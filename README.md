# Easy Cytoid Player Command Line

## What is Easy Cytoid Player Command Line?
Easy Cytoid Player Command Line is a command line version of Easy Cytoid Player for use of Mac computers.

## How to set up Easy Cytoid Player Command Line
To set up Easy Cytoid Player, first open the terminal and navigate to it. You can navigate the terminal by typing `cd folder_name` to go into that folder, `cd ..` to go out of the folder you're currently in and `ls` to see what's in the folder you're in.  
Afer you make it into the folder with Easy Cytoid Player, type in `chmod u+x "Easy Cytoid Player.command"`. Afterwards, you should be able to open it. It should then ask you for the path to the Cytoid Player app. You have to put the entire path to the app.

Once you've done that, Easy Cytoid Player will run as normal.

PLEASE NOTE: Currently, you cannot change the settings on Easy Cytoid Player once you confirm them during setup. That functionality is coming in the future.

## How to use Easy Cytoid Player Command Line
To use Easy Cytoid Player, you must first go through the setup. That process is detailed above.

To use Easy Cytoid Player, first covert the chart's audio to wav format. The recommended way to do this is by importing it into Audacity and exporting it into wav format with the same filename as the original audio file (for example, naming the file "audio.wav" if the original was "audio.mp3".

Once you've done that. Open Easy Cytoid Player and point it to the chart folder.

Finally, select the chart difficulty and Easy Cytoid Player will close. Currently, Easy Cytoid Player doesn't open Cytoid player upon finishing setup, so you will then have to navigate to and run the Cytoid Player app yourself.

## How do I build Easy Cytoid Player Command Line?
How you build Easy Cytoid Player Command Line depends on what operating system you are running.

To build Easy Cytoid Player Command Line on Windows, you must have Python 2.7 installed (preferably 2.7.10). Afterwards, open up the compile.py file in a text editor and configure the compile options at the top of the script. Afterwards, execute the script by double-clicking it. There should be a new file called Easy Cytoid Player.command (or .sh if you set that compile option).

To build Easy Cytoid Player Command Line on Mac, open up the compile.py file in a text editor and configure the compile options at the top of the script. Afterwards, open up Terminal, navigate to where the compile.py file is and type `python Compile.py`. There should be a new file called Easy Cytoid Player.command (or .sh if you set that compile option).

To build Easy Cytoid Player Command Line on Linux, you must have Python 2.7 installed (preferably 2.7.10). Afterwards, open up the comple.py file in a text editor and configure the compile options at the top of the script. Afterwards open up Terminal, navigate to where the compile.py file is and type `python Compile.py1. there should be a new file called Easy Cytoid Player.command (or .sh if you set that compile option).

NOTE: Despite being able to be built on Windows and Linux, Easy Cytoid Player only runs on Mac. (I mean, it *does* run on Linux, but Cytoid Player doesn't so what's the point?)

NOTE: This entire codebase is temporary and is likely to be discarded in the future. It is also unfinished and has not been properly tested yet.