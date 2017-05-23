using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls skateboard object.
public class moveBoard : MonoBehaviour {
	private float force = 0f;


	// Update is called once per frame
	void Update () {

        ConstantForce2D skate = GetComponent<ConstantForce2D>();
        skate.relativeForce = new Vector3(force, 0, 1);

    }

	public void AdjustSpeed(float newForce)	{
        force = newForce;
    }

}


