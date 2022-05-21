using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{
    public GameObject flashlight;
    private float flashlightIntensity;
    public Light myLight;
    private float flashlightOpenTime=0f;
    
    public List<GameObject> batteries;
    GameObject currentBattery;
    List<GameObject> activeBatteries = new List<GameObject>();
    
    private float maxIntensity = 2.0f;
    private float minIntensity = 0.1f;
    private float fadeRate = 0.01f;
    private float chargeRate = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        myLight = myLight.GetComponent<Light>();
        print(batteries.Count);
        makeReady();
        
    }

    public void makeReady(){
        setActiveBatteries(this.batteries);
        
        
        if(this.activeBatteries.Count > 0)
        {
            setCurrentBattery(this.activeBatteries);
        }
        else
        {
            this.currentBattery = null;
        }
    }

    void setActiveBatteries(List<GameObject> batteries)
    {
        for(int i = 0; i < batteries.Count; i++)
        {
            print(batteries[i].name);
            bool batteryActiveness = batteries[i].GetComponent<BatteryController>().getIsActive();
            print(batteryActiveness);
            if(batteryActiveness)
            {
                this.activeBatteries.Add(batteries[i]);
            }
        }
    }

    void setCurrentBattery(List<GameObject> batteries){
        for(int i = 0; i < batteries.Count; i++){
            bool batteryActiveness = batteries[i].GetComponent<BatteryController>().getIsActive();
            float batteryFullness = batteries[i].GetComponent<BatteryController>().getBatteryFullness();
            if(batteryActiveness){
                currentBattery = batteries[i];
                break;
            }
            else{
                this.activeBatteries.Remove(batteries[i]);
            }
            print(this.activeBatteries.Count);
        }
                
    }

    void setCurrentBatteryFullness(){
        currentBattery.GetComponent<BatteryController>().setBatteryFullness(-0.08f);
    }

    void changeBattery(){
        if(this.activeBatteries.Count > 0){
            setCurrentBattery(this.activeBatteries);
        }
        else{
            this.currentBattery = null;
        }
    }

    bool checkLight(){
        if(this.currentBattery != null){
            return true;
        }
        else{
            return false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.F))
        {
           
           myLight.enabled = !myLight.enabled;

           
        }
        if(myLight.enabled == true && checkLight())
        {
            if(currentBattery.GetComponent<BatteryController>().getBatteryFullness() <= 0f)
            {
                currentBattery.GetComponent<BatteryController>().setIsActive(false);
                myLight.enabled = false;
                changeBattery();
            }
            else{
                setCurrentBatteryFullness();
                //print(currentBattery.GetComponent<BatteryController>().getBatteryFullness());
            }
            
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
