using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    #region vars
    public Canvas playCanvas;
    public Canvas optionsCanvas;
    public Canvas creditsCanvas;
    #endregion

    #region initialization
    /// <summary>
    /// Initializes the canvas objects and hides them.
    /// </summary>
    void Start()
    {
        playCanvas = playCanvas.GetComponent<Canvas>();
        optionsCanvas = optionsCanvas.GetComponent<Canvas>();
        creditsCanvas = creditsCanvas.GetComponent<Canvas>();

        playCanvas.enabled = false;
        optionsCanvas.enabled = false;
        creditsCanvas.enabled = false;
    }
    #endregion

    #region Updater
    /// Update is called once per frame
    void Update()
    {
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
