/****************************************************************************************/
/*
/* FILE NAME: CameraController.cs
/*
/* DESCRIPTION: Establishes Camera mechanics
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/29/2015   Ritchie Hofmann                 Made this script to control camera behavior.
/*
/*
/****************************************************************************************/
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float MIN_X;
	public float MAX_X;
	public float MIN_Y;
	public float MAX_Y;

	// Use this for initialization
	void Start () {
		// set the desired aspect ratio. These values are hard coded to 16:9.
		// set to public to modify whilst designing. 
		float targetaspect = 16.0f / 9.0f;

		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;

		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;

		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera> ();

		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f) {
			Rect rect = camera.rect;
			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;
			camera.rect = rect;
		} else {
			// add pillarbox
			float scalewidth = 1.0f / scaleheight;
			Rect rect = camera.rect;
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			camera.rect = rect;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(movement * speed * Time.deltaTime, Space.Self);
		// Sets camera boundaries and will follow the player
		transform.position = new Vector3(
			Mathf.Clamp(GameObject.FindGameObjectWithTag("Player").transform.position.x, MIN_X, MAX_X),
			Mathf.Clamp(GameObject.FindGameObjectWithTag("Player").transform.position.y, MIN_Y, MAX_Y),
			-8.0f);
	}
}
