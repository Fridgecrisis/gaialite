using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//--- This object is responsible for running and managing the game. ---//
public class GameMaster : MonoBehaviour
{
	public PlayMakerFSM gameStateMachine;
	public PlayMakerFSM mapStateMachine;
	public PlayMakerFSM freeMovementStateMachine;
	public PlayMakerFSM mapDialogueStateMachine;
	public PlayMakerFSM battleStateMachine;
	public PlayMakerFSM cutsceneStateMachine;
	
	public GameData gameData;
	
	public string nextContentType;
	public string nextContentName;
	
    void Start() {
        
    }

    void Update() {
        
    }
	
	public void SetNextContent (string type, string name) {
		nextContentType = type;
		nextContentName = name;
	}
	
	public void StartNextContent () {
		StartContent(nextContentName, nextContentType);
	}
	
	public void StartContent (string type, string name) {
		SetNextContent(type, name);
		switch (type) {
			case "map":
				StartMap(name);
				break;
			case "cutscene":
				StartCutscene(name);
				break;
			case "battle":
				StartBattle(name);
				break;
			case "dialogue":
				StartDialogue(name);
				break;
			case "return to map":
				ReturnToMap();
				break;
			default:
				Debug.LogWarning("Next content type not recognized.");
				break;
		}
	}
	
	void UpdateStateMachines () {
		if (mapStateMachine.gameObject.activeSelf == true && nextContentType != "map" && nextContentType != "battle" && nextContentType != "dialogue" && nextContentType != "return to map") {
			mapStateMachine.SendEvent("Deactivate");
		} else if (cutsceneStateMachine.gameObject.activeSelf == true && nextContentType != "cutscene") {
			cutsceneStateMachine.SendEvent("Deactivate");
		} else if (battleStateMachine.gameObject.activeSelf == true && nextContentType != "battle") {
			battleStateMachine.SendEvent("Deactivate");
		} else if (mapDialogueStateMachine.gameObject.activeSelf == true && nextContentType != "dialogue") {
			mapDialogueStateMachine.SendEvent("Deactivate");
		}
		
		if (mapStateMachine.gameObject.activeSelf == false && nextContentType == "map") {
			mapStateMachine.gameObject.SetActive(true);
			mapStateMachine.SendEvent("Activate");
		} else if (cutsceneStateMachine.gameObject.activeSelf == false && nextContentType == "cutscene") {
			cutsceneStateMachine.gameObject.SetActive(true);
			cutsceneStateMachine.SendEvent("Activate");
		} else if (battleStateMachine.gameObject.activeSelf == false && nextContentType == "battle") {
			battleStateMachine.gameObject.SetActive(true);
			battleStateMachine.SendEvent("Activate");
		} else if (mapDialogueStateMachine.gameObject.activeSelf == false && nextContentType == "dialogue") {
			mapStateMachine.SendEvent("OpenDialogue");
		}
		
		if (nextContentType == "return to map") {
			mapStateMachine.SendEvent("ReturnTo");
		}
	}
	
//--- Map ---//
	
	public void StartNextMap () {
		StartMap(nextContentName);
	}
	
	public void StartMap (string name) {
		SetNextContent("map", name);
		EndCurrentMap();
		EndCurrentCutscene();
		EndCurrentBattle();
		EndCurrentDialogue();
		LoadMap(name);
		UpdateStateMachines();
	}
	
	public void EndCurrentMap () {
		if (gameData.currentMapName != "") {
			Debug.Log("Unloading map: " + gameData.currentMapName);
			SceneManager.UnloadSceneAsync(gameData.currentMapName);
			UpdateGameData("map", "");
		} else {
			Debug.Log("Unloading map: No map to unload.");
		}
	}
	
	void LoadMap (string name) {
		if (name != "") {
			Debug.Log("Loading map: " + name);
			SceneManager.LoadScene(name, LoadSceneMode.Additive);
			UpdateGameData("map", name);
		} else {
			Debug.Log("Loading map: No map to load.");
		}
	}
	
