using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool Tap { get; private set; }

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange = 100;
    public float tapRange = 10;



    private Touch touch;
    [SerializeField] private float speedModifier=1f;

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        //if(Input.touchCount>0)
        //{
        //    //touch = Input.GetTouch(0);

        //    //if(touch.phase == TouchPhase.Moved)
        //    //{
        //    //    Horizontal = Mathf.Clamp(touch.deltaPosition.x*speedModifier,-1,1);
        //    //    //Vertical = Mathf.Clamp(touch.deltaPosition.y*speedModifier,-1,1);
        //    //    //Debug.Log(touch.deltaPosition.x);
        //    //}
        //}


        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    startTouchPosition = Input.GetTouch(0).position;
        //}

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    currentPosition = Input.GetTouch(0).position;
        //    Vector2 Distance = currentPosition - startTouchPosition;
        //    //Debug.Log("Distance is"+ Distance);


        //    Horizontal = Mathf.Clamp(Input.GetTouch(0).deltaPosition.x * speedModifier, -2, 2);
        //    if (!stopTouch)
        //    {

        //        //if (Distance.x < -swipeRange)
        //        //{ 
        //        //    stopTouch = true;
        //        //}
        //        //else if (Distance.x > swipeRange)
        //        //{
        //        //    stopTouch = true;
        //        //}
        //        if (Distance.y > swipeRange)
        //        {
        //            //VerticalInput = 1;
        //            Vertical = 1;
        //            stopTouch = true;
        //        }
        //        else if (Distance.y < -swipeRange)
        //        {
        //            Vertical = -1;
        //            //VerticalInput = -1;
        //            stopTouch = true;
        //        }

        //    }

        //}
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    stopTouch = false;
        //    //Horizontal = 0;
        //    Vertical = 0;

        //    endTouchPosition = Input.GetTouch(0).position;

        //    Vector2 Distance = endTouchPosition - startTouchPosition;

        //    //if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
        //    //{
        //    //    //tap = true;
        //    //}

        //}
    }
}
