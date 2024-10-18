using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FPA
{
    public class TargetMovement : MonoBehaviour
    {
        public float amplitude = 1f;

        public float timePeriod = 1f;

        private Vector3 startPosition;

        public float chanceOfMovement = 0.5f;

        private void Start()
        {
            startPosition = transform.localPosition;

            if(Random.Range(0,1) >= chanceOfMovement)
            {
                this.enabled = false;
            }
        }

        private void Update()
        {
            float theta = Time.timeSinceLevelLoad/timePeriod;

            float distance = Mathf.Sin(theta) * amplitude;

            Vector3 deltaPosition = new Vector3(0,0,distance);

            transform.position = startPosition + deltaPosition;
        }
    }

}
