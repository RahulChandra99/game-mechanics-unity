using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScanner : MonoBehaviour
{

   [SerializeField] private Vector3 offset;
   [SerializeField] private float forwardDistance;
   [SerializeField] private LayerMask obstacleLayer;
   //function to check obstacles using raycast -> start from bit higher than feet, forward direction, out keyword, length of ray, layermask -> store in bool value
   public ObstacleHitData ObstacleCheck()
   {
      var hitData = new ObstacleHitData();
      
      var origin = transform.position + offset;
      hitData.forwardHitFound = Physics.Raycast(origin, transform.forward, out hitData.forwardHit, forwardDistance, obstacleLayer);
      
      Debug.DrawRay(origin,transform.forward * forwardDistance,(hitData.forwardHitFound)? Color.green:Color.red);

      return hitData;
   }
}

public struct ObstacleHitData
{
   public bool forwardHitFound;
   public RaycastHit forwardHit;
}
