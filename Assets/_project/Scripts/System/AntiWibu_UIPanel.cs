using UnityEngine;

[System.Serializable]
public class AntiWibu_UIPanel 
{
    public string panelName;
    public GameObject panelObject;
    public bool isVisibleDefault = false;
    
    public void Show()
    {
        panelObject.SetActive(true);
    }

    public void Hide()
    {
        panelObject.SetActive(false);
    }
}
