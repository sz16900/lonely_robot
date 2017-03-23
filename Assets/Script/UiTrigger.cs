using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTrigger : MonoBehaviour {

    // The UI for the box controls are wrapped up in a Canvas Group
	public CanvasGroup CanvasGroupBox;

    // When player enters the BoxUI collider, the UI is shown
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
            // Alpha adjusts the opacity of the UI. 1 = visible 0 = hidden (anything in between is transparent).
            CanvasGroupBox.alpha = 0.8f;
            CanvasGroupBox.interactable = true;
            CanvasGroupBox.blocksRaycasts = true;
		}
	}

    // When player leaves, the BoxUI collider is hidden
	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.CompareTag("Player")) {
            CanvasGroupBox.alpha = 0f;
            CanvasGroupBox.interactable = false;
            CanvasGroupBox.blocksRaycasts = false;
		}
	}
}
