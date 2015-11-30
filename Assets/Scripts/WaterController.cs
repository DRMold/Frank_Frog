using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour {
	// User-Added vars
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

	public GameObject bubble;
	public float threshold;


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

	//Create Bubbles throughout the water
	void GenerateBubbles() {
		Vector3 playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		Vector3 position = new Vector3 (Random.Range (playerPos.x - threshold, playerPos.x + threshold),
		                                playerPos.y - 5,
		                                0);
		Instantiate(bubble, position, Quaternion.identity);
	}

	void InitQuadSizes() {
		float distance = Camera.main.transform.position.z - zPlane;
		float height = 4.0f * Mathf.Tan (0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * distance;
		float width =  2.0f * height * Screen.width / Screen.height;
		// assign for each quad
		lr2.transform.localScale = ud1.transform.localScale = new Vector3(width,height);
	}

	void OnTriggerExit2D(Collider2D other) {
		Destroy(other.gameObject);
	}

	// Use this for initialization
	void Start () {
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
	}
	
	// Update is called once per frame
	void Update () {
		AnimateWater();
		if (Random.value>0.95)
			GenerateBubbles();
	}
}
