using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RC
{
    public class EditorMenus
    {
        [MenuItem("CustomTools/Project Tools/Project Folder Setup")]
        public static void IniProjectFolderSetupTool()
        {
            ProjectSetup_window.InitWindow();
        }
        
        [MenuItem("CustomTools/Scene Tools/Create Game Manager")]
        public static void CreateGM()
        {
            CreateGameManager.CreateGameObjectWithComponent("GameManager");
        }
    }
}


