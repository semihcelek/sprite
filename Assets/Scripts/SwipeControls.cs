using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    //public float HorizontalInput;
    //public float VerticalInput;
    public bool tap =false;
    public Vector2 InputVector= new Vector2(0, 0);

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange=50;
    public float tapRange=10;


    //////////////
    private bool enableSlowSwipe = false;


    void Update()
    {

        if (!enableSlowSwipe)
        {
            fastSwipe();
        }
        else
        {
            slowSwipe();
        }


    }

    public void fastSwipe()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;
            //Debug.Log("Distance is"+ Distance);
            if (!stopTouch)
            {

                if (Distance.x < -swipeRange)
                {
                    //HorizontalInput = -1;
                    InputVector=new Vector2(-1, 0);
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    //HorizontalInput = 1;
                    InputVector = new Vector2(1, 0);
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    //VerticalInput = 1;
                    InputVector = new Vector2(0, -1);
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    //VerticalInput = -1;
                    InputVector = new Vector2(0, 1);
                    stopTouch = true;
                }

            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            //HorizontalInput = 0;
            //VerticalInput = 0;
            InputVector = new Vector2(0, 0);

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                tap = true;
            }

        }
    }

    public void slowSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;


            Vector2 Distance = endTouchPosition - startTouchPosition;


            if (Distance.x < -swipeRange)
            {
                //HorizontalInput = -1;
            }
            else if (Distance.x > swipeRange)
            {
                //HorizontalInput = 1;
            }
            else if (Distance.y > swipeRange)
            {
                //VerticalInput = 1;
            }
            else if (Distance.y < -swipeRange)
            {
                //VerticalInput = -1; 
            }

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                tap = true;
            }


        }

    }

    public void changeMode()
    {
        if (!enableSlowSwipe)
        {
            enableSlowSwipe = true;
        }
        else
        {
            enableSlowSwipe = false;
        }

    }

}
