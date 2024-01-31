public class EnemyAttack : PersonAttack
{
    EnemyAttack()
    {
        damageToEnemy = 10;
    }

    protected override bool Attacking()
    {
        if (attackTimer == 0)
        {
            animator.SetTrigger("Attack");
            PerformAttack();
            return true;
        }
        else
            return false;
    }

}
