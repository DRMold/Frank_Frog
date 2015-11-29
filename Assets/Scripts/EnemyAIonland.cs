/****************************************************************************************/
/*
/* FILE NAME: EnemyAIonland.cs
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

public class EnemyAIonland : MonoBehaviour {

    public float velocity = 1f;
    public Transform sightStart;
    public Transform sightEnd;

    public bool colliding;
    public LayerMask detectWhat;
    void Update()
    {
        //Ai on land, only movement being left and right
         new Vector2(velocity, velocity);

        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, detectWhat);

        if (colliding)
        {

            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocity *= -1;
        }

    }


}
