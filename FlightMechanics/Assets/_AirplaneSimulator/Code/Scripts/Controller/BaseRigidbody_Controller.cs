using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fun
{
    [RequireComponent(typeof(Rigidbody))]
    public class BaseRigidbody_Controller : MonoBehaviour
    {
        #region Variables

        protected Rigidbody rb;

        #endregion

        #region BuildIn Methods

        public virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if(rb)
            {
                HandlePhysics();
            }
        }

        #endregion

        #region Custom Methods

        protected virtual void HandlePhysics()
        {

        }

        #endregion
    }
}


