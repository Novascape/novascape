using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {
	public static int resourceRequirement;
    // Use this for initialization
    void Start () {
        resourceRequirement = 5;
	}

    void OnCollisionEnter2D(Collision col)
	{
		InventoryGUI inventory = GameObject.Find ("Inventory").GetComponent<InventoryGUI> ();
        if (col.gameObject.CompareTag("Person") && 
		    inventory.list[0].count >= resourceRequirement &&
		    inventory.list[1].count >= resourceRequirement &&
		    inventory.list[2].count >= resourceRequirement &&
		    inventory.list[3].count >= resourceRequirement &&
		    inventory.list[4].count >= resourceRequirement &&
		    inventory.list[5].count >= resourceRequirement){
			Application.Quit();
        }
    }

}
