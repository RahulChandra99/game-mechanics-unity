using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace RC
{

    static class MenuItems
    {
        const int priority = 10000;

        [MenuItem("Assets/CustomTools(Folder Icon)/Red", false, priority)]
        static void Red()
        {
            ColoredFolders.SetIconName("Red");
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/Green", false, priority)]
        static void Green()
        {
            ColoredFolders.SetIconName("Green");
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/Blue", false, priority)]
        static void Blue()
        {
            ColoredFolders.SetIconName("Blue");
        }
        
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Animations", false, priority+11)]
        static void Animations()
        {
            ColoredFolders.SetIconName("Animations");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Audio", false, priority+11)]
        static void Audio()
        {
            ColoredFolders.SetIconName("Audio");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Editor", false, priority+11)]
        static void Editor()
        {
            ColoredFolders.SetIconName("Editor");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Fonts", false, priority+11)]
        static void Fonts()
        {
            ColoredFolders.SetIconName("Fonts");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Materials", false, priority+11)]
        static void Materials()
        {
            ColoredFolders.SetIconName("Materials");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Models", false, priority+11)]
        static void Models()
        {
            ColoredFolders.SetIconName("Models");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Plugins", false, priority+11)]
        static void Plugins()
        {
            ColoredFolders.SetIconName("Plugins");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Prefabs", false, priority+11)]
        static void Prefabs()
        {
            ColoredFolders.SetIconName("Prefabs");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Resources", false, priority+11)]
        static void Resources()
        {
            ColoredFolders.SetIconName("Resources");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Scenes", false, priority+11)]
        static void Scenes()
        {
            ColoredFolders.SetIconName("Scenes");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Scripts", false, priority+11)]
        static void Scripts()
        {
            ColoredFolders.SetIconName("Scripts");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Shaders", false, priority+11)]
        static void Shaders()
        {
            ColoredFolders.SetIconName("Shaders");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Sprites", false, priority+11)]
        static void Sprites()
        {
            ColoredFolders.SetIconName("Sprites");
        }
        [MenuItem("Assets/CustomTools(Folder Icon)/Category/Textures", false, priority+11)]
        static void Textures()
        {
            ColoredFolders.SetIconName("Textures");
        }
        
        [MenuItem("Assets/CustomTools(Folder Icon)/My Logo", false, priority+11)]
        static void MyLogo()
        {
            ColoredFolders.SetSpecialIconName("MyLogo");
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/CustomIcon", false, priority + 23)]
        static void CustomIcon()
        {
            CustomFoldersEditor.ChooseCustomIcon();
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/ResetIcon", false, priority + 34)]
        static void ResetIcon()
        {
            Debug.Log("Icon set to Default");
            ColoredFolders.ResetFolderIcon();
        }

        [MenuItem("Assets/CustomTools(Folder Icon)/Red", true)]
        [MenuItem("Assets/CustomTools(Folder Icon)/Green", true)]
        [MenuItem("Assets/CustomTools(Folder Icon)/Blue", true)]
        [MenuItem("Assets/CustomTools(Folder Icon)/CustomIcon", true)]
        [MenuItem("Assets/CustomTools(Folder Icon)/ResetIcon", true)]
        static bool ValidateFunction()
        {
            if(Selection.activeObject == null)
            {
                return false;
            }

            /*Only allow menu options for folders*/

            Object selectedObject = Selection.activeObject; 

            string objectPath = AssetDatabase.GetAssetPath(selectedObject);
            return AssetDatabase.IsValidFolder(objectPath);
            

        }

    }

}



#endif