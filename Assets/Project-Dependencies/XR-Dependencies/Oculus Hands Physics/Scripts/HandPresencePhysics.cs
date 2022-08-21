using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.velocity = (target.position - transform.position) / Time.deltaTime;

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rigidbody.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad) / Time.fixedDeltaTime;
    }
}
