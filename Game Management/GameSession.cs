/*
File: GameSession.cs
Author: George Darling
Updated: 10/22/2015

Description:
This is an example class that can be used for storing global information in a Unity3D game.
The design concept here is that you have one single class that holds global information,
so that your other classes can just be instance based and use their own variables. 
That's helpful for keeping all of your code from being dependent on all of your other code.
The members in this class really are just there for example; modify for your own needs.
Also, this type of design is useful for saving / loading games. All of the data you need to
save will be right here.

How to use:
Include this on an empty game object in your scene. Or, you can remove the ": MonoBehavior" 
and it shouldn't need to be put in the scene at all.
Access the members in this class from any other class in your project with ClassName.member
	Example: GameSession.currentLevel = "Intro"; // this could be in any other class.
*/


using UnityEngine;
using System.Collections.Generic;

public class GameSession : MonoBehaviour {
	// The data will persist accross scenes because it is declared static
	public static readonly int numberOfCharacters = 5;
	public static string[] charactersAlive = new string[numberOfCharacters];
	public static int[] characterHealth = new int[numberOfCharacters];
	public static int[] characterEnergy = new int[numberOfCharacters];
	public static int[] characterXP = new int[numberOfCharacters];
	public static string currentLevel;
}
