using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private GameObject gameManager;
    private Text timerText;
    private int frameCounter = 0;
    private int counterLimit = 60;

    //level timer
    int timeLimit = 60;
    
    //delay before timer start
    int timeDelay = 3;

    void Start () {
        timerText = GameObject.Find("TimeText").GetComponent<Text>();
    }

	void Update () {
        if (timeLimit + timeDelay - (int)Time.timeSinceLevelLoad == 0) {
            this.GetComponent<GameManager>().timerEnded();
        }
        if (Time.timeSinceLevelLoad < timeDelay) {
            timerText.text = "t1m3 : " + timeLimit;
        }
        else {
            int secs = (int)Time.timeSinceLevelLoad;
            if (frameCounter % counterLimit == 0) {
                frameCounter = 0;
                timerText.text = "t1m3 : " + (timeLimit + timeDelay - (int)Time.timeSinceLevelLoad);
            }
            frameCounter++;
        }
    }

    //To be called at level loading
    public void setTimer(int _tL) {
        timeLimit = _tL;
    }
}
