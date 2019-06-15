using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
	
	public string mapToLoad;
	
    void Start() {
        GameObject[] mainObjects = SceneManager.GetSceneByName("Main").GetRootGameObjects();
		for (int i = 0; i < mainObjects.Length; i++) {
			if (mainObjects[i].name == "GameMaster") {
				mainObjects[i].GetComponent<GameFunctions>().LoadMap(mapToLoad);
			}
		}
    }
	
    void Update() {
    }
}
