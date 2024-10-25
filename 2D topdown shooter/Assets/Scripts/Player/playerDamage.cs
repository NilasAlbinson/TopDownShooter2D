using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerDamage : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;
    [SerializeField] float damageColdown = 3f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= 1;

            if (playerHealth > 0)
            {
                Invoke("OnCollisionEnter2D", damageColdown);
            }
            else if (playerHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
