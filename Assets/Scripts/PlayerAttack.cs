using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public enum InputType {Keyboard, Joystick}
    public InputType inputType;

    private SoundManager soundManager;
    
    [SerializeField] private bool isAttacking, isDuringCombo, isFinal;
    
    [SerializeField] private Animator playerAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame

    void Awake()
    {
        if (playerAnim == null)
        {
            playerAnim = GetComponentInChildren<Animator>();
        }

        soundManager = FindFirstObjectByType<SoundManager>();
    }
    void Update()
    {
        if (inputType == InputType.Keyboard)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Attack();
            }
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            playerAnim.SetTrigger("Attack");
        }
        else
        {
            if (!isDuringCombo)
                isDuringCombo = true;
            else
                isFinal = true;
        }
    }

    public void CheckCombo()
    {
        if (isDuringCombo)
        {
            playerAnim.SetInteger("Combo", 1);
        }
        else
        {
            isAttacking = false;
            playerAnim.SetInteger("Combo", 0);
        }
    }

    public void CheckFinal()
    {
        if (isFinal)
        {
            playerAnim.SetInteger("Combo", 2);
        }
        else
        {
            isAttacking = false;
            isDuringCombo = false;
            playerAnim.SetInteger("Combo", 0);
        }
    }

    public void ClearCombo()
    {
        playerAnim.SetInteger("Combo", 0);
        isAttacking = false;
        isDuringCombo = false;
        isFinal = false;
    }

    public void AttackSound1()
    {
        soundManager.SoundOneShot("Attack1");
    }

    public void AttackSound2()
    {
        soundManager.SoundOneShot("Attack2");
    }

    public void AttackSound3()
    {
        soundManager.SoundOneShot("Attack3");
    }
}
