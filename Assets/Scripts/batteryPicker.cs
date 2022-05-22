using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batteryPicker : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject battery;
    public GameObject pickedBattery;
    public GameObject flashlight;
    private bool Action = false;
    // Start is called before the first frame update
    void Start()
    {
        Instruction.GetComponent<MeshRenderer>().enabled = true;
        Instruction.SetActive(false);
    }

    void OnTriggerStay(Collider collison)
    {
         if (collison.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }
    void OnTriggerExit(Collider collision)
    {
        Instruction?.SetActive(false);
        Action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Action)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Picked");
                print(pickedBattery.name);
                pickedBattery.GetComponent<BatteryController>().setIsActive(true);
                flashlight.GetComponent<FlashlightManager>().makeReady();
                Destroy(battery);
                Action = false;
            }
           
        }
    }
}
