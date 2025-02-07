﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    public NavMeshAgent Mob;
    public float MobDistanceRun = 100f;

    public int currentHp;
    public int maxHp = 50;

    // Update is called once per frame

    private void Start()
    {
        currentHp = maxHp;
        Mob = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }
    void LateUpdate()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;
            Mob.SetDestination(newPos);

        }


    }

    public void TakeDamage(int dmgTaken)
    {
        currentHp -= dmgTaken;

    }
}
