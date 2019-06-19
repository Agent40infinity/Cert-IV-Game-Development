using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage = 10; //Damage of the tower
    public float attackRate = 1f; //How fast the tower attacks
    public float attackRange = 2f; //How far the tower attacks

    protected Enemy currentEnemy; //Current target to shoot at

    private float attackTimer = 0f; //Time elapsed for attacking

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green; //Draw the attack sphere around Tower
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public virtual void Aim(Enemy e) //Face the enemy
    {
        print("I am aiming at '" + e.name + "'");
    }

    public virtual void Attack(Enemy e) //Attacks a given enemy only when 'attacking'
    {
        print("I am attacking '" + e.name + "'");
    }

    void DetectEnemy() //Detects the enemy within range
    {
        currentEnemy = null; //Reset currentEnemy (to null)
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange); //Get hit colliders from OverlapSphere
        foreach (var hit in hits) //Loop through all hit colliders
        {
            Enemy enemy = hit.GetComponent<Enemy>(); //If we hit an enemy
            if (enemy)
            {
                currentEnemy = enemy; //Set currentEnemy to enemy
            }
        }
    }

    //Protected - Accessible to Cannon / Other Tower Classes (Derivatives)
    //Virtual - Able to change what this function does in derived classes
    protected virtual void Update()
    {
        DetectEnemy(); //Detect enemies before performing attack logic
        attackTimer += Time.deltaTime; //Count up the timer
        if (currentEnemy) //If there is a current enemy
        {
            Aim(currentEnemy); //Aim at the enemy
            if (attackTimer >= attackRate) //Is attack timer ready?
            {
                Attack(currentEnemy); //Attack the enemy!
                attackTimer = 0; //Reset the timer
            }
        }
    }
}
