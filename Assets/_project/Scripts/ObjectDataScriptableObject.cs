using UnityEngine;

[CreateAssetMenu(fileName = "Object Data", menuName = "Data", order = 1)]
public class ObjectDataScriptableObject : ScriptableObject
{
    [SerializeField] string objectName;
    [SerializeField] string objectDescription;

    public string ObjectName => objectName;
    public string ObjectDescription => objectDescription;
}
