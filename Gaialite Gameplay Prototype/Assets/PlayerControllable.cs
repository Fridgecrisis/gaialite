using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllable : MonoBehaviour
{
	
	public GameObject map;
	public GameObject freeMovement;
	public GameObject player;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Is map active?
		if (map.activeInHierarchy == true) {
			player.gameObject.SetActive(true);
		} else {
			player.gameObject.SetActive(false);
		}
		
		// Enable free movement?
        if (freeMovement.activeInHierarchy == true) {
			player.GetComponent<PlayerCharacter>().enabled = true;
		} else {
			player.GetComponent<PlayerCharacter>().enabled = false;
		}
    }
}
