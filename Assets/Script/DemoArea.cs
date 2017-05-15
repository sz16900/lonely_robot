using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DemoArea : MonoBehaviour {

	//private AudioSource audioSource;
	//public AudioClip Scored;
	//private bool inZone = true;

	//void Start () {
	//	audioSource = GetComponent<AudioSource>();
	//	audioSource.clip = Scored;
	//}



	//public void Update (){
		//audioSource = GetComponent<AudioSource>();
	//	audioSource.clip = Scored;
	//	if (PlayerController.moving == true  && PlayerController.grounded  == true && !audioSource.isPlaying) {
			//audioSource.Play ();
			//print ("GRASS PLAY");
	//	}if (PlayerController.moving == false|| inZone==false){
	//		audioSource.Stop ();
	//		print ("GRASS STOP");
	//	}
//	}





	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			{
				//inZone = true;
				PlayerController.drumVar = 0;
				//Player.csound.setChannel ("wheelSlider", 1);
				print ("in DEMO proximity");

			}
		}
	}
		// When player leaves, the BoulderUI collider is hidden
    void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.CompareTag("Player")) {
			PlayerController.drumVar = 1;
			//audioSource.Stop ();
			//inZone = false;
			//Player.csound.setChannel ("wheelSlider", 0);
		    print ("out of DEMO proximity");
		}
	}
}





