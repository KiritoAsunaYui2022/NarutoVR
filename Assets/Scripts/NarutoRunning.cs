

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

//namespace NarutoRunning
//{
    public class NarutoRunning : MonoBehaviour
    {
        public OVRPlayerController ninjaSpeed; //Oculus 
        public AreHandsBehind areHandsBehind; //Mine 

        //public GameObject rightHand;
        //public GameObject 
        public GameObject head;
        private Vector3 headPos;

        //Constant
        public float playerHeightAtStart;

        //Variable 
        public float playerHeight;
        public float modifiedPlayerHeight;


        public void Start()
        {
            //    headPos = head.transform.localPosition;
            //    playerHeight = headPos.y; 

            //    playerHeightAtStart = playerHeight; 
            playerHeightAtStart = 1.75f;
        }


        public void narutoRun()
        {
            if (areHandsBehind.runningStance == true && playerHeight < (playerHeightAtStart - 0.3f))
            {
                //          child                          parent
                areHandsBehind.rightHand.transform.parent = GameObject.Find("RightHandRunPos").transform;
                areHandsBehind.leftHand.transform.parent = GameObject.Find("LeftHandRunPos").transform;
                //ninjaSpeed.MoveScaleMultiplier = 5f;  

            }

            // areHandsBehind.runningStance == false && -- because how are you going to retrieve your hands when they are locked in a position? Might change because of some defects. 
            if (playerHeight > (playerHeightAtStart - 0.3f))
            {
                //          child                          parent
                areHandsBehind.rightHand.transform.parent = GameObject.Find("TrackingSpace").transform;
                areHandsBehind.leftHand.transform.parent = GameObject.Find("TrackingSpace").transform;
                //ninjaSpeed.MoveScaleMultiplier = 1f;


                //I want to have this in here because it might give me a resource to work with. 
                //if (averageControllerDistance > -.5f) 
                //{
                //    ninjaSpeed.MoveScaleMultiplier = 5f;
                //    print("NINJA SPEED"); TEMP COMMENTED 
                //    //slide.maximumSpeed = slide.maximumSpeed * speedMultiplier; 
                //}

                //if (averageControllerDistance < -1f)
                //{
                //    ninjaSpeed.MoveScaleMultiplier = 7f;
                //    slide.maximumSpeed = slide.maximumSpeed * speedMultiplier;
                //}

            }
        }
    


        public void Update()
        {
            narutoRun();
            print("Height At Start: " + playerHeightAtStart);
            //print("Head Height: " + head.transform.localPosition.y); 
            headPos = head.transform.localPosition;
            playerHeight = headPos.y;
            print("Current Head Height: " + playerHeight);
            print("Modified Head Height: " + (playerHeightAtStart - 0.3f));


            //if (playerHeight < (playerHeightAtStart - 0.3f))
            //{
            //    print("Player Height is under Start Constant.");
            //}

            //if (playerHeight > (playerHeightAtStart - 0.3f))
            //{
            //    print("Player Height is over Start Constant.");
            //}
        }
    }
//}
