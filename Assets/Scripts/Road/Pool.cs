using System;
using System.Collections;
using System.Collections.Generic;
// using Road;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;


public class ReturnToThePool : MonoBehaviour
{
    public ObjectPool<GameObject> _pool;
    private Transform _playerPosition;

    private void Awake()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    private void Update()
    {
        if (_playerPosition.position.z > 60 +gameObject.transform.position.z)
        {
            _pool.Release(gameObject);
        }
    }
}




public class Pool : MonoBehaviour
{
    private Transform _playerPosition;
    public GameObject[] _prefabsToInitializePool;
    [SerializeField] private float _tileLenght=60;
    private float _zOffset;


    // private IPoolGenerator _poolGenerator;
    
    private ObjectPool<GameObject> _pool;
    
    private void Awake()
    {
        // _poolGenerator = GetComponent<IPoolGenerator>();   

        // for(int i=0; i<_prefabsToInitializePool.Length; i++)
        // {
        //     SpawnTile(0); 
        // }
    }

    private void Start()
    {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        _zOffset = 0;
        
        _pool = new ObjectPool<GameObject>(CreateGameObject,OnTakeGameObjectFromPool, OnReturnGameObjectToPool,defaultCapacity:20);
        
        // for (int i = 0; i < 2; i++)
        // {
        //     _pool.Get();
        // }
    }

    private void Update()
    {
         
        
        if (_playerPosition.position.z  > _zOffset-((_prefabsToInitializePool.Length)*_tileLenght))
        {
            Debug.Log(_playerPosition.position.z);
            var roads = _pool.Get();  
        }
        Debug.Log(_pool.CountActive);
    }

    private GameObject CreateGameObject()
    {
        var road = Instantiate(_prefabsToInitializePool[0
                // Random.Range(0, _prefabsToInitializePool.Length)
            ],
            new Vector3(0, -8, 1), Quaternion.Euler(0, 90, 0));

        var returnToPool = road.AddComponent<ReturnToThePool>();
        returnToPool._pool = _pool;
        
        road.SetActive(false);
        return road;
    }

    private void OnTakeGameObjectFromPool(GameObject road)
    {
        road.transform.position = new Vector3(0,-8,_zOffset);
        _zOffset += _tileLenght;
        
        road.SetActive(true);
    }

    private void OnReturnGameObjectToPool(GameObject road)
    {
        
        road.SetActive(false);
    }
}
