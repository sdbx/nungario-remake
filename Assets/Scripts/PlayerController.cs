using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject DirectionObject;

    private Rigidbody rigidbody_;
    public float Speed = 30f;
    public float jumpSpeed  = 15f;
    private bool isGrounded;
    public bool isOnSnow;

    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");


        var temp = -DirectionObject.transform.rotation.y;

        var dirForward = DirectionObject.transform.forward;
        dirForward = new Vector3(dirForward.x,0f,dirForward.z);

        var dirRight = DirectionObject.transform.right;
        dirRight = new Vector3(dirRight.x,0f,dirRight.z);

        if (isGrounded)
        {
            rigidbody_.AddForce(vertical * dirRight * Speed, ForceMode.Acceleration);
            rigidbody_.AddForce(-horizontal * dirForward * Speed, ForceMode.Acceleration);
        }

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rigidbody_.velocity += jumpSpeed * Vector3.up;
        }

        if (GetComponent<Rigidbody>().velocity.magnitude > 0)
         {
            if (isGrounded&&isOnSnow)
            {
                var scalespeed =Mathf.Abs(GetComponent<Rigidbody>().velocity.z)* 0.0001f;
                transform.localScale += new Vector3(scalespeed,scalespeed,scalespeed);
            }            
         }

    }
    private void FixedUpdate()
    {
        // rigidbody_.AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.collider.name == "snowfloor") isOnSnow = true;
    }
    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        if (collision.collider.name == "snowfloor") isOnSnow = true;
    }
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        isOnSnow = false;
    }
}
