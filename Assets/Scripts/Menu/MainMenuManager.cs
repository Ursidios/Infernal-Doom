using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject TutorialScree;
    public GameObject MainScreen;

    public GameObject winScree;
    public GameObject looseScreen;

    public void Start()
    {
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenTutorial()
    {
        TutorialScree.SetActive(true);
        MainScreen.SetActive(false);
    }

    public void CloseTutorial()
    {
        TutorialScree.SetActive(false);
        MainScreen.SetActive(true);
    }

    public void WinScreen()
    {
        winScree.SetActive(true);
        looseScreen.SetActive(false);
        TutorialScree.SetActive(false);
        MainScreen.SetActive(false);
    }

    public void LooseScreen()
    {
        looseScreen.SetActive(true);
        winScree.SetActive(false);
        TutorialScree.SetActive(false);
        MainScreen.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
