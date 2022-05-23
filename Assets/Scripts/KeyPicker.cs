using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPicker : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject key;
    public GameObject pickedKey;
    public GameObject door;
    public GameObject Task;
    public AudioClip pickingKeySound;
    private float TaskClose = 0;
    private bool Action = false;
    // Start is called before the first frame update
    void Start()
    {
        Instruction.GetComponent<MeshRenderer>().enabled = true;
        Instruction.SetActive(false);
    }

    void OnTriggerStay(Collider collison)
    {
         if (collison.transform.tag == "Player" && key != null)
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
    string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + '\u0336' + c  ;
        }
        return strikethrough;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickedKey.activeSelf == true)
        {
            TaskClose += Time.deltaTime;
            if (TaskClose >= 1.5)
            {
                Task.GetComponent<TextMesh>().text = "Yatak Odasının Anahtarını Bul.";

            }

        }

        if (Action)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickedKey.SetActive(true);
                GetComponent<AudioSource>().PlayOneShot(pickingKeySound);
                Destroy(key);
                Action = false;
                Task.GetComponent<TextMesh>().text = StrikeThrough(Task.GetComponent<TextMesh>().text);
            }
           
        }

    }
}
