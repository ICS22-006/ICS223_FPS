using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int health;
    private int maxHealth = 5;
    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }

    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }

    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.PICKUP_HEALTH, this.OnPickupHealth);
    }

    public void Hit()
    {
        health -= 1;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, health / (float)maxHealth);
        Debug.Log("Health: " + health);
        if (health == 0)
        {
            // Debug.Break();
            Messenger.Broadcast(GameEvent.PLAYER_DEAD);
        }
    }

    public void OnPickupHealth(int healthAdded)
    {
        health += healthAdded;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        float healthPercent = ((float)health) / maxHealth;
        Messenger<float>.Broadcast(GameEvent.HEALTH_CHANGED, healthPercent);
    }
}
