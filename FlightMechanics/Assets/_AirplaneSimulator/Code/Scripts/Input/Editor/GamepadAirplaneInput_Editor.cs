using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fun
{
    [CustomEditor(typeof(GamepadAirplane_Input))]
    public class GamepadAirplaneInput_Editor : Editor
    {
        #region Variables
        private GamepadAirplane_Input targetInput;
        #endregion


        #region BuildIn Methods
        private void OnEnable()
        {
            targetInput = (GamepadAirplane_Input)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            string debugInfo = "";
            debugInfo += "Pitch = " + targetInput.Pitch + "\n";
            debugInfo += "Roll = " + targetInput.Roll + "\n";
            debugInfo += "Yaw = " + targetInput.Yaw + "\n";
            debugInfo += "Throttle = " + targetInput.Throttle + "\n";
            debugInfo += "Brake = " + targetInput.Brake + "\n";
            debugInfo += "Flaps = " + targetInput.Flaps + "\n";



            GUILayout.Space(20);
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(100));
            GUILayout.Space(20);
        }
        #endregion
    }
}


