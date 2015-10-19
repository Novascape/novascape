using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Player player;
	void Start () {
		player = gameObject.GetComponent<Player>();
	}

	void OnTriggerEnter2D(Collider2D col){
		//player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col){
		//player.grounded = false;
	}
}
