using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

#if UNITY_ANDROID
    // Update is called once per frame
    new void Update()
    {

        base.Update();

        if(Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {

                Vector3 inputPos = new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, 0);
                if(inputPos.x > Screen.width/2)
                {
                    base.HorizontalMovement(1);
                }
                if (inputPos.x < Screen.width / 2)
                {
                    base.HorizontalMovement(-1);
                }

                if(Input.touchCount > 2)
                {
                    base.Jump();
                }


            }



        }


    }
#endif

}
