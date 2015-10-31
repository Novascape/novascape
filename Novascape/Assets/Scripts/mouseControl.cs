using UnityEngine;
using System.Collections;

public class mouseControl : MonoBehaviour {

	private Vector2 mousePosition;
	public float moveSpeed = 50.0f;
	private int durability = 1000000;

	// Use this for initialization
	void Start () {
		//Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		}
		/*
		if (Input.GetMouseButtonDown (0)) {
			transform.position=Input.mousePosition;
			Debug.Log ("Pressed left click");
		}*/
		/*
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition,moveSpeed);*/
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Tile")) {
			durability --;
		}
		if (durability == 0) {
			this.gameObject.SetActive (false);
		}
	}

	void OnGUI()
	{
		GUI.Label (new Rect (20, 20, 100, 100), durability.ToString ());
	}
}
