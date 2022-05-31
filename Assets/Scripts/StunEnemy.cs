using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StunEnemy : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistence;
    public LayerMask layer;
    public Light myLight;
    public GameObject enemy;
    
    void Start()
    {
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistence, layer))
        {
            if (myLight.enabled)
            {
                enemy.GetComponent<NavMeshAgent>().speed -= 0.009f;
                if(enemy.GetComponent<NavMeshAgent>().speed <= 0.2f)
                {
                    enemy.GetComponent<EnemyRespawn>().Respawn();
                }

            }
            else{
                if(enemy.GetComponent<NavMeshAgent>().speed <= enemy.GetComponent<EnemyController>().enemyMaxSpeed){
                enemy.GetComponent<NavMeshAgent>().speed += 0.009f;
            }
            }
        }
        else{
            if(enemy.GetComponent<NavMeshAgent>().speed <= enemy.GetComponent<EnemyController>().enemyMaxSpeed){
                enemy.GetComponent<NavMeshAgent>().speed += 0.009f;
            }
        }

    }
}
