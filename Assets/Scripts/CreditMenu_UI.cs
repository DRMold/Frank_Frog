/****************************************************************************************/
/*
/* FILE NAME: CreditMenu.cs
/*
/* DESCRIPTION: Models the behavior of the Credit Menu by specifying what back button in
/*  the credit menu does. The method is public so the back button object can reference to 
/*  it for specified behavior.
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

public class CreditMenu_UI : MonoBehaviour {

    // The back button in credits is pressed
    public void Back()
    {
        Application.LoadLevel(0); // Returns back to main menu
    }
}
