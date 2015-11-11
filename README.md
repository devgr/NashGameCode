# NashGameCode
A collection of somewhat standalone scripts useful for video game development.

## Contributing
Feel free to contribute any code that is relatively general and could be useful for other developers, either as examples or as a ready to go components. Add a note in this readme with a summary of your code files, along with a comment at the top of the files with how to use it.

## File list:
* Game Management
  * GameSession.cs - This is an example of a simple way to store global information in your Unity3D game that persists across scenes.
  * Character.cs - Useful in a similar manner to GameSession.cs, this file shows a helpful way to organize characters.

* Sound
  * AudioController.cs - Provides some basic functions for working with audio in Unity3D. Useful for adding background music and multiple sound effects.

* Timers
  * CountdownTimerController.cs - Provides a basic countdown timer with the ability to pause, start, reset. Minutes, seconds, & milliseconds are able to display (optional). Intented to update a Text UI component.
  * PerformanceTimer.cs - Example of using the Stopwatch class to test code performance, and outputs the result to the console.
