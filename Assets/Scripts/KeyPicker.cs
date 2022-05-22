using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPicker : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject key;
    public GameObject pickedKey;
    public GameObject door;
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
                print(key.name);
                Destroy(key);
                Action = false;
            }
           
        }
    }
}
