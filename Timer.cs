using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	string textTime; //added this member variable here so we can access it through other scripts
	private float timeLimit=180f;

	
	
	public void OnGUI () {
		
		
		//float minutes = timeLimit / 60;
		//float seconds  = timeLimit % 60;
		//float fraction  = (timeLimit * 100) % 100;
		
		
		//textTime = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction); 
		GUI.Label (new Rect (20, 20, 100, 100), timeLimit.ToString()); //changed variable name to textTime -->text is not a good variable name since it has other use already
		
		
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timeLimit -= Time.deltaTime;
		if (timeLimit <= 0)
			Application.Quit ();
	}
}

