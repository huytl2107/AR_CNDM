using Unity.VisualScripting;
using UnityEngine;
using Lean.Touch;

public class ARTouchController : MonoBehaviour
{

    private bool isFingerStationary = true;
    private float timeTouchStarted;
    private LeanFinger trackedFinger;

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
        if (finger == trackedFinger && isFingerStationary)
        {
            Ray ray = Camera.main.ScreenPointToRay(finger.ScreenPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.GetComponent<ObjectController>() != null)
                {
                    AntiWibu_UIManager.Instance.ShowPanelWithLeanTween("InfoPanel");
                    AntiWibu_UIManager.Instance.ChangeText("InfoPanel", hit.collider.gameObject.GetComponent<ObjectController>().ObjectDataScriptable.ObjectDescription);
                }
            }
        }
    }

    void Update()
    {
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
    }
}
