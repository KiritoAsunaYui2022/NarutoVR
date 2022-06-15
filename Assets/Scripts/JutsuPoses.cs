using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JutsuPoses : MonoBehaviour
{

    public Transform customPos;
    public OvrAvatar avatar; 

    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<OvrAvatar>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.01f || Input.GetKey("h"))
        {
            avatar.RightHandCustomPose = customPos; 
            
        } 

        else
        {
            avatar.RightHandCustomPose = null; 
        }
    }
}
