using UnityEngine;

public class CamCollision : MonoBehaviour {

    private float minDistan = 1.0f;
    private float maxDistan = 4.0f;
    private float smooth = 10.0f;
    Vector3 dollyDir;
    private Vector3 dollyDirAdjusted;
    private float distance;

    void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    void Update()
    {

        Vector3 desiredCampos = transform.parent.TransformPoint(dollyDir * maxDistan);
        RaycastHit hit;

        if(Physics.Linecast(transform.parent.position,desiredCampos,out hit))
        {
            distance = Mathf.Clamp(hit.distance, minDistan, maxDistan);
            Debug.Log("잭스");
            transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        }
        else
        {
            distance = maxDistan;
        }

        //transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}

