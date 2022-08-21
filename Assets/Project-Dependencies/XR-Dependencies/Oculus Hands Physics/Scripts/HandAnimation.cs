using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimation : MonoBehaviour
{
    public Animator leftHandAnimator, rightHandAnimator;

    public ActionBasedController leftController, rightController;

    float leftGripVal, rightGripVal;
    float leftTriggerVal, rightTriggerVal;

    void Start()
    {
        leftController.selectAction.action.performed += LeftSelectActionPerformed;
        rightController.selectAction.action.performed += RightSelectActionPerformed;
        
        leftController.activateAction.action.performed += LeftActivateActionPerformed;
        rightController.activateAction.action.performed += RightActivateActionPerformed;



        leftController.selectAction.action.canceled += LeftSelectActionCanceled;
        rightController.selectAction.action.canceled += RightSelectActionCanceled;

        leftController.activateAction.action.canceled += LeftActivateActionCanceled;
        rightController.activateAction.action.canceled += RightActivateActionCanceled;
    }

    private void LeftSelectActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        leftGripVal = obj.action.ReadValue<float>();
    }
    
    private void RightSelectActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rightGripVal = obj.action.ReadValue<float>();
    }

    private void LeftActivateActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        leftTriggerVal = obj.action.ReadValue<float>();
    }

    private void RightActivateActionPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rightTriggerVal = obj.action.ReadValue<float>();
    }



    private void LeftSelectActionCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        leftGripVal = 0f;
    }

    private void RightSelectActionCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rightGripVal = 0f;
    }
    private void LeftActivateActionCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        leftTriggerVal = 0f;
    }

    private void RightActivateActionCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        rightTriggerVal = 0f;
    }



    void Update()
    {
        AnimateHands();
    }

    private void AnimateHands()
    {
        if (leftTriggerVal > 0)
        {
            leftHandAnimator.SetFloat("Trigger", leftTriggerVal);
        }
        else
        {
            leftHandAnimator.SetFloat("Trigger", 0f);
        }

        if (rightTriggerVal > 0)
        {
            rightHandAnimator.SetFloat("Trigger", rightTriggerVal);
        }
        else
        {
            rightHandAnimator.SetFloat("Trigger", 0f);
        }
        

        if (leftGripVal > 0f)
        {
            leftHandAnimator.SetFloat("Grip", leftGripVal);
        }
        else
        {
            leftHandAnimator.SetFloat("Grip", 0f);
        }

        if (rightGripVal > 0f)
        {
            rightHandAnimator.SetFloat("Grip", rightGripVal);
        }
        else
        {
            rightHandAnimator.SetFloat("Grip", 0f);
        }
    }
    
    void OnDestroy()
    {
        leftController.selectAction.action.performed -= LeftSelectActionPerformed;
        rightController.selectAction.action.performed -= RightSelectActionPerformed;

        leftController.activateAction.action.performed -= LeftActivateActionPerformed;
        rightController.activateAction.action.performed -= RightActivateActionPerformed;
    }
}

