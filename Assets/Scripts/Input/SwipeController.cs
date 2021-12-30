using UnityEngine;

namespace SemihCelek.Sprinter.Input
{
    public class SwipeController : MonoBehaviour, IInputController
    {
        public float HorizontalInput { get; private set; }
        public float VerticalInput { get; private set; }


        private Vector2 _startTouchPosition;
        private Vector2 _currentPosition;
        private Vector2 _endTouchPosition;
        private bool _stopTouch = false;

        public float swipeRange = 50;
        public float tapRange = 10;

        void Update()
        {
            Swipe();
        }

        private void Swipe()
        {
            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _startTouchPosition = UnityEngine.Input.GetTouch(0).position;
            }

            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _currentPosition = UnityEngine.Input.GetTouch(0).position;
                var distance = _currentPosition - _startTouchPosition;

                if (!_stopTouch)
                {
                    if (distance.x < -swipeRange)
                    {
                        HorizontalInput = -1;
                        _stopTouch = true;
                    }
                    else if (distance.x > swipeRange)
                    {
                        HorizontalInput = 1;
                        _stopTouch = true;
                    }
                    else if (distance.y > swipeRange)
                    {
                        VerticalInput = 1;
                        _stopTouch = true;
                    }
                    else if (distance.y < -swipeRange)
                    {
                        VerticalInput = -1;
                        _stopTouch = true;
                    }
                }
            }

            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _stopTouch = false;
                HorizontalInput = 0;
                VerticalInput = 0;

                _endTouchPosition = UnityEngine.Input.GetTouch(0).position;
            }
        }
    }
}