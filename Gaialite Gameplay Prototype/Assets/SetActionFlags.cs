using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActionFlag : MonoBehaviour {

	void ActionStarted() {
		var animator = gameObject.GetComponent<Animator>();
		animator.SetBool("Action", true);
	}
	
	void ActionFinished() {
		var animator = gameObject.GetComponent<Animator>();
		animator.SetBool("Action", false);
	}
	
}
