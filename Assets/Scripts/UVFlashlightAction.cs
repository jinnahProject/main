using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVFlashlightAction : MonoBehaviour
{
    public Light light;

    public GameObject flashlight;

    public GameObject Inventory;

    
    // Start is called before the first frame update
    void Start()
    {
        light = light.GetComponent<Light>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
            
        
    }
}
