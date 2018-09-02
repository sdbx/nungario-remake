using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float XSens = 1, YSens = 1, Sens = 1;
    public float XOffset = 0, YOffSet = 0, ZOffset = 0;
    public GameObject FollowingObject;
    public int DistanceLimit = 10;
    public Vector3 boxSize = new Vector3(0.3f, 0.3f, 0.3f);
    private bool isChanging=false;
    private float TargetValue;

    void Start()
    {
        //커서 고정 및 숨기기.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");
   
        
        Collider[] arr=Physics.OverlapBox(transform.position, boxSize * 0.5f, transform.rotation);

          if (!isChanging)
          {
            if (arr.Length > 0 && arr[0].name != "Player")
            {
                isChanging = true;
                TargetValue = -1;
            }
            else
            {
                if (FollowingObject.GetComponent<PlayerController>().isOnSnow)
                {
                    isChanging = true;
                    TargetValue = -5;
                }
             }
      
           }

        if (TargetValue == -1)
        {
            XOffset = Mathf.Lerp(XOffset, -1, 0.2f);
        }
        else if (TargetValue == -5)
        {
            XOffset = -Mathf.Lerp(Mathf.Abs(XOffset), 5, 0.2f);
        }

        if (Mathf.Approximately(XOffset ,TargetValue)) isChanging = false;  

            // Debug.Log(FollowingObject.transform.localScale.y);
            transform.parent.position =new Vector3(FollowingObject.transform.position.x
        , FollowingObject.transform.position.y+(FollowingObject.transform.localScale.y - 1)
        , FollowingObject.transform.position.z);
        transform.localPosition = new Vector3(XOffset-(FollowingObject.transform.localScale.y - 1), YOffSet, ZOffset);
        transform.parent.Rotate(0f, x * XSens * Sens, 0f, Space.World);
        transform.parent.Rotate(0f, 0f, y * YSens * Sens, Space.Self);
    }

}
