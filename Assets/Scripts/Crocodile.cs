using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }
    public Player player;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bullet;

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Start()
    {
        Init(30);
        WaitTime = 0.0f;
        ReloadTime = 5.0f;
        DamageHit = 30;
        AttackRange = 6;
        player = GameObject.FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        Behavior();
    }

    public override void Behavior()
    {
        Vector2 distance = player.transform.position - transform.position;
        if (distance.magnitude <= attackRange) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            animator.SetTrigger("Shoot");
            GameObject obj = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            //GetConponent Script Rock from obj(bullet)
            //innitialize Rock's attributes

            WaitTime = 0; 
        }
    }
}


