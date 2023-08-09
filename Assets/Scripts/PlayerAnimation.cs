using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.moveInput.x > 0 || Player.moveInput.x < 0)
        {
            anim.SetFloat("Speed",Mathf.Abs(Player.moveInput.x));
        }
        if (Player.moveInput.y > 0 || Player.moveInput.y < 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(Player.moveInput.y));
        }
    }
}
