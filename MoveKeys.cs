using UnityEngine;
using System.Collections;

public class MoveKeys : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}
	public float speed = 1.0f;
	// Update is called once per frame
	void Update () 
	{
		//if(NetworkView.isMine){
			Vector3 zpos = transform.position;
			zpos.z = 0;
			transform.position = zpos;
			transform.Rotate (0, 0, 0);

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Translate (Vector3.left*(speed)*Time.deltaTime);
				transform.eulerAngles=new Vector3(0,100,0);
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.Translate(Vector3.right*(speed)*Time.deltaTime);
				transform.eulerAngles=new Vector3(0,0,0);
			}
			if (Input.GetKey(KeyCode.UpArrow))
			{
				transform.Translate(Vector3.up*(speed)*Time.deltaTime);
				transform.eulerAngles=new Vector3(100,0,0);
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.Translate(Vector3.down*(speed*2)*Time.deltaTime);
				transform.eulerAngles=new Vector3(-100,0,0);
			}
		//}
	}
}
