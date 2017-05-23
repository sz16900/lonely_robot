using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls parralaxing backound sprites.
public class ScrollingBackground : MonoBehaviour
{

    public float backgroundSize;
    public float paralaxSpeed;
    public float positionZ;

    private Transform cameraTransform;
    private Transform[] layers;
    // viewzone used to be at 10
    private float viewzone = 50;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;
    Transform background;

    private void Start() {

        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update() {

        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewzone)) {
            ScrollLeft();
        }
        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewzone)) {
            ScrollRight();
        }

    }

    private void ScrollLeft() {
        int lastRight = rightIndex;
        layers[rightIndex].position = new Vector3(1 * layers[leftIndex].position.x - backgroundSize, 0, positionZ);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0) {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight() {
        int lastLeft = leftIndex;
        layers[leftIndex].position = new Vector3 (1 * layers[rightIndex].position.x + backgroundSize, 0, positionZ);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length) {
            leftIndex = 0;
        }
    }
}
