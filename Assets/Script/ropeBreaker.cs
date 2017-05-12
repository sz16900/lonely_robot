using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeBreaker : MonoBehaviour {
	
	private int brForce = 100000;

	// Update is called once per frame
	void Update () {
		HingeJoint2D rope = GetComponent<HingeJoint2D> ();
		rope.breakForce = brForce;
	}

	public void Tension(int newForce)
	{
		brForce = newForce;
	}

}