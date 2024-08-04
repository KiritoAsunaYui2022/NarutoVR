using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;



[RequireComponent(typeof(InputData))]
public class HandSeals : MonoBehaviour
{

    //Hope 

    public GameObject controllerR;
    public GameObject controllerL;
    public float distance;
    public JutsuScroll scroll;
    public HandAnimation animations;
    public bool useLocalRotation = true; // Toggle to switch between global and local rotations 


    //Game Logic 
    public bool disAreaOne;     //Within a distance to add Jutsu to Astra 
    public bool disAreaTwo;     //Within a distance that pauses the addition of Jutsu to Astra 
    public bool disAreaThree;   //Within a distance that clears Astra 

    //Texts 
    public TextMeshProUGUI x_RightText;
    public TextMeshProUGUI x_LeftText;
    public TextMeshProUGUI z_RightText;
    public TextMeshProUGUI z_LeftText;

    public TextMeshProUGUI Right_x_axis;
    public TextMeshProUGUI Right_y_axis;
    public TextMeshProUGUI Right_z_axis;

    public TextMeshProUGUI Left_x_axis;
    public TextMeshProUGUI Left_y_axis;
    public TextMeshProUGUI Left_z_axis;

    public TextMeshProUGUI poseText;
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

    //Serpent
    public bool x_LeftSerpent;
    public bool x_RightSerpent;
    public bool z_LeftSerpent;
    public bool z_RightSerpent;

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

    public bool serpentJutsu = false;
    public bool serpentPos;

    public bool tigerJutsu = false;
    public bool tigerPos;


    //Hand Seal Sound Effect 
    public SoundEffects soundEffect;

    private InputData inputData;

    //Right Hand Controller 
    public bool
        // Right is Secondary for some reason 
        RightPrimaryPressed, // OVRInput.Get(OVRInput.Button.One) //
        RightSecondaryPressed, // OVRInput.Get(OVRInput.Button.Two) // 
        RightTriggerPressed, // OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) // 
        RightGripPressed, // OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) // 
        RightAxisPressed, // OVRInput.Get(OVRInput.Button.SecondaryThumbstick) // 

        RightPrimaryTouch, // OVRInput.Get(OVRInput.Touch.One) //
        RightSecondaryTouch, // OVRInput.Get(OVRInput.Touch.Two) // 
        RightTriggerTouch, // OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger) // 
        RightAxisTouch, // OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) // 

        // Left is Primary I guess 
        LeftPrimaryPressed, // OVRInput.Get(OVRInput.Button.Three) // 
        LeftSecondaryPressed, // OVRInput.Get(OVRInput.Button.Four) // 
        LeftTriggerPressed, // OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) // 
        LeftGripPressed, // OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) // 
        LeftAxisPressed, // OVRInput.Get(OVRInput.Button.PrimaryThumbstick) // 

        LeftPrimaryTouch, // OVRInput.Get(OVRInput.Touch.Three) // 
        LeftSecondaryTouch, // OVRInput.Get(OVRInput.Touch.Four) // 
        LeftTriggerTouch, // OVRInput.Get(OVRInput.Touch.PrimaryIdexTrigger) // 
        LeftAxisTouch, // OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) //  

        //Positions of Hands to replace specific coordinates that was the old system (Oh it was horrible) 
        RightUp,
        RightDown,
        RightLevel,
        RightOut,

        LeftUp,
        LeftDown,
        LeftLevel,
        LeftOut;


    public void Start()
    {
        inputData = GetComponent<InputData>();
        Debug.Log("Start");
    }

    //Consistently tests the distance between the two controllers (L & R) with a simple function and if function 
    public void distanceOfControllers()
    {
        distance = Vector3.Distance(controllerR.transform.position, controllerL.transform.position);

        //print("Hello: " + controllerR.transform.position);
        //Debug.Log("Hello"); 

        disAreaOne = (distance <= 0.25);

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

        disAreaThree = (distance >= 1.2);
    }


    // This function normalizes an angle to be within the range 0-360 degree range 
    float StableAngle(float angle)
    {
        if (angle < 0f)
            angle = (angle += 360f) % 360f;

        return angle;
    }

