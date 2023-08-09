using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;
    public GameObject muzzle;
    public Transform Guntip;
    public float TimeBtwFire = 0.2f;
    public float bulletForce = 2;

    public float timeBtwFire;
    private void Start()
    {
    }
    void Update()
    {
       timeBtwFire -= Time.deltaTime;
        if(timeBtwFire < 0 && Input.GetKey(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;
        GameObject bulletTmp = Instantiate(bullet,Guntip.position, Quaternion.identity);
        GameObject muzzles = Instantiate(muzzle,Guntip.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce,ForceMode2D.Impulse);
    }

 
    

}
