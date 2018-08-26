using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody_;
    private float speed_ = 10f;

    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * speed_;
        var vertical = Input.GetAxis("Vertical") * speed_;

        var force = new Vector3(horizontal, 0, vertical);
        rigidbody_.AddForce(force, ForceMode.Acceleration);
    }
}
