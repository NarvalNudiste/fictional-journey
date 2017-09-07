using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour {


	public void show(float score)
    {
        Debug.Log("yo");
        Text txt = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        txt.text = score.ToString();
    }

    public void nextLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
