using SelectionSystem;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SelectionGroup))]
public class SelectionGroupInspector : Editor
{
    private SelectionGroup group;
    private void OnEnable()
    {
        group = target as SelectionGroup;
    }

    public override void OnInspectorGUI()
    {
        group.multipleSelection =
            EditorGUILayout.Toggle(new GUIContent("Multiple Selection", "Allow selecting multiple objects."),
                group.multipleSelection);
        
        group.allowNoneSelected =
            EditorGUILayout.Toggle(new GUIContent("Allow Empty Selection", "Allow selecting no object"),
                group.allowNoneSelected);

        if (group.allowNoneSelected == false)
        {
            group.firstSelected = EditorGUILayout.ObjectField(new GUIContent("First Selected", "Object that will be selected on start."), group.firstSelected,
                typeof(SelectableComponent), true) as SelectableComponent;
        }

        GUILayout.Space(10);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("selectionChanged"));
    }
}
