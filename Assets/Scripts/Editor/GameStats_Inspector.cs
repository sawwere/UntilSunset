using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(GameStats))]
public class GameStats_Inspector : Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();

        // Add a simple label
        myInspector.Add(new Label("This is a custom inspector"));

        // Return the finished inspector UI
        //return myInspector;
        return base.CreateInspectorGUI();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Test"))
            Debug.Log("Test button pressed");
    }
}
