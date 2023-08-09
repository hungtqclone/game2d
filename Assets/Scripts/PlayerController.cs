using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] public float hp, maxHp;
    [SerializeField] FloatingHealthBar healthBarPlayer;
    public bool isRight;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        rb2d = GetComponent<Rigidbody2D>();
        healthBarPlayer.UpdateHealthBarEnemy(hp, maxHp);
    }

    void Awake()
    {
       healthBarPlayer = GetComponentInChildren<FloatingHealthBar>(); 
    }

    // Update is called once per frame
    void Update()
    {
        healthBarPlayer.UpdateHealthBarEnemy(hp, maxHp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        Rotate();
        
    }
    void Rotate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lockDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lockDir.y, lockDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        Flip();


    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) isRight = false;
        else isRight = true;
        if (isRight == false) theScale.y = -1;
        else theScale.y = 1;
        transform.localScale = theScale;
    }

    public void Damege(float dame)
    {
        hp -= dame;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBullet"))
        {
            Damege(Random.Range(10, 20));
            Destroy(collision.gameObject);
        }
    }


}
