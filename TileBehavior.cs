using UnityEngine;
using System.Collections;

public class TileBehavior : MonoBehaviour {

	private int durability = 3;
	public int id=1;
	public Texture2D tileText;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Tool")) {
			durability--;
		}
		if (durability == 0) {
			InventoryGUI script = GameObject.Find ("Inventory").GetComponent<InventoryGUI>();
			script.add (id, "Black Tile", tileText, "Simple");
			this.gameObject.SetActive (false);
		}
	}
}
