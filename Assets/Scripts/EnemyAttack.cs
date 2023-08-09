using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform Guntip;
    public GameObject PlayerAT;
    public float TimeBtwFire = 2f;
    public float bulletForce = 20;

    public float timeBtwFire;
    public float positionPlayer = Player.positionX;
    public float posAttackX;
    public float posAttackY;
    public float posAttack;
    private float posXEnemy;
    private float posYEnemy;
    private float distance;
    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position,PlayerAT.transform.position);
        Vector2 direction = PlayerAT.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Flip();
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        timeBtwFire -= Time.deltaTime;
        posXEnemy = transform.position.x;
        posYEnemy = transform.position.y;
        posAttackX = posXEnemy - PlayerAT.transform.position.x;
        posAttackY = posYEnemy - PlayerAT.transform.position.y;
        if(Mathf.Abs(posAttackX) > Mathf.Abs(posAttackY)) posAttack = Mathf.Abs(posAttackX);
        else posAttack = Mathf.Abs(posAttackY);

        if (timeBtwFire < 0 && posAttack <=20)
        {
           
            FireBullet();
        }
    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;
        GameObject bulletTmp = Instantiate(bullet, Guntip.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) isRight = false;
        else isRight = true;
        if (isRight == false) theScale.y = -5;
        else theScale.y = 5;
        transform.localScale = theScale;
    }
}
