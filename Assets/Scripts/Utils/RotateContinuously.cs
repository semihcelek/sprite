using UnityEngine;

namespace SemihCelek.Sprinter.Utils
{
    public class RotateContinuously : MonoBehaviour
    {
        [SerializeField]
        private float xRotationSpeed = 0f;
        [SerializeField]
        private float yRotationSpeed = 0f;
        [SerializeField]
        private float zRotationSpeed = 0f;

        private Vector3 _rotation;

        void Start()
        {
            _rotation = new Vector3(xRotationSpeed, yRotationSpeed, zRotationSpeed);
        }

        void Update()
        {
            transform.Rotate(_rotation * Time.deltaTime);
        }
    }
}