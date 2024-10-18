using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fun
{
    
    public static class Airplane_Menus 
    {
        [MenuItem("Airplane Tools/Create New Airplane")]
        public static void CreateNewAirplane()
        {
            GameObject curSelected = Selection.activeGameObject; 
            if(curSelected)
            {
                Airplane_Controller curController = curSelected.AddComponent<Airplane_Controller>();
                GameObject cogGO = new GameObject("COG");
                cogGO.transform.SetParent(curSelected.transform);

                curController.centreOfGravity = cogGO.transform;

            }
        }
    }
}


