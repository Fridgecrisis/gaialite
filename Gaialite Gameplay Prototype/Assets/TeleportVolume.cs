using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportVolume : MonoBehaviour
{
	
	public string teleportTo;
	public string spawnPoint;
	private GameMaster gameMaster;
	
    // Start is called before the first frame update
    void Start()
    {
        if (gameMaster == null) {
			gameMaster = GameObject.FindWithTag("GameMaster").GetComponent<GameMaster>();
		}
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.transform.parent.gameObject.tag == "Player") {
			gameMaster.nextSpawnPoint = spawnPoint;
			gameMaster.StartContent("map", teleportTo);
		}
	}
}
