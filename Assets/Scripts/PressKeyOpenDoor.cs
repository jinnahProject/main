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

    public bool locked;

    public void beginScript()
    {
        Action = true;
    }

    void Pressed()
    {
        opened = !opened;
        anim.SetBool("Opened", !opened);
    }

    void checkKey()
    {
        try
        {
            doIHaveKey = AnimeObject.GetComponent<KeyController>().keyControl();
        }
        catch
        {
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.locked)
        {
            checkKey();
        }
        else
        {
            doIHaveKey = true;
        }

        animTime += Time.deltaTime;


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
                AnimeObject.GetComponent<AudioSource>().PlayOneShot(lockedDoorSound);

            }


        }



    }
}
