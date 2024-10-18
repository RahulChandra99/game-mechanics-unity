using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fun
{
    public class Airplane_Controller : BaseRigidbody_Controller
    {

        #region Variables
        [Header("Base Airplane Properties")]
        public BaseAirplane_Input input;
        public Transform centreOfGravity;
        [Tooltip("In Pounds")]
        public float planeWeight = 800f;
        private const float poundsToKilos = 0.453592f;

        [Header("Engines")]
        public List<Airplane_Engine> engines = new List<Airplane_Engine>();

        [Header("Wheels")]
        public List<Airplane_Wheel> wheels = new List<Airplane_Wheel>();
        #endregion

        public override void Start()
        {
            base.Start();

            float finalWeight = planeWeight * poundsToKilos;
            if(rb)
            {
                rb.mass = finalWeight;
                if(centreOfGravity)
                {
                    rb.centerOfMass = centreOfGravity.localPosition;
                }
            }

            if(wheels != null)
            {
                if(wheels.Count > 0)
                {
                    foreach(Airplane_Wheel wheel in wheels)
                    {
                        wheel.IniWheel();
                    }
                }
            }
        }

        #region Custom Methods
        protected override void HandlePhysics()
        {
            if(input )
            {
                HandleEngine();
                HandleAerodynamics();
                HandleSteering();
                HandleBrakes();
                HandleAltitude();
            }
            
        }

        private void HandleAltitude()
        {
        }

        private void HandleBrakes()
        {
        }

        private void HandleSteering()
        {
        }

        private void HandleAerodynamics()
        {
        }

        private void HandleEngine()
        {
            if(engines != null)
            {
                if(engines.Count > 0)
                {
                    foreach(Airplane_Engine engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(-input.Throttle));
                    }
                }
            }
        }
        #endregion 
    }
}


