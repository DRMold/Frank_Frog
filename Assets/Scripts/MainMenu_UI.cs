/****************************************************************************************/
/*
/* FILE NAME: MainMenu_UI.cs
/*
/* DESCRIPTION: Models the behavior of the Main Menu by specifying what each button in the
/*  main menu does. The methods are public so each button object can reference to their
/*  respective method for specified behavior.
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/22/2015   Joshua Medernach    1CF: JM     Created the class & full implementation
/*
/*
/*
/****************************************************************************************/


using UnityEngine;
using System.Collections;

public class MainMenu_UI : MonoBehaviour {

    // The start button is pressed
    public void PlayGame()
    { Application.LoadLevel(1); } // In build settings, level 0 is assigned integer 1

    // The load level button is pressed
    public void StartLevelSelect()
    {
        Application.LoadLevel(5); // This loads the Level Select scene
    }

    // The credits button is pressed
    public void StartCredit()
    {
        Application.LoadLevel(6); // This loads the Credits scene
    }

    // The quit button is pressed
    public void QuitGame()
    {
        Application.Quit();
    }
}
