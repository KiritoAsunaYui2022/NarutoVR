using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Temporary 

[RequireComponent(typeof(SightOfHands))]
[RequireComponent(typeof(OVRPlayerController))]
public class NarutoRun : MonoBehaviour
{
    public SightOfHands handsBehind = null;
    private OVRPlayerController controller;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject head;
    public GameObject RightHandRunPos;
    public GameObject LeftHandRunPos; 
    private Vector3 headPos;
    public SoundEffects soundEffect;

    public TextMeshProUGUI height;
    public TextMeshProUGUI handsAre; 

    public bool runningStance = false;

    //Constant
    public float playerHeightAtStart;

    //Variable 
    public float playerHeight;
    public float modifiedPlayerHeight;

    [SerializeField]
    private float moveSpeedMultiplier = 3.0f;

    void Start()
    {
        handsBehind = GetComponent<SightOfHands>();
        playerHeightAtStart = 1f;
        controller = GetComponent<OVRPlayerController>();
        controller.SetMoveScaleMultiplier(moveSpeedMultiplier);
    }
    public void areHandsBehind()
    {
        if (handsBehind == null)
        {
            handsBehind = GameObject.FindObjectOfType<SightOfHands>();

            if (handsBehind == null)
            {
                return;
            }
        }

        bool rightHandBool;
        bool leftHandBool;

        rightHandBool = handsBehind.TestCone(rightHand.transform.position);
        leftHandBool = handsBehind.TestCone(leftHand.transform.position);

        //Basically testing to see if hands are still in front of you. It is suppoose to be the otherway around, but mechanic seems to work better this way. Might try more tests. 
        if (rightHandBool == true && leftHandBool == true)
        {
            runningStance = true;
        }

        else
        {
            runningStance = false;
        }
    }

    //?????????? CONFUSING TIME ??????????? 
    //So the PlayNarutoRunningSound method plays when hands are behind/running is true, but only if it is in the other if statement? 

    //Also within this method I wanted to have the hands transformed and or childed to two positions behind the head which looks like you're Naruto Running. 
    //I vote against this because it would only make sense if I had a full body rig that would show you naruto running, and the Quest will still ruin the illusion 
    //because once the controller irl comes into view, it'll kick you out of running since one of your hands are in front of you. 
    //There is a work around for this by sensing if your height is above a certain level, then it'll kick back into the original position. 
    public void narutoRun()
    {
        //Running 
        if (runningStance && playerHeight < .7f)
        {
            //          child                          parent
            //rightHand.transform.parent = GameObject.Find("RightHandRunPos").transform;
            //leftHand.transform.parent = GameObject.Find("LeftHandRunPos").transform;

            //rightHand.transform.position = RightHandRunPos.transform.position;
            //leftHand.transform.position = LeftHandRunPos.transform.position; 

            handsAre.text = "Running";
            controller.SetMoveScaleMultiplier(moveSpeedMultiplier * 4.0f); 
        }

        //Walking 
        if (!runningStance && playerHeight > .7f)
        {
            //          child                          parent
            //rightHand.transform.parent = GameObject.Find("RightHandAnchor").transform;
            //leftHand.transform.parent = GameObject.Find("LeftHandAnchor").transform;
            //rightHand.transform.parent.rotation = GameObject.Find("RightHandAnchor").transform.rotation;
            //leftHand.transform.parent.rotation = GameObject.Find("LeftHandAnchor").transform.rotation;

            //rightHand.transform.parent = GameObject.Find("TrackingSpace").transform; 
            //leftHand.transform.parent = GameObject.Find("TrackingSpace").transform; 
            
            handsAre.text = "Walking"; 
            controller.SetMoveScaleMultiplier(moveSpeedMultiplier * 1.0f);
            soundEffect.PlayNarutoRunningSound();
        }
    }

    public void Update()
    {
        headPos = head.transform.localPosition;
        playerHeight = headPos.y;
        height.text = "Height: " + playerHeight; 
        areHandsBehind();
        narutoRun(); 
    }
}
