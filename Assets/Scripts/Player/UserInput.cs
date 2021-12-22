using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class UserInput : MonoBehaviour, IInput
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }
}
