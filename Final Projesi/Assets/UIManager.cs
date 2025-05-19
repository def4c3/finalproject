using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{
    public GameObject startMenu, settingsMenu, ingameMenu, UICamera, FPSController, EventSystem;
    





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameStart();


    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            CheckForMenuKeyPressed();
        }
        if (SceneManager.GetActiveScene().name == "GameStart")
        {
            UIBackToMenu();
        }
    }

    public void GameStart()
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
        ingameMenu.SetActive(false);
        UICamera.SetActive(true);
    }
    public void ClickedSettings()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
        ingameMenu.SetActive(false);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        startMenu.SetActive(false);
        settingsMenu.SetActive(false);
        ingameMenu.SetActive(false);
        UICamera.SetActive(false);
        FPSController.SetActive(true);
        EventSystem.SetActive(false);


    }
    public int escapecounter = 0;
    public void ToggleInGameMenu()
    {
        if (escapecounter == 0)
        {
            ingameMenu.SetActive(true);
            settingsMenu.SetActive(false);
            UICamera.SetActive(true);
            FPSController.SetActive(false);
            EventSystem.SetActive(true);
            UnlockMouse();
            escapecounter = 1;
        }
        else if (escapecounter == 1)
        {
            ingameMenu.SetActive(false);
            settingsMenu.SetActive(false);
            UICamera.SetActive(false);
            FPSController.SetActive(true);
            EventSystem.SetActive(false);
            CloseMouse();
            escapecounter = 0;
        }
    }



    public void ClouseMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void CheckForMenuKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ToggleInGameMenu();
    }
    public void ResumeButtonPressed()
    {
        ingameMenu.SetActive(false);
        UICamera.SetActive(false);
        FPSController.SetActive(true);
        EventSystem.SetActive(false);
        CloseMouse();
        escapecounter = 0;

    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CloseMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
    public void BackButtonPressed()
    {
        settingsMenu.SetActive(false);
        startMenu.SetActive(true);
        ingameMenu.SetActive(false);
    }
    public void ClickedSettingsInGame()
    {
        ingameMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void ClickedBackButtonInGame()
    {
        ingameMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
    public void UIBackToMenu()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            settingsMenu.SetActive(false);
            ingameMenu.SetActive(false);
            startMenu.SetActive(true);

        }

    }


}

