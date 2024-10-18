using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/BuildingTypeSO")]
public class BuildingTypeSO : ScriptableObject
{
   public string nameString;
   public GameObject pfBuildingType;
   public ResourceGeneratorData resourceGeneratorData;
}
