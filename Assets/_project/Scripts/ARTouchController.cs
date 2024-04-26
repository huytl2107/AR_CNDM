using Unity.VisualScripting;
using UnityEngine;

public class ARTouchController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.GetComponent<ObjectController>() != null)
                {
                    AntiWibu_UIManager.Instance.ShowPanelWithLeanTween("InfoPanel");
                    AntiWibu_UIManager.Instance.ChangeText("InfoPanel", hit.collider.gameObject.
                        GetComponent<ObjectController>().ObjectDataScriptable.ObjectDescription);
                }
            }
        }
    }
}
