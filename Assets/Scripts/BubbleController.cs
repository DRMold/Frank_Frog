/****************************************************************************************/
/*
/* FILE NAME: BubbleController.cs
/*
/* DESCRIPTION: Makes bubbles move.
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/29/2015   Ritchie Hofmann        "        Genesis
/* 
/*
/*
/****************************************************************************************/
using UnityEngine;
using System.Collections;

public class BubbleController : MonoBehaviour {
	private int direction = -1;
	public float speed = 250f;
	public Rigidbody2D myBody;
	Vector2 movement;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 20);
	}
	
	// Update is called once per frame
	void Update () {
		direction = -direction;
		movement = myBody.velocity;
		
		movement.y = speed * Time.deltaTime;
		movement.x = 2.0f * direction * speed * Time.deltaTime;
		
		myBody.velocity = movement;
	}

}
