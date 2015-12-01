/****************************************************************************************/
/*
/* FILE NAME: PlayerControlWater.cs
/*
/* DESCRIPTION: Establishes player mechanics in water.
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/27/2015   John Rubadue        1CF: JM     Created the class & full implementation
/* 11/29/2015   Ritchie Hofmann        "        Fixed issues.
/*
/*
/****************************************************************************************/
using UnityEngine;
using System.Collections;

// Player Boundaries
[System.Serializable] 
public class Boundary 
{ public float xMin, xMax, yMin, yMax; }


public class PlayerControlWater : MonoBehaviour {
    public float speed = 250f;
    public Boundary boundary;
    public Rigidbody2D myBody; 
    Vector2 movement;

    void Start()
    { }

    void FixedUpdate()  
    {
		//pick up movement from user input
		//myBody.transform.rotation = Quaternion.identity;
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical   = Input.GetAxis("Vertical");
		applyMovement (moveHorizontal, moveVertical);
    }

	public void applyMovement(float moveHorizontal, float moveVertical) 
	{		
		movement = myBody.velocity;
		movement.x = moveHorizontal * speed * Time.deltaTime;
		movement.y = moveVertical * speed * Time.deltaTime;
		
		myBody.velocity = movement;

		GetComponent<Rigidbody2D> ().position = new Vector2
			(
				Mathf.Clamp (myBody.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (myBody.position.y, boundary.yMin, boundary.yMax)
			);
	}
}
