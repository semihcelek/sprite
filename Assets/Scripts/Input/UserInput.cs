using UnityEngine;

namespace Sprinter.Input
{
    public class UserInput : MonoBehaviour, IInput
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
