using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float maxSpeed = 3.0f;
	float speed = 50.0f;
	//float jumpPower = 150.0f;
	bool grounded = true;

	Rigidbody2D rb2d;
	Animator anim;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
        fixedUpdate();
	}

	void fixedUpdate(){
		// Player Movement
		float h = Input.GetAxis ("Horizontal");
		rb2d.AddForce((Vector2.right * speed) * h);
		
		//  Limits the speed of the player.
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}
}