    //public bool IsAngleInRange(float angle, float min, float max)
    // This function checks if the angle is within the specified range, considering wrap-around and inversion
    public bool IsAngleInRange(float localEulerAngles, float angle, bool wrapAround)
    {
        float min = StableAngle(angle - 20f);
        float max = StableAngle(angle + 20f);

        bool isInRange;

        if (min < max)
        {
            isInRange = localEulerAngles >= min && localEulerAngles <= max;
        }
        else // wrap-around case
        {
            isInRange = localEulerAngles >= min || localEulerAngles <= max;
        }

        return wrapAround ? !isInRange : isInRange;
    }

    public void Angles()
    {
        Quaternion RightRotation = useLocalRotation ? controllerR.transform.localRotation : controllerR.transform.rotation;
        Quaternion LeftRotation = useLocalRotation ? controllerL.transform.localRotation : controllerL.transform.rotation;
        RightRotation.ToAngleAxis(out float RightAngle, out Vector3 RightAxis);
        LeftRotation.ToAngleAxis(out float LeftAngle, out Vector3 LeftAxis);

        Vector3 RightHandNormalizedAngle = RightAngle * RightAxis;
        Vector3 LeftHandNormalizedAngle = LeftAngle * LeftAxis;

        //float Right_X_Axis = Mathf.Round(StableAngle(RightHandNormalizedAngle.x * 100f) * .01f);
        float Right_X_Axis = StableAngle(RightHandNormalizedAngle.x);
        float Right_Y_Axis = StableAngle(RightHandNormalizedAngle.y);
        float Right_Z_Axis = StableAngle(RightHandNormalizedAngle.z);

        float Left_X_Axis = StableAngle(LeftHandNormalizedAngle.x);
        float Left_Y_Axis = StableAngle(LeftHandNormalizedAngle.y);
        float Left_Z_Axis = StableAngle(LeftHandNormalizedAngle.z);

        //Debugging Purposes 
        Right_x_axis.text = "Right X Axis: " + Right_X_Axis;
        Right_y_axis.text = "Right Y Axis: " + Right_Y_Axis;
        Right_z_axis.text = "Right Z Axis: " + Right_Z_Axis;

        Left_x_axis.text = "Left X Axis: " + Left_X_Axis;
        Left_y_axis.text = "Left Y Axis: " + Left_Y_Axis;
        Left_z_axis.text = "Left Z Axis: " + Left_Z_Axis;
    }

