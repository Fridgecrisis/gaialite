using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_PickupBox : Interaction
{
	
	//--- This function is called when the object is interacted with. ---//
    public override void Interact() {
		Debug.Log("Pickup Box!");
		this.gameObject.SetActive(false);
		gameMaster.StartDialogue("Dialogue1");
		gameData.SetProgress("Pickup box", true);
	}
	
}
