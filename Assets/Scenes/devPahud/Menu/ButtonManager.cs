using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private GameObject panel;
    private bool multi;

    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("ButtonPanel").gameObject;
        multi = false;
    }

    public void newGame(string newGameLevel)
    {
        if (!multi)
        {
            SceneManager.LoadScene(newGameLevel);
        }
        else
        {
            SceneManager.LoadScene(newGameLevel+"_multi");
        }
        
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void showAbout(bool Hide)
    {
        foreach (Text item in this.GetComponentsInChildren<Text>(true))
        {
            if(item.tag =="disable")
            {
                item.gameObject.SetActive(Hide);
            }
        }

        panel.SetActive(!Hide);
        GetComponentInChildren<Image>(true).gameObject.SetActive(!Hide);
        GetComponentInChildren<Toggle>(true).gameObject.SetActive(!Hide);
    }

    public void toggle()
    {
        multi = !multi;
    }
}
