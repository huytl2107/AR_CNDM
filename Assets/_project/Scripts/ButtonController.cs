using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void LoadNextScene()
    {
        GameManager.Instant.LoadNextScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #region ExitConfirm
    public void PopUpExitConfirm()
    {
        UIManager.Instant.PopUpExitConfirm();
    }

    public void PopDownExitConfirm()
    {
        UIManager.Instant.PopDownExitConfirm();
    }
    #endregion ExitConfirm

    #region Credit
    public void PopUpCreditPanel()
    {
        UIManager.Instant.PopUpCreditPanel();
    }

    public void PopDownCreditPanel()
    {
        UIManager.Instant.PopDownCreditPanel();
    }
    #endregion Credit
}
