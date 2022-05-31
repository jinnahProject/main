using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public LayerMask whatIsGround;
    /// <Patrolling>
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    /// </Patrolling>
    private float enemyMoveCheckX = 0f;
    private float enemyMoveCheckZ = 0f;

    public float lookRadius = 10f;

    public float enemyMaxSpeed = 2f;

    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }
    private bool EnemyMovingOrNot()
    {
        if (enemyMoveCheckZ == transform.position.z && enemyMoveCheckX == transform.position.x)
        {
            return false;
        }
        else
        {
            return true;    
        }
    } 
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if(distance <= 6.0f)
            {
                FaceTarget();

            }
        }
        else
        {
            Patroling();
        }
        if (!EnemyMovingOrNot())
        {
             SearchWalkPoint();

        }

        enemyMoveCheckZ = transform.position.z;
        enemyMoveCheckX = transform.position.x;

    }
    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    public void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    void FaceTarget()
    {
        //jumpscare
        print("jumpscare");
        SceneManager.LoadScene("GameOverScene");

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
