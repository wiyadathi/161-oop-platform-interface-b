using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public Transform SpawnPoint { get; set; }
    [field: SerializeField] public GameObject Bullet { get; set; }

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    public void Shoot()
    {
        //คลิกเมาส์ซ้าย >> shoot
        if (Input.GetButtonDown("Fire1" ) && (WaitTime >= ReloadTime))
        {
            Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            WaitTime = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init(100);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }
}
