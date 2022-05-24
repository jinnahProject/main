using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEOpenDrawer : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public bool Action = false;
    private bool opened ;
    public Animator anim;
    private float animTime = 0f;

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
        animTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (Action == true)
            {
                
                    Instruction.SetActive(false);
                    if (animTime >= 1f)
                    {
                        AnimeObject.GetComponent<Animator>().Play("DrawerOpen");
                        anim.SetBool("Opened", !opened);

                        opened = !opened;
                        animTime = 0f;
                    }
                    Action = false;
                
                


            }
        }
    }
}
