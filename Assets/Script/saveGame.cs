using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls saving game menu button.
public class saveGame : MonoBehaviour {
    public Transform Player;
    public Transform canvas;
	public Transform mainCanvas;

    void Awake() {
        Player.position = new Vector3(
            PlayerPrefs.GetFloat("x"),
               PlayerPrefs.GetFloat("y"),
                  PlayerPrefs.GetFloat("z")
                  );
        Player.eulerAngles = new Vector3(0, PlayerPrefs.GetFloat("Cam_y"),0);
		mainCanvas.gameObject.SetActive (true);
    }

    public void saveGameSettings(bool Quit) {
        PlayerPrefs.SetFloat("x", Player.position.x);
        PlayerPrefs.SetFloat("y", Player.position.y);
        PlayerPrefs.SetFloat("z", Player.position.z);
        PlayerPrefs.SetFloat("Cam_y", Player.eulerAngles.y);
        if (Quit) {
            Time.timeScale = 1;
            SceneManager.LoadScene("game_menu");
        }
    }

    public void startFromSaved() {
        Time.timeScale = 1;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.gameObject.SetActive(false);
        Awake();
    }
    

}
