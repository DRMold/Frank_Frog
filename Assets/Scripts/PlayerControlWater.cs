/****************************************************************************************/
/*
/* FILE NAME: PlayerControlWater.cs
/*
/* DESCRIPTION: Establishes the AI for the enemies incountered throughout the game.
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/27/2015   John Rubadue        1CF: JM     Created the class & full implementation
/*
/*
/*
/****************************************************************************************/
using UnityEngine;
using System.Collections;

public class PlayerControlWater : MonoBehaviour {
    public float speed = 250f;
    public LayerMask playerLayerMask;//
    Transform myTrans;
    public Rigidbody myBody; 
    Vector2 movement;//
    


    void Start()
    {
        myTrans = this.transform;
        
    }

    void Update()
    {
    
#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
        Move1(Input.GetAxisRaw("Horizontal"));
        Move2(Input.GetAxisRaw("Vertical"));
#endif
    }
    //x axis movement
    public void Move1(float horizontal_input)
    {
        movement = myBody.velocity;

        movement.x = horizontal_input * speed * Time.deltaTime;

        myBody.velocity = movement;
    
    }
    //y axis movement
    public void Move2(float vertical_input)
    {
        movement = myBody.velocity;

        movement.y = vertical_input * speed * Time.deltaTime;

        myBody.velocity = movement;

    }
}