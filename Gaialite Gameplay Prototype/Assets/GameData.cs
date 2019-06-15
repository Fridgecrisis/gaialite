using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

	public GameObject GameManager;
	
	public string currentMapSceneName;
	public string nextMapSceneName;
	public string currentBattleName;
	public string nextBattleName;
	
	public bool seenIntro;
	
	void Start () {
	}
	
	void Update () {
	}

//--- Content Type ---//

	public string currentContentType;
	public string nextContentType;
	
	public void SetCurrentContentType (string name) {
		currentContentType = name;
	}
	
	public void SetNextContentType (string name) {
		nextContentType = name;
	}
	
//--- Map Data ---//
	
	public string currentMapName;
	public string nextMapName;
	
	public void SetCurrentMapName (string name) {
		currentMapName = name;
	}
	
	public void SetNextMap (string name) {
		nextMapName = name;
	}
	
//--- Cutscene Data ---//	

	public string currentCutsceneName;
	public string nextCutsceneName;
	
	public void SetCurrentCutsceneName (string name) {
		currentCutsceneName = name;
	}
	
	public void SetNextCutscene (string name) {
		nextCutsceneName = name;
	}
	
//--- Game Progress ---//
	
	public Dictionary<string, bool> gameProgress;
	
	void InitializeProgress () {
		AddProgressItem("Seen intro", false);
	}
	
	void AddProgressItem (string name, bool progressValue = false) {
		if (!gameProgress.ContainsKey(name)) {
			gameProgress.Add(name, progressValue);
		}
	}
	
	bool GetProgress (string name) {
		if (!gameProgress.ContainsKey(name)) {
			Debug.LogWarning("Progress item '" + name + "' not found. Returning false.");
			return false;
		}
		return gameProgress[name];
	}
	
	void SetProgress (string name, bool progressValue = true) {
		if (!gameProgress.ContainsKey(name)) {
			gameProgress.Add(name, progressValue);
		} else {
			gameProgress[name] = progressValue;
		}
	}
	
}
