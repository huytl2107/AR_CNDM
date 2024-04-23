using System.Collections.Generic;
using UnityEngine;

public class AntiWibu_UIManager : MonoBehaviour
{
    [SerializeField] List<AntiWibu_UIPanel> uiPanels = new List<AntiWibu_UIPanel>();

    private void Start()
    {
        //foreach (AntiWibu_UIPanel panel in uiPanels)
        //{
        //    if (panel.isVisibleDefault)
        //        ShowPanelWithLeanTween(panel.panelName);
        //    else
        //        HidePanelWithLeanTween(panel.panelName);
        //}
    }

    public void ShowPanelWithLeanTween(string panelName)
    {
        AntiWibu_UIPanel panel = uiPanels.Find(p => p.panelName == panelName);
        if (panel != null)
        {
            LeanTween.scale(panel.panelObject, Vector3.one, 0.5f)
                .setFrom(Vector3.zero)
                .setEase(LeanTweenType.easeOutBack);

            panel.panelObject.SetActive(true);
            panel.Show();
        }
        else
        {
            Debug.LogError("Panel not found: " + panelName);
        }
    }

    public void HidePanelWithLeanTween(string panelName)
    {
        AntiWibu_UIPanel panel = uiPanels.Find(p => p.panelName == panelName);
        if (panel != null)
        {
            LeanTween.scale(panel.panelObject, Vector3.zero, 0.5f)
                .setEase(LeanTweenType.easeInBack)
                .setOnComplete(() => panel.panelObject.SetActive(false));

            panel.Hide();
        }
        else
        {
            Debug.LogError("Panel not found: " + panelName);
        }
    }

}
