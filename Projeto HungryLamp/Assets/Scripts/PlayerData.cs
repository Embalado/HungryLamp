using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    // Start is called before the first frame update
    public int health;
    public float[] position;

   public PlayerData( PlayerMovement player)
    {
        health = player.lives;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}
