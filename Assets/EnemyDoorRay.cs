using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyDoorRay : MonoBehaviour
{
    public Transform rayInteractPoint;
    float rayDistance = 3f;
    float tick = 1f;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        tick -= Time.deltaTime;
        if (tick <= 0f)
        {
            tick = 1f;
            if (Physics.Raycast(rayInteractPoint.position, rayInteractPoint.forward, out hit, rayDistance, layer))
            {
                PressKeyOpenDoor openDoor = hit.transform.GetComponent<PressKeyOpenDoor>();

                if (openDoor.canEnemyOpenDoor())
                {
                    GetComponent<NavMeshAgent>().speed = 4f;

                    openDoor.Pressed();

                }
                else if (openDoor.opened)
                {
                    GetComponent<NavMeshAgent>().speed = 4f;

                }
                else
                {
                    GetComponent<NavMeshAgent>().speed = 0f;

                }


            }
        }
    }
}
