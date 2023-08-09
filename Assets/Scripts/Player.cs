using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public static Vector3 moveInput;
    public bool isRight;
    public static float positionX;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        positionX = transform.position.x;
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * speed * Time.deltaTime;
        
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
}
