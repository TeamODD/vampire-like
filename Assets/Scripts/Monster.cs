using System;
using Database.Data.Monsters;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterEntityData MonsterData;
    public SpriteRenderer SpriteRenderer;
    public float Hp;
    public float Speed;
    
    public Transform Target;
    public Rigidbody2D Rigidbody2D;
    public Animator Animator;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }

    public void Initialize(MonsterEntityData monsterData, Transform target)
    {
        MonsterData = monsterData;
        SpriteRenderer.sprite = monsterData.Sprite;
        Animator.runtimeAnimatorController = monsterData.AnimatorController;
        Hp = monsterData.Hp;
        Speed = monsterData.Speed;
        
        Target = target;
    }

    private void FixedUpdate()
    {
        Vector2 direction = Target.position - transform.position; 
        Rigidbody2D.MovePosition(Rigidbody2D.position + direction.normalized * Speed / 100 * Time.fixedDeltaTime);
        Rigidbody2D.linearVelocity = Vector2.zero;
    }
}
