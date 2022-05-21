using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private float batteryFullness = 100f;
    private bool isActive = false;
    public GameObject battery;
    // Start is called before the first frame update



    void Start()
    {
        
    }

    public float getBatteryFullness()
    {
        return this.batteryFullness;
    }

    public void setBatteryFullness(float changeRate)
    {
        this.batteryFullness += changeRate;
    }
    

    public bool getIsActive()
    {
        return this.isActive;
    }

    public void setIsActive(bool isActive)
    {
        this.isActive = isActive;
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            if(batteryFullness <= 0f)
            {
                isActive = false;
            }
        }
    }
}
