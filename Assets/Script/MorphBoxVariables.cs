using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphBoxVariables : MonoBehaviour {

    // Controls the rotation speed for the box
	private float rotateSpeed = 0f;
    // Controls the X length of the box
	private float scaleX = 1f;
    // Controls the Y length of the box
    private float scaleY = 1f;
    // Controls the gravity of the box
    private float objGravity = 1f;

	void Start() {

	}

	void Update() {
		transform.Rotate (0, 0, rotateSpeed * 2 * Time.deltaTime);
		transform.localScale = new Vector2(scaleX, scaleY);
		Rigidbody2D crate = GetComponent<Rigidbody2D>();
		crate.gravityScale = objGravity;
	}

	public void AdjustRotateSpeed (float newSpeed) {
        rotateSpeed = newSpeed;
	}

	public void AdjustScaleX (float newScale) {
		scaleX = newScale;
	}

	public void AdjustScaleY (float newScale) {
		scaleY = newScale;
	}

	public void AdjustObjGravity (float newObjGravity) {
		objGravity = newObjGravity;
	}
}
