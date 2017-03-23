using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphBoulderVariables : MonoBehaviour {

    // Controls the rotation speed for the boulder
	private float rotateSpeed = 0f;
    // Controls the X length of the boulder
    private float scaleX;
    // Controls the Y length of the boulder
    private float scaleY;
    // Controls the gravity of the boulder
    private float objGravity = 1f;

	void Start() {
        // Sets the initial size of the boulder object to the variables set in the Inspector.
        // Without this the boulder sprite will not be visible, or if set to 1 the sprite
        // will be set to the original sprite size e.g very large!
        Transform boulderTransform = GetComponent<Transform>();
        scaleX = boulderTransform.localScale.x;
        scaleY = transform.localScale.y;

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
