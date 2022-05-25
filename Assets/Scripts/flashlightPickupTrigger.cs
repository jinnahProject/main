using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPickupTrigger : MonoBehaviour
{
    public List<GameObject> Instructions;
    public GameObject flashlightOnHand;
    public GameObject flashlightOnDesk;
    private float flashlightInstructionTime = 0f;
    private bool Action = false;
    //public void showCursor(bool active)
    //{
    //    Instructions[0].SetActive(active);
    //}

    public void beginScript()
    {
        Action = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (flashlightInstructionTime > 1.5f)
        {
            Instructions[1].SetActive(false);
        }
        if (Instructions[1].activeSelf)
        {
            flashlightInstructionTime += Time.deltaTime;
        }
        if (Action)
            {
                Destroy(flashlightOnDesk);
                flashlightOnHand.SetActive(true);
                Instructions[1].SetActive(true);
            }
        Action = false;
     


    }
}
