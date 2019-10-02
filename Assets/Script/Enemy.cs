using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    [HideInInspector]
    public float health;

    public int worth = 50;

    public GameObject EnemyDeathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;

        PlayerStatus.Money += worth;

        GameObject effectIns = (GameObject)Instantiate(EnemyDeathEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject); ;
    }

    public void Slow(float slowAmount)
    {
        speed = startSpeed * (1f - slowAmount);
    }
}