	public void ReturnToMap () {
		SetNextContent("return to map", name);
		EndCurrentBattle();
		EndCurrentDialogue();
		if (gameData.currentMapName != "") {
			Debug.Log("Returning to map: " + gameData.currentMapName);
		} else {
			Debug.LogWarning("No current map to return to.");
		}
		UpdateStateMachines();
	}
	
//--- Cutscene ---//
	
	public void StartNextCutscene () {
		StartCutscene(nextContentName);
	}
	
	public void StartCutscene (string name) {
		SetNextContent("cutscene", name);
		EndCurrentMap();
		EndCurrentCutscene();
		EndCurrentBattle();
		EndCurrentDialogue();
		LoadCutscene(name);
		UpdateStateMachines();
	}
	
	public void EndCurrentCutscene () {
		if (gameData.currentCutsceneName != "") {
			Debug.Log("Unloading cutscene: " + gameData.currentCutsceneName);
			SceneManager.UnloadSceneAsync(gameData.currentCutsceneName);
			UpdateGameData("cutscene", "");
		} else {
			Debug.Log("Unloading cutscene: No cutscene to unload.");
		}
	}
	
	void LoadCutscene (string name) {
		if (name != "") {
			Debug.Log("Loading cutscene: " + name);
			SceneManager.LoadScene(name, LoadSceneMode.Additive);
			UpdateGameData("cutscene", name);
		} else {
			Debug.Log("Loading cutscene: No cutscene to load.");
		}
	}
	
//--- Battle ---//
	
	public void StartNextBattle () {
		StartBattle(nextContentName);
	}
	
	public void StartBattle (string name) {
		SetNextContent("battle", name);
		EndCurrentCutscene();
		EndCurrentBattle();
		EndCurrentDialogue();
		LoadBattle(name);
		UpdateStateMachines();
	}
	
	public void EndCurrentBattle () {
		if (gameData.currentBattleName != "") {
			Debug.Log("Unloading battle: " + gameData.currentBattleName);
			SceneManager.UnloadSceneAsync(gameData.currentBattleName);
			UpdateGameData("battle", "");
		} else {
			Debug.Log("Unloading battle: No battle to unload.");
		}
	}
	
	void LoadBattle (string name) {
		if (name != "") {
			Debug.Log("Loading battle: " + name);
			SceneManager.LoadScene(name, LoadSceneMode.Additive);
			UpdateGameData("battle", name);
		} else {
			Debug.Log("Loading battle: No battle to load.");
		}
	}
	
//--- Dialogue ---//
	
	public void StartNextDialogue () {
		StartDialogue(nextContentName);
	}
	
	public void StartDialogue (string name) {
		SetNextContent("dialogue", name);
		EndCurrentCutscene();
		EndCurrentBattle();
		EndCurrentDialogue();
		LoadDialogue(name);
		UpdateStateMachines();
	}
	
	public void EndCurrentDialogue () {
		if (gameData.currentDialogueName != "") {
			Debug.Log("Unloading dialogue: " + gameData.currentDialogueName);
			SceneManager.UnloadSceneAsync(gameData.currentDialogueName);
			UpdateGameData("dialogue", "");
		} else {
			Debug.Log("Unloading dialogue: No dialogue to unload.");
		}
	}
	
	void LoadDialogue (string name) {
		if (name != "") {
			Debug.Log("Loading dialogue: " + name);
			SceneManager.LoadScene(name, LoadSceneMode.Additive);
			UpdateGameData("dialogue", name);
		} else {
			Debug.Log("Loading dialogue: No dialogue to load.");
		}
	}
	
//--- Other ---//
	
	void UpdateGameData (string type, string name) {
		gameData.SetCurrentContentType(type);
		switch (type) {
			case "map":
				gameData.SetCurrentMapName(name);
				break;
			case "battle":
				gameData.SetCurrentBattleName(name);
				break;
			case "cutscene":
				gameData.SetCurrentCutsceneName(name);
				break;
			case "dialogue":
				gameData.SetCurrentDialogueName(name);
				break;
			default:
				break;
		}
	}
}
