using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit; 
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;



[RequireComponent(typeof(InputData))]
public class HandSealsLab : MonoBehaviour
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
    public TextMeshProUGUI Right_x_axis;
    public TextMeshProUGUI Right_y_axis;
    public TextMeshProUGUI Right_z_axis;

    public TextMeshProUGUI rightTreeText;
    public TextMeshProUGUI leftTreeText;
    public TextMeshProUGUI rightAxisTouchText;
    public TextMeshProUGUI leftAxisTouchText;

    public TextMeshProUGUI Left_x_axis;
    public TextMeshProUGUI Left_y_axis;
    public TextMeshProUGUI Left_z_axis;

    public TextMeshProUGUI handSealBoolText;

    public TextMeshProUGUI poseText;
    public TextMeshProUGUI distanceText;

    public List<float> RightTreeAngles = new List<float> { 0f, 0f, 0f };   // This is desire hand seal 
    public List<float> LeftTreeAngles = new List<float> { 0f, 0f, 0f };


    public List<float> RightSkyAngles = new List<float> { 0f, 0f, 0f };
    public List<float> LeftSkyAngles = new List<float> { 0f, 0f, 0f };


    public List<float> RightWallAngles = new List<float> { 0f, 0f, 0f };
    public List<float> LeftWallAngles = new List<float> { 0f, 0f, 0f };


    public List<float> RightGroundAngles = new List<float> { 0f, 0f, 0f };
    public List<float> LeftGroundAngles = new List<float> { 0f, 0f, 0f };


    public List<float> RightHandSealAngles = new List<float> { 0f, 0f, 0f }; // This is the Angles of the right hand 
    public List<float> LeftHandSealAngles = new List<float> { 0f, 0f, 0f }; // This is the Angles of the left hand 

    List<bool> RightHandSealBool = new List<bool> { false, false, false };
    List<bool> LeftHandSealBool = new List<bool> { false, false, false };

    List<bool> MonkeyComponents = new List<bool> { false, false, false, false, false, false }; // RightTree, LeftTree, RightAxisTouch, LeftAxisTouch, disAreaOne, scroll.moveOn 
    List<bool> BirdComponents = new List<bool> { false, false, false, false, false, false, false, false, false, false }; // RightSky, LeftSky, RightGripPressed, RightPrimaryTouched, RightSecondaryTouched, LeftGripPressed, LeftPrimaryTouched, LeftSecondaryTouched, disAreaOne, scroll.moveOn 
    List<bool> RamComponents = new List<bool> { false, false, false, false, false }; //RightSky, LeftSky, RightGripPressed, disAreaOne, scroll.moveOn 
    List<bool> SerpantComponents = new List<bool> { false, false, false, false, false, false, false, false }; //RightSky, LeftSky, RightGripPressed, RightTriggerPressed, LeftGripPressed, LeftTriggerPressed, disAreaOne, scroll.moveOn 
    List<bool> TigerComponents = new List<bool> { false, false, false, false, false, false, false, false }; //RightSky, LeftSky, RightGripPressed, RightAxisTouched, LeftGripPressed, LeftAxisTouched, disAreaOne, scroll.moveOn 
    List<bool> RatComponents = new List<bool> { false, false, false, false, false, false, false }; //RightWall, LeftTree, RightGripPressed, RightTriggerPressed, LeftGripPressed, disAreaOne, scroll.moveOn 
    List<bool> BoarComponents = new List<bool> { false, false, false, false, false, false, false, false }; //RightGround, LeftGround, RightGripPressed, RightTriggerPressed, LeftGripPressed, LeftTriggerPressed, disAreaOne, scroll.moveOn 
    List<bool> DragonComponents = new List<bool> { false, false, false, false, false, false, false, false }; //RightWall, LeftWall, RightGripPressed, RightTriggerPressed, LeftGripPressed, LeftTriggerPressed, disAreaOne, scroll.moveOn 
    List<bool> HorseComponents = new List<bool> { false, false, false, false, false, false, false, false }; //RightWall, LeftWall, RightGripPressed, RightAxisTouched, LeftGripPressed, LeftAxisTouched, disAreaOne, scroll.moveOn 
    List<bool> OxComponents = new List<bool> { false, false, false, false, false }; //RightWall, LeftSky, LeftGripPressed, disAreaOne, scroll.moveOn 
    List<bool> HareComponents = new List<bool> { false, false, false, false, false, false }; //RightTree, LeftWall, RightGripPressed, LeftGripPressed, disAreaOne, scroll.moveOn 
    List<bool> DogComponents = new List<bool> { false, false, false, false, false, false, false, false}; //RightTree, LeftTree, RightGripPressed, RightTriggerPressed, RightAxisTouched, LeftAxisTouched, disAreaOne, scroll.moveOn                                                                         
    
    List<bool> HandSeals = new List<bool> { false, false, false, false, false, false, false, false, false, false, false, false }; 

    //public bool mKey;
    //public bool oKey;

    // These two make up monkey
    //public bool RightTree;
    //public bool LeftTree;

    // Monkey would be made of the angles and hands, but also the button and touch statements 
    //public bool Monkey;

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

        RightPrimaryTouched, // OVRInput.Get(OVRInput.Touch.One) //
        RightSecondaryTouched, // OVRInput.Get(OVRInput.Touch.Two) // 
        RightTriggerTouched, // OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger) // 
        RightAxisTouched, // OVRInput.Get(OVRInput.Touch.SecondaryThumbstick) // 
        RightGripTouched,

        // Left is Primary I guess 
        LeftPrimaryPressed, // OVRInput.Get(OVRInput.Button.Three) // 
        LeftSecondaryPressed, // OVRInput.Get(OVRInput.Button.Four) // 
        LeftTriggerPressed, // OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) // 
        LeftGripPressed, // OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) // 
        LeftAxisPressed, // OVRInput.Get(OVRInput.Button.PrimaryThumbstick) // 

        LeftPrimaryTouched, // OVRInput.Get(OVRInput.Touch.Three) // 
        LeftSecondaryTouched, // OVRInput.Get(OVRInput.Touch.Four) // 
        LeftTriggerTouched, // OVRInput.Get(OVRInput.Touch.PrimaryIdexTrigger) // 
        LeftAxisTouched, // OVRInput.Get(OVRInput.Touch.PrimaryThumbstick) //  
        LeftGripTouched,

        //Positions of Hands to replace specific coordinates that was the old system (Oh it was horrible) 
        RightSky,
        RightGround,
        RightTree,
        RightWall,

        LeftSky,
        LeftGround,
        LeftTree,
        LeftWall; 


    public void Start() 
    {
        inputData = GetComponent<InputData>(); 

        // Tree 
        RightTreeAngles = new List<float> { 70f, 305f, 289f };  
        LeftTreeAngles = new List<float> { 300f, 45f, 300f };

        // Sky 
        RightSkyAngles = new List<float> { 284f, 14f, 13f };
        LeftSkyAngles = new List<float> { 282f, 11f, 9f };

        // Wall 
        RightWallAngles = new List<float> { 9f, 3f, 5f }; 
        LeftWallAngles = new List<float> { 9f, 7f, 1f };

        // Ground 
        RightGroundAngles = new List<float> { 91f, 19f, 353f }; 
        LeftGroundAngles = new List<float> { 98f, 12f, 341f }; 
    }

    //Consistently tests the distance between the two controllers (L & R) with a simple function and if function 
    public void distanceOfControllers()
    {
        distance = Vector3.Distance(controllerR.transform.position, controllerL.transform.position);

        disAreaOne = (distance <= 0.25);

        if (distance > .25 && distance < 1.2)
        {
            disAreaTwo = true;
            scroll.moveOn = true;
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
    public bool IsAngleInRange(List<float> handAngles, List<float> desiredAngles, List<bool> ifWithinAngle) // One of the most fucking important (and beautiful) functions of this mechanic 
    {
        bool isInRange = false;

        for (int angle = 0; angle < desiredAngles.Count; angle++)
        {
            float min = StableAngle(desiredAngles[angle] - 20f);
            float max = StableAngle(desiredAngles[angle] + 20f);

            if (min < max)
                ifWithinAngle[angle] = handAngles[angle] >= min && handAngles[angle] <= max;


            else // Automatically wraps around 
                ifWithinAngle[angle] = handAngles[angle] >= min || handAngles[angle] <= max;
        }

        float howManyTrue = 0f;

        foreach (bool truths in ifWithinAngle)
        {
            isInRange = false;

            if (truths == true)
            {
                howManyTrue += 1f;
            }

            if (howManyTrue == ifWithinAngle.Count)
            {
                isInRange = true;
                break;
            }
        }

        return isInRange; 
    }


    public void Angles()
    {
        Quaternion RightRotation = controllerR.transform.localRotation;
        Quaternion LeftRotation = controllerL.transform.localRotation; 

        RightRotation.ToAngleAxis(out float RightAngle, out Vector3 RightAxis);
        LeftRotation.ToAngleAxis(out float LeftAngle, out Vector3 LeftAxis);

        Vector3 RightHandNormalizedAngle = RightAngle * RightAxis;
        Vector3 LeftHandNormalizedAngle = LeftAngle * LeftAxis;

        RightHandSealAngles = new List<float> { StableAngle(RightHandNormalizedAngle.x), StableAngle(RightHandNormalizedAngle.y), StableAngle(RightHandNormalizedAngle.z) };
        LeftHandSealAngles = new List<float> { StableAngle(LeftHandNormalizedAngle.x), StableAngle(LeftHandNormalizedAngle.y), StableAngle(LeftHandNormalizedAngle.z) };

        Right_x_axis.text = "Right X Axis: " + RightHandSealAngles[0];
        Right_y_axis.text = "Right Y Axis: " + RightHandSealAngles[1];
        Right_z_axis.text = "Right Z Axis: " + RightHandSealAngles[2];

        Left_x_axis.text = "Left X Axis: " + LeftHandSealAngles[0];
        Left_y_axis.text = "Left Y Axis: " + LeftHandSealAngles[1];
        Left_z_axis.text = "Left Z Axis: " + LeftHandSealAngles[2];

        RightTree = IsAngleInRange(RightHandSealAngles, RightTreeAngles, RightHandSealBool);
        LeftTree = IsAngleInRange(LeftHandSealAngles, LeftTreeAngles, LeftHandSealBool); 

        RightSky = IsAngleInRange(RightHandSealAngles, RightSkyAngles, RightHandSealBool); 
        LeftSky = IsAngleInRange(LeftHandSealAngles, LeftSkyAngles, LeftHandSealBool); 

        RightWall = IsAngleInRange(RightHandSealAngles, RightWallAngles, RightHandSealBool); 
        LeftWall = IsAngleInRange(LeftHandSealAngles, LeftWallAngles, LeftHandSealBool); 

        RightGround = IsAngleInRange(RightHandSealAngles, RightGroundAngles, RightHandSealBool); 
        LeftGround = IsAngleInRange(LeftHandSealAngles, LeftGroundAngles, LeftHandSealBool); 
    }

    public bool DetectHandSeals(List<bool> handSeal)
    {
        float howManyTrue = 0f;
        bool handSealActive = false; 

        foreach (bool truths in handSeal)
        {
            handSealActive = false;

            if (truths == true)
            {
                howManyTrue += 1f;
            }

            if (howManyTrue == handSeal.Count)
            {
                handSealActive = true;
                break;
            }
        }

        return handSealActive;
    }

    //Senses the angle of the controllers, and if they are both in between the right values, then it produces an output 
    public void angleOfControllers()
    {
                                        // Right Hand Controller 
        // Buttons  
        inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out RightPrimaryPressed); 
        inputData.rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out RightSecondaryPressed);
        inputData.rightController.TryGetFeatureValue(CommonUsages.triggerButton, out RightTriggerPressed);
        inputData.rightController.TryGetFeatureValue(CommonUsages.gripButton, out RightGripPressed);
        inputData.rightController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out RightAxisPressed);

        // Touch 
        inputData.rightController.TryGetFeatureValue(CommonUsages.primaryTouch, out RightPrimaryTouched); 
        inputData.rightController.TryGetFeatureValue(CommonUsages.secondaryTouch, out RightSecondaryTouched);
        RightTriggerTouched = inputData.rightController.TryGetFeatureValue(CommonUsages.trigger, out var RightTriggerTouchedValue) && (RightTriggerTouchedValue > 0f && RightTriggerTouchedValue < 1f); // no triggerTouched there seems to be, translate float to bool I will  
        inputData.rightController.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out RightAxisTouched);
        RightGripTouched = inputData.rightController.TryGetFeatureValue(CommonUsages.grip, out var RightGripTouchedValue) && (RightGripTouchedValue > 0f && RightGripTouchedValue < 1f); 


                                        // Left Hand Controller 
        // Buttons 
        inputData.leftController.TryGetFeatureValue(CommonUsages.primaryButton, out LeftPrimaryPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out LeftSecondaryPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.triggerButton, out LeftTriggerPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.gripButton, out LeftGripPressed);
        inputData.leftController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out LeftAxisPressed);

        // Touch 
        inputData.leftController.TryGetFeatureValue(CommonUsages.primaryTouch, out LeftPrimaryTouched);
        inputData.leftController.TryGetFeatureValue(CommonUsages.secondaryTouch, out LeftSecondaryTouched);
        LeftTriggerTouched = inputData.leftController.TryGetFeatureValue(CommonUsages.trigger, out var LeftTriggerTouchedValue) && (LeftTriggerTouchedValue > 0f && LeftTriggerTouchedValue < 1f); // triggerTouched there seems to be not, translate float to bool I will  
        inputData.leftController.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out LeftAxisTouched);
        LeftGripTouched = inputData.leftController.TryGetFeatureValue(CommonUsages.grip, out var LeftGripTouchedValue) && (LeftGripTouchedValue > 0f && LeftGripTouchedValue < 1f); 

        // Keep it simple. Was thinking about making the Jutsu Hand Seals into 12 different lists, but I'll have more code and potentially more problems if I didn't go with if statements 
        rightTreeText.text = "Right Grip: "  + RightPrimaryTouched;
        leftTreeText.text = "Left Grip: " + LeftPrimaryTouched; 
        rightAxisTouchText.text = "Scroll Astra: " + scroll.moveOn; 
        leftAxisTouchText.text = "Left Axis Touched?: " + LeftAxisTouched;

        MonkeyComponents = new List<bool> { RightTree, LeftTree, RightAxisTouched, LeftAxisTouched, disAreaOne, scroll.moveOn }; 
        BirdComponents = new List<bool> { RightSky, LeftSky, RightGripPressed, RightPrimaryTouched, RightSecondaryTouched, LeftGripPressed, LeftPrimaryTouched, LeftSecondaryTouched, disAreaOne, scroll.moveOn }; 
        RamComponents = new List<bool> { RightSky, LeftSky, RightGripPressed, LeftGripTouched, disAreaOne, scroll.moveOn }; 
        SerpantComponents = new List<bool> { RightSky, LeftSky, RightGripPressed, RightTriggerPressed, LeftGripPressed, LeftTriggerPressed, disAreaOne, scroll.moveOn }; 
        TigerComponents = new List<bool> { RightSky, LeftSky, RightGripPressed, RightAxisTouched, LeftGripPressed, LeftAxisTouched, disAreaOne, scroll.moveOn }; 
        RatComponents = new List<bool> { RightWall, LeftTree, RightGripPressed, RightTriggerPressed, LeftGripPressed, disAreaOne, scroll.moveOn };
        BoarComponents = new List<bool> { RightGround, LeftGround, RightGripPressed, RightTriggerPressed, LeftGripPressed, LeftTriggerPressed, disAreaOne, scroll.moveOn }; 
        DragonComponents = new List<bool> { RightWall, LeftWall, RightGripPressed, RightTriggerPressed, LeftGripPressed, LeftTriggerPressed, disAreaOne, scroll.moveOn }; 
        HorseComponents = new List<bool> { RightWall, LeftWall, RightGripPressed, RightAxisTouched, LeftGripPressed, LeftAxisTouched, disAreaOne, scroll.moveOn }; 
        OxComponents = new List<bool> { RightWall, LeftSky, LeftGripPressed, disAreaOne, scroll.moveOn }; 
        HareComponents = new List<bool> { RightTree, LeftWall, RightGripPressed, LeftGripPressed, disAreaOne, scroll.moveOn }; 
        DogComponents = new List<bool> { RightTree, LeftTree, RightGripPressed, RightTriggerPressed, RightAxisTouched, LeftAxisTouched, disAreaOne, scroll.moveOn }; 

        HandSeals = new List<bool> { DetectHandSeals(MonkeyComponents), DetectHandSeals(BirdComponents), DetectHandSeals(RamComponents), DetectHandSeals(SerpantComponents), DetectHandSeals(TigerComponents), DetectHandSeals(RatComponents), DetectHandSeals(BoarComponents), DetectHandSeals(DragonComponents), DetectHandSeals(HorseComponents), DetectHandSeals(OxComponents), DetectHandSeals(HareComponents), DetectHandSeals(DogComponents) };

        for (int handSeals = 0; handSeals < HandSeals.Count; handSeals++)
        {
            if (HandSeals[handSeals])
            {
                switch (handSeals)
                {
                    case 0:
                        print("Monkey Case");
                        animations.monkey = HandSeals[handSeals];
                        scroll.astra += "Monkey";
                        soundEffect.playHandSealSound(); 
                        break;

                    case 1:
                        print("Bird Case");
                        break;

                    case 2:
                        print("Ram Case");
                        break;

                    case 3:
                        print("Serpant Case");
                        break;

                    case 4:
                        print("Tiger Case");
                        break;

                    case 5:
                        print("Rat Case");
                        break;

                    case 6:
                        print("Boar Case");
                        break;

                    case 7:
                        print("Dragon Case");
                        break;

                    case 8:
                        print("Horse Case");
                        break;

                    case 9:
                        print("Ox Case");
                        break;

                    case 10:
                        print("Hare Case");
                        break;

                    case 11:
                        print("Dog Case");
                        break; 
                }
            } 
        }
    }

    public void Update()
    {
        Angles(); 
        angleOfControllers(); 
        distanceOfControllers(); 
    }
}