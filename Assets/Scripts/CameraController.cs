using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float XSens = 1, YSens = 1, Sens = 1;
    public float XOffset = 0, YOffSet = 0, ZOffset = 0;
    public GameObject FollowingObject;

    private void Awake()
    {

    }
    private void Update()
    {
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");

		if(x>0)
		{

		}
		if(x<0)
		{

		}
		if(y>0)
		{

		}
		if(y<0)
		{

		}
        transform.parent.Rotate(0f, 0f, y * YSens * Sens, Space.Self);
        transform.parent.Rotate(0f, x * XSens * Sens, 0f, Space.World);
		
		transform.localPosition = new Vector3(XOffset, YOffSet, ZOffset);

        transform.parent.position = FollowingObject.transform.position;
    }
}
