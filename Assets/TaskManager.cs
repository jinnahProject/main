using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<GameObject> Keys;
    public GameObject Flashlight;
    private int taskOrder = 0;
    private TextMesh task;
    private float TaskClose = 0f;
    void Start()
    {
        task = GetComponent<TextMesh>();
    }

    string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + '\u0336' + c;
        }
        return strikethrough;
    }
    void changeTask(string taskTxt, GameObject gameObject,int taskOrd)
    {
        task.text = taskTxt;
        if (gameObject.activeSelf)
        {
            TaskClose += Time.deltaTime;
            if (TaskClose <= 1.5)
            {
                task.text = StrikeThrough(task.text);
            }
            else
            {
                taskOrder = taskOrd;
                TaskClose = 0f;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (taskOrder)
        {
            case 0:
                {
                    changeTask("El feneri bul", Flashlight, 1);
                    break;
                }
            case 1:
                {
                    changeTask("Kýsa koridora çýkan kapýyý açmak için anahtar bul.", Keys[0], 2);
                    break;
                }
            case 2:
                {
                    changeTask("Kanlý kapýyý açmak için anahtar bul.",Keys[1], 3);
                    break;
                }
            case 3:
                {
                    break;
                }
        }
    }
}
