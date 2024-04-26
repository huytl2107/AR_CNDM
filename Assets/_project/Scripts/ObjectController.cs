using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] ObjectDataScriptableObject data;
    public ObjectDataScriptableObject ObjectDataScriptable => data;
}
