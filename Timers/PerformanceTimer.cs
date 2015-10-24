/*
File: PerformanceTimer.cs
Author: George Darling (devgr)
Updated: 10/24/2015

Description:
This class is an example of using the System.Diagnostics.Stopwatch class, which is a very precise 
way to time your code. It's useful for finding potential performance problems in your code or 
comparing two different algorithms.

How to use:
Either copy and paste the code you want to test inside the provided functions, or grab the code
here and integrate it into your own classes. This is meant mainly as an example.
*/

using UnityEngine;
using System.Diagnostics;
using System;

public class PerformanceTimer : MonoBehaviour{

	void FunctionThatDoesStuff(){
		// put your code here that you are trying to time.
		// try not to put Debug.Log statements here, because you'll get inconsistent timing.
	}
	void AnotherFunction(){
		// more code can go here!
	}

	void Update () {
        TimeSpan timeOne = new TimeSpan();
        TimeSpan timeTwo = new TimeSpan();
        Stopwatch timer = Stopwatch.StartNew();

        FunctionThatDoesStuff();
        timeOne = timer.Elapsed;
        AnotherFunction();
        timeTwo = timer.Elapsed;

        timer.Stop();
        UnityEngine.Debug.Log("Time One: " + timeOne.ToString() + "    Time Two: " + (timeTwo - timeOne).ToString());
    }

}
