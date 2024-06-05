using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elixir : MonoBehaviour
{
    [SerializeField] int ResID, ResToReceive;
    public static Action<int, int> updateRes;

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) { 
            updateRes?.Invoke(ResID,ResToReceive);
            Destroy(this.gameObject);
        }
    }
}
