using Fun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fun
{
    public class GamepadAirplane_Input : BaseAirplane_Input
    {
        protected override void HandleInput()
        {
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("RH_Stick");
            throttle = Input.GetAxis("RV_Stick");

            brake = Input.GetAxis("Fire1");

            if (Input.GetButtonDown("L_Bumper"))
                flaps += 1;
            if (Input.GetButtonDown("R_Bumper"))
                flaps -= 1;

            flaps = Mathf.Clamp(flaps, 0, 3);
        }


    }
}

