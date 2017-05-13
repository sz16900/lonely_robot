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
    // If you add another boulder, make sure you also add it here
    private Vector2 Boulder1Pos;
    private Vector2 Boulder2Pos;
    private Vector2 Boulder3Pos;
    private Vector2 Boulder4Pos;
    private Vector2 BoulderBasketballPos;

    void Start() {
        // Sets the initial size of the boulder object to the variables set in the Inspector.
        // Without this the boulder sprite will not be visible, or if set to 1 the sprite
        // will be set to the original sprite size e.g very large!
        Transform boulderTransform = GetComponent<Transform>();
        scaleX = boulderTransform.localScale.x;
        scaleY = transform.localScale.y;

        Boulder1Pos = GameObject.Find("Boulder1").transform.position;
        Boulder2Pos = GameObject.Find("Boulder2").transform.position;
        Boulder3Pos = GameObject.Find("Boulder3").transform.position;
        Boulder4Pos = GameObject.Find("Boulder4").transform.position;
        BoulderBasketballPos = GameObject.Find("BoulderBasketballPos").transform.position;
    }

	void Update() {
		transform.Rotate (0, 0, rotateSpeed * 2 * Time.deltaTime);
		transform.localScale = new Vector2(scaleX, scaleY);
		Rigidbody2D boulder = GetComponent<Rigidbody2D>();
		boulder.gravityScale = objGravity;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathTrigger"))
        {
            if (gameObject.name == "Boulder1")
            {
                Transform boulderTransform = GetComponent<Transform>();
                transform.position = new Vector2(Boulder1Pos[0], Boulder1Pos[1]);
                resetParameters();
            }
            if (gameObject.name == "Boulder2")
            {
                Transform boulderTransform = GetComponent<Transform>();
                transform.position = new Vector2(Boulder2Pos[0], Boulder2Pos[1]);
                resetParameters();
            }
            if (gameObject.name == "Boulder3")
            {
                Transform boulderTransform = GetComponent<Transform>();
                transform.position = new Vector2(Boulder3Pos[0], Boulder3Pos[1]);
                resetParameters();

            }
            if (gameObject.name == "Boulder4")
            {
                Transform boulderTransform = GetComponent<Transform>();
                transform.position = new Vector2(Boulder4Pos[0], Boulder4Pos[1]);
                resetParameters();

            }
        }
    }

    void resetParameters() {
        AdjustObjGravity(1f);
        AdjustRotateSpeed(0f);
    }
}
