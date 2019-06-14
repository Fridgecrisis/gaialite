using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {

	public string currentMapName;
	public string nextMapName;
	
	public bool seenIntro;
	
	void Start () {
	}
	
	void Update () {
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
