using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    private PlayerManager playerManager;
    private void Start()
    {
        playerManager = PlayerManager.instance;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            GameObject[] listEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log(listEnemies.Length);
            if (listEnemies.Length <= 1)
            {
                playerManager.ShowFinishUI();
            }
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
