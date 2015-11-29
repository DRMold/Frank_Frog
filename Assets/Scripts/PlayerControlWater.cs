﻿/****************************************************************************************/
/*
/* FILE NAME: PlayerControlWater.cs
/*
/* DESCRIPTION: Establishes player mechanics in water.
/*
/* REFERENCE:
/*
/* DATE         BY                  CHANGE REF  DESCRIPTION
/* ========     =======             =========== =============
/* 11/27/2015   John Rubadue        1CF: JM     Created the class & full implementation
/* 11/29/2015   Ritchie Hofmann        "        Made not stupid.
/*
/*
/****************************************************************************************/
using UnityEngine;
using System.Collections;

public class PlayerControlWater : MonoBehaviour {
    public float speed = 250f;
    Transform myTrans;
    public Rigidbody2D myBody; 
    Vector2 movement;
    


    void Start()
    {
        myTrans = this.transform;
        
    }

    void Update()
    {
        Move1(Input.GetAxisRaw("Horizontal"));
        Move2(Input.GetAxisRaw("Vertical"));
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