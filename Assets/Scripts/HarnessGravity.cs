using UnityEngine;
using TMPro;

public class HarnessGravity : MonoBehaviour
{
    //public TextMeshProUGUI debugText;

    Transform obj;
    Rigidbody objRigidBody;

    public float influenceRange;
    public float intensity;
    
    private float distanceToPlayer;
    
    Vector3 pullForce;

    // Start is called before the first frame update
    void Start()
    {
        obj = null;


        //debugText.text = "x";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * influenceRange, Color.green);

        if (Physics.Raycast(transform.position, transform.right, out RaycastHit hit, influenceRange) && hit.transform.tag == "Interactable")
        {
            obj = hit.transform;
            objRigidBody = hit.rigidbody;

            //debugText.text = obj.transform.name;

            if (!objRigidBody.useGravity)
                objRigidBody.useGravity = true;

            distanceToPlayer = Vector3.Distance(obj.position, transform.position);

            if (distanceToPlayer <= influenceRange)
            {
                pullForce = (transform.position - obj.position).normalized / distanceToPlayer * intensity;
                objRigidBody.AddForce(pullForce, ForceMode.Force);
            }
        }
        
        //else
            //debugText.text = "x";
    }
}
