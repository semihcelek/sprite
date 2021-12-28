using UnityEngine;

namespace SemihCelek.Sprinter.Utils
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private float smoothTime = 0.5f;

        private Transform _target;
        private Vector3 _offset;

        private Vector3 _cameraVelocity = Vector3.zero;

        void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            _offset = transform.position - _target.position;
        }

        void LateUpdate()
        {
            Vector3 newPosition = new Vector3(_offset.x + _target.position.x, _offset.y + _target.position.y,
                _offset.z + _target.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref _cameraVelocity, smoothTime);
        }
    }
}