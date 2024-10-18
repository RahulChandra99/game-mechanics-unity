using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace RC
{
    public class ProjectSetup_window : EditorWindow
    {
        static ProjectSetup_window win;
        static string projectName = "_MyGame";
        bool SimpleStructure = true;
        bool DetailedStructure = false;
        
        public static void InitWindow()
        {
            win = EditorWindow.GetWindow<ProjectSetup_window>("Project Setup");
            win.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
                projectName = EditorGUILayout.TextField("Project Name :" ,projectName);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
                SimpleStructure = EditorGUILayout.Toggle("Simple Structure", SimpleStructure);
                DetailedStructure = EditorGUILayout.Toggle("Detailed Structure", DetailedStructure);
            EditorGUILayout.EndHorizontal();


            if (SimpleStructure)
            {
                DetailedStructure = false;
                if (GUILayout.Button("Create Simple Project Structure", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
                    CreateProjectFolders();
            }


            if (DetailedStructure)
            {
                SimpleStructure = false;
                if (GUILayout.Button("Create Detailed Project Structure", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
                    CreateProjectFolders();
            }
            
            
            GUILayout.Label("It is recommended to start project name with '_' to keep it on the top.");
            

            if (win != null)
            {
                win.Repaint();
            }
        }

        void CreateProjectFolders()
        {
            if(string.IsNullOrEmpty(projectName))
            {
                Debug.Log("Enter a name");
                return;
            }

            if(projectName == "_MyGame")
            {
                    
            }

            //creating root directory
            string assetPath = Application.dataPath;
            string rootPath = assetPath + "/" + projectName;

            DirectoryInfo rootInfo = Directory.CreateDirectory(rootPath);
            

            if (!rootInfo.Exists)
            {
                return;
            }
            
            //creating sub directories
            if(SimpleStructure)
                CreateSimpleSubFolders(rootPath);
            else if (DetailedStructure)
                CreateDetailedSubFolders(rootPath);

            AssetDatabase.Refresh();
            CloseWindow();
        }

        void CreateSimpleSubFolders(string rootPath)
        {
            DirectoryInfo rootInfo = null;
            List<string> folderNames = new List<string>();

            //Folders and their sub folders
            rootInfo = Directory.CreateDirectory(rootPath + "/Art");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Animation");
                folderNames.Add("Audio");
                folderNames.Add("Models");
                folderNames.Add("Sprites");
                folderNames.Add("Textures");
                
                CreatingFolders(rootPath + "/Art", folderNames);
                
            }
            
            rootInfo = Directory.CreateDirectory(rootPath + "/Scripts");
            
            rootInfo = Directory.CreateDirectory(rootPath + "/Prefabs");
            
            rootInfo = Directory.CreateDirectory(rootPath + "/ThirdPartyAssets");
           
            
            //Creating Scenes
            DirectoryInfo sceneInfo = Directory.CreateDirectory(rootPath + "/Scenes");
            if (sceneInfo.Exists)
            {
                CreateScene(rootPath + "/Scenes", projectName + "_Main");
                CreateScene(rootPath + "/Scenes", projectName + "_UI");
            }
        }
        
        void CreateDetailedSubFolders(string rootPath)
        {
            DirectoryInfo rootInfo = null;
            List<string> folderNames = new List<string>();

            //Folders and their sub folders
            rootInfo = Directory.CreateDirectory(rootPath + "/Art");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Animation");
                folderNames.Add("Audio");
                folderNames.Add("Fonts");
                folderNames.Add("Models");
                folderNames.Add("PhysicMaterials");
                folderNames.Add("Shaders");
                folderNames.Add("Sprites");
                folderNames.Add("Textures");
                
                CreatingFolders(rootPath + "/Art", folderNames);
                
                folderNames.Clear();
                folderNames.Add("AnimationClips ");
                folderNames.Add("Animators");
                CreatingFolders(rootPath + "/Art/Animation", folderNames);
                
                folderNames.Clear();
                folderNames.Add("AudioClips ");
                folderNames.Add("AudioMixers");
                CreatingFolders(rootPath + "/Art/Audio", folderNames);
            }
            
            rootInfo = Directory.CreateDirectory(rootPath + "/Code");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Editor");
                folderNames.Add("Scripts");
                folderNames.Add("Shaders");
                
                CreatingFolders(rootPath + "/Code", folderNames);
            }
            
            rootInfo = Directory.CreateDirectory(rootPath + "/Prefabs");
            
            
            rootInfo = Directory.CreateDirectory(rootPath + "/Resources");
            if (rootInfo.Exists)
            {
                folderNames.Clear();
                folderNames.Add("Managers");
                folderNames.Add("UI");
                folderNames.Add("ThirdPartyAssets");
                
                CreatingFolders(rootPath + "/Resources", folderNames);
            }
            
            //Creating Scenes
            DirectoryInfo sceneInfo = Directory.CreateDirectory(rootPath + "/Scenes");
            if (sceneInfo.Exists)
            {
                CreateScene(rootPath + "/Scenes", projectName + "_Main");
                CreateScene(rootPath + "/Scenes", projectName + "_UI");
            }
        }
        
        

        void CreatingFolders(string aPath, List<string> folders)
        {
            foreach (string folder in folders)
            {
                Directory.CreateDirectory(aPath + "/" + folder);
            }
        }

        void CreateScene(string aPath, string aName)
        {
            Scene curScene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects);
            EditorSceneManager.SaveScene(curScene, aPath + "/" + aName + ".unity", true);
        }

        void CloseWindow()
        {
            if(win)
            {
                win.Close();
            }
        }

        
    }
}


