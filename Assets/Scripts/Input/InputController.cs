using UnityEngine;

namespace SemihCelek.Sprinter.Input
{
    public class InputController : MonoBehaviour, IInputController
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        void Update()
        {
            Horizontal = UnityEngine.Input.GetAxis("Horizontal");
            Vertical = UnityEngine.Input.GetAxis("Vertical");
        }
    }
}