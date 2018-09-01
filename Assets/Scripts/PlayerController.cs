using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject DirectionObject;

    private Rigidbody rigidbody_;
    public float Speed = 10f;

    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");


        var temp = DirectionObject.transform.rotation.y;

        var dirForward = DirectionObject.transform.forward;
        dirForward = new Vector3(dirForward.x,0f,dirForward.z);

        var dirRight = DirectionObject.transform.right;
        dirRight = new Vector3(dirRight.x,0f,dirRight.z);
        

        rigidbody_.AddForce(vertical * dirRight * Speed , ForceMode.Acceleration);
        rigidbody_.AddForce(-horizontal * dirForward * Speed , ForceMode.Acceleration);
        
    }
    private void OnDrawGizmos()
    {


        //Gizmos.DrawRay(transform.position,v3Direction);
    }
}
