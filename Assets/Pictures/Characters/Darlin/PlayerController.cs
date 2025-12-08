using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerMoveInfo : MonoBehaviour
{

    //PHYSIC DATA
    public float speedValue = 10f;
    public float stepDelay = 0.5f;  
    public float stepTimer = 0f;


    //PHYSICS
    public float moveInput;
    public Rigidbody2D rigidBody;
    public Animator animPlayer;

    //CHECK
    public bool facingRight = false;
    public bool Freeze = false;

    //public GameObject Monolog;
    public AudioSource Step;
}






    public class PlayerController : PlayerMoveInfo



{


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
  

    }


    void Update()
    {
        if (stepTimer > 0)
        {
            stepTimer -= Time.deltaTime;
        }

    }


    void FixedUpdate()
    {

        Walk();

        FlipCondition();

        
    }


    public void Walk()
    {
        if (Freeze == true)
        {
            moveInput = 0;
            Step.Stop();
            animPlayer.SetBool("IsWalking", false);
        }
        else
        {
            moveInput = Input.GetAxis("Horizontal");
            rigidBody.velocity = new Vector2(moveInput * speedValue, rigidBody.velocity.y);

            if (moveInput == 0)
            {
                animPlayer.SetBool("IsWalking", false);
                if (Step.isPlaying)  
                {
                    Step.Stop();
                }
            }
            else
            {
                animPlayer.SetBool("IsWalking", true);
                if (!Step.isPlaying && stepTimer <= 0)  
                {
                    Step.Play();
                    stepTimer = stepDelay;  
                }
            }
        }
    }



    public void FlipCondition()
    {
        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


    public void Dialog()
    {
       Freeze = true;
    }

    public void Unfreeze()
    {
        Freeze = false;
    }

}
