using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fun
{
    [RequireComponent(typeof(WheelCollider))]
    public class Airplane_Wheel : MonoBehaviour
    {
        private WheelCollider wheelCol;

        private void Start()
        {
            wheelCol = GetComponent<WheelCollider>();
        }

        public void IniWheel()
        {
            if(wheelCol)
            {
                wheelCol.motorTorque = 0.000000001f;
            }
        }
    }
}

