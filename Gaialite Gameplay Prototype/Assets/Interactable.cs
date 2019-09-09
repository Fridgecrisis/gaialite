using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	
	public SphereCollider rangeCollider;
	public CapsuleCollider playerCollider;
	public GameObject buttonImage;
	public bool playerInRange = false;
	public Interaction interaction;
	
    void Start()
    {
        
    }

    void Update()
    {
		// Look for range collider
		if (rangeCollider == null) {
			rangeCollider = this.gameObject.GetComponent<SphereCollider>();
		}
		
		// Look for player collider
		if (playerCollider == null) {
			playerCollider = GameObject.FindWithTag("Player").GetComponentInChildren<CapsuleCollider>();
		}
		
		// Look for interaction
		if (interaction == null) {
			interaction = this.gameObject.GetComponent<Interaction>();
		}
		
        if (playerInRange == true) {
			buttonImage.SetActive(true);
			if (Input.GetButtonDown("A")) {
				Interact();
			}
		} else {
			buttonImage.SetActive(false);
		}
		
    }
	
	public void OnTriggerEnter(Collider other) {
		if (other == playerCollider) {
			playerInRange = true;
		}
	}
	
	public void OnTriggerExit(Collider other) {
		if (other == playerCollider) {
			playerInRange = false;
		}
	}
	
	public void Interact() {
		Debug.Log("Interacting!");
		interaction.Interact();
	}
	
}
