using UnityEngine;
using TMPro;

public class FingerMovementTransfer_Right : MonoBehaviour
{
    //[Header("TRACKED JOINTS")]
    public Transform[] trackedThumbJoints, trackedIndexJoints, trackedMiddleJoints, trackedRingJoints, trackedPinkyJoints;

    //[Header("ACTUAL FINGER JOINTS")]
    public Transform[] thumbJoints, indexJoints, middleJoints, ringJoints, pinkyJoints;

    public Vector3 thumbRotationOffset, indexRotationOffset, middleRotationOffset, ringRotationOffset, pinkyRotationOffset;

    //public TextMeshProUGUI targetRot, objRot;

    private int i, j, k, l, m;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (i = 0; i < 3; i++)
        {
            Vector3 newRotation = new Vector3(trackedThumbJoints[i].eulerAngles.x, trackedThumbJoints[i].eulerAngles.y, trackedThumbJoints[i].eulerAngles.z);
            newRotation += thumbRotationOffset;
            thumbJoints[i].transform.eulerAngles = newRotation;
        }

        for (j = 0; j < 3; j++)
        {
            Vector3 newRotation = new Vector3(trackedIndexJoints[j].eulerAngles.x, trackedIndexJoints[j].eulerAngles.y, trackedIndexJoints[j].eulerAngles.z);
            newRotation += indexRotationOffset;
            indexJoints[j].transform.eulerAngles = newRotation;
        }

        for (k = 0; k < 3; k++)
        {
            Vector3 newRotation = new Vector3(trackedMiddleJoints[k].eulerAngles.x, trackedMiddleJoints[k].eulerAngles.y, trackedMiddleJoints[k].eulerAngles.z);
            newRotation += middleRotationOffset;
            middleJoints[k].transform.eulerAngles = newRotation;
        }

        for (l = 0; l < 3; l++)
        {
            Vector3 newRotation = new Vector3(trackedRingJoints[l].eulerAngles.x, trackedRingJoints[l].eulerAngles.y, trackedRingJoints[l].eulerAngles.z);
            newRotation += ringRotationOffset;
            ringJoints[l].transform.eulerAngles = newRotation;
        }

        for (m = 0; m < 3; m++)
        {
            Vector3 newRotation = new Vector3(trackedPinkyJoints[m].eulerAngles.x, trackedPinkyJoints[m].eulerAngles.y, trackedPinkyJoints[m].eulerAngles.z);
            newRotation += pinkyRotationOffset;
            pinkyJoints[m].transform.eulerAngles = newRotation;
        }

        

        i = 0;
        j = 0;
        k = 0;
        l = 0;
        m = 0;
    }
}
