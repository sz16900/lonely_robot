using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Music at the start of the level, before drums kick in!
public class DemoArea : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			{
				PlayerController.drumVar = 0;
                //test if the zone has been entered
				print ("in DEMO proximity");
			}
		}
	}
    void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.CompareTag("Player")) {
			PlayerController.drumVar = 1;
            //test if the zone has been exited
            print("out of DEMO proximity");
		}
	}
}





