using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class skateboardProx : MonoBehaviour {



	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			{
				PlayerController.skateboardVar = 1;
				print ("in Skateboard proximity");
			}
		}
	}
	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.CompareTag("Player")) {
			PlayerController.skateboardVar = 0;
			print ("out of Skateboard proximity");
		}
	}
}

