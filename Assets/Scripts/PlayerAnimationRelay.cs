using UnityEngine;

public class PlayerAnimationRelay : MonoBehaviour
{
    [SerializeField] private PlayerAttack playerAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (playerAttack == null)
        {
            playerAttack = GetComponentInParent<PlayerAttack>();
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
}
