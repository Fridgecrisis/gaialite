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

/* 	public Dictionary<string, bool> gameProgress;

	void Start () {
		
	}
	
	void Update () {
		
	}
	
	void Initialize () {
		AddProgressItem("Seen intro", false);
	}
	
	void AddProgressItem (string name, bool progressValue) {
		if (!gameProgress.ContainsKey(name)) {
			gameProgress.Add(name, progressValue);
		}
	} */
}
