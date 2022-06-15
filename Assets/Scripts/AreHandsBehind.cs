using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreHandsBehind : MonoBehaviour
{

    public SightOfHands handsInSight = null;
    public GameObject rightHand;
    public GameObject leftHand;
    public bool runningStance = false; 

    public void handsBehind()
    {
        if (handsInSight == null)
        {
            handsInSight = GameObject.FindObjectOfType<SightOfHands>();

            if (handsInSight == null)
            {
                return;
            }
        }

        bool rightHandBool;
        bool leftHandBool;

        rightHandBool = handsInSight.TestCone(rightHand.transform.position);
        leftHandBool = handsInSight.TestCone(leftHand.transform.position);

        //Basically testing to see if hands are still in front of you. It is suppoose to be the otherway around, but mechanic seems to work better this way. Might try more tests. 
        if (rightHandBool == true && leftHandBool == true)
        {
            print("Hands are front head");
            runningStance = false;   
        }

        else
        {
            print("Hands are in behind of head");
            runningStance = true; 
        }
    }

    public void Update()
    {
        handsBehind();
    }
}

