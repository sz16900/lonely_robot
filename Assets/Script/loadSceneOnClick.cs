using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Load scene from menu.
public class loadSceneOnClick : MonoBehaviour {
	public void loadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
}
