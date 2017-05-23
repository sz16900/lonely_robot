using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls ball object.
public class moveBall : MonoBehaviour {
	private float rotationSpeed = 0f;
	private float objGravity = 1f;


	// Update is called once per frame
	void Update () {

		transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed);
		Rigidbody2D boulder = GetComponent<Rigidbody2D>();
		boulder.gravityScale = objGravity;
	}

	public void AdjustSpeed(float newSpeed) {
		rotationSpeed = newSpeed;
	}

	public void AdjustObjGravity (float newObjGravity) {
		objGravity = newObjGravity;
	}
}


