using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrows : MonoBehaviour
{
    public GameObject arrowPrefab;

    public Transform arrowTransform;

    public float maxArrowForce = 200f;

    private float currentArrowForce;

    private float maxLerpTime = 1f;
    private float currentLerpTime;

    private Animator bowAnimator;

    private void Start()
    {
        bowAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DrawBow();
        }
        if (Input.GetMouseButton(0))
        {
            PowerUpBow();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseBow();
        }
    }

    private void DrawBow()
    {
        bowAnimator.SetBool("drawing", true);
    }

    private void PowerUpBow()
    {
        currentLerpTime += Time.deltaTime;

        if (currentLerpTime > maxLerpTime)
        { currentLerpTime = maxLerpTime; }

        float perc = currentLerpTime / maxLerpTime;

        currentArrowForce = Mathf.Lerp(0, maxArrowForce, perc);
                  
    }

    private void ReleaseBow()
    {
        bowAnimator.SetBool("drawing", false);

       GameObject arrow = Instantiate(arrowPrefab, arrowTransform.position , arrowTransform.rotation) as GameObject;

        arrow.GetComponent<Rigidbody>().AddForce(arrowTransform.forward * currentArrowForce);

        currentArrowForce = 0;
        currentLerpTime = 0;

    }



}
