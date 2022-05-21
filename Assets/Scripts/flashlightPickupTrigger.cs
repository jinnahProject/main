using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightPickupTrigger : MonoBehaviour
{
    public List<GameObject> Instructions;
    public GameObject flashlightOnHand;
    public GameObject flashlightOnDesk;
    private float flashlightInstructionTime = 0f;
    public List<GameObject> batteries;
    private bool Action = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerStay(Collider collison)
    {
        if (collison.transform.tag == "Player")
        {
            
            if (flashlightOnHand.activeSelf)
            {
                Instructions[0].SetActive(false);
            }
            else
            {
                Instructions[0].SetActive(true);

            }



            Action = true;
        }
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action)
            {
                for (int i = 0; i < batteries.Count; i++)
                {
                    Destroy(batteries[i]);
                }
                Destroy(flashlightOnDesk);
                flashlightOnHand.SetActive(true);
                Instructions[1].SetActive(true);


            }
            Action = false;
        }
        

    }
}
