using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedroomInside : MonoBehaviour
{
    public List<GameObject> lights;
    public bool Action = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider collison)
    {
        if (collison.transform.tag == "Player")
        {
            Action = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Action){
            for(int i = 0; i < lights.Count; i++){
                lights[i].SetActive(false);
                //lights[i].GetComponent<Light>().enabled = false;
            }
        }
        Action = false;

    }
}
