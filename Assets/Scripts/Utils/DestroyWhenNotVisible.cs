using UnityEngine;

namespace SemihCelek.Sprinter.Utils
{
    public class DestroyWhenNotVisible : MonoBehaviour
    {
        [SerializeField] 
        private float destroyGameObjectDistance=60;
        
        private Transform _playerPosition;

        private void Start()
        {
            _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if(_playerPosition.position.z>gameObject.transform.position.z+destroyGameObjectDistance)
            {
                Destroy(gameObject);
            }
        }
    }
}
