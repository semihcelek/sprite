using System;
using UnityEngine;

namespace Player
{
    public class SwipteTest : MonoBehaviour, IInput
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private Vector2 _currentScreenRes;
        private Vector2 _deltaPositionDividedByScreenRes;
        private Vector2 _startPosition;
        private Vector2 _currentPosition;
        // private Vector2 _endTouchPosition;
        // public float swipeRange=0.5;


        private void Awake()
        {
            _currentScreenRes = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
            Debug.Log(_currentScreenRes);
        }

        private void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Began)
            {
                _startPosition = Input.GetTouch(0).position;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _currentPosition = Input.GetTouch(0).position;
                _deltaPositionDividedByScreenRes = (_currentPosition - _startPosition )/ _currentScreenRes*20 ;
                // Horizontal = _deltaPositionDividedByScreenRes.x;
                // Vertical = _deltaPositionDividedByScreenRes.y;


                // _currentPosition = Input.GetTouch(0).position;
                // Debug.Log("delta position is "+ Input.GetTouch(0).deltaPosition);
                // Debug.Log("subtracted position is "+(_currentPosition-_startPosition));
                // _deltaPositionDividedByScreenRes = Input.GetTouch(0).deltaPosition / _currentScreenRes * 50;
                // Debug.Log(_deltaPositionDividedByScreenRes);
                Horizontal = Mathf.Clamp(_deltaPositionDividedByScreenRes.x,-1,1);
                Vertical = Mathf.Clamp( _deltaPositionDividedByScreenRes.y,-1,1);
                // Debug.Log(Horizontal);
            }
            
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Horizontal = 0;
                Vertical = 0;
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                // Horizontal = Mathf.Clamp(_deltaPositionDividedByScreenRes.x,-2,2);
                // Vertical = Mathf.Clamp( _deltaPositionDividedByScreenRes.y,-2,2);
                Horizontal = Mathf.Clamp(_deltaPositionDividedByScreenRes.x,-1,1);
                Vertical = Mathf.Clamp( _deltaPositionDividedByScreenRes.y,-1,1);
            }


        }
    }
}