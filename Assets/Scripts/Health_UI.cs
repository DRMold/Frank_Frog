/****************************************************************************************/
/*
/* FILE NAME: Health_UI.cs
/*
/* DESCRIPTION: Models the behavior of the Health Display by specifying what 
/* 	the Health Level text object does. The methods are public so the player controller
/* 	can update the Health Level text to reflect the player's health level.
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

public class Health_UI : MonoBehaviour {

	public Text healthLevel;

	// On start, initally set health to 100%
	void Start () {
		updateHealth (100);
	}
	
	// The public method that allows Health Level text to be updated
	public void updateHealth(int health) {
		healthLevel.text = health.ToString () + "%";
	}
}
