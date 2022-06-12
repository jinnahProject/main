using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class StunEnemy : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public static AudioSource audioSource;
    public Transform cam;
    public float playerActivateDistence;
    public LayerMask layer;
    public Light myLight;
    public GameObject enemy;
    private NavMeshAgent baby;
    void Start()
    {
        baby = enemy.GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void playSound(AudioClip clip)
    {
        if (audioSource.isPlaying);
        else audioSource.PlayOneShot(clip);
    }
    // Update is called once per frame
    void Update()
    {
        if (TaskManager.createEnemy)
        {
            enemy.SetActive(true);
        }
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistence, layer))
        {
            if (myLight.enabled)
            {
                print(baby.speed);
                baby.speed -= 0.02f;
                if (baby.speed >= 1.7f)
                {
                    playSound(audioClips[0]);
                }
                else if(baby.speed < 1.7f && baby.speed > 1.0f)
                {
                    playSound(audioClips[1]);
                }
                else if (baby.speed < 0.8f && baby.speed > 0.1f)
                {
                    playSound(audioClips[2]);
                }
                if (baby.speed <= 0.1f)
                {
                    enemy.GetComponent<EnemyRespawn>().Respawn();
                }

            }
            else
            {
                if (baby.speed <= enemy.GetComponent<EnemyController>().enemyMaxSpeed)
                {
                    baby.speed += 0.009f;
                }
            }
        }
        else
        {
            if (baby.speed <= enemy.GetComponent<EnemyController>().enemyMaxSpeed)
            {
                baby.speed += 0.009f;
            }
        }

    }
}
