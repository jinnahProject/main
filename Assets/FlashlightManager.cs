using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    public GameObject flashlight;
    private float flashlightIntensity;
    public Light myLight;
    private float flashlightOpenTime=0f;

    private float maxIntensity = 2.0f;
    private float minIntensity = 0.1f;
    private float fadeRate = 0.01f;
    private float chargeRate = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        myLight = myLight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
           myLight.enabled = !myLight.enabled;
        }
        if(myLight.enabled == true)
        {
            if(myLight.intensity <= maxIntensity)
            {
                myLight.intensity -= fadeRate * Time.deltaTime;
            }
            if(myLight.intensity < minIntensity)
            {
                myLight.intensity = minIntensity;
            }
        }
    }
}
