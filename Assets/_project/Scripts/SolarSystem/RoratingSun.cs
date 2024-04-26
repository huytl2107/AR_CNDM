using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoratingSun : MonoBehaviour
{
    [SerializeField] private float _rorationSpeed;
    private void Update()
    {
        transform.Rotate(new Vector3(0, _rorationSpeed, 0) *Time.deltaTime);
    }
}
