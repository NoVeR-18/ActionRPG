using UnityEngine;

public class PersonAttack : OverlapAttack
{
    [SerializeField]
    protected float attackTimer;
    [SerializeField]
    private float coolDown;
    [SerializeField]
    protected bool isAttacking = false;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected int damageToEnemy;

    void Start()
    {
        attackTimer = 0;
        coolDown = 1.0f;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isAttacking)
        {
            //animator.SetBool("attack", true);
        }
        else
        {
            //animator.SetBool("attack", false);
        }
    }
    void FixedUpdate()
    {
        AttackTimer();
    }
    private void AttackTimer()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;

        if (attackTimer < 0)
        {
            attackTimer = 0;
        }
        if (Attacking())
        {
            isAttacking = true;
            attackTimer = coolDown;
        }
        else
        {
            isAttacking = false;
        }
    }
    //protected virtual void OnTriggerStay2D(Collider2D collider)
    //{
    //    if (collider.tag == "Player" && isAttacking)
    //        collider.GetComponent<IDamageable>().ApplyDamage(damageToEnemy);
    //}
    protected virtual bool Attacking()
    {
        return false;
    }
}
