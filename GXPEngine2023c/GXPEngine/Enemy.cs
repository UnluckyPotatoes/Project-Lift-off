using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

public enum EnemyState
{
    Guard,
    Patrol,
    Chase,
    Return,
    Attack
}
public class Enemy : Character
{
    Player targetPlayer;
    readonly float speed = 0.75f;
    readonly float startX;
    readonly float startY;
    readonly float damage;
    readonly float movementCooldown = 1000f; //in miliseconds
    private float cooldownX;
    private float cooldownY;
    private float movementAdjustment;
    public float GetDamage() { return damage; }


    public Enemy(TiledObject obj = null) : base("Assets/Enemy.png", 1, 1)
    {
        startX = obj.X;
        startY = obj.Y;
        health = obj.GetFloatProperty("Health");
        damage = obj.GetFloatProperty("damage");
        maxHealth = health;
        collider.isTrigger = true;
        EnemyHealthInfo enemyHealthInfo = new EnemyHealthInfo();
        AddChild(enemyHealthInfo);
    }
    private EnemyState currentState;

    private void GuardBehavior() { }
    private void PatrolBehavior() { }
    private void ChaseBehavior(Vector2 p)
    {
        MoveInDirection(p);
    }
    private void ReturnBehavior(Vector2 q)
    {
        MoveInDirection(q);
    }
    private void AttackBehavior() { }
    private void MoveInDirection(Vector2 p)
    {
        Collision col = MoveUntilCollision(p.x * speed, 0);
        if (col == null)
        {
            col = MoveUntilCollision(0, p.y * speed);

            if (col != null) 
            {
                if (cooldownX <= 0)
                {
                    movementAdjustment = (p.x + (Mathf.Sign(p.x) - p.x));
                    cooldownX = movementCooldown;
                }
                else 
                {
                    cooldownX -= Time.deltaTime;
                    MoveUntilCollision(movementAdjustment * speed, 0);
                }
                
            }
        }
        else
        {
            if (cooldownY <= 0)
            {
                movementAdjustment = (p.y + (Mathf.Sign(p.y) - p.y));
                cooldownY = movementCooldown;
            }
            else 
            {
                cooldownY -= Time.deltaTime;
                MoveUntilCollision(0, movementAdjustment*speed);
            }

        }

    }

    private void BehaviourManager()
    {
        if (targetPlayer == null)
        {
            targetPlayer = ((MyGame)game).FindObjectOfType<Player>();
        }

        if (targetPlayer != null)
        {
            Vector2 directionToPlayer = new Vector2(targetPlayer.x - x, targetPlayer.y - y);
            float distanceToTargetPlayer = directionToPlayer.Magnitude();
            directionToPlayer.Normalize();

            Vector2 directionToStart = new Vector2(startX - x, startY - y);
            float distanceToTargetStart = directionToStart.Magnitude();
            directionToStart.Normalize();


            if (distanceToTargetPlayer < 128f && distanceToTargetPlayer > 16f)
            {
                currentState = EnemyState.Chase;
            }
            else
        if (distanceToTargetPlayer < 16f)
            {
                currentState = EnemyState.Attack;
            }
            else
        if (distanceToTargetPlayer > 128f)
            {
                currentState = EnemyState.Return;
                if (distanceToTargetStart < 0.25f)
                {
                    currentState = EnemyState.Guard;
                }
            }
            else currentState = EnemyState.Guard;



            switch (currentState)
            {
                case EnemyState.Guard:
                    GuardBehavior();
                    break;
                case EnemyState.Patrol:
                    PatrolBehavior();
                    break;
                case EnemyState.Chase:
                    ChaseBehavior(directionToPlayer);
                    break;
                case EnemyState.Return:
                    ReturnBehavior(directionToStart);
                    break;
                case EnemyState.Attack:
                    AttackBehavior();
                    break;
            }


        }
        
    }


    private void Update()
    {
        BehaviourManager();


        if (IsDead(health))
        {
            Destroy();
        }
    }

}

