using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
	
	public Queue<string> sentences;
	public Dialogue dialogue;

    void Start() {
        sentences = new Queue<string>();
		StartDialogue(dialogue);
    }
	
	public void StartDialogue (Dialogue dialogue) {
		Debug.Log("Starting conversation");
		sentences.Clear();
		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}
	
	public void DisplayNextSentence() {
		if (sentences.Count == 0) {
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		Debug.Log(sentence);
	}
	
	void EndDialogue() {
		Debug.Log("End of conversation");
		GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>().ReturnToMap();
	}
	
}
