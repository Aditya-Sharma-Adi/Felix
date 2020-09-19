using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class touchCam : MonoBehaviour
{
    public bool touchActive; //for touchPad
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;
    

    void Start()
    {
        xAngle = 0;
        yAngle = 0;
        this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);
    }

    public void pointerUP()
    {
        touchActive = false; // when we not touch the touchPad
    }

    public void pointerDown()
    {
        touchActive = true; // when we touch the touchPad
    }

   

    void Update()
    {

        if (Input.touchCount > 0 && touchActive == true)
        {

                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    FirstPoint = Input.GetTouch(0).position;
                    xAngleTemp = xAngle;
                    yAngleTemp = yAngle;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                   SecondPoint = Input.GetTouch(0).position;
                   xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                   yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
                   yAngle = Mathf.Clamp(yAngle, -45, 45); //Restrict camera movement in vertical direction
                  this.transform.rotation = Quaternion.Euler(-yAngle, xAngle, 0.0f);
                   
                }
         
        }
   
    }
}
 
