/****************************************************************************************/
/*
/* FILE NAME: EnemyAI.cs
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
//underwater Ai, omni directional
public class EnemyAI : MonoBehaviour
{

    public Transform player;
    public float speed = 100f;


    void Start()
    {

    }

    void Update()
    {

        transform.LookAt(player.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);


        if (Vector3.Distance(transform.position, player.position) > 1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }

}
