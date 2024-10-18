using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Fun
{
    public class BaseAirplane_Input : MonoBehaviour
    {
        #region Variables
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;
        protected int flaps = 0;
        protected float brake = 0f;

        
        #endregion

        #region Properties
        public float Pitch { get { return pitch; } }
        public float Roll { get { return roll; } }
        public float Yaw { get {  return yaw; } }
        public float Throttle { get { return throttle; } }
        public int Flaps { get {  return flaps; } }
        public float Brake { get {  return brake; } }
        #endregion

        #region BuiltIn Methods
        

     
        private void Update()
        {
            HandleInput();  
        }

       

        #endregion
        //protected class means when we inherit it we can use this method, virtual means we can override it from class that inherits it
        #region Custom Methods

        protected virtual void HandleInput()                
        {

            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");

            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");

            brake = Input.GetKey(KeyCode.Space) ? 1f : 0f;

            if (Input.GetKeyDown(KeyCode.F))
                flaps += 1;
            if (Input.GetKeyDown(KeyCode.G))
                flaps -= 1;

            flaps = Mathf.Clamp(flaps, 0, 3);

            
        }
        #endregion
    }
}

