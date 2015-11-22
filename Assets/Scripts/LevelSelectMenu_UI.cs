/****************************************************************************************/
/*
/* FILE NAME: LevelSelectMenu_UI.cs
/*
/* DESCRIPTION: Models the behavior of the Level Select Menu by specifying what each 
/*  button in the main menu does. The methods are public so each button object can 
/*  reference to their respective method for specified behavior.
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

public class LevelSelectMenu_UI : MonoBehaviour {

    // Button for Level 0 is selected
    public void PlayLevelZero()
    {
        Application.LoadLevel(1); // In build settings, level 0 is assigned integer 1
    }

    // Button for Level 1 is selected
    public void PlayLevelOne()
    {
        Application.LoadLevel(2); // Level 1
    }

    // Button for Level 2 is selected
    public void PlayLevelTwo()
    {
        Application.LoadLevel(3); // Level 2
    }

    // Button for Level 3 is selected
    public void PlayLevelThree()
    {
        Application.LoadLevel(4); // Level 3
    }

    public void Back()
    {
        Application.LoadLevel(0); // Goes back to main menu
    }
}
