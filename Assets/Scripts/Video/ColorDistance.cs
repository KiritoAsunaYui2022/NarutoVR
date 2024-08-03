using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDistance : MonoBehaviour
{
    public GameObject right;
    public GameObject left;

    public Material distanceIndicator;

    public Color green, blue, purple; 

    public float distance;

    private float lerpTime = .15f; 
    public float currentLerpTime1; 

    public bool disAreaOne;
    public bool disAreaTwo;
    public bool disAreaThree;

    public bool trigger1;
    public bool trigger2;
    public bool trigger3;

    public bool trigger1_2;
    public bool trigger3_2;


    void Start()
    {
        Color green = new Color32(80, 200, 114, 0);
        Color blue = new Color32(76, 146, 114, 0);
        Color purple = new Color32(179, 76, 255, 0);


        //distanceIndicator.color = green; 
    }

    public void distanceOfControllers()
    {
        distance = Vector3.Distance(right.transform.position, left.transform.position);

        disAreaOne = (distance <= 0.25f);

        if (distance > .25f && distance < 1.2f)
        {
            disAreaTwo = true;
        }

        else
        {
            disAreaTwo = false;
        }

        disAreaThree = (distance >= 1.2);
    }

    public void colorChange()
    {
        if (disAreaOne)
        {
            if (trigger2)
            {
                currentLerpTime1 = 0f;
                trigger2 = false;
            }

            distanceIndicator.color = Color.Lerp(blue, green, (currentLerpTime1 / lerpTime));
            currentLerpTime1 += Time.deltaTime;

            trigger1 = true;

            if (currentLerpTime1 >= lerpTime)
            {
                currentLerpTime1 = lerpTime;
            }
        }


        if (disAreaTwo)
        {
            if (trigger1)
            {
                currentLerpTime1 = 0f;
                trigger1 = false;
                trigger3 = false; 
                trigger1_2 = true;
                trigger3_2 = false;
            }

            if (trigger3)
            {
                currentLerpTime1 = 0f;
                trigger1 = false;
                trigger3 = false;
                trigger1_2 = false; 
                trigger3_2 = true; 
            }

            if (trigger1_2)
            {
                distanceIndicator.color = Color.Lerp(green, blue, (currentLerpTime1 / lerpTime));
                currentLerpTime1 += Time.deltaTime;

                if (currentLerpTime1 >= lerpTime)
                {
                    currentLerpTime1 = lerpTime;
                    trigger1_2 = false;
                }
            }

            if (trigger3_2)
            {
                distanceIndicator.color = Color.Lerp(purple, blue, (currentLerpTime1 / lerpTime));
                currentLerpTime1 += Time.deltaTime;

                if (currentLerpTime1 >= lerpTime)
                {
                    currentLerpTime1 = lerpTime;
                    trigger3_2 = false;
                }
            }

            trigger2 = true;
        }

        if (disAreaThree)
        {
            if (trigger2)
            {
                currentLerpTime1 = 0f;
                trigger2 = false;
            }

            distanceIndicator.color = Color.Lerp(blue, purple, (currentLerpTime1 / lerpTime));
            currentLerpTime1 += Time.deltaTime;

            trigger3 = true;

            if (currentLerpTime1 >= lerpTime)
            {
                currentLerpTime1 = lerpTime;
            }
        }

    }

    void Update()
    {
        distanceOfControllers();
        colorChange(); 
    }
}
