﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls restarting from beginning menu button.
public class restartFromBeginning : MonoBehaviour {
    public Transform Player;


    void Awake()  {
		Player.position = new Vector3(-723, -42, 0);
        // Change the position below to move player in the game - for play testing.
		// Player.position = new Vector3(821, 46, 0);
        Player.eulerAngles = new Vector3(0, PlayerPrefs.GetFloat("Cam_y"), 0);
    }

    public void restartGameFromBeginning() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
