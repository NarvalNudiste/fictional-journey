using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private GameObject panel;

    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("ButtonPanel").gameObject;
    }

    public void newGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
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
    }


}
