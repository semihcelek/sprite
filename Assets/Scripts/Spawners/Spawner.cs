using UnityEngine;

namespace Sprinter.Spawners
{
    public class Spawner : MonoBehaviour
    {
        private ISpawner _spawner;
        private void Awake()
        {
            _spawner = GetComponent<ISpawner>();
        }
        void Start()
        {

            StartCoroutine(_spawner.Spawn());
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
    
    }
}
