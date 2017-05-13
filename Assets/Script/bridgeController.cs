using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeController : MonoBehaviour {

    public Transform platform;
    public Transform startTransform;
    public Transform endTransform;    
    public float platformSpeed;

    Vector3 direction;
    Transform destination;

    // Use this for initialization
    void Start()
    {
        SetDestination(startTransform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);
        if (Vector3.Distance(platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
        {
            SetDestination(destination == startTransform ? endTransform : startTransform);
        }
    }

    public void AdjustSpeed(float newSpeed)
    {
        platformSpeed = newSpeed;
    }

    void SetDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized;
    }
}
