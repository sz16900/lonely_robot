using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Changes the music when player enters the christmas lights bridge.
public class christmassProx : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			{
				PlayerController.christmassVar = 1;
				print ("in Christmass proximity");
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.CompareTag("Player")) {
			PlayerController.christmassVar = 0;
			print ("out of Chriatmass proximity");
		}
	}
}