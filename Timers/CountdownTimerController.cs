/*
 * CountdownTimerController.cs
 * 
 * Author: Justin Giles (greenrift)
 * 
 * This is a simple countdown timer. 
 * You can enable/disable minute & millisecond displays
 * You can specify starting number of seconds.
 * You can start, pause, and reset the timer
 * It is intended to associate a Text UI component in order to update the UI
 * 
 * Option to send a broadcast when the timer is up.
 * 
 * Feel free to modify or improve.  Just add your name/github name to the author portion.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimerController : MonoBehaviour
{
	//Default starting time
	public float m_startingSeconds = 120; //in seconds
	public bool m_startTimer = false;

	//Enable output in minutes & seconds
	public bool mins_enabled = true;

	//Enable output of milliseconds
	public bool millis_enabled = false;
	public bool prefix_mins = false;

	//Text component to update
	public Text m_text;
	public string suffix = "";
	public bool forChoices = false;

	//Send Game Over message enabled
	public bool alertGameOver = true;
	private float m_miliseconds;
	private float m_seconds;
	private float m_mins;
	private float m_totalmiliseconds;	// Use this for initialization

	private bool gameover = false;

	void Start ()
	{
		Init (m_startingSeconds);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (m_startTimer) {
			formatTime ();
		}
	}

	void formatTime ()
	{
		if (m_totalmiliseconds >= 0.5 && m_startTimer) {
			if (m_miliseconds <= 0) {
				if (m_seconds <= 0) {
					m_mins--;
					m_seconds = 59;
				} else {
					m_seconds--;
				}
				
				m_miliseconds = 99;
			}
			
			m_miliseconds -= Time.deltaTime * 100;
			m_totalmiliseconds -= Time.deltaTime * 1000;

		} else if (m_totalmiliseconds <= 0.5) {
			m_startTimer = false;
			m_miliseconds = 0.0f;
			m_seconds = 0.0f;
			m_mins = 0.0f;

			if (alertGameOver) {
				GameObject game = GameObject.Find ("GameController");
				game.SendMessage ("TimerEnded");
			}
		}
		
		string format_builder = "";

		if (mins_enabled) {
			if ((int)m_mins > 9 || !prefix_mins) {
				format_builder += "{0}";
			} else {
				format_builder += "0{0}";
			}
		}
		
		if ((int)m_seconds > 9) {
			if (mins_enabled) {
				format_builder += ":{1}";
			} else {
				format_builder += "{0}";
			}
		} else {
			if (mins_enabled) {
				format_builder += ":0{1}";
			} else {
				format_builder += "0{0}";
			}
		}

		if (millis_enabled) {
			if ((int)m_miliseconds > 9) {
				if (mins_enabled) {
					format_builder += ":{2}";
				} else {
					format_builder += ":{1}";
				}
			} else {
				if (mins_enabled) {
					format_builder += ":0{2}";
				} else {
					format_builder += ":0{1}";
				}
			}
		}

		if (!m_startTimer) {
			m_text.text = string.Format (format_builder + suffix, 0, 0, 0);
		} else {

			if (mins_enabled && millis_enabled) {
				m_text.text = string.Format (format_builder + suffix, m_mins, m_seconds, (int)m_miliseconds);
			} else if (mins_enabled && !millis_enabled) {
				m_text.text = string.Format (format_builder + suffix, m_mins, m_seconds);
			} else {
				m_text.text = string.Format (format_builder + suffix, m_seconds, (int)m_miliseconds);
			}
		}
	}

	public void PauseTimer ()
	{
		m_startTimer = false;
	}

	public void StartTimer ()
	{
		m_startTimer = true;
	}

	public void resetTimer ()
	{
		Init (m_startingSeconds);
	}

	public void Init (float p_startingTime)
	{
		// convert start time to milliseconds
		m_totalmiliseconds = p_startingTime * (1000);
		m_mins = (int)(p_startingTime / 60);
		m_miliseconds = 0f;
		m_seconds = p_startingTime % 60;
		m_startTimer = false;
		formatTime ();
	}
}
