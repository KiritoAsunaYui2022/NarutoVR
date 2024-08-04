using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using TMPro;

public class Lab : MonoBehaviour
{
    public Transform rightHand;
    public Transform leftHand;
    public bool useLocalRotation = true; // Toggle to switch between global and local rotations 

    public TextMeshProUGUI Right_x_axis;
    public TextMeshProUGUI Right_y_axis;
    public TextMeshProUGUI Right_z_axis;

    public TextMeshProUGUI x_bool;
    public TextMeshProUGUI y_bool;
    public TextMeshProUGUI z_bool; 

    public TextMeshProUGUI Left_x_axis;
    public TextMeshProUGUI Left_y_axis;
    public TextMeshProUGUI Left_z_axis;

    public TextMeshProUGUI handSealBoolText;

    //public List<float> handSeal = new List<float> { 200f, 90f, 350f }; 
    public List<float> RightTreeAngles = new List<float> { 0f, 0f, 0f };   // This is desire hand seal 
    public List<float> LeftTreeAngles = new List<float> { 0f, 0f, 0f }; 

    public List<float> RightHandSealAngles = new List<float> { 0f, 0f, 0f }; // This is the Angles of the right hand 
    public List<float> LeftHandSealAngles = new List<float> { 0f, 0f, 0f }; // This is the Angles of the left hand 

    List<bool> RightHandSealBool = new List<bool> { false, false, false };                         
    List<bool> LeftHandSealBool = new List<bool> { false, false, false };

    public bool mKey;
    public bool oKey;

    // These two make up monkey
    public bool RightTree;
    public bool LeftTree;

    // Monkey would be made of the angles and hands, but also the button and touch statements 
    public bool Monkey; 


    private void Start()
    {
        RightTreeAngles = new List<float> { 55f, 23f, 23f }; 
        LeftTreeAngles = new List<float> { 55f, 23f, 23f }; 
    }

    void Update()
    {
        Quaternion RightRotation = useLocalRotation ? rightHand.localRotation : rightHand.rotation;
        Quaternion LeftRotation = useLocalRotation ? leftHand.localRotation : leftHand.rotation;
        //Vector3 stableAngles = QuaternionToStableAngles(rotation);
        //Vector3 stableAngles = rotation.ToAngleAxis(out float angle, out Vector3 axis); 
        RightRotation.ToAngleAxis(out float RightAngle, out Vector3 RightAxis);
        LeftRotation.ToAngleAxis(out float LeftAngle, out Vector3 LeftAxis);

        Vector3 RightHandNormalizedAngle = RightAngle * RightAxis;
        Vector3 LeftHandNormalizedAngle = LeftAngle * LeftAxis; 

        RightHandSealAngles = new List<float> {StableAngle(RightHandNormalizedAngle.x), StableAngle(RightHandNormalizedAngle.y), StableAngle(RightHandNormalizedAngle.z)}; 
        LeftHandSealAngles = new List<float> {StableAngle(LeftHandNormalizedAngle.x), StableAngle(LeftHandNormalizedAngle.y), StableAngle(LeftHandNormalizedAngle.z)}; 

        Right_x_axis.text = "Right X Axis: " + RightHandSealAngles[0];
        Right_y_axis.text = "Right Y Axis: " + RightHandSealAngles[1];
        Right_z_axis.text = "Right Z Axis: " + RightHandSealAngles[2]; 

        Left_x_axis.text = "Left X Axis: " + LeftHandSealAngles[0];
        Left_y_axis.text = "Left Y Axis: " + LeftHandSealAngles[1];
        Left_z_axis.text = "Left Z Axis: " + LeftHandSealAngles[2];

        RightTree = IsAngleInRange(RightHandSealAngles, RightTreeAngles, RightHandSealBool); 
        LeftTree = IsAngleInRange(LeftHandSealAngles, LeftTreeAngles, LeftHandSealBool); 
        handSealBoolText.text = "Hand Seal Bool: " + RightTree + LeftTree; 

        x_bool.text = "X Bool: " + RightHandSealBool[0]; 
        y_bool.text = "Y Bool: " + RightHandSealBool[1]; 
        z_bool.text = "Z Bool: " + RightHandSealBool[2];



        mKey = false;
        if (Input.GetKey(KeyCode.M))         
        {
            mKey = true;
            print("M"); 
        }

        oKey = false; 
        if (Input.GetKey(KeyCode.O)) 
        {
            oKey = true;
            print("O"); 
        }

        // Keep it simple. Was thinking about making the Jutsu Hand Seals into 12 different lists, but I'll have more code and potentially more problems if I didn't go with if statements 
        Monkey = false; 
        if (RightTree && LeftTree && mKey && oKey)
            Monkey = true;


        print("HAND SEAL: " + Monkey); 
    }


    
    float StableAngle(float angle)
    {
        if (angle < 0f)
            angle = (angle += 360f) % 360f;

        return angle;
    }

    //Vector3 QuaternionToStableAngles(Quaternion q)
    //{
    //    // Calculate the angle and axis of the quaternion
    //    q.ToAngleAxis(out float angle, out Vector3 axis);

    //    // Convert angle to 0-360 range
    //    if (angle < 0)
    //        angle += 360;

    //    // Multiply the axis by the angle to get the stable angles
    //    Vector3 stableAngles = axis * angle;

    //    // Normalize the angles to 0-360 range
    //    stableAngles.x = (stableAngles.x + 360) % 360;
    //    stableAngles.y = (stableAngles.y + 360) % 360;
    //    stableAngles.z = (stableAngles.z + 360) % 360;

    //    return stableAngles;
    //}




    // Feel like I could write a for loop that has the desired angles stored within it that coordinates with each bool that will constantly run though the list to see if the coordinates match up 
    // localEulerAngles could be x, y, and z while angle could be the list/index 
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
}
