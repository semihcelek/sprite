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
        
        [SerializeField]
        private float _swipeRange = 50f;


        private void Update()
        {
            TouchStart();

            DetectSwipeTouch();

            EndTouch();
        }

        private void EndTouch()
        {
            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                _stopTouch = false;
                HorizontalInput = 0;
                VerticalInput = 0;

                _endTouchPosition = UnityEngine.Input.GetTouch(0).position;
            }
        }

        private void DetectSwipeTouch()
        {
            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                _currentPosition = UnityEngine.Input.GetTouch(0).position;
                var distance = _currentPosition - _startTouchPosition;

                if (!_stopTouch)
                {
                    if (distance.x < -_swipeRange)
                    {
                        HorizontalInput = -1f;
                        _stopTouch = true;
                    }
                    else if (distance.x > _swipeRange)
                    {
                        HorizontalInput = 1f;
                        _stopTouch = true;
                    }
                    else if (distance.y > _swipeRange)
                    {
                        VerticalInput = 1f;
                        _stopTouch = true;
                    }
                    else if (distance.y < -_swipeRange)
                    {
                        VerticalInput = -1f;
                        _stopTouch = true;
                    }
                }
            }
        }

        private void TouchStart()
        {
            if (UnityEngine.Input.touchCount > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _startTouchPosition = UnityEngine.Input.GetTouch(0).position;
            }
        }
    }
}