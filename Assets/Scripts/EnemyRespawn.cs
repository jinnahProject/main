using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyRespawn : MonoBehaviour
{
    public Transform PlayerPosition;
    public AudioClip babyLaughing;
    public List<Vector3> spawnPoints;
    private float maxDistance = 0f;
    private Vector3 actualSpawnPoint;
    public GameObject audioObject;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();   
    }
    void Laugh()
    {
        audioSource.PlayOneShot(babyLaughing,0.5f);
    }

    public void Respawn()
    {
        print("Respawning");
        Invoke("Laugh", 2f);
        float playerX = PlayerPosition.position.x;
        float playerZ = PlayerPosition.position.z;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            
            float distance = Mathf.Abs(spawnPoints[i].x - playerX + spawnPoints[i].z - playerZ);
            print(distance + " " + i);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                actualSpawnPoint = spawnPoints[i];

            }
        }
        transform.position = actualSpawnPoint;
        GetComponent<EnemyController>().enemyMaxSpeed += 0.2f;
        print("enemy max speed " + GetComponent<EnemyController>().enemyMaxSpeed);
        GetComponent<NavMeshAgent>().speed = GetComponent<EnemyController>().enemyMaxSpeed;
        print("enemy speed " + GetComponent<NavMeshAgent>().speed);
    }
}
