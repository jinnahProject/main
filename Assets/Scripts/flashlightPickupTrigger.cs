using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPickupTrigger : MonoBehaviour
{
    public GameObject flashlightOnHand;
    public GameObject flashlightOnDesk;
    private bool Action = false;
    public GameObject Inventory;


    public void beginScript()
    {
        Action = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (Action)
        {
            Inventory.GetComponent<InventoryManager>().addFlashlight(flashlightOnHand);
            flashlightOnDesk.GetComponent<MeshRenderer>().enabled = false;
            flashlightOnDesk.GetComponent<CapsuleCollider>().enabled = false;
        }
        Action = false;
    }
}
