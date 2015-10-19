using UnityEngine;
using System.Collections;

public class mouseControl : MonoBehaviour {

	private Vector2 mousePosition;
	public float moveSpeed = 0.1f;
	private int durability = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition,moveSpeed);
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
