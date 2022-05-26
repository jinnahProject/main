using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEnemy : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistence;
    public LayerMask layer;
    public Light myLight;
    public int xPos;
    public int zPos; 
    public GameObject enemy;

    // Start is called before the first frame update

    public void spawnEnemy()
    {
        xPos = Random.Range(-50, 50);
        zPos = Random.Range(-30, 30);
        Instantiate(enemy, new Vector3 (xPos, 1, zPos), Quaternion.identity);
        enemy.SetActive(true);
        
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistence, layer))
        {
            if (myLight.enabled)
            {
                Destroy(enemy);
                spawnEnemy();
            }
        }
        
    }
}
