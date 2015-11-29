/****************************************************************************************/
/*
/* FILE NAME: PlayerControlLand.cs
/*
/* DESCRIPTION: Establishes the AI for the enemies incountered throughout the game.
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/25/2015   John Rubadue        1CF: JM     Created the class & full implementation
/*
/*
/*
/****************************************************************************************/
using UnityEngine;
using System.Collections;

public class PlayerControlLand : MonoBehaviour {
    public float speed = 250f, jumpHeight = 500f;
    public LayerMask playerLayerMask;
    Transform myTrans;
    public Rigidbody Player;
    Vector2 movement;
    bool Land = true;


    void Start()
    {
        myTrans = this.transform;
            }

    void Update()
    {
        //Check if the player is on land
        Land = Physics2D.Linecast(myTrans.position,
                                        GameObject.Find(this.name + "/tag_ground").transform.position,
                                        playerLayerMask);

        
#if !UNITY_ANDROID 
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
            Jump();
#endif
    }
    //The movement for left and right
    public void Move(float horizontal_input)
    {
        movement = Player.velocity;

        if (Land)
            movement.x = horizontal_input * speed;

       
        Player.velocity = movement;
    }
    //movement for jumping
    public void Jump()
    {
        movement = Player.velocity;
        float Jumpdistance = movement.y;
        if (Land)
            Jumpdistance += jumpHeight;
        movement.y=Jumpdistance;
        Player.velocity = movement;
        
    }
}
