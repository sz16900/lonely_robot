using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTrigger : MonoBehaviour {

    // The UI for the Boulder controls are wrapped up in a Canvas Group
	public CanvasGroup CanvasGroupBoulder;

    public Canvas CanvasSortOrder;


    // When player enters the BoulderUI collider, the UI is shown
    void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag("Player")) {
            // Alpha adjusts the opacity of the UI. 1 = visible 0 = hidden (anything in between is transparent).
            CanvasSortOrder.sortingOrder = 1;
            CanvasGroupBoulder.alpha = 0.8f;
            CanvasGroupBoulder.interactable = true;
            CanvasGroupBoulder.blocksRaycasts = true;
            Debug.Log(CanvasGroupBoulder.name);
		}
	}

    // When player leaves, the BoulderUI collider is hidden
	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.CompareTag("Player")) {
            CanvasSortOrder.sortingOrder = 0;
            CanvasGroupBoulder.alpha = 0f;
            CanvasGroupBoulder.interactable = false;
            CanvasGroupBoulder.blocksRaycasts = false;
            Debug.Log(CanvasGroupBoulder.name);

        }
    }
}
