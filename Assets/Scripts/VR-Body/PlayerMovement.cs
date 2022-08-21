using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public OVRPlayerController playerController;
    private bool gestureAlreadyDeployed_moveForward, gestureAlreadyDeployed_moveBackward, gestureAlreadyDeployed_rotateRight, gestureAlreadyDeployed_rotateLeft;

    //public TextMeshProUGUI debugText;

    
    
    // Start is called before the first frame update
    void Start()
    {
        gestureAlreadyDeployed_moveForward = 
        gestureAlreadyDeployed_moveBackward = 
        gestureAlreadyDeployed_rotateRight = 
        gestureAlreadyDeployed_rotateLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*
        LOCOMOTION
     */

    // Move Forward
    public void MoveForwardSelected()
    {
        if (!gestureAlreadyDeployed_moveForward)
        {
            gestureAlreadyDeployed_moveForward = true;

            SetHandPoseMoveForward(true);

            playerController.HmdRotatesY = true;
        }
    }

    public void MoveForwardUnselected()
    {
        gestureAlreadyDeployed_moveForward = false;

        SetHandPoseMoveForward(false);

        playerController.HmdRotatesY = false;

        ResetRotationAfterMovement();
    }

    // Move Backward
    public void MoveBackwardSelected()
    {
        if (!gestureAlreadyDeployed_moveBackward)
        {
            gestureAlreadyDeployed_moveBackward = true;

            SetHandPoseMoveBackward(true);

            playerController.HmdRotatesY = true;
        }
    }

    public void MoveBackwardUnselected()
    {
        gestureAlreadyDeployed_moveBackward = false;

        SetHandPoseMoveBackward(false);

        playerController.HmdRotatesY = false;

        ResetRotationAfterMovement();
    }


    // Rotate Right
    public void RotateRightSelected()
    {
        if (!gestureAlreadyDeployed_rotateRight)
        {
            gestureAlreadyDeployed_rotateRight = true;

            SetHandPoseRotateRight(true);
        }
    }

    public void RotateRightUnselected()
    {
        SetHandPoseRotateRight(false);

        gestureAlreadyDeployed_rotateRight = false;

        ResetRotationAfterMovement();
    }

    // Rotate Left
    public void RotateLeftSelected()
    {
        if (!gestureAlreadyDeployed_rotateLeft)
        {
            gestureAlreadyDeployed_rotateLeft = true;

            SetHandPoseRotateLeft(true);
        }
    }

    public void RotateLeftUnselected()
    {
        SetHandPoseRotateLeft(false);

        gestureAlreadyDeployed_rotateLeft = false;

        ResetRotationAfterMovement();
    }


    // STATE MANAGERS
    public void SetHandPoseMoveForward(bool state)
    {
        playerController.HandPoseMoveForward = state;
    }
    public void SetHandPoseMoveBackward(bool state)
    {
        playerController.HandPoseMoveBackward = state;
    }
    public void SetHandPoseRotateRight(bool state)
    {
        playerController.HandPoseRotateRight = state;
    }
    public void SetHandPoseRotateLeft(bool state)
    {
        playerController.HandPoseRotateLeft = state;
    }

    private void ResetRotationAfterMovement()
    {
        Transform root = playerController.CameraRig.trackingSpace;
        Transform centerEye = playerController.CameraRig.centerEyeAnchor;

        Vector3 prevPos = root.position;
        Quaternion prevRot = root.rotation;

        transform.rotation = Quaternion.Euler(0.0f, centerEye.rotation.eulerAngles.y, 0.0f);

        root.position = prevPos;
        root.rotation = prevRot;
    }
}
