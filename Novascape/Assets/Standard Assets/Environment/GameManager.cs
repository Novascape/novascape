using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance= null;
	private Planet planet1;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		planet1 = GetComponent<Planet>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
