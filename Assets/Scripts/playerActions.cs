using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerActions : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistence;
    bool active = false;
    public GameObject cursor;
    public GameObject doorName;
    public GameObject InteractionText;
    private TextMesh IntTxt;
    private TextMesh DoorTxt;
    private bool TextVisibility = false;
    private float TextVisibilityTimer = 0f;

    // Update is called once per frame
    void Start()
    {
        IntTxt = InteractionText.GetComponent<TextMesh>();
        DoorTxt = doorName.GetComponent<TextMesh>();

    }
    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistence);

        if (TextVisibility)
        {
            InteractionText.SetActive(true);
            TextVisibilityTimer += Time.deltaTime;
            if (TextVisibilityTimer > 1.5f)
            {
                InteractionText.SetActive(false);
                TextVisibilityTimer = 0f;
                TextVisibility = false;
            }   
        }
        if (active)
        {
            if (hit.transform.tag == "Flashlight")
            {
                cursor.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<flashlightPickupTrigger>().beginScript();
                    TextVisibility = true;
                    IntTxt.text = "El feneri al�nd�";

                }

            }
            else if (hit.transform.tag == "Battery")
            {
                cursor.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<batteryPicker>().beginScript();
                    TextVisibility = true;
                    IntTxt.text = "1 batarya al�nd�";

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
                doorName.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(DoorTxt.text== "Ana Kap�" && hit.transform.GetComponent<PressKeyOpenDoor>().doIHaveKey)
                    {
                        SceneManager.LoadScene("MenuScene");
                    }
                    hit.transform.GetComponent<PressKeyOpenDoor>().beginScript();
                    
                }
                DoorTxt.text = hit.collider.gameObject.name;
                

            }
            else if (hit.transform.tag == "Key")
            {
                cursor.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<KeyPicker>().beginScript();
                    TextVisibility = true;
                    IntTxt.text = "Bir anahtar buldun!";

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
                doorName.SetActive(false);
            }
        }
        else
        {
            doorName.SetActive(false);

            cursor.SetActive(false);
        }

    }
}