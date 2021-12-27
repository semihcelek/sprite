using System;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

namespace SemihCelek.Sprinter.Input
{
    public class SwipeTest : MonoBehaviour
    {
        [SerializeField] 
        private float _leftBoundryOnXAxis, _rightBoundryOnXAxis;
        private Transform _cachedTransform;
        private TransformGesture _gesture;
        private TransformGesture.TransformType _transformMask;
        private Vector3 _targetPosition;
        
        private Vector3 _lastPosition, _lastScale;
        
        private void Awake()
        {
             _cachedTransform = transform;
        }
        
        private void OnEnable()
        {
            _gesture = GetComponent<TransformGesture>();
            _gesture.StateChanged += GestureStateChangeHandler;
        }

        private void OnDestroy()
        {
            _gesture.StateChanged += GestureStateChangeHandler;
        }

        private void ManualUpdate()
        {
            var mask = _gesture.TransformMask;
            if ((mask & TransformGesture.TransformType.Translation) != 0) _targetPosition += _gesture.DeltaPosition;
            _transformMask |= mask;
            
            _gesture.OverrideTargetPosition(_targetPosition);

            ApplyValues();
        }

        private void ApplyValues()
        {
            if ((_transformMask & TransformGesture.TransformType.Translation) != 0)
            {
                Vector3 tp = _cachedTransform.position;
                tp.x = Math.Clamp(_targetPosition.x,_leftBoundryOnXAxis,_rightBoundryOnXAxis) ;
            }

            _transformMask = TransformGesture.TransformType.None;
        }
        private float ReturnPositionFromSwipe()
        {
            if ((_transformMask & TransformGesture.TransformType.Translation) != 0)
            {
                return _targetPosition.x;
            }

            return 0;
        }

        private void GestureStateChangeHandler(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
        {
            switch (gestureStateChangeEventArgs.State)
            {
                case Gesture.GestureState.Changed:
                    ManualUpdate();
                    break;
                case Gesture.GestureState.Idle:
                    break;
            }
        }
    }
}