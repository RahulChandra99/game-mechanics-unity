using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentScanner : MonoBehaviour
{

   [SerializeField] private Vector3 offset;
   [SerializeField] private float forwardDistance;
   [SerializeField] private float heightRayLength = 5;
   [SerializeField] private LayerMask obstacleLayer;
   public ObstacleHitData ObstacleCheck()
   {
      var hitData = new ObstacleHitData();
      
      var origin = transform.position + offset;
      hitData.forwardHitFound = Physics.Raycast(origin, transform.forward, out hitData.forwardHit, forwardDistance, obstacleLayer);
      
      Debug.DrawRay(origin,transform.forward * forwardDistance,(hitData.forwardHitFound)? Color.green:Color.red);

      if (hitData.forwardHitFound)
      {
         //origin will be point where obstacle is detected
         var heightOrigin = hitData.forwardHit.point + Vector3.up * heightRayLength;
         hitData.heightHitFound = Physics.Raycast(heightOrigin, Vector3.down, out hitData.heightHit, heightRayLength, obstacleLayer);
         
         Debug.DrawRay(heightOrigin,Vector3.down * heightRayLength,(hitData.heightHitFound)? Color.green:Color.red);
      }
      
      return hitData;
   }
}

public struct ObstacleHitData
{
   public bool forwardHitFound;
   public bool heightHitFound;
   public RaycastHit forwardHit;
   public RaycastHit heightHit;
}
