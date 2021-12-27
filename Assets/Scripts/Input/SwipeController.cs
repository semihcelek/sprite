using UnityEngine;

namespace SemihCelek.Sprinter.Input
{
    public class SwipeInputController : MonoBehaviour, IInputController
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public bool tap { get; private set; } = false;


        private Vector2 _startTouchPosition;
        private Vector2 _currentPosition;
        private Vector2 _endTouchPosition;
        private bool _stopTouch = false;

        public float swipeRange=50;
        public float tapRange=10;

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
            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _startTouchPosition = UnityEngine.Input.GetTouch(0).position;
            }

            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _currentPosition = UnityEngine.Input.GetTouch(0).position;
                Vector2 Distance = _currentPosition - _startTouchPosition;

                if (!_stopTouch)
                {

                    if (Distance.x < -swipeRange)
                    {
                        Horizontal = -1;
                        _stopTouch = true;
                    }
                    else if (Distance.x > swipeRange)
                    {
                        Horizontal = 1;
                        _stopTouch = true;
                    }
                    else if (Distance.y > swipeRange)
                    {
                        Vertical = 1;
                        _stopTouch = true;
                    }
                    else if (Distance.y < -swipeRange)
                    {
                        Vertical = -1;
                        _stopTouch = true;
                    }

                }

            }

            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _stopTouch = false;
                Horizontal = 0;
                Vertical = 0;
                //InputVector = new Vector2(0, 0);

                _endTouchPosition = UnityEngine.Input.GetTouch(0).position;

                Vector2 Distance = _endTouchPosition - _startTouchPosition;

                if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
                {
                    tap = true;
                }

            }
        }

        public void slowSwipe()
        {
            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _startTouchPosition = UnityEngine.Input.GetTouch(0).position;

            }

            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _endTouchPosition = UnityEngine.Input.GetTouch(0).position;


                Vector2 Distance = _endTouchPosition - _startTouchPosition;


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
}
