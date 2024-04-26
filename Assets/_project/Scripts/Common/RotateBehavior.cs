using UnityEngine;

public class RotateBehavior : MonoBehaviour
{
    public float angularVelocity = 10;
    void Update()
    {
        var rotationAngular = Quaternion.AngleAxis(angularVelocity * Time.deltaTime, Vector3.forward);
        transform.localRotation = rotationAngular * transform.localRotation;
    }
}
