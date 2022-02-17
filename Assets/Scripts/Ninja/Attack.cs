using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Attack : MonoBehaviour
{
    private const string Attacking = "Attack";
    private const string ExtraAttack = "Extra_Attack";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AttackEnemy();        
    }

    private void AttackEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(Attacking);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _animator.SetTrigger(ExtraAttack);
        }
    }
}
