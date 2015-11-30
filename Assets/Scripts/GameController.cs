/****************************************************************************************/
/*
/* FILE NAME: GameController.cs
/*
/* DESCRIPTION: Establishes Game mechanics
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/29/2015   Ritchie Hofmann                 Made this script to control everything else.
/*
/*
/****************************************************************************************/
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	// User-Added vars

//------------------Game Mechanic Variables-----------------------------------------------
	private bool gameOver;
	private bool paused;
	private int score;

//------------------Water Animation Variables---------------------------------------------
//	public Material lr1_tex;
	public Material lr2_tex;
	public Material ud1_tex;
	public GameObject player;
	// User-Manipulated vars
	public int zPlane = -1;
	public float lrScroll = 5;
	public float udScroll = 5;
	// Create quads
//	private GameObject lr1;
	private GameObject lr2;
	private GameObject ud1;
	// player vars
	private Vector2 lastPosition;
	// animator vars
//	private Material lr1_material;
	private Material lr2_material;
	private Material ud1_material;

//------------------Bubble Animation Variables---------------------------------------------
	public GameObject bubble;
	public int bubbleCount;
	public float threshold, spawnWait, startWait, waveWait;

	// Use this for initialization
	void Start () {
		gameOver = false;
		paused = false;
		score = 0;
		
		// Create quads
		//		lr1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
		lr2 = GameObject.CreatePrimitive(PrimitiveType.Quad);
		ud1 = GameObject.CreatePrimitive(PrimitiveType.Quad);
		// initiate quad sizes
		InitQuadSizes();
		// set material vars
		//		lr1_material = lr1.GetComponent<Renderer>().material;
		lr2_material = lr2.GetComponent<Renderer>().material;
		ud1_material = ud1.GetComponent<Renderer>().material;
		// Add textures to quads
		//		lr1.GetComponent<Renderer>().material = lr1_tex;
		lr2.GetComponent<Renderer>().material = lr2_tex;
		ud1.GetComponent<Renderer>().material = ud1_tex;
		
		// set lastPosition
		lastPosition = player.transform.position;
		
		StartCoroutine (GenerateBubbles ());
	}
	
	// Update is called once per frame
	void Update () {
		// We are checking whether or not the keyboard key 'P' is pressed
		// Obviously, this is not what we want for an android game as there is no keyboard key 'P'
		// Let's change this.
		if (Input.GetKeyUp(KeyCode.P))
		{
			Pause();
		}
		
		if (paused || gameOver)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;

		AnimateWater();
	}

	// The following methods are used in controlling gameflow
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player")
			Finish ();
		else
			Destroy(other.gameObject);
	}

	public void Pause()
	{ this.paused = !this.paused; }
	
	public void GameOver()
	{ gameOver = true; Application.LoadLevel(1); } 
	
	public bool getGameOver()
	{ return gameOver; }

	public void Finish() { StartCoroutine(BeatGame()); }
	IEnumerator BeatGame()
	{
		yield return new WaitForSeconds(5);
		Application.LoadLevel(0);
	}

	// The following methods are used in water animation
	// Animation Controller
	void AnimateWater () {
		Vector2 offset = (new Vector2(player.transform.position.x, player.transform.position.y) - lastPosition);
		lastPosition = player.transform.position;
		// Track camera position
//		lr1.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, zPlane);
		lr2.transform.position = ud1.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, zPlane);

		// SetTextureOffset LR
//		lr1.GetComponent<Renderer>().material.mainTextureOffset = lr1.GetComponent<Renderer>().material.mainTextureOffset + Time.deltaTime * (new Vector2(lrScroll, 0) - offset * 3);
		lr2.GetComponent<Renderer>().material.mainTextureOffset = lr2.GetComponent<Renderer>().material.mainTextureOffset - Time.deltaTime * (new Vector2(lrScroll * 3/4, 0) + offset * 1.5f);
		ud1.GetComponent<Renderer>().material.mainTextureOffset = ud1.GetComponent<Renderer>().material.mainTextureOffset + Time.deltaTime * (new Vector2(udScroll / 3, udScroll) - offset * 7.5f);
	}
	
	void InitQuadSizes() {
		float distance = Camera.main.transform.position.z - zPlane;
		float height = 4.0f * Mathf.Tan (0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * distance;
		float width =  2.0f * height * Screen.width / Screen.height;
		// assign for each quad
		lr2.transform.localScale = ud1.transform.localScale = new Vector3(width,height);
	}

	// The following methods are used in controlling bubbles
	//Create Bubbles throughout the water
	IEnumerator GenerateBubbles() {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i=0; i<bubbleCount; i++) {
				yield return new WaitForSeconds(waveWait);
				Vector3 playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
				Vector3 position = new Vector3 (Random.Range (playerPos.x - threshold, playerPos.x + threshold),
				                                playerPos.y - 5,
				                                0);
				Instantiate (bubble, position, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}

			if (gameOver) {
				break;
			}
		}
		
	}

}
