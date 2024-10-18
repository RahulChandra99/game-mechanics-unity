using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


#if UNITY_EDITOR
using UnityEditor;

namespace RC
{
    [InitializeOnLoad]
    static class ColoredFolders
    {
        static string iconName;

        static ColoredFolders()
        {
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        private static void OnGUI(string guid, Rect selectionRect)
        {
            Color backgroundColor;
            Rect folderRect = GetFolderRect(selectionRect, out backgroundColor);

            string iconGuid = EditorPrefs.GetString(guid, "");

            if (iconGuid == "" || iconGuid == "00000000000000000000000000000000")
                return;

            EditorGUI.DrawRect(folderRect, backgroundColor);

            string folderTexPath = AssetDatabase.GUIDToAssetPath(iconGuid);
            Texture2D folderTex = AssetDatabase.LoadAssetAtPath<Texture2D>(folderTexPath);

            GUI.DrawTexture(folderRect, folderTex);
        }

        private static Rect GetFolderRect(Rect selectionRect, out Color backgroundColor)
        {
            Rect folderRect;
            backgroundColor = new Color(.2f, .2f, .2f);

            if (selectionRect.x < 15)
                folderRect = new Rect(selectionRect.x + 3, selectionRect.y, selectionRect.height, selectionRect.height);

            else if (selectionRect.x > 15 && selectionRect.height < 30)
            {
                folderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.height, selectionRect.height);
                backgroundColor = new Color(0.22f, 0.22f, 0.22f);
            }

            else
                folderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width, selectionRect.width);

            return folderRect;
        }

        public static void SetIconName(string m_iconName)
        {
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string folderGuid = AssetDatabase.GUIDFromAssetPath(folderPath).ToString();

            string iconPath = "Assets/RC_CustomTools/T_SetFolderIcon/Icons/Colors/" + m_iconName + ".png";
            string iconGuid = AssetDatabase.GUIDFromAssetPath(iconPath).ToString();

            EditorPrefs.SetString(folderGuid, iconGuid);

            /*iconName = m_iconName;*/
        }
        
        public static void SetSpecialIconName(string m_iconName)
        {
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string folderGuid = AssetDatabase.GUIDFromAssetPath(folderPath).ToString();

            string iconPath = "Assets/RC_CustomTools/T_SetFolderIcon/Icons/CustomIcons/" + m_iconName + ".png";
            string iconGuid = AssetDatabase.GUIDFromAssetPath(iconPath).ToString();

            EditorPrefs.SetString(folderGuid, iconGuid);

            /*iconName = m_iconName;*/
        }

        public static void ResetFolderIcon()
        {
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string folderGuid = AssetDatabase.GUIDFromAssetPath(folderPath).ToString();

            EditorPrefs.DeleteKey(folderGuid);
        }
    }
}

#endif


