using UnityEngine;
using System.Collections;
public class PlanetaryGravity : MonoBehaviour
{
	
	//necessary to instantiate each planet in runtime here^
	private Vector3 directionOfPlanetFromPerson;
	private Vector3 directionOfPlanetFromPerson2;
	private Vector3 directionOfPlanetFromPerson3;
	private Vector3 directionOfPlanetFromPerson4;
	private Vector3 directionOfPlanetFromPerson5;
	private bool allowForce;
	public bool planetgrav1;
	public bool planetgrav2;
	public bool planetgrav3;
	public bool planetgrav4;
	public bool planetgrav5;
	public float gravityDirection;
	Rigidbody2D rb;

	void Start () 
	{
		directionOfPlanetFromPerson = Vector3.zero;
		directionOfPlanetFromPerson2 = Vector3.zero;
		directionOfPlanetFromPerson3 = Vector3.zero;
		directionOfPlanetFromPerson4 = Vector3.zero;
		directionOfPlanetFromPerson5 = Vector3.zero;
		//necessary to set all planetdirections to zero here as well^
		rb = GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		allowForce = false;
		if (Input.GetKey (KeyCode.Space))//planetjump enabled
			allowForce = true;
		ClosestPlanet ();
		if (allowForce&&planetgrav1) 
		{
			Planet p1 = GameObject.Find ("Planet1").GetComponent<Planet>();
			Vector2 Gravdirection = -(transform.position - new Vector3(p1.getMidX(),p1.getMidY(),0));
			rb.AddForceAtPosition (transform.position,(-Gravdirection.normalized)*1/2,ForceMode2D.Force);
		}
		if (allowForce && planetgrav2) 
		{
			Planet p3 = GameObject.Find ("Planet1").GetComponent<Planet>();
			Vector2 Gravdirection = -(transform.position-new Vector3(p3.getMidX(), p3.getMidY(), 0));
			rb.AddForceAtPosition(transform.position,(Gravdirection.normalized),ForceMode2D.Force);
		}
		if (allowForce && planetgrav3) 
		{
			Planet p1 = GameObject.Find ("Planet1").GetComponent<Planet>();
			Vector2 Gravdirection = -(transform.position-new Vector3(p1.getMidX(), p1.getMidY(), 0));
			rb.AddForceAtPosition(transform.position,(Gravdirection.normalized),ForceMode2D.Force);
		}
		if (allowForce && planetgrav4) 
		{
			Planet p4 = GameObject.Find ("Planet1").GetComponent<Planet>();
			Vector2 Gravdirection = -(transform.position-new Vector3(p4.getMidX(), p4.getMidY(), 0));
			rb.AddForceAtPosition(transform.position,(Gravdirection.normalized),ForceMode2D.Force);
		}
		if (allowForce && planetgrav5) 
		{
			Planet p5 = GameObject.Find ("Planet1").GetComponent<Planet>();
			Vector2 Gravdirection = -(transform.position-new Vector3(p5.getMidX(), p5.getMidY(), 0));
			rb.AddForceAtPosition(transform.position,(Gravdirection.normalized),ForceMode2D.Force);
		}
	}
	void ClosestPlanet()
	{
		Planet p1 = GameObject.Find ("Planet1").GetComponent<Planet>();
		Planet p2 = GameObject.Find ("Planet2").GetComponent<Planet>();
		Planet p3 = GameObject.Find ("Planet3").GetComponent<Planet>();
		Planet p4 = GameObject.Find ("Planet4").GetComponent<Planet>();
		Planet p5 = GameObject.Find ("Planet5").GetComponent<Planet>();
		directionOfPlanetFromPerson = (transform.position - new Vector3(p1.getMidX(), p1.getMidY(), 0));
		//transform.right = Vector3.Cross (directionOfPlanetFromPerson, Vector3.forward);
		directionOfPlanetFromPerson2 = transform.position - new Vector3(p2.getMidX(), p2.getMidY(), 0);
		directionOfPlanetFromPerson3 = transform.position - new Vector3 (p3.getMidX (), p3.getMidY (), 0);
		directionOfPlanetFromPerson4 = transform.position - new Vector3 (p4.getMidX (), p4.getMidY (), 0);
		directionOfPlanetFromPerson5 = transform.position - new Vector3 (p5.getMidX (), p5.getMidY (), 0);
		//Planet1
		float one = directionOfPlanetFromPerson.magnitude;
		float two = directionOfPlanetFromPerson2.magnitude;
		float three = directionOfPlanetFromPerson3.magnitude;
		float four = directionOfPlanetFromPerson4.magnitude;
		if (one<two && one<three && one<four) 
		{
			planetgrav1=true;
			planetgrav2=false;
			planetgrav3=false;
			planetgrav4=false;
			planetgrav5=false;
			transform.right = Vector3.Cross (directionOfPlanetFromPerson, Vector3.forward);
			Vector2 Gravdirection = -(transform.position - new Vector3(p1.getMidX(), p1.getMidY(), 0));
			rb.AddForceAtPosition (Gravdirection.normalized, transform.position, ForceMode2D.Force);
		}
		//Planet2
		if (two<one && two<three && two<four) 
		{
			planetgrav2=true;
			planetgrav1=false;
			planetgrav3=false;
			planetgrav4=false;
			planetgrav5=false;
			transform.right = Vector3.Cross(directionOfPlanetFromPerson2,Vector3.forward);
			Vector2 Gravdirection = -(transform.position - new Vector3(p2.getMidX(),p2.getMidY(),0));
			rb.AddForceAtPosition (Gravdirection.normalized, transform.position, ForceMode2D.Force);
		}
		//Planet3
		if (three<one && three<two && three<four)
		{
			planetgrav3=true;
			planetgrav1=false;
			planetgrav2=false;
			planetgrav4=false;
			planetgrav5=false;
			transform.right = Vector3.Cross(directionOfPlanetFromPerson3,Vector3.forward);
			Vector2 Gravdirection = -(transform.position - new Vector3(p3.getMidX(),p3.getMidY(),0));
			rb.AddForceAtPosition (Gravdirection.normalized, transform.position, ForceMode2D.Force);
		}
		//Planet4
		if (four<one && four<two && four<three) 
		{
			planetgrav4 = true;
			planetgrav1 = false;
			planetgrav2 = false;
			planetgrav3 = false;
			planetgrav5 = false;
			transform.right = Vector3.Cross (directionOfPlanetFromPerson4, Vector3.forward);
			Vector2 Gravdirection = -(transform.position - new Vector3 (p4.getMidX (), p4.getMidY (), 0));
			rb.AddForceAtPosition (Gravdirection.normalized, transform.position, ForceMode2D.Force);
		} else {
			planetgrav5 = true;
			planetgrav1 = false;
			planetgrav2 = false;
			planetgrav3 = false;
			planetgrav4 = false;
			transform.right = Vector3.Cross (directionOfPlanetFromPerson5, Vector3.forward);
			Vector2 Gravdirection = -(transform.position - new Vector3 (p5.getMidX (), p5.getMidY (), 0));
			rb.AddForceAtPosition (Gravdirection.normalized, transform.position, ForceMode2D.Force);

		}

	}
}