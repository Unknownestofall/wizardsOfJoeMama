using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [SerializeField] List<gameResources> mats = new List<gameResources>();

    void OnEnable(){
        elixir.updateRes += addResourceToPlayer;
    }

    void addResourceToPlayer(int id,int value) {
        foreach (var mat in mats) { 
            if(id == mat.resouceID) {
                mat.resourceCount += value;
            }
        }
    }
}
