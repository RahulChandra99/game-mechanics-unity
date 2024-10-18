using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPA
{
    public class Waypoint1 : MonoBehaviour
    {
        public RectTransform waypointPrefab;

        private RectTransform waypoint;

        private Transform player;

        private Text text;

        public Vector3 offset = new Vector3(0, 1.25f, 0);

        private void Start()
        {
            if(PlayerMovement.canMove == true)
            {
                var canvas = GameObject.Find("WaypointUI2").transform;

                waypoint = Instantiate(waypointPrefab, canvas);
                text = waypoint.GetComponentInChildren<Text>();

                player = GameObject.Find("FirstPersonPlayer").transform;
            }
            
        }

        private void Update()
        {
            if(PlayerMovement.canMove == true)
            {
                var screenPos = Camera.main.WorldToScreenPoint(transform.position + offset);

                waypoint.position = screenPos;

                waypoint.gameObject.SetActive(screenPos.z > 0);

                text.text = Vector3.Distance(player.position, transform.position).ToString("0") + " m ";
            }
            
        }
    }
}

