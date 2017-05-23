using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controlls the ferris wheel object.
public class FerrisController : MonoBehaviour {

    public float rotationSpeed;

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * rotationSpeed);
    }

    public void AdjustSpeed(float newSpeed) {
        rotationSpeed = newSpeed;
    }

}
