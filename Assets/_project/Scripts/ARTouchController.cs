using Unity.VisualScripting;
using UnityEngine;
using Lean.Touch;

public class ARTouchController : MonoBehaviour
{

    private bool isFingerStationary = true;
    private float timeTouchStarted;
    private LeanFinger trackedFinger;
    private LeanSelectByFinger leanSelect;

    private void Awake()
    {
        leanSelect = GetComponent<LeanSelectByFinger>();
    }
    private void OnEnable()
    {
        LeanTouch.OnFingerDown += HandleFingerDown;
        LeanTouch.OnFingerUpdate += HandleFingerSet;
        LeanTouch.OnFingerUp += HandleFingerUp;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerDown -= HandleFingerDown;
        LeanTouch.OnFingerUpdate -= HandleFingerSet;
        LeanTouch.OnFingerUp -= HandleFingerUp;
    }

    private void HandleFingerDown(LeanFinger finger)
    {
        trackedFinger = finger;
        timeTouchStarted = Time.time;
        isFingerStationary = true;

        Ray ray = Camera.main.ScreenPointToRay(finger.ScreenPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            LeanSelectableByFinger selectable = hit.collider.gameObject.GetComponent<LeanSelectableByFinger>();
            if (selectable != null)
            {
                leanSelect.Select(selectable);
                Debug.Log("Đã chọn GameObject: " + hit.collider.gameObject.name);
            }
            else
            {
                Debug.Log("Không nhận diện được selectable by finger");
            }
        }
    }

    private void HandleFingerSet(LeanFinger finger)
    {
        if (finger == trackedFinger && finger.SwipeScreenDelta.magnitude > LeanTouch.Instance.SwipeThreshold)
        {
            isFingerStationary = false;
        }
    }

    private void HandleFingerUp(LeanFinger finger)
    {
        //Deselect toàn bộ object được chọn
        leanSelect.DeselectAll();
        
        if (finger == trackedFinger && isFingerStationary)
        {
            Ray ray = Camera.main.ScreenPointToRay(finger.ScreenPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.GetComponent<ObjectController>() != null)
                {
                    Debug.Log("Hiện info panel");
                    AntiWibu_UIManager.Instance.ShowPanelWithLeanTween("InfoPanel");
                    AntiWibu_UIManager.Instance.ChangeText("InfoPanel", hit.collider.gameObject.GetComponent<ObjectController>().ObjectDataScriptable.ObjectDescription);
                }
            }
        }
    }

    void Update()
    {
        //bug chí vcl
        /*
        if (Input.GetMouseButtonDown(0) )
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
        */
    }
}
