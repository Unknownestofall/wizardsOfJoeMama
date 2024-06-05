using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] Text[] ResText;
    [SerializeField] int[] ResCount;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        elixir.updateRes += updateResText;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateResText(int id,int value) {
        for (int i = 0; i < ResCount.Length; i++) { 
            if(i == id) { 
                ResCount[i] += value;
                ResText[i].text = $"{ResCount[i]}"; 
            }
        }
    }
}
