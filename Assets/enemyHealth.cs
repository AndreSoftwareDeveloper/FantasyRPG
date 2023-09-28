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
        //starText = GetComponent<fragCounter>();
    }

    public void takeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
                enemyDeath();
            Debug.Log("Hit");
        }
    }

    void enemyDeath()
    {
        rgdlManager.TriggerRagdoll();
        killed_enemies++;
        Debug.Log(killed_enemies);

        animator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("None", typeof(RuntimeAnimatorController));
    }
}
