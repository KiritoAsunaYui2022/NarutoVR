using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

[RequireComponent(typeof(InputData))]
public class DisplayInputData : MonoBehaviour
{
    //public TextMeshProUGUI leftScoreDisplay;
    //public TextMeshProUGUI rightScoreDisplay;

    private InputData inputData;
    private float _leftMaxScore = 0f;
    private float _rightMaxScore = 0f;

    //Right Hand Controller 
    public bool
        RightPrimaryPressed, // B 
        RightSecondaryPressed, // A 
        RightTriggerPressed,
        RightGripPressed,
        RightAxisPressed,

        RightPrimaryTouch,
        RightSecondaryTouch,
        RightTriggerTouch,
        RightAxisTouch;

    //public float
    //    triggerTouch; 

    private void Start()
    {
        inputData = GetComponent<InputData>();
    }
    // Update is called once per frame

    public void Index()
    {   
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
        RightTriggerTouch = inputData.rightController.TryGetFeatureValue(CommonUsages.trigger, out var triggerTouch) && triggerTouch > 0; // triggerTouch there seems to be not, translate float to bool I will  
        inputData.rightController.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out RightAxisTouch);

        // Don't need this as the gameobject attached to the hand's local variable will be tracked instead 
        //// Locations and Positions 
        //inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out RightPrimaryPressed);
        //inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out RightPrimaryPressed); 
    }
    void Update()
    {
        Index(); 
        if (inputData.leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        {
            _leftMaxScore = Mathf.Max(leftVelocity.magnitude, _leftMaxScore);
            //leftScoreDisplay.text = _leftMaxScore.ToString("F2");
        }
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        {
            _rightMaxScore = Mathf.Max(rightVelocity.magnitude, _rightMaxScore);
            //rightScoreDisplay.text = _rightMaxScore.ToString("F2");
        }

        

        if(RightPrimaryPressed)
        {
            print("Hello there"); 
        }
    }
}
