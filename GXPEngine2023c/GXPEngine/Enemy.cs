using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
    private int scoreGained = 1;

    private int buffType;
    private string buffTypeString;
    Buffs BuffType;
    private int ammoType;
    AmmoCase ammoCase;
    private string ammoCaseImg;
    UI ui;




    public float GetDamage() { return damage; }


    public Enemy() : base("Assets/Enemy.png", 4, 4)
    {
        scale = 0.2f;
        health = 5f;
        maxHealth = 5f;
        damage = 1;
        collider.isTrigger = true;
        SetOrigin(width / 2, height / 2);
        EnemyHealthInfo enemyHealthInfo = new EnemyHealthInfo();

        ui = game.FindObjectOfType<UI>();

        //AddChild(enemyHealthInfo);
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
        SetCycle(0, 3);
        Collision col = MoveUntilCollision(p.x * speed, 0);  //move in x-axis
        
        if (col == null) // if no collison on x
        {
            if (p.x > 0) { SetCycle(8, 2); } else if(p.x < 0) { SetCycle(10, 2); }
            col = MoveUntilCollision(0, p.y * speed); //move in y-axis

            if (col != null)  //if collision on y
            {
                if (cooldownX <= 0)
                {
                    movementAdjustment = (p.x + (Mathf.Sign(p.x) - p.x));
                    cooldownX = movementCooldown;
                }
                else 
                {
                    cooldownX -= Time.deltaTime;
                    if (movementAdjustment >= 0) { SetCycle(4, 2); } else { SetCycle(12, 2); }
                    MoveUntilCollision(movementAdjustment * speed, 0); //move in ONLY x-axis
                }
                
            }
        }
        else //if collision on x
        {
            if (cooldownY <= 0)
            {
                movementAdjustment = (p.y + (Mathf.Sign(p.y) - p.y));
                cooldownY = movementCooldown;
            }
            else 
            {
                cooldownY -= Time.deltaTime;
                if (movementAdjustment >= 0) { SetCycle(8, 2); } else { SetCycle(10, 2); }
                MoveUntilCollision(0, movementAdjustment*speed); // move in ONLY y-axis
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


            if (distanceToTargetPlayer < 10000f && distanceToTargetPlayer > 16f)
            {
                currentState = EnemyState.Chase;
            }
            else
        if (distanceToTargetPlayer < 16f)
            {
                currentState = EnemyState.Attack;
            }
            else
        if (distanceToTargetPlayer > 10000f)
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



    private void GenerateAmmoType() 
    { 
        Random random = new Random();
        ammoType = random.Next(0,3);
        switch (ammoType)
        {
            case 0:
                ammoCaseImg = "Assets/pistol_AmmoCase.png";
                break;
            case 1:
                ammoCaseImg = "Assets/rifle_AmmoCase.png";
                break;
            case 2:
                ammoCaseImg = "Assets/shotgun_AmmoCase.png";
                break;
        }

        ammoCase = new AmmoCase(ammoCaseImg, ammoType);
        ammoCase.x = x; ammoCase.y = y;
        parent.AddChild(ammoCase);

    }

    private void GenerateBuffDrop() 
    {
        Random random = new Random();
        buffType = random.Next(0, 100);
        switch (buffType) 
        {
            //player buffs
            case 0:
                buffTypeString = "speed";
                break;
            case 1:
                buffTypeString = "invulernableWindow";
                break;
            case 2:
                buffTypeString = "health";
                break;

                // weapon dmg buffs
            case 3:
                buffTypeString = "pistolDamage";
                break;
            case 4:
                buffTypeString = "assaultDamage";
                break;
            case 5:
                buffTypeString = "shotgunDamage";
                break;

                //weapon fireRate buffs
            case 6:
                buffTypeString = "pistolFireRate";
                break;
            case 7:
                buffTypeString = "assaultFireRate";
                break;
            case 8:
                buffTypeString = "shotgunFireRate";
                break;

                //weapon range buffs
            case 9:
                buffTypeString = "pistolAmmoGained";
                break;
            case 10:
                buffTypeString = "assaultAmmoGained";
                break;
            case 11:
                buffTypeString = "shotgunAmmoGained";
                break;

        }

        if (buffTypeString != null) 
        {
            BuffType = new Buffs("Assets/Buff.png", buffTypeString);
            BuffType.x = x; BuffType.y = y;
            parent.AddChild(BuffType);
        }

    }

    private void Update()
    {
        Animate(0.085f);
        BehaviourManager();


        if (IsDead(health))
        {
            GenerateBuffDrop();

            GenerateAmmoType();
            
            ui._Score += scoreGained;
            Destroy();
        }
    }

}

