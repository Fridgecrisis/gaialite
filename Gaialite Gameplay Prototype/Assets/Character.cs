using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	[SerializeField] float jumpPower = 5f;
	[SerializeField] float moveSpeed = 1f;
	[SerializeField] float rotateSpeed = 360f;
	[SerializeField] float animSpeedMultiplier = 1f;
	[SerializeField] float groundCheckDistance = 0.1f;

	Rigidbody myRigidbody;
	Animator myAnimator;
	bool moving;
	float leftRight;
	float upDown;
	bool jumping;
	float jumpHeight;
	float origGroundCheckDistance;
	Vector3 m_GroundNormal;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody>();
		myRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		origGroundCheckDistance = groundCheckDistance;
	}

	void Update () {
		if ((leftRight < -0.2f) || (leftRight > 0.2f) || (upDown < -0.2f) || (upDown > 0.2f)) {
			moving = true;
		} else {
			leftRight = 0;
			upDown = 0;
			moving = false;
		}
		if (jumpHeight > 0) {
			jumping = true;
		} else {
			jumping = false;
		}
	}

	public void Move (Vector3 move, bool jump) {
		if (move.magnitude > 1f) move.Normalize();
		CheckGroundStatus();
		move = Vector3.ProjectOnPlane(move, m_GroundNormal);

		//leftRight = Input.GetAxisRaw ("Horizontal");
		//upDown = Input.GetAxisRaw ("Vertical");

		leftRight = move.x;
		upDown = move.z;

		// Dead zone
		if (leftRight < 0.2f && leftRight > -0.2f) {
			leftRight = 0.0f;
		}
		if (upDown < 0.2f && upDown > -0.2f) {
			upDown = 0.0f;
		}

		if (!jumping) {
			HandleGroundMovement(jump);
		} else {
			HandleAirMovement();
		}

		var movement = new Vector3(leftRight, 0, upDown);
		if (movement != Vector3.zero) {
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.2f);
		}
		transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

		Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z - 2);

		UpdateAnimator(move);

		// Super basic, but it works.
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 2.0f;
		//var z = Input.GetAxis("Vertical") * Time.deltaTime * 1.0f;
		//transform.Translate(x, 0, z);
	}

	void UpdateAnimator(Vector3 move)
	{
		myAnimator.SetBool("Moving", moving);
		myAnimator.SetFloat("LeftRight", leftRight, 0.1f, Time.deltaTime);
		myAnimator.SetFloat("UpDown", upDown, 0.1f, Time.deltaTime);
		myAnimator.SetBool("Jumping", jumping);
		if (jumping) {
			myAnimator.SetFloat("Jump", myRigidbody.velocity.y);
		} else {
			myAnimator.SetFloat("Jump", 0.0f);
		}
	}

	void HandleGroundMovement(bool jump) {
		if (jump && !jumping) {
			// jump!
			myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpPower, myRigidbody.velocity.z);
			jumping = true;
			groundCheckDistance = 0.1f;
		}
	}

	void HandleAirMovement() {
		Vector3 extraGravityForce = (Physics.gravity * 1.0f) - Physics.gravity;
		myRigidbody.AddForce(extraGravityForce);
		groundCheckDistance = myRigidbody.velocity.y < 0 ? origGroundCheckDistance : 0.01f;
	}

	void CheckGroundStatus() {
		RaycastHit hitInfo;
		#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * groundCheckDistance));
		#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, groundCheckDistance))
		{
			//Debug.Log("Hit ground");
			jumping = false;
			m_GroundNormal = hitInfo.normal;
		}
		else
		{
			//Debug.Log("In air");
			jumping = true;
			m_GroundNormal = Vector3.up;
		}
	}

}
