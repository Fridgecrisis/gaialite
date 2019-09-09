using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
	
	public GameData gameData;
	public GameMaster gameMaster;
	
	void Start() {
		gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
		gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
	}
	
	//--- To be expanded by children. ---//
	public virtual void Interact() {
	}

}
