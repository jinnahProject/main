using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyRespawn : MonoBehaviour
{
    public Transform PlayerPosition;
    public List<Vector3> spawnPoints;
    private float maxDistance = 0f;
    private Vector3 actualSpawnPoint;
    // Start is called before the first frame update
    public void Respawn()
    {
        float playerX = PlayerPosition.position.x;
        float playerZ = PlayerPosition.position.z;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            float distance = Mathf.Abs(spawnPoints[i].x - playerX + spawnPoints[i].z - playerZ);
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