    //Senses the angle of the controllers, and if they are both in between the right values, then it produces an output 
    public void angleOfControllers()
    {
        //Debug.Log("angle"); 

        // Right Hand Controller 
        // Buttons  
        inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out RightPrimaryPressed);
        inputData.rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out RightSecondaryPressed);
        inputData.rightController.TryGetFeatureValue(CommonUsages.triggerButton, out RightTriggerPressed);
        inputData.rightController.TryGetFeatureValue(CommonUsages.gripButton, out RightGripPressed);
        inputData.rightController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out RightAxisPressed);

        // Touch 
        inputData.rightController.TryGetFeatureValue(CommonUsages.primaryTouch, out RightPrimaryPressed);
        inputData.rightController.TryGetFeatureValue(CommonUsages.secondaryTouch, out RightSecondaryTouch);
        RightTriggerTouch = inputData.rightController.TryGetFeatureValue(CommonUsages.trigger, out var RightTriggerTouchValue) && RightTriggerTouchValue > 0; // no triggerTouch there seems to be, translate float to bool I will  
        inputData.rightController.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out RightAxisTouch);


        // Left Hand Controller 
        // Buttons 
        inputData.leftController.TryGetFeatureValue(CommonUsages.primaryButton, out LeftPrimaryPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out LeftSecondaryPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.triggerButton, out LeftTriggerPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.gripButton, out LeftGripPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out LeftAxisPressed);

        // Touch 
        inputData.leftController.TryGetFeatureValue(CommonUsages.primaryTouch, out LeftPrimaryPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.secondaryTouch, out LeftSecondaryTouch);
        RightTriggerTouch = inputData.leftController.TryGetFeatureValue(CommonUsages.trigger, out var LeftTriggerTouchValue) && LeftTriggerTouchValue > 0; // triggerTouch there seems to be not, translate float to bool I will  
        inputData.leftController.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out LeftAxisTouch);

        //Monkey -----------




        //X values for L & R
        //The value of angle that your controllers output have to be either greater than 340degrees OR less than 20degrees, the two outputs switch
        //x_RightMonkey = (controllerR.transform.localEulerAngles.x > 340f || controllerR.transform.localEulerAngles.x < 20f);
        x_RightMonkey = IsAngleInRange(controllerR.transform.localEulerAngles.x, 22f, true);

        //z_RightMonkey = (controllerR.transform.localEulerAngles.z > 250f && controllerR.transform.localEulerAngles.z < 325f);
        z_RightMonkey = IsAngleInRange(controllerR.transform.localEulerAngles.z, 286f, true);

        //x_LeftMonkey = (controllerL.transform.localEulerAngles.x > 340f || controllerL.transform.localEulerAngles.x < 20f);
        x_LeftMonkey = IsAngleInRange(controllerL.transform.localEulerAngles.x, 333f, true);

        //z_LeftMonkey = (controllerL.transform.localEulerAngles.z > 230f && controllerL.transform.localEulerAngles.z < 290f);
        z_LeftMonkey = IsAngleInRange(controllerL.transform.localEulerAngles.z, 268f, true);



        //Monkey Pose construct
        monkeyPos = (x_RightMonkey == true && x_LeftMonkey == true && z_RightMonkey == true && z_LeftMonkey == true && disAreaOne == true);


        //x_RightText.text = "ControllerR_x: " + controllerR.transform.localEulerAngles.x + " -- Bool: " + x_RightMonkey;
        //z_RightText.text = "ControllerR_z: " + controllerR.transform.localEulerAngles.z + " -- Bool: " + z_RightMonkey;
        //x_LeftText.text = "ControllerL_x: " + controllerL.transform.localEulerAngles.x + " -- Bool: " + x_LeftMonkey;
        //z_LeftText.text = "ControllerL:_z: " + controllerL.transform.localEulerAngles.z + " -- Bool: " + z_LeftMonkey;


        var testLab = monkeyPos ? "Monkey Pose" : "Null";
        print(testLab);

        //Full fuction parameters for Monkey Jutsu Hand Gesture 
        //if (RightAxisTouch && LeftAxisTouch && !LeftSecondaryTouch && !LeftPrimaryTouch && !RightSecondaryTouch && !RightPrimaryTouch && !LeftTriggerPressed && !RightTriggerPressed && !LeftGripPressed && !RightGripPressed && !monkeyJutsu && monkeyPos && scroll.moveOn)
        //{
        if (RightAxisTouch && LeftAxisTouch && monkeyPos)
        {
            print("Monkey");
            //animations.monkey = true; 
            scroll.astra += "Monkey";
            soundEffect.playHandSealSound();

            monkeyJutsu = disAreaOne ? monkeyJutsu = true : monkeyJutsu = false;

            scroll.moveOn = false;
        }

        if (!RightAxisTouch || !LeftAxisTouch || LeftSecondaryTouch || LeftPrimaryTouch || RightSecondaryTouch || RightPrimaryTouch || LeftTriggerPressed || RightTriggerPressed || LeftGripPressed || RightGripPressed || monkeyJutsu && !monkeyPos && !scroll.moveOn)
        {
            animations.monkey = false;
            monkeyJutsu = false;
        }

        //Monkey -------------



        //Bird ---------------

        x_RightBird = (controllerR.transform.localEulerAngles.x > 250f && controllerR.transform.localEulerAngles.x < 320f);

        z_RightBird = (controllerR.transform.localEulerAngles.z > 55f && controllerR.transform.localEulerAngles.z < 115f);

        x_LeftBird = (controllerL.transform.localEulerAngles.x > 295f && controllerL.transform.localEulerAngles.x < 320f);

        z_LeftBird = (controllerL.transform.localEulerAngles.z > 240f && controllerL.transform.localEulerAngles.z < 300f);

        birdPos = (x_RightBird == true && z_RightBird == true && z_LeftBird == true && x_LeftBird == true && disAreaOne == true);

        if (RightAxisTouch && LeftAxisTouch && LeftTriggerPressed && RightTriggerPressed && !LeftSecondaryTouch && !LeftPrimaryTouch && !RightSecondaryTouch && !RightPrimaryTouch && !LeftGripPressed && !RightGripPressed && !birdJutsu && birdPos && scroll.moveOn)
        {
            animations.bird = true;
            scroll.astra += "Bird";
            soundEffect.playHandSealSound();

            birdJutsu = disAreaOne ? birdJutsu = true : birdJutsu = false;

            scroll.moveOn = false;
        }

        if (!RightAxisTouch || !LeftAxisTouch || !LeftTriggerPressed || !RightTriggerPressed || LeftSecondaryTouch || LeftPrimaryTouch || RightSecondaryTouch || RightPrimaryTouch || LeftGripPressed || RightGripPressed || birdJutsu && !birdPos && !scroll.moveOn)
        {
            animations.bird = false;
            birdJutsu = false;
        }

        //Bird ---------------


        //Ram ----------------

        //Ram utilizes Serpent's Angle values, so a truth serum with button touches are all required
        ramPos = (x_RightSerpent == true && z_RightSerpent == true && z_LeftSerpent == true && x_LeftSerpent == true && disAreaOne == true);

        if (!LeftSecondaryPressed && !LeftPrimaryPressed && RightSecondaryPressed && RightPrimaryPressed && LeftGripPressed && RightGripPressed && !RightTriggerPressed && !LeftTriggerPressed && !RightAxisTouch && LeftAxisTouch && !ramJutsu && ramPos && scroll.moveOn)
        {
            animations.ram = true;
            scroll.astra += "Ram";
            soundEffect.playHandSealSound();

            ramJutsu = disAreaOne ? ramJutsu = true : ramJutsu = false;

            scroll.moveOn = false;
        }

        if (LeftSecondaryPressed || LeftPrimaryPressed || !RightSecondaryTouch || !RightPrimaryTouch || !LeftGripPressed || !RightGripPressed || RightTriggerPressed || LeftTriggerPressed || RightAxisTouch || !LeftAxisTouch || ramJutsu && !ramPos && !scroll.moveOn)
        {
            animations.ram = false;
            ramJutsu = false;
        }

        //Ram ----------------


        //Serpent ---------------- 

        x_LeftSerpent = (controllerL.transform.localEulerAngles.x > 275f && controllerL.transform.localEulerAngles.x < 320f); //300 

        z_LeftSerpent = (controllerL.transform.localEulerAngles.z > 230f && controllerL.transform.localEulerAngles.z < 330f); //320

        x_RightSerpent = (controllerR.transform.localEulerAngles.x > 280f && controllerR.transform.localEulerAngles.x < 320f); //300f

        z_RightSerpent = (controllerR.transform.localEulerAngles.z > 50f && controllerR.transform.localEulerAngles.z < 130f);

        serpentPos = (x_RightSerpent == true && z_RightSerpent == true && z_LeftSerpent == true && x_LeftSerpent == true && disAreaOne == true);

        if (RightAxisTouch && LeftAxisTouch && LeftTriggerPressed && RightTriggerPressed && LeftGripPressed && RightGripPressed && !RightPrimaryTouch && !RightSecondaryTouch && !LeftPrimaryTouch && !LeftSecondaryTouch && !serpentJutsu && serpentPos && scroll.moveOn)
        {
            animations.serpent = true;
            scroll.astra += "Serpent";
            soundEffect.playHandSealSound();

            serpentJutsu = disAreaOne ? serpentJutsu = true : serpentJutsu = false;

            scroll.moveOn = false;
        }

        if (!RightAxisTouch || !LeftAxisTouch || !LeftTriggerPressed || !RightTriggerPressed || !LeftGripPressed || !RightGripPressed || RightPrimaryTouch || RightSecondaryTouch || LeftPrimaryTouch || LeftSecondaryTouch || serpentJutsu && !serpentPos && !scroll.moveOn)
        {
            animations.serpent = false;
            serpentJutsu = false;
        }

        //Serpent ----------------


        //Tiger ------------------

        //Tiger utilizes Serpent's Angle values, so a truth serum with button touches are all required
        tigerPos = (x_RightSerpent == true && z_RightSerpent == true && z_LeftSerpent == true && x_LeftSerpent == true && disAreaOne == true);

        if (!RightAxisTouch && !LeftAxisTouch && RightGripPressed && LeftGripPressed && !RightTriggerPressed && !LeftTriggerPressed && RightPrimaryPressed && RightSecondaryPressed && LeftPrimaryPressed && LeftSecondaryPressed && !tigerJutsu && tigerPos && scroll.moveOn)
        {
            animations.tiger = true;
            scroll.astra += "Tiger";
            soundEffect.playHandSealSound();

            tigerJutsu = disAreaOne ? tigerJutsu = true : tigerJutsu = false;

            scroll.moveOn = false;
        }

        if (RightAxisTouch || LeftAxisTouch || !RightGripPressed || !LeftGripPressed || RightTriggerPressed || LeftTriggerPressed || !RightPrimaryPressed || !RightSecondaryPressed || !LeftPrimaryPressed || !LeftSecondaryPressed || tigerJutsu && !tigerPos && !scroll.moveOn)
        {
            animations.tiger = false;
            tigerJutsu = false;
        }

        //Tiger ------------------


        //Rat --------------------

        x_LeftRat = (controllerL.transform.localEulerAngles.x > 330f || controllerL.transform.localEulerAngles.x < 10f);

        z_LeftRat = (controllerL.transform.localEulerAngles.z > 320f || controllerL.transform.localEulerAngles.z < 25f);

        x_RightRat = (controllerR.transform.localEulerAngles.x > 270f && controllerR.transform.localEulerAngles.x < 317f);

        ratPos = (x_LeftRat == true && z_LeftRat == true && x_RightRat == true && x_RightSerpent == true && disAreaOne == true);


        if (LeftTriggerPressed && LeftGripPressed && RightGripPressed && !RightTriggerPressed && RightPrimaryPressed && RightSecondaryPressed && !LeftPrimaryTouch && !LeftSecondaryTouch && LeftAxisTouch && !ratJutsu && ratPos && scroll.moveOn)
        {
            animations.rat = true;
            scroll.astra += "Rat";
            soundEffect.playHandSealSound();

            ratJutsu = disAreaOne ? ratJutsu = true : ratJutsu = false;

            scroll.moveOn = false;
        }

        if (!LeftTriggerPressed || !LeftGripPressed || !RightGripPressed || RightTriggerPressed || !RightPrimaryPressed || !RightSecondaryPressed || LeftPrimaryTouch || LeftSecondaryTouch || !LeftAxisTouch || ratJutsu && !ratPos && !scroll.moveOn)
        {
            animations.rat = false;
            ratJutsu = false;
        }

        //Rat ------------



        //Boar -----------

        x_RightBoar = (controllerR.transform.localEulerAngles.x > 55f && controllerR.transform.localEulerAngles.x < 80f);

        z_RightBoar = (controllerR.transform.localEulerAngles.z > 320f || controllerR.transform.localEulerAngles.z < 15f);

        x_LeftBoar = (controllerL.transform.localEulerAngles.x > 55f && controllerL.transform.localEulerAngles.x < 80f);

        z_LeftBoar = (controllerL.transform.localEulerAngles.z > 350f || controllerL.transform.localEulerAngles.z > 15f);

        boarPos = (x_RightBoar == true && z_RightBoar == true && z_LeftBoar == true && x_LeftBoar == true && disAreaOne == true);


        if (RightAxisTouch && LeftAxisTouch && LeftTriggerPressed && RightTriggerPressed && LeftGripPressed && RightGripPressed && !RightPrimaryTouch && !RightSecondaryTouch && !LeftPrimaryTouch && !LeftSecondaryTouch && !boarJutsu && boarPos && scroll.moveOn)
        {
            animations.boar = true;
            scroll.astra += "Boar";
            soundEffect.playHandSealSound();

            boarJutsu = disAreaOne ? boarJutsu = true : boarJutsu = false;

            scroll.moveOn = false;
        }

        if (!RightAxisTouch || !LeftAxisTouch || !LeftTriggerPressed || !RightTriggerPressed || !LeftGripPressed || !RightGripPressed || RightPrimaryTouch || RightSecondaryTouch || LeftPrimaryTouch || LeftSecondaryTouch || boarJutsu && !boarPos && !scroll.moveOn)
        {
            animations.boar = false;
            boarJutsu = false;
        }

        //Boar -----------



        //Dragon ---------

        x_RightDragon = (controllerR.transform.localEulerAngles.x > 330f || controllerR.transform.localEulerAngles.x < 20f);

        z_RightDragon = (controllerR.transform.localEulerAngles.z > 330f || controllerR.transform.localEulerAngles.z < 20f);

        x_LeftDragon = (controllerL.transform.localEulerAngles.x > 330f || controllerL.transform.localEulerAngles.x < 30f);

        z_LeftDragon = (controllerL.transform.localEulerAngles.z > 330f || controllerL.transform.localEulerAngles.z < 30f);

        dragonPos = (x_RightDragon == true && z_RightDragon == true && x_LeftDragon == true && z_LeftDragon == true && disAreaOne == true);


        if (!RightAxisTouch && !LeftAxisTouch && LeftTriggerPressed && RightTriggerPressed && LeftGripPressed && RightGripPressed && !RightPrimaryTouch && !RightSecondaryTouch && !LeftPrimaryTouch && !LeftSecondaryTouch && !dragonJutsu && dragonPos && scroll.moveOn)
        {
            animations.dragon = true;
            scroll.astra += "Dragon";
            soundEffect.playHandSealSound();

            dragonJutsu = disAreaOne ? dragonJutsu = true : dragonJutsu = false;

            scroll.moveOn = false;
        }

        if (RightAxisTouch || LeftAxisTouch || !LeftTriggerPressed || !RightTriggerPressed || !LeftGripPressed || !RightGripPressed || RightPrimaryTouch || RightSecondaryTouch || LeftPrimaryTouch || LeftSecondaryTouch || dragonJutsu && !dragonPos && !scroll.moveOn)
        {
            animations.dragon = false;
            dragonJutsu = false;
        }

        //Dragon ------------- 



        //Horse --------------

        x_RightHorse = (controllerR.transform.localEulerAngles.x > 335f || controllerR.transform.localEulerAngles.x < 25f);

        z_RightHorse = (controllerR.transform.localEulerAngles.z > 330f || controllerR.transform.localEulerAngles.z < 25f);

        x_LeftHorse = (controllerL.transform.localEulerAngles.x > 325f || controllerL.transform.localEulerAngles.x < 30f);

        z_LeftHorse = (controllerL.transform.localEulerAngles.z > 330f || controllerL.transform.localEulerAngles.z < 35f);

        horsePos = (x_RightHorse == true && z_RightHorse == true && x_LeftHorse == true && z_RightHorse == true && disAreaOne == true);


        if (RightAxisTouch && LeftAxisTouch && LeftGripPressed && RightGripPressed && !RightTriggerPressed && !LeftTriggerPressed && !RightPrimaryTouch && !RightSecondaryTouch && !LeftPrimaryTouch && !LeftSecondaryTouch && !horseJutsu && horsePos && scroll.moveOn)
        {
            animations.horse = true;
            scroll.astra += "Horse";
            soundEffect.playHandSealSound();

            horseJutsu = disAreaOne ? horseJutsu = true : horseJutsu = false;

            scroll.moveOn = false;
        }

        if (!RightAxisTouch || !LeftAxisTouch || !LeftGripPressed || !RightGripPressed || RightTriggerPressed || LeftTriggerPressed || RightPrimaryTouch || RightSecondaryTouch || LeftPrimaryTouch || LeftSecondaryTouch || horseJutsu && !horsePos && !scroll.moveOn)
        {
            animations.horse = false;
            horseJutsu = false;
        }

        //Horse -----------------


        //Ox --------------------

        z_RightOx = (controllerR.transform.localEulerAngles.z > 65f && controllerR.transform.localEulerAngles.z < 115f);

        //Ox Utilizes Monkey for Right Hand, and Serpent for Left Hand
        oxPos = (x_RightMonkey == true && z_RightOx == true && z_LeftSerpent == true && x_LeftSerpent == true && disAreaOne == true);


        if (LeftPrimaryTouch && LeftSecondaryTouch && LeftGripPressed && !RightGripPressed && !RightTriggerPressed && !LeftTriggerPressed && !RightPrimaryTouch && !RightSecondaryTouch && !LeftAxisTouch && !oxJutsu && oxPos && scroll.moveOn)
        {
            animations.ox = true;
            scroll.astra += "Ox";
            soundEffect.playHandSealSound();

            oxJutsu = disAreaOne ? oxJutsu = true : oxJutsu = false;

            scroll.moveOn = false;
        }

        if (!LeftPrimaryTouch || !LeftSecondaryTouch || !LeftGripPressed || RightGripPressed || RightTriggerPressed || LeftTriggerPressed || RightPrimaryTouch || RightSecondaryTouch || LeftAxisTouch || oxJutsu && !oxPos && !scroll.moveOn)
        {
            animations.ox = false;
            oxJutsu = false;
        }

        //Ox --------------------



        //Hare ------------------

        //Hare Utilizes Ox's and Monkey's Right Hand and Horse's Left Hand
        harePos = (x_RightMonkey == true && z_RightOx == true && x_LeftHorse == true && z_LeftHorse == true && disAreaOne == true);


        if (RightAxisTouch && RightTriggerPressed && LeftGripPressed && RightGripPressed && !LeftTriggerPressed && !RightPrimaryTouch && !RightSecondaryTouch && !LeftPrimaryTouch && !LeftSecondaryTouch && !LeftAxisTouch && !hareJutsu && harePos && scroll.moveOn)
        {
            animations.hare = true;
            scroll.astra += "Hare";
            soundEffect.playHandSealSound();

            hareJutsu = disAreaOne ? hareJutsu = true : hareJutsu = false;

            scroll.moveOn = false;
        }

        if (!RightAxisTouch || !RightTriggerPressed || !LeftGripPressed || !RightGripPressed || LeftTriggerPressed || RightPrimaryTouch || RightSecondaryTouch || LeftPrimaryTouch || LeftSecondaryTouch || LeftAxisTouch || hareJutsu && !harePos && !scroll.moveOn)
        {
            animations.hare = false;
            hareJutsu = false;
        }

        //Hare ------------------




        //Dog -------------------

        //Dog Utilizesc Ox's Right Hand 
        x_LeftDog = (controllerL.transform.localEulerAngles.x > 330f || controllerL.transform.localEulerAngles.x < 20f);

        z_LeftDog = (controllerL.transform.localEulerAngles.z > 240f && controllerL.transform.localEulerAngles.z < 300f);

        dogPos = (x_LeftDog == true && z_LeftDog == true && x_RightMonkey == true && z_RightOx == true && disAreaOne == true);


        if (RightAxisTouch && RightTriggerPressed && RightGripPressed && !LeftGripPressed && !LeftTriggerPressed && !RightPrimaryTouch && !RightSecondaryTouch && !LeftPrimaryTouch && !LeftSecondaryTouch && LeftAxisTouch && !dogJutsu && dogPos && scroll.moveOn)
        {
            animations.dog = true;
            scroll.astra += "Dog";
            soundEffect.playHandSealSound();

            dogJutsu = disAreaOne ? dogJutsu = true : dogJutsu = false;

            scroll.moveOn = false;
        }

        if (!RightAxisTouch || !RightTriggerPressed || !RightGripPressed || LeftGripPressed || LeftTriggerPressed || RightPrimaryTouch || RightSecondaryTouch || LeftPrimaryTouch || LeftSecondaryTouch || !LeftAxisTouch || dogJutsu && !dogPos && !scroll.moveOn)
        {
            animations.dog = false;
            dogJutsu = false;
        }

        //Dog ---------------------  

    }


    public void Update()
    {
        Angles();
        Debug.Log("Update called");
        angleOfControllers();
        Debug.Log("angleOfControllers called");
        distanceOfControllers();
        Debug.Log("distanceOfControllers called");

        poseText.text = scroll.astra;
    }
}
