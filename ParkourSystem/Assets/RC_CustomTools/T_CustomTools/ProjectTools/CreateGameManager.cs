using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateGameManager : EditorWindow
{
    
    public static void CreateGameObjectWithComponent(string goName)
    {
        // Create a new game object
        GameObject newGameObject = new GameObject(goName);

        // Attach the MyComponent script
        newGameObject.AddComponent<GameManager>();
        
        Selection.activeGameObject = newGameObject;

        Debug.Log(goName + "created!");
    }
}
