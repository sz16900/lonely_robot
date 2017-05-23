using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Music for ferris wheel.
public class ferrisProx : MonoBehaviour {

    // The UI for the Boulder controls are wrapped up in a Canvas Group
	//public 

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			{
				PlayerController.wheelVar = 1;
				//Player.csound.setChannel ("wheelSlider", 1);
				print ("in ferris proximity");
			}
		}
	}
		// When player leaves, the BoulderUI collider is hidden
    void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
			PlayerController.wheelVar = 0;
			//Player.csound.setChannel ("wheelSlider", 0);
		    print ("out of ferris proximity");
		}
	}
}





