using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float maxSpeed = 3.0f;
	float speed = 50.0f;
	float jumpPower = 250.0f;
	public bool grounded = false;

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
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));
        if (Input.GetAxis("Horizontal") < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetAxis("Horizontal") > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);
        if (Input.GetButtonDown("Jump") && grounded == true)
            rb2d.AddForce(Vector2.up * jumpPower);
        rb2d.freezeRotation = true;

        fixedUpdate();
	}

	void fixedUpdate(){

        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;
        //fake friction / easing the x speed of the player.
        if (grounded){
            rb2d.velocity = easeVelocity;
        }
        
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
