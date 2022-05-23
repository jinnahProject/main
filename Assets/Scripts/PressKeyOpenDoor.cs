using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public bool Action = false;
    private bool opened = false;
    public Animator anim;
    private float animTime = 1f;
    private bool doIHaveKey = false;
    public AudioClip lockedDoorSound;


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
    void Pressed()
    {
        opened = !opened;
        anim.SetBool("Opened", !opened);
    }
    // Update is called once per frame
    void Update()
    {
        try { 
            doIHaveKey = AnimeObject.GetComponent<KeyController>().keyControl();
        }
        catch
        {
        }

        animTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (Action == true)
            {
                if (doIHaveKey)
                {
                    Instruction.SetActive(false);
                    if (animTime >= 1f)
                    {
                        AnimeObject.GetComponent<Animator>().Play("DoorOpen");
                        Pressed();
                        animTime = 0f;
                    }
                    Action = false;
                }
                else
                {
                    GetComponent<AudioSource>().PlayOneShot(lockedDoorSound);

                }


            }
        }
        

    }
}
