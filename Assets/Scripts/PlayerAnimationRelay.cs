using UnityEngine;

public class PlayerAnimationRelay : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (playerAttack == null)
        {
            playerAttack = GetComponentInParent<PlayerAttack>();
        }

        if (playerMovement == null)
        {
            playerMovement = GetComponentInParent<PlayerMovement>();
        }
    }

    // Update is called once per frame
    public void OnAttack()
    {
        if (playerAttack == null) return;
        playerAttack.Attack();
    }

    public void OnCheckCombo()
    {
        if (playerAttack == null) return;
        playerAttack.CheckCombo();
    }

    public void OnClearCombo()
    {
        if (playerAttack == null) return;
        playerAttack.ClearCombo();
    }

    public void OnCheckFinal()
    {
        if (playerAttack == null) return;
        playerAttack.CheckFinal();
    }

    public void OnRunningSound()
    {
        if (playerMovement == null) return;
        playerMovement.FootStepSound();
    }

    public void PlayAttackSound1()
    {
        if (playerAttack == null) return;
        playerAttack.AttackSound1();
    }
    
    public void PlayAttackSound2()
    {
        if (playerAttack == null) return;
        playerAttack.AttackSound2();
    }
    
    public void PlayAttackSound3()
    {
        if (playerAttack == null) return;
        playerAttack.AttackSound3();
    }
}
