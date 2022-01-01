using UnityEngine;

namespace SemihCelek.Sprinter.Input
{
    public class InputController : MonoBehaviour, IInputController
    {
        public float HorizontalInput { get; private set; }
        public float VerticalInput { get; private set; }

       private void Update()
        {
            HorizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            VerticalInput = UnityEngine.Input.GetAxis("Vertical");
        }
    }
}