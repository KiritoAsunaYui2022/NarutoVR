﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class HandJutsu : MonoBehaviour
{

    //Hope

    public GameObject controllerR;
    public GameObject controllerL;
    public float distance;
    public JutsuScroll scroll;
    public HandAnimation animations; 

    //Game Logic 
    public bool disAreaOne;     //Within a distance to add Jutsu to Astra 
    public bool disAreaTwo;     //Within a distance that pauses the addition of Jutsu to Astra 
    public bool disAreaThree;   //Within a distance that clears Astra 

    //Button Press/Touch - OVR Quest Controller Mapping 
    //public bool PrimaryThumbstick => OVRInput.Get(OVRInput.Touch.PrimaryThumbstick); //Primary Thumbstick Touch 
    //public bool SecondaryThumbstick => OVRInput.Get(OVRInput.Touch.SecondaryThumbstick); //Secondary Thumbstick Touch 
    //public bool fBt;    //Four Button Touch  
    //public bool thBt;   //Three Button Touch 
    //public bool twBt;   //Two Button Touch 
    //public bool oBt;    //One Button Touch 
    //public bool pTrb;   //Primary Trigger Button 
    //public bool sTrb;   //Secondary Trigger Button 
    //public bool pHb;    //Primary Hand Button 
    //public bool sHb;    //Secondary Hand Button 

    public TextMeshProUGUI x_RightText;
    public TextMeshProUGUI x_LeftText;
    public TextMeshProUGUI z_RightText;
    public TextMeshProUGUI z_LeftText;
    public TextMeshProUGUI poseText;
    public TextMeshProUGUI justuText;
    public TextMeshProUGUI distanceText; 

    //Monkey
    public bool x_RightMonkey;    //X Coordinate Right Controller Monkey
    public bool x_LeftMonkey;    //X Coordinate Left Controller Monkey
    public bool z_RightMonkey;    //Z Coordinate Right Controller Monkey
    public bool z_LeftMonkey;    //Z Coordinate Left Controller Monkey

    //Bird
    public bool x_RightBird;
    public bool x_LeftBird;
    public bool z_RightBird;
    public bool z_LeftBird;

    //Rat
    public bool x_LeftRat;
    public bool z_LeftRat;
    public bool x_RightRat;

    //Serpant
    public bool x_LeftSerpant;
    public bool x_RightSerpant;
    public bool z_LeftSerpant;
    public bool z_RightSerpant;

    //Boar
    public bool x_RightBoar;
    public bool z_RightBoar;
    public bool x_LeftBoar;
    public bool z_LeftBoar;

    //Dragon
    public bool x_RightDragon;
    public bool z_RightDragon;
    public bool x_LeftDragon;
    public bool z_LeftDragon;

    //Horse
    public bool x_RightHorse;
    public bool z_RightHorse;
    public bool x_LeftHorse;
    public bool z_LeftHorse;

    //Ox
    public bool z_RightOx;

    //Dog
    public bool x_LeftDog;
    public bool z_LeftDog;


    //Bool Of Each Jutsu w/ Pos
    public bool birdJutsu = false;
    public bool birdPos;

    public bool boarJutsu = false;
    public bool boarPos;

    public bool dogJutsu = false;
    public bool dogPos;

    public bool dragonJutsu = false;
    public bool dragonPos;

    public bool hareJutsu = false;
    public bool harePos; 

    public bool horseJutsu = false;
    public bool horsePos;

    public bool monkeyJutsu = false;
    public bool monkeyPos;

    public bool oxJutsu = false;
    public bool oxPos;

    public bool ramJutsu = false;
    public bool ramPos;

    public bool ratJutsu = false;
    public bool ratPos;

    public bool serpantJutsu = false;
    public bool serpantPos;

    public bool tigerJutsu = false;
    public bool tigerPos;


    //Hand Seal Sound Effect 
    public SoundEffects soundEffect; 




    //Consistently tests the distance between the two controllers (L & R) with a simple function and if function 
    public void distanceOfControllers()
    {

        distance = Vector3.Distance(controllerR.transform.position, controllerL.transform.position);

        
        if (distance < 0.25)
        {
            print("Distance Area One");
            disAreaOne = true;
        }

        else
        {
            disAreaOne = false;
        }

        if (distance > .25 && distance < 1.2)
        {
            disAreaTwo = true;
            scroll.moveOn = true;
            print("Distance Area Two");
        }

        else
        {
            disAreaTwo = false;
        }

        //Was 1 
        if(distance < 1.2)
        {
            //You are within the distance
            disAreaThree = true;
        }

        else
        {
            disAreaThree = false;
            print("Distance Area Three");
        }

    }



    //Senses the angle of the controllers, and if they are both in between the right values, then it produces an output 
    public void angleOfControllers()
    {

        //If buttons are touched/pressed
        //Primary Thumbstick touch
        //if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        //{
        //    pTt = true;
        //}

        //else
        //{
        //    pTt = false;
        //}

        //Secondary Thumbstick touch
        //if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        //{
        //    sTt = true;
        //}

        //else
        //{
        //    sTt = false;
        //}

        //
        //if (OVRInput.Get(OVRInput.Touch.Four))
        //{
        //    fBt = true;
        //}

        //else
        //{
        //    fBt = false;
        //}

        //if (OVRInput.Get(OVRInput.Touch.Three))
        //{
        //    thBt = true;
        //}

        //else
        //{
        //    thBt = false;
        //}

        //if (OVRInput.Get(OVRInput.Touch.Two))
        //{
        //    twBt = true;
        //}

        //else
        //{
        //    twBt = false;
        //}

        //if (OVRInput.Get(OVRInput.Touch.One))
        //{
        //    oBt = true;
        //}

        //else
        //{
        //    oBt = false;
        //}

        //if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        //{
        //    pTrb = true;
        //}

        //else
        //{
        //    pTrb = false;
        //}

        //if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        //{
        //    sTrb = true;
        //}

        //else
        //{
        //    sTrb = false;
        //}

        //if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        //{
        //    pHb = true;
        //}

        //else
        //{
        //    pHb = false;
        //}

        //if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        //{
        //    sHb = true;
        //}

        //else
        //{
        //    sHb = false;
        //}


//Monkey -----------

        //X values for L & R
        //The value of angle that your controllers output have to be either greater than 340degrees OR less than 20degrees, the two outputs switch
        x_RightMonkey = (controllerR.transform.localEulerAngles.x > 340f || controllerR.transform.localEulerAngles.x < 20f); /* ? x_RightMonkey == true : x_RightMonkey == false;*/

        //x_RightText.text = x_RightMonkey ? "X_Right: True" : "X_Right: False"; //Text 


        x_LeftMonkey = (controllerL.transform.localEulerAngles.x > 340f || controllerL.transform.localEulerAngles.x < 20f); /* ? x_LeftMonkey == true : x_LeftMonkey == false;*/

        //x_LeftText.text = x_LeftMonkey ? "X_Left: True" : "X_Left: False"; //Text 


        z_RightMonkey = (controllerR.transform.localEulerAngles.z > 250f && controllerR.transform.localEulerAngles.z < 325f); /* ? z_RightMonkey == true : z_RightMonkey == false;*/

        //z_RightText.text = z_RightMonkey ? "Z_Right: True" : "Z_Right: False"; //Text 


        z_LeftMonkey = (controllerL.transform.localEulerAngles.z > 230f && controllerL.transform.localEulerAngles.z < 290f); /* ? z_LeftMonkey == true : z_LeftMonkey == false;*/

        //z_LeftText.text = z_LeftMonkey ? "Z_Left: True" : "Z_Left: False"; //Text 




        //Monkey Pose construct
        monkeyPos = (x_RightMonkey == true && x_LeftMonkey == true && z_RightMonkey == true && z_LeftMonkey == true && disAreaOne == true);

        //poseText.text = monkeyPos ? "Pose: True" : "Pose: False"; //Text 


        //Full fuction parameters for Monkey Jutsu Hand Gesture 
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && !OVRInput.Get(OVRInput.Touch.Four) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !monkeyJutsu && monkeyPos && scroll.moveOn)
        {

            animations.monkey = true;
            scroll.astra += "Monkey";
            soundEffect.playHandSealSound(); 

            monkeyJutsu = disAreaOne ? monkeyJutsu = true : monkeyJutsu = false; 

            scroll.moveOn = false;
            justuText.text = "Justu: Monkey";
        }

        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || OVRInput.Get(OVRInput.Touch.Four) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || monkeyJutsu && !monkeyPos && !scroll.moveOn)
        {
            animations.monkey = false; 
            monkeyJutsu = false; 
            justuText.text = "Justu: ";
        }

        //distanceText.text = monkeyJutsu ? "Monkey" : "!Monkey!";
//Monkey -------------



//Bird ---------------

        x_RightBird = (controllerR.transform.localEulerAngles.x > 250f && controllerR.transform.localEulerAngles.x < 320f); 
        //x_RightText.text = x_RightBird ? "X_Right: True" : "X_Right: False"; //Text 


        z_RightBird = (controllerR.transform.localEulerAngles.z > 55f && controllerR.transform.localEulerAngles.z < 115f);
        //z_RightText.text = z_RightBird ? "Z_Right: True" : "Z_Right: False"; //Text 


        x_LeftBird = (controllerL.transform.localEulerAngles.x > 295f && controllerL.transform.localEulerAngles.x < 320f);
        //x_LeftText.text = x_LeftBird ? "X_Left: True" : "X_Left: False"; //Text 


        z_LeftBird = (controllerL.transform.localEulerAngles.z > 240f && controllerL.transform.localEulerAngles.z < 300f); 
        //z_LeftText.text = z_LeftBird ? "Z_Left: True" : "Z_Left: True"; //Text 


        birdPos = (x_RightBird == true && z_RightBird == true && z_LeftBird == true && x_LeftBird == true && disAreaOne == true); 
        //poseText.text = birdPos ? "Pose: True" : "Pose: False";


        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && !OVRInput.Get(OVRInput.Touch.Four) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !birdJutsu && birdPos && scroll.moveOn)
        {
            animations.bird = true;
            scroll.astra += "Bird";

            birdJutsu = disAreaOne ? birdJutsu = true : birdJutsu = false; 

            scroll.moveOn = false;
            justuText.text = "Justu: Bird";
        }

        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Touch.Four) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || birdJutsu && !birdPos && !scroll.moveOn)
        {
            animations.bird = false;
            birdJutsu = false;
            justuText.text = "Jutsu: "; 
        }

        //distanceText.text = birdJutsu ? "Bird" : "!Bird!";

//Bird ---------------


//Ram ----------------

        //Ram utilizes Serpant's Angle values, so a truth serum with button touches are all required
        ramPos = (x_RightSerpant == true && z_RightSerpant == true && z_LeftSerpant == true && x_LeftSerpant == true && disAreaOne == true);
        poseText.text = ramPos ? "Pose: True" : "Pose: False";


        if (!OVRInput.Get(OVRInput.Button.Four) && !OVRInput.Get(OVRInput.Button.Three) && OVRInput.Get(OVRInput.Button.Two) && OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && !ramJutsu && ramPos && scroll.moveOn)
        {
            animations.ram = true;
            scroll.astra += "Ram";

            ramJutsu = disAreaOne ? ramJutsu = true : ramJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Ram";
        }

        if (OVRInput.Get(OVRInput.Button.Four) || OVRInput.Get(OVRInput.Button.Three) || !OVRInput.Get(OVRInput.Touch.Two) || !OVRInput.Get(OVRInput.Touch.One) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || ramJutsu && !ramPos && !scroll.moveOn)
        {
            animations.ram = false;
            ramJutsu = false;
            justuText.text = "Jutsu: "; 
        }

        distanceText.text = ramJutsu ? "Ram" : "!Ram!";

//Ram ----------------


//Serpant ----------------


        x_LeftSerpant = (controllerL.transform.localEulerAngles.x > 275f && controllerL.transform.localEulerAngles.x < 320f); //300 
        x_RightText.text = x_RightSerpant ? "X_Right: True" : "X_Right: False"; //Text


        z_LeftSerpant = (controllerL.transform.localEulerAngles.z > 230f && controllerL.transform.localEulerAngles.z < 330f); //320
        x_LeftText.text = x_LeftSerpant ? "X_Left: True" : "X_Left: False"; //Text 


        x_RightSerpant = (controllerR.transform.localEulerAngles.x > 280f && controllerR.transform.localEulerAngles.x < 320f); //300f
        z_RightText.text = z_RightSerpant ? "Z_Right: True" : "Z_Right: False"; //Text


        z_RightSerpant = (controllerR.transform.localEulerAngles.z > 50f && controllerR.transform.localEulerAngles.z < 130f);
        z_LeftText.text = z_LeftSerpant ? "Z_Left: True" : "Z_Left: False"; //Text 


        serpantPos = (x_RightSerpant == true && z_RightSerpant == true && z_LeftSerpant == true && x_LeftSerpant == true && disAreaOne == true);
        //poseText.text = serpantPos ? "Pose: True" : "Pose: False";

        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Four) && !serpantJutsu && serpantPos && scroll.moveOn)
        {
            animations.serpant = true;
            scroll.astra += "Serpant";

            serpantJutsu = disAreaOne ? serpantJutsu = true : serpantJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Serpant";
        }

        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Four) || serpantJutsu && !serpantPos && !scroll.moveOn)
        {
            animations.serpant = false;
            serpantJutsu = false;
            justuText.text = "Jutsu: ";
        }

//Serpant ----------------


//Tiger ------------------

        //Tiger utilizes Serpant's Angle values, so a truth serum with button touches are all required

        tigerPos = (x_RightSerpant == true && z_RightSerpant == true && z_LeftSerpant == true && x_LeftSerpant == true && disAreaOne == true); 
        
        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Two) && OVRInput.Get(OVRInput.Button.Three) && OVRInput.Get(OVRInput.Button.Four) && !tigerJutsu && tigerPos && scroll.moveOn)
        {
            animations.tiger = true;
            scroll.astra += "Tiger";

            tigerJutsu = disAreaOne ? tigerJutsu = true : tigerJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Tiger";
        }

        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.One) || !OVRInput.Get(OVRInput.Button.Two) || !OVRInput.Get(OVRInput.Button.Three) || !OVRInput.Get(OVRInput.Button.Four) || tigerJutsu && !tigerPos && !scroll.moveOn)
        {
            animations.tiger = false;
            tigerJutsu = false;
            justuText.text = "Jutsu: ";
        }
//Tiger ------------------


//Rat --------------------


        x_LeftRat = (controllerL.transform.localEulerAngles.x > 330f || controllerL.transform.localEulerAngles.x < 10f);



        z_LeftRat = (controllerL.transform.localEulerAngles.z > 320f || controllerL.transform.localEulerAngles.z < 25f);



        x_RightRat = (controllerR.transform.localEulerAngles.x > 270f && controllerR.transform.localEulerAngles.x < 317f);



        ratPos = (x_LeftRat == true && z_LeftRat == true && x_RightRat == true && x_RightSerpant == true && disAreaOne == true); 

    
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.One) && OVRInput.Get(OVRInput.Button.Two) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Four) && OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && !ratJutsu && ratPos && scroll.moveOn)
        {
            animations.rat = true;
            scroll.astra += "Rat";

            ratJutsu = disAreaOne ? ratJutsu = true : ratJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Rat";
        }

        if (!OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.One) || !OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Four) || !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || ratJutsu && !ratPos && !scroll.moveOn)
        {
            animations.rat = false;
            ratJutsu = false;
            justuText.text = "Jutsu: ";
        }
//Rat ------------



//Boar -----------

        x_RightBoar = (controllerR.transform.localEulerAngles.x > 55f && controllerR.transform.localEulerAngles.x < 80f);


        z_RightBoar = (controllerR.transform.localEulerAngles.z > 320f || controllerR.transform.localEulerAngles.z < 15f);


        x_LeftBoar = (controllerL.transform.localEulerAngles.x > 55f && controllerL.transform.localEulerAngles.x < 80f);


        z_LeftBoar = (controllerL.transform.localEulerAngles.z > 350f || controllerL.transform.localEulerAngles.z > 15f);


        boarPos = (x_RightBoar == true && z_RightBoar == true && z_LeftBoar == true && x_LeftBoar == true && disAreaOne == true); 


        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Four) && !boarJutsu && boarPos && scroll.moveOn)
        {
            animations.boar = true;
            scroll.astra += "Boar";

            boarJutsu = disAreaOne ? boarJutsu = true : boarJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Boar";
        }

        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Four) || boarJutsu && !boarPos && !scroll.moveOn)
        {
            animations.boar = false;
            boarJutsu = false;
            justuText.text = "Jutsu: ";
        }


//Boar -----------



//Dragon ---------


        x_RightDragon = (controllerR.transform.localEulerAngles.x > 330f || controllerR.transform.localEulerAngles.x < 20f);


        z_RightDragon = (controllerR.transform.localEulerAngles.z > 330f || controllerR.transform.localEulerAngles.z < 20f);


        x_LeftDragon = (controllerL.transform.localEulerAngles.x > 330f || controllerL.transform.localEulerAngles.x < 30f);


        z_LeftDragon = (controllerL.transform.localEulerAngles.z > 330f || controllerL.transform.localEulerAngles.z < 30f);


        dragonPos = (x_RightDragon == true && z_RightDragon == true && x_LeftDragon == true && z_LeftDragon == true && disAreaOne == true); 


        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Four) && !dragonJutsu && dragonPos && scroll.moveOn)
        {
            animations.dragon = true;
            scroll.astra += "Dragon";

            dragonJutsu = disAreaOne ? dragonJutsu = true : dragonJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Dragon";
        }

        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Four) || dragonJutsu && !dragonPos && !scroll.moveOn)
        {
            animations.dragon = false;
            dragonJutsu = false;
            justuText.text = "Jutsu: ";
        }

//Dragon ------------- 



