using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActions : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistence;
    bool active = false;
    public GameObject cursor;
    // Update is called once per frame

    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistence);


        if (active)
        {
            if (hit.transform.tag == "Flashlight")
            {
                cursor.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<flashlightPickupTrigger>().beginScript();
                }

            }
            else if (hit.transform.tag == "Battery")
            {
                cursor.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<batteryPicker>().beginScript();

                }
            }
            else if(hit.transform.tag == "Drawer")
            {
                cursor.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<PressEOpenDrawer>().beginScript();

                }
            }
            else if (hit.transform.tag == "Cabinet")
            {
                cursor.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<OpenCabinet>().beginScript();

                }
            }
            else if (hit.transform.tag == "Door")
            {
                cursor.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<PressKeyOpenDoor>().beginScript();

                }
            }
            else if (hit.transform.tag == "Key")
            {
                cursor.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<KeyPicker>().beginScript();

                }
            }
            else if (hit.transform.tag == "Lamp")
            {
                cursor.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<LightEnable>().beginScript();

                }
            }
            else
            {
                cursor.SetActive(false);
            }
        }
        else
        {
            cursor.SetActive(false);
        }

        /* if(Input.GetKeyDown(KeyCode.E) && active)
        {
            if(hit.transform.tag == "Flashlight")
            {
                instruction.SetActive(true);
                hit.transform.GetComponent<flashlightPickupTrigger>().test();
                print("Interaction");
            }
        } */

    }
}