using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextContent : MonoBehaviour
{
	
	public string nextContentType;
	public string nextContentName;
	
    void Start() {
        GameObject[] mainObjects = SceneManager.GetSceneByName("Main").GetRootGameObjects();
		for (int i = 0; i < mainObjects.Length; i++) {
			if (mainObjects[i].name == "GameMaster") {
				mainObjects[i].GetComponent<GameMaster>().StartContent(nextContentType, nextContentName);
			}
		}
    }
	
    void Update() {
    }
}
