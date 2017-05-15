using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class endProx : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			{
				PlayerController.endVar = 1;
				print ("in End  proximity");
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.CompareTag("Player")) {
			PlayerController.endVar = 0;
			print ("out of End proximity");
		}
	}
}