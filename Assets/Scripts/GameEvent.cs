using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour
{

    public GameObject puzBoard;
    public GameObject gameBoard;
    public Text annoucementText;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool TabIsComplete()
    {
        for (int i = 0; i < puzBoard.transform.childCount; ++i)
        {
            if (!puzBoard.transform.GetChild(i).GetComponent<Pi_Slot>().taken)
                return false;
        }

        return true;
    }

    public void Win()
    {
        if (TabIsComplete())
        {
            annoucementText.text = "Win";
            gameBoard.SetActive(false);
            annoucementText.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        annoucementText.text = "Loose";
        gameBoard.SetActive(false);
        annoucementText.gameObject.SetActive(true);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
