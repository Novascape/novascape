using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour {

	private Rect inventoryRect = new Rect(40,40,400,320);
	private bool toggleShow = false;
	public ItemClass[] list = new ItemClass[25];
	public Texture2D blank;

	// Use this for initialization
	void Start () {
		for (int i=0; i<list.Length; i++) { //initialization
			list[i] = new ItemClass(-1, "Blank", blank, "Blank shit");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void add(int a, string b, Texture2D c, string d)
	{
		ItemClass newItem = new ItemClass (a, b, c, d);
		for (int i=0; i<list.Length; i++) {
			if (list[i].getID() == -1)
			{
				list[i] = newItem;
				break;
			}
		}
	}

	void OnGUI(){
		toggleShow = GUI.Toggle (new Rect (400, 20, 100, 50), toggleShow, "Inventory");

		if (toggleShow) {
			inventoryRect = GUI.Window (0, inventoryRect, inventoryMethod, "Inventory");
		}
	}

	void inventoryMethod(int windowID){
		GUILayout.BeginArea (new Rect (5, 50, 395, 270));

		GUILayout.BeginHorizontal ();
		GUILayout.Button (list[0].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.Button (list[1].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.Button (list[2].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.Button (list[3].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.Button (list[4].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Button (list[5].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.Button (list[6].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.Button (list[7].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.Button (list[8].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.Button (list[9].getIcon(), GUILayout.Height (50), GUILayout.Width (50));
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Button ("Item 7", GUILayout.Height (50));
		GUILayout.Button ("Item 8", GUILayout.Height (50));
		GUILayout.Button ("Item 9", GUILayout.Height (50));
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Button ("Item 10", GUILayout.Height (50));
		GUILayout.Button ("Item 11", GUILayout.Height (50));
		GUILayout.Button ("Item 12", GUILayout.Height (50));
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Button ("Item 13", GUILayout.Height (50));
		GUILayout.Button ("Item 14", GUILayout.Height (50));
		GUILayout.Button ("Item 15", GUILayout.Height (50));
		GUILayout.EndHorizontal ();

		GUILayout.EndArea ();
	}

	public class ItemClass{
		int id;
		string name;
		Texture2D icon;
		string description;

		public ItemClass(int x, string y, Texture2D z, string a)
		{
			id = x;
			name = y;
			icon = z;
			description = a;
		}
		public int getID()
		{
			return id;
		}
		public Texture2D getIcon(){
			return icon;
		}

	}






}
