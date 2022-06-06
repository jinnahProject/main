using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<GameObject> Keys;
    public GameObject Flashlight;
    public GameObject uvFlashlight;

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
                    changeTask("Normal el feneri bul", Flashlight, 1);
                    break;
                }
            case 1:
                {
                    changeTask("K�sa koridora ��kan kap�y� a�mak i�in anahtar bul.", Keys[0], 2);
                    break;
                }
            case 2:
                {
                    changeTask("K�z�l �tesi El feneri bul\n(�pucu: Bebek, �����ndan �ok rahats�z olur)", uvFlashlight, 3);
                    break;
                }
            case 3:
                {
                    changeTask("Kanl� kap�y� a�mak i�in anahtar bul.", Keys[1], 4);
                    break;
                }
            case 4:
                {
                    changeTask("Banyoya ula�mak i�in anahtar bul.", Keys[2], 5);
                    break;
                }
            case 5:
                {
                    changeTask("�al��ma Odas�na girebilmek i�in anahtar bul.", Keys[3], 6);
                    break;
                }
            case 6:
                {
                    changeTask("B�y�k odaya girmek i�in anahtar bul.", Keys[4], 7);
                    break;
                }
            case 7:
                {
                    changeTask("Yemek odas�na ula�mak i�in anahtar bul.", Keys[5], 8);
                    break;
                }
            case 8:
                {
                    changeTask("Ana kap�dan ka�mak i�in anahtar�n� bul.", Keys[6], 9);
                    break;
                }
            case 9:
                {
                    task.text = "EVDEN KA�!\n(Dikkat et, bebek �ok k�zg�n!!)";
                    break;
                }
        }
    }
}
