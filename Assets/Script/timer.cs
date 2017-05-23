using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controls the game timer.
public class timer : MonoBehaviour {
    public Text timerText;
    private float startTime;
    bool finished = false;
    bool wasSaved = false;
    public Transform Player;

    // Use this for initialization
    void Start () {
        startTime = Time.time;

        string minutes = ((int)startTime / 60).ToString();
        string seconds = (startTime % 60).ToString("f2");


    }
	
	// Update is called once per frame
	void Update () {
        if (finished) return;
      /*  if(wasSaved)
        {
            startTime = savedTime;
            wasSaved = false;
        }*/
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
	}

    public void Finnish() {
        finished = true;
        timerText.color = Color.yellow;
    }

    public void saveTimeOnQuit() {
        PlayerPrefs.SetFloat("savedTime", Time.time - startTime);
    }
    public void reloadSavedTime() {
        startTime = Time.time - PlayerPrefs.GetFloat("savedTime");
    }
}
