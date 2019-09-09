using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--- This object is for storing game variables and progress data. It does not actually run the game--that's the Game Master's job. ---//
public class GameData : MonoBehaviour {

	public GameMaster gameMaster;

	public bool seenIntro;
	
	void Start () {
	}
	
	void Update () {
	}

//--- Content Type ---//

	public string currentContentType;
	public string currentMapName;
	public string currentBattleName;
	public string currentCutsceneName;
	public string currentDialogueName;
	
	public void SetCurrentContentType (string type) {
		currentContentType = type;
	}
	
	public void SetCurrentMapName (string name) {
		currentMapName = name;
	}
	
	public void SetCurrentBattleName (string name) {
		currentBattleName = name;
	}
	
	public void SetCurrentCutsceneName (string name) {
		currentCutsceneName = name;
	}
	
	public void SetCurrentDialogueName (string name) {
		currentDialogueName = name;
	}
	
//--- Game Progress ---//
	
	public Dictionary<string, bool> gameProgress;
	
	public void InitializeProgress () {
		//--- List ALL trackable progress items here. ---//
		AddProgressItem("Seen intro", false);
		AddProgressItem("Pickup box", false);
	}
	
	public void AddProgressItem (string name, bool progressValue = false) {
		if (!gameProgress.ContainsKey(name)) {
			gameProgress.Add(name, progressValue);
		}
	}
	
	public bool GetProgress (string name) {
		if (!gameProgress.ContainsKey(name)) {
			Debug.LogWarning("Progress item '" + name + "' not found. Returning false.");
			return false;
		}
		return gameProgress[name];
	}
	
	public void SetProgress (string name, bool progressValue = true) {
		if (!gameProgress.ContainsKey(name)) {
			gameProgress.Add(name, progressValue);
		} else {
			gameProgress[name] = progressValue;
		}
	}
	
}
