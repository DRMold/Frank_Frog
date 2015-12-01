/****************************************************************************************/
/*
/* FILE NAME: EnemyAI.cs
/*
/* DESCRIPTION: Establishes the AI for the enemies 'incountered' throughout the game.
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/25/2015   John Rubadue        1CF: JM     Created the class & full implementation
/* 11/29/2015   Ritchie Hofmann                 Finished Full implementation and added an animation
/*
/*
/****************************************************************************************/
using UnityEngine;
using System.Collections;

//underwater Ai, omni directional
public class EnemyAI : MonoBehaviour
{
	private SpriteRenderer spR;
	private GameController gameController;

        public Transform player;
        public float speed = 100f;
	public Sprite sprite1; 
	public Sprite sprite2; 

	public float maxDistance;

	// Ends game when making contact with player
	void OnCollisionEnter2D (Collision2D other) {
		if (other.collider.tag == "Player") {
			other.gameObject.GetComponent<SpriteRenderer>().sprite = null;
			gameController.GameOver();
		}
	}

    void Start()
    {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{ gameController = gameControllerObject.GetComponent<GameController> (); }
		else { Debug.Log ("Cannot find 'GameController' script."); }

		// we are accessing the SpriteRenderer that is attached to the Gameobject
		spR = GetComponent<SpriteRenderer>(); 
		if (spR.sprite == null) 			  
			spR.sprite = sprite1;	
    }

    void Update()
    {
//		float maxDistanceSqr = maxDistance * maxDistance;
//		Vector3 rayDirection = player.localPosition - this.transform.localPosition;
//		Vector3 enemyDirection = transform.TransformDirection (Vector3.forward);
//		float angleDot = Vector3.Dot (rayDirection, enemyDirection);
//		bool playerInFrontOfEnemy = angleDot > 0.0;
//		bool playerCloseToEnemy = rayDirection.sqrMagnitude < maxDistanceSqr;
//
//		if (playerInFrontOfEnemy && playerCloseToEnemy) {

                // Will follow player when they get close
		if ((player.position - transform.position).sqrMagnitude < maxDistance) {
			transform.LookAt (player.position);
			transform.Rotate (new Vector3 (0, -90, 0), Space.Self);

			if (Vector3.Distance (transform.position, player.position) > 1f)
				transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));

			// Chomps at player
			if (Vector3.Distance (transform.position, player.position) < 2.5f)
				spR.sprite = sprite2;
			else
				spR.sprite = sprite1;
		}
    }
}
