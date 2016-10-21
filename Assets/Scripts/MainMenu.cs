using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    #region vars
    public Canvas playCanvas;
    public Canvas optionsCanvas;
    public Canvas creditsCanvas;
    public Canvas playPopup;

    #endregion

    #region initialization
    /// <summary>
    /// Initializes the canvas objects and hides them.
    /// </summary>
    void Start()
    {
        playCanvas =  playCanvas.GetComponent<Canvas>();
        optionsCanvas = optionsCanvas.GetComponent<Canvas>();
        creditsCanvas = creditsCanvas.GetComponent<Canvas>();
        playPopup = playPopup.GetComponent<Canvas>();

        CloseMenu();

    }
    #endregion

    #region Updater
    /// Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            CloseMenu();
        }
    }
    #endregion

    #region Open Methods
    /// <summary>                   
    /// Opens the credits menu.
    /// </summary>
    /// <author> Henry</author>
    public void OpenCredits()
    {
        creditsCanvas.enabled = true;
    }

    /// <summary>
    /// Opens the options menu.
    /// </summary>
    /// <author> Henry</author>
    public void OpenOptions()
    {
        optionsCanvas.enabled = true;
    }

    /// <summary>
    /// Opens the chapter select menu.
    /// </summary>
    /// <author> Henry</author>
    public void OpenPlay()
    {
        playCanvas.enabled = true;
    }
    #endregion

    /// Opens the popup where you can select to play new game, load game, or select chapter. Author: Ben
    public void OpenPopup()
    {
        playPopup.enabled = true;
    }

    #region close methods
    /// <summary>
    /// closes all menus.
    /// </summary>
    /// <author> Henry</author>
    public void CloseMenu()
    {
        playCanvas.enabled = false;
        optionsCanvas.enabled = false;
        creditsCanvas.enabled = false;
        playPopup.enabled = false;
    }

    /// <summary>
    /// Exits out of the application.
    /// </summary>
    /// <author>Henry</author>
    public void Quit()
    {
        Application.Quit();
    }
    #endregion
}
