using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int money;
    public int health;
    public int maxHealth;
    public int damage;
    public bool isDashUnlocked;
    public float[] position;
    public int keys;
    public int sceneID;

    public PlayerData(Player_Controler player)
    {
        money = player.GetCoins();
        health = player.GetHealth();
        maxHealth = player.GetMaxHealth();
        damage = player.GetDamage();
        isDashUnlocked = player.GetDash();
        position = new float[3];
        position[0] = player.GetPlayerPosition().x;
        position[1] = player.GetPlayerPosition().y;
        position[2] = player.GetPlayerPosition().z;
        sceneID = player.GetActiveSceneID();
        keys = player.GetSecretKey();
    }
}