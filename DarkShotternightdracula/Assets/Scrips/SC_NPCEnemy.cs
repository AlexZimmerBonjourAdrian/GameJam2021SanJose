﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class SC_NPCEnemy : MonoBehaviour, IEntity
{
    public float attackDistance = 3f;
    public float movementSpeed = 4f;
    public float npcHP = 100;
    //How much damage will npc deal to the player
    public float npcDamage = 5;
    public float attackRate = 0.5f;
    public Transform firePoint;
    public GameObject npcDeadPrefab;
    public GameObject bullet;
    public Transform playerTransform;
    [HideInInspector]
    public SC_EnemySpawner es;
    NavMeshAgent agent;
    float nextAttackTime = 0;
    Rigidbody r;
    public double speedBullet = 1;
    public SC_EnemySpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackDistance;
        agent.speed = movementSpeed;
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
        r.isKinematic = true;
        StartCoroutine("DoStuff");

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance - attackDistance < 0.01f)
        {
            if(Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackRate;
                
                //Attack
                RaycastHit hit;
                if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, attackDistance))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        Debug.DrawLine(firePoint.position, firePoint.position + firePoint.forward * attackDistance, Color.cyan);

                        IEntity player = hit.transform.GetComponent<IEntity>();
                        player.ApplyDamage(npcDamage);
                    }
                }
            }

            GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
            
        }
        //Move towardst he player
        agent.destination = playerTransform.position;
        //Always look at player
        transform.LookAt(new Vector3(playerTransform.transform.position.x, transform.position.y, playerTransform.position.z));
        //Gradually reduce rigidbody velocity if the force was applied by the bullet
        r.velocity *= 0.99f;
    }
    public void Atack()
    {
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject; //shoots from enemies eyes
        Rigidbody bulletRigidBody = tempBullet.GetComponent<Rigidbody>();
        bulletRigidBody.AddForce(bulletRigidBody.transform.forward*20f, ForceMode.Impulse);
        

    }

    IEnumerator DoStuff()
    {
        int value = 0;
        while (true)
        {
            yield return new WaitForSeconds(1);
            value++;
            Atack();
        }
    }

    private void OnDestroy()
    {
        //Slightly bounce the npc dead prefab up
        //  es.EnemyEliminated(this);
        spawner.EnemyEliminated(this);
    }
    public void ApplyDamage(float points)
    {
        npcHP -= points;
        if(npcHP <= 0)
        {
            Destroy(this.gameObject);

            GameObject npcDead = Instantiate(npcDeadPrefab, transform.position, transform.rotation);
            npcDead.GetComponent<Rigidbody>().velocity = (-(playerTransform.position - transform.position).normalized * 8) + new Vector3(0, 5, 0);
            Destroy(npcDead, 10);

            //Destroy the NPC
            

        }
    }
}