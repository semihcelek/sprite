// using System.Collections;
// using System.Collections.Generic;
// using Road;
// using UnityEngine;
//
// public class RoadPool : MonoBehaviour,IPoolGenerator
// {
//
//     public GameObject CreateGameObject()
//     {
//         var road = Instantiate(_prefabsToInitializePool[Random.Range(0, _prefabsToInitializePool.Length)],
//             new Vector3(0, -8, 0), Quaternion.Euler(0, 90, 0));
//         road.SetActive(false);
//         return road;
//     }
//         
// }
