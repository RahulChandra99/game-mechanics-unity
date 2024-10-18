using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Connector : MonoBehaviour
{
   public Vector2 size = Vector2.one * 4;
   public bool isConnected;

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.green;

      Vector2 halfSize = size * 0.5f;
      Vector3 offset = transform.position + transform.up * halfSize.y;
      Gizmos.DrawLine(offset, offset + transform.forward);

      Vector3 top = transform.up * size.y;
      Vector3 side = transform.right * halfSize.x;
      
      //corners
      Vector3 topRight = transform.position + top + side;
      Vector3 topLeft = transform.position + top - side;
      Vector3 bottomRight = transform.position + side;
      Vector3 bottomLeft = transform.position - side;
      
      Gizmos.DrawLine(topRight,topLeft);
      Gizmos.DrawLine(topLeft,bottomLeft);
      Gizmos.DrawLine(bottomLeft, bottomRight);
      Gizmos.DrawLine(bottomRight, topRight);

      Gizmos.color *= 0.7f;
      Gizmos.DrawLine(offset,topLeft);
      Gizmos.DrawLine(offset,bottomLeft);
      Gizmos.DrawLine(offset, bottomRight);
      Gizmos.DrawLine(offset, topRight);

   }
}
