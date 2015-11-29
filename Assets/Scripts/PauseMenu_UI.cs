/****************************************************************************************/
/*
/* FILE NAME: PauseMenu_UI.cs
/*
/* DESCRIPTION: Models the behavior of the Pause System that includes Pause Menu Canvas and
/* 	the Pause Button Canvas, by specifying what each button in the pause menu does. Also 
/* 	specifies the behavior of the Pause Button. The methods are public so each button 
/* 	object can reference to their respective method for specified behavior.
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/29/2015   Joshua Medernach    1CF: JM     Created the class & full implementation
/*
/*
/*
/****************************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu_UI : MonoBehaviour {

	public Canvas pauseButtonCanvas;
	public Canvas pauseMenuCanvas;

	// Make sure the pause system is properly displaying upon start of level
	void Start () {
		pauseButtonCanvas.enabled = true;
		pauseMenuCanvas.enabled = false;
	}

	// Models the behavior for Pause Button
	public void PausePressed() {
		pauseButtonCanvas.enabled = false;
		pauseMenuCanvas.enabled = true;

		Time.timeScale = 0; // This pauses the game
	}

	// Models the behavior for Resume Button
	public void ResumePressed() {
		pauseButtonCanvas.enabled = true;
		pauseMenuCanvas.enabled = false;
		
		Time.timeScale = 1; // This resumes the game
	}

	// Models the behavior for Quit Button
	public void QuitPressed() {

		Time.timeScale = 1; // We must not forget that Time class is universal.
							// We must set Time back to normal before exiting the level

		Application.LoadLevel(0); // This takes the user back to the main menu
	}
}
