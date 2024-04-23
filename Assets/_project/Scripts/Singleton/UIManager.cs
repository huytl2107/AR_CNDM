using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject _startMenuUI;
    [SerializeField] private GameObject _exitConfirm;
    [SerializeField] private GameObject _credit;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        LoadUI();
    }

    public void LoadUI()
    {
        if (SceneLoader.Instant.GetBuildIndex() == 0)
        {
            _startMenuUI.SetActive(true);
        }
        else
        {
            _startMenuUI.SetActive(false);
        }

        PopDownExitConfirm();
        PopDownCreditPanel();
    }

    #region ReloadUI
    private IEnumerator LoadUICoroutine()
    {
        yield return new WaitForSeconds(.1f);
        LoadUI();
    }

    public void ReloadUI()
    {
        StartCoroutine("LoadUICoroutine");
    }
    #endregion ReloadUI

    #region ExitConfirm
    public void PopUpExitConfirm()
    {
        _exitConfirm.SetActive(true);
    }

    public void PopDownExitConfirm()
    {
        _exitConfirm.SetActive(false);
    }
    #endregion ExitConfirm

    #region Credit
    public void PopUpCreditPanel()
    {
        _credit.SetActive(true);
    }

    public void PopDownCreditPanel()
    {
        _credit.SetActive(false);
    }
    #endregion Credit
}
