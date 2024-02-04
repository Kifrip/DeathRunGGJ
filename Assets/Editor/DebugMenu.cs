#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Transform))]
class TransformOverride : Editor
{
    public override void OnInspectorGUI()
    {
        Transform transform = (Transform)target;
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("Position", EditorStyles.boldLabel);
        EditorGUILayout.Vector3Field("World Position", transform.position);

        if (GUILayout.Button("Copy world Position"))
        {
            GUIUtility.systemCopyBuffer = $"Vector3{transform.position}";
        }
    }
}
#endif