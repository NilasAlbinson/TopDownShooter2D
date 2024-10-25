using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float enemySpeed = 2f;
    [SerializeField] float honingLevel = 30f;
    [SerializeField] float honingDistance = 1f;
    Rigidbody2D rb;
    GameObject player;
    float modifiedEnemySpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        modifiedEnemySpeed = enemySpeed;
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < honingDistance)
            {
                float percentage = 1 - (distance / honingDistance);
                modifiedEnemySpeed = enemySpeed + honingLevel * percentage;
            }
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + (direction * modifiedEnemySpeed * Time.fixedDeltaTime));
            Debug.Log(modifiedEnemySpeed);
        }
    }
}
