using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ColorChange : MonoBehaviour
{
    public HandSeals handSeals; 

    public Material button0;
    public Material button1; 
    public Material button2;
    public Material button3;
    public Material button4;

    public bool trigger0;
    public bool trigger1;
    public bool trigger2;
    public bool trigger3;
    public bool trigger4;

    //public Image button0;
    //public Image button1;
    //public Image button2;
    //public Image button3;
    //public Image button4; 

    public Color red, green;

    //[Range(0f, 1f)]
    public float lerpTime = .15f; 

    public float currentLerpTime0;
    public float currentLerpTime1;
    public float currentLerpTime2;
    public float currentLerpTime3;
    public float currentLerpTime4;


    void Start()
    {
        Color green = new Color32(80, 200, 114, 255);
        Color red = new Color32(241, 114, 114, 255); 

        button0.color = red;
        button1.color = red;
        button2.color = red;
        button3.color = red;
        button4.color = red;
    }

    public void colorLerp()
    {
        //Button0 
        if (/*handSeals.x_RightMonkey*/ Input.GetKey("r"))
        {
            if(!trigger0)
            {
                currentLerpTime0 = 0f; 
            }

            trigger0 = true; 

            button0.color = Color.Lerp(red, green, (currentLerpTime0 / lerpTime));
            currentLerpTime0 += Time.deltaTime; 

            if(currentLerpTime0 >= lerpTime)
            {
                currentLerpTime0 = lerpTime; 
            }
        }

        if (/*handSeals.x_RightMonkey*/ !Input.GetKey("r"))
        {
            if(trigger0)
            {
                currentLerpTime0 = 0f; 
            }

            trigger0 = false; 

            button0.color = Color.Lerp(green, red, (currentLerpTime0 / lerpTime));
            currentLerpTime0 += Time.deltaTime;

            if (currentLerpTime0 >= lerpTime)
            {
                currentLerpTime0 = lerpTime;
            }
        }


        //Button1 
        if (/*handSeals.x_RightMonkey*/ Input.GetKey("t"))
        {
            if (!trigger1)
            {
                currentLerpTime1 = 0f;
            }

            trigger1 = true;

            button1.color = Color.Lerp(red, green, (currentLerpTime1 / lerpTime));
            currentLerpTime1 += Time.deltaTime;

            if (currentLerpTime1 >= lerpTime)
            {
                currentLerpTime1 = lerpTime;
            }
        }

        if (/*handSeals.x_RightMonkey*/ !Input.GetKey("t"))
        {
            if (trigger1)
            {
                currentLerpTime1 = 0f;
            }

            trigger1 = false;

            button1.color = Color.Lerp(green, red, (currentLerpTime1 / lerpTime));
            currentLerpTime1 += Time.deltaTime;

            if (currentLerpTime1 >= lerpTime)
            {
                currentLerpTime1 = lerpTime;
            }
        }


        //Button2 
        if (/*handSeals.x_RightMonkey*/ Input.GetKey("y"))
        {
            if (!trigger2)
            {
                currentLerpTime2 = 0f;
            }

            trigger2 = true;

            button2.color = Color.Lerp(red, green, (currentLerpTime2 / lerpTime));
            currentLerpTime2 += Time.deltaTime;

            if (currentLerpTime2 >= lerpTime)
            {
                currentLerpTime2 = lerpTime;
            }
        }

        if (/*handSeals.x_RightMonkey*/ !Input.GetKey("y"))
        {
            if (trigger2)
            {
                currentLerpTime2 = 0f;
            }

            trigger2 = false;

            button2.color = Color.Lerp(green, red, (currentLerpTime2 / lerpTime));
            currentLerpTime2 += Time.deltaTime;

            if (currentLerpTime2 >= lerpTime)
            {
                currentLerpTime2 = lerpTime;
            }
        }


        //Button3 
        if (/*handSeals.x_RightMonkey*/ Input.GetKey("u"))
        {
            if (!trigger3)
            {
                currentLerpTime3 = 0f;
            }

            trigger3 = true;

            button3.color = Color.Lerp(red, green, (currentLerpTime3 / lerpTime));
            currentLerpTime3 += Time.deltaTime;

            if (currentLerpTime3 >= lerpTime)
            {
                currentLerpTime3 = lerpTime;
            }
        }

        if (/*handSeals.x_RightMonkey*/ !Input.GetKey("u"))
        {
            if (trigger3)
            {
                currentLerpTime3 = 0f;
            }

            trigger3 = false;

            button3.color = Color.Lerp(green, red, (currentLerpTime3 / lerpTime));
            currentLerpTime3 += Time.deltaTime;

            if (currentLerpTime3 >= lerpTime)
            {
                currentLerpTime3 = lerpTime;
            }
        }


        //Button4 ALL XZs
        if (/*handSeals.x_RightMonkey*/ Input.GetKey("i"))
        {
            if (!trigger4)
            {
                currentLerpTime4 = 0f;
            }

            trigger4 = true;

            button4.color = Color.Lerp(red, green, (currentLerpTime4 / lerpTime));
            currentLerpTime4 += Time.deltaTime;

            if (currentLerpTime4 >= lerpTime)
            {
                currentLerpTime4 = lerpTime;
            }
        }

        if (/*handSeals.x_RightMonkey*/ !Input.GetKey("i"))
        {
            if (trigger4)
            {
                currentLerpTime4 = 0f;
            }

            trigger4 = false;

            button4.color = Color.Lerp(green, red, (currentLerpTime4 / lerpTime));
            currentLerpTime4 += Time.deltaTime;

            if (currentLerpTime4 >= lerpTime)
            {
                currentLerpTime4 = lerpTime;
            }
        }
    }

    void Update()
    {
        colorLerp(); 
    }
}
