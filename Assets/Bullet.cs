using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [HideInInspector] public weaponManager weapon;

    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<enemyHealth>())
        {
            enemyHealth enemyHP = collision.gameObject.GetComponentInParent<enemyHealth>();
            enemyHP.takeDamage(weapon.damage);
        }
        Destroy(this.gameObject);
    }
}
