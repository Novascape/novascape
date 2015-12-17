using UnityEngine;
using System.Collections;

public class mouseControl : MonoBehaviour {

	private Vector2 mousePosition;
	public float moveSpeed = 50.0f;
	private int durability = 1000000;
	private GameObject player;

	private Quaternion initRot;
	// Use this for initialization
	void Start () 
	{
		//Screen.showCursor = false;
	}
	 
	// Update is called once per frame
	void Update () 
	{
		transform.localPosition = new Vector3 (-0.131f, -0.139f, 0);
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5.23f;
		
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		
		float angle = (Mathf.Atan2(mousePos.y, mousePos.x)+180) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
//		if (Input.GetMouseButtonDown (0)) 
//		{
//			transform.position=Input.mousePosition;
//			Debug.Log ("Pressed left click");
//		}
		/*
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = Vector2.Lerp(transform.position, mousePosition,moveSpeed);*/
	}
	void LateUpdate()
	{

		//transform.rotation = initRot;
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
		//GUI.Label (new Rect (20, 20, 100, 100), durability.ToString ());
	}
}