//Horse --------------


        x_RightHorse = (controllerR.transform.localEulerAngles.x > 335f || controllerR.transform.localEulerAngles.x < 25f);


        z_RightHorse = (controllerR.transform.localEulerAngles.z > 330f || controllerR.transform.localEulerAngles.z < 25f);


        x_LeftHorse = (controllerL.transform.localEulerAngles.x > 325f || controllerL.transform.localEulerAngles.x < 30f);


        z_LeftHorse = (controllerL.transform.localEulerAngles.z > 330f || controllerL.transform.localEulerAngles.z < 35f);


        horsePos = (x_RightHorse == true && z_RightHorse == true && x_LeftHorse == true && z_RightHorse == true && disAreaOne == true); 


        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Four) && !horseJutsu && horsePos && scroll.moveOn)
        {
            animations.horse = true;
            scroll.astra += "Horse";

            horseJutsu = disAreaOne ? horseJutsu = true : horseJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Horse";
        }

        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Four) || horseJutsu && !horsePos && !scroll.moveOn)
        {
            animations.horse = false;
            horseJutsu = false;
            justuText.text = "Jutsu: ";
        }

//Horse -----------------


//Ox --------------------

        z_RightOx = (controllerR.transform.localEulerAngles.z > 65f && controllerR.transform.localEulerAngles.z < 115f);


        //Ox Utilizes Monkey for Right Hand, and Serpant for Left Hand
        oxPos = (x_RightMonkey == true && z_RightOx == true && z_LeftSerpant == true && x_LeftSerpant == true && disAreaOne == true); 


        if (OVRInput.Get(OVRInput.Touch.Three) && OVRInput.Get(OVRInput.Touch.Four) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && !oxJutsu && oxPos && scroll.moveOn)
        {
            animations.ox = true;
            scroll.astra += "Ox";

            oxJutsu = disAreaOne ? oxJutsu = true : oxJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Ox";
        }

        if (!OVRInput.Get(OVRInput.Touch.Three) || !OVRInput.Get(OVRInput.Touch.Four) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || oxJutsu && !oxPos && !scroll.moveOn)
        {
            animations.ox = false;
            oxJutsu = false;
            justuText.text = "Jutsu: ";
        }

//Ox --------------------



//Hare ------------------

        //Hare Utilizes Ox's and Monkey's Right Hand and Horse's Left Hand

        harePos = (x_RightMonkey == true && z_RightOx == true && x_LeftHorse == true && z_LeftHorse == true && disAreaOne == true); 


        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Four) && !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && !hareJutsu && harePos && scroll.moveOn)
        {
            animations.hare = true;
            scroll.astra += "Hare";

            hareJutsu = disAreaOne ? hareJutsu = true : hareJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Hare";
        }

        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Four) || OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || hareJutsu && !harePos && !scroll.moveOn)
        {
            animations.hare = false;
            hareJutsu = false;
            justuText.text = "Jutsu: ";
        }


//Hare ------------------




//Dog -------------------


        //Dog Utilizesc Ox's Right Hand 
        x_LeftDog = (controllerL.transform.localEulerAngles.x > 330f || controllerL.transform.localEulerAngles.x < 20f);


        z_LeftDog = (controllerL.transform.localEulerAngles.z > 240f && controllerL.transform.localEulerAngles.z < 300f);


        dogPos = (x_LeftDog == true && z_LeftDog == true && x_RightMonkey == true && z_RightOx == true && disAreaOne == true); 


        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && !OVRInput.Get(OVRInput.Touch.One) && !OVRInput.Get(OVRInput.Touch.Two) && !OVRInput.Get(OVRInput.Touch.Three) && !OVRInput.Get(OVRInput.Touch.Four) && OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) && !dogJutsu && dogPos && scroll.moveOn)
        {
            animations.dog = true;
            scroll.astra += "Dog";

            dogJutsu = disAreaOne ? dogJutsu = true : dogJutsu = false;

            scroll.moveOn = false;
            justuText.text = "Justu: Dog";
        }

        if (!OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) || !OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || !OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Touch.One) || OVRInput.Get(OVRInput.Touch.Two) || OVRInput.Get(OVRInput.Touch.Three) || OVRInput.Get(OVRInput.Touch.Four) || !OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) || dogJutsu && !dogPos && !scroll.moveOn)
        {
            animations.dog = false;
            dogJutsu = false;
            justuText.text = "Jutsu: ";
        }

        
//Dog ---------------------  


    }
    

    public void Update()
    { 
        angleOfControllers();
        distanceOfControllers(); 
    }
}
