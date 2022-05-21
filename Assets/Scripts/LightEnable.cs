using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnable : MonoBehaviour
{
   public GameObject Instruction;
    public GameObject light;

    public bool Action = false;
    private bool opened = false;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(Action){
                if(opened){
                light.GetComponent<Light>().enabled = false;
                    opened = !opened;
                }
                else
                {
                    light.GetComponent<Light>().enabled = true;
                    opened = !opened;
                }
            }
            Action = false;
        }
        

    }
}
