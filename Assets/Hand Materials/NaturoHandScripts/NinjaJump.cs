using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaJump : MonoBehaviour
{
    /*Ninja Jumping could be done by testing to see where the controller is relative to the head (maybe a set range like +-0.3f like Naruto Running) 
     while testing to see if Primary/SecondaryHandTrigger are held at that position and within the same test (Possibly) will test to see if the hand positions are above a 
     set position such as +-0.3f all while testing to see if Primary/SecondaryHandTrigger is released. If those conditions are met, then an upward force on the RigidBody
     that is attached to the player is applied that puts them into the air. *If I can, make it so the ninja is up ontop of the parabolla a little longer than normal 
     like in the anime. Also, make it so the ninja disapears at the beginning and towards the end of the parabolla like in the anime (Sometimes).*/


    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject head; 


    public void ninjaJump()
    {
        if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {

        }
    }






}
