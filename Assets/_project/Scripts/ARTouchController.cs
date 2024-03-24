using TMPro;
using UnityEngine;

public class ARTouchController : MonoBehaviour
{
    [SerializeField] GameObject descriptionPanel;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("hit");
                Debug.Log(hit.transform.name + " : " + hit.transform.name);

                ObjectController objectController = hit.collider.gameObject.GetComponent<ObjectController>();
                descriptionPanel.GetComponent<TMP_Text>().text = objectController.Data.ObjectDescription;
            }
        }
    }
}
