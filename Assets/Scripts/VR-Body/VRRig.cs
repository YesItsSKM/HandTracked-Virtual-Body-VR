using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class VRMap
{
    public Transform vrTarget, rigTarget;

    public Vector3 trackingPositionOffset, trackingRotationOffset;

    public void MapHand()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);

        
    }

    public void MapHead()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}


public class VRRig : MonoBehaviour
{
    public VRMap leftArm, rightArm, head;

    public Transform headConstraint, vrBody;
    Vector3 headBodyOffset;

    public float turnSmoothness;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = vrBody.transform.position - headConstraint.position;

        //head.rigTargetNextBone = null;
    }

    // Update is called once per frame
    void Update()
    {
        leftArm.MapHand();
        rightArm.MapHand();
    }

    void LateUpdate()
    {
        vrBody.transform.position = headConstraint.position + headBodyOffset;
        vrBody.transform.forward = Vector3.Lerp(vrBody.transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        head.MapHead();
    }
}
