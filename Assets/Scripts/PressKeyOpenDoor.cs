using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject AnimeObject;
    public bool Action = false;
    public bool opened = false;
    public Animator anim;
    private float animTime = 1f;
    public bool doIHaveKey = true;
    public AudioClip lockedDoorSound;

    public bool locked;

    public void beginScript()
    {
        Action = true;
    }

    public void Pressed()
    {
        AnimeObject.GetComponent<Animator>().Play("DoorOpen");
        opened = !opened;
        anim.SetBool("Opened", !opened);

    }
    public bool canEnemyOpenDoor()
    {
        if (!opened && !locked)
            return true;
        else
        {
            return false;
        }
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
                this.locked = false;
                if (animTime >= 1f)
                {
                    Pressed();
                    animTime = 0f;
                }
                Action = false;
            }
            else
            {
                AnimeObject.GetComponent<AudioSource>().PlayOneShot(lockedDoorSound);
                Action = false;

            }


        }



    }
}
