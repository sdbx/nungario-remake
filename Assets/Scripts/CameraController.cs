using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float XSens = 1, YSens = 1, Sens = 1;
    public float XOffset = 0, YOffSet = 0, ZOffset = 0;
    public GameObject FollowingObject;

    public int DistanceLimit = 10;

    private void Awake()
    {

    }
    private void Update()
    {
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");



        
        transform.parent.position = FollowingObject.transform.position;
        
        
    

        transform.localPosition = new Vector3(XOffset, YOffSet, ZOffset);

        transform.parent.Rotate(0f, 0f, y * YSens * Sens, Space.Self);
        transform.parent.Rotate(0f, x * XSens * Sens, 0f, Space.World);


    }

}
