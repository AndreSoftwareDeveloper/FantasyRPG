using UnityEngine;
using TMPro;

public class enemyHealth : MonoBehaviour
{
    public float health;
    ragdollManager rgdlManager;
    Animator animator;
    public static uint killed_enemies = 0;
    public TMP_Text starText;

    private void Start()
    {
        rgdlManager = GetComponent<ragdollManager>();
        animator = this.GetComponent<Animator>();
    }

    private void Update() {
        Debug.Log(health);
    }

    public void takeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
                enemyDeath();
        }
    }

    void enemyDeath()
    {
        animator.Play("death");
        killed_enemies++;
    }
}
