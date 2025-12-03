using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector2 startPos, currentPos;
    private float maxDistance = 75f;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;
    [SerializeField] private GameObject backgroundUI;

    [SerializeField] private GameObject handleUI;
    [SerializeField] private Button jumpButton;
    [SerializeField] private Button attackButton;

    private void Awake()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        playerAttack = FindFirstObjectByType<PlayerAttack>();
        jumpButton.onClick.AddListener(playerMovement.Jump);
        attackButton.onClick.AddListener(playerAttack.Attack);
    }

    void Start()
    {
        backgroundUI.SetActive(false);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position;
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentPos = eventData.position;
        Vector2 dragDir = currentPos - startPos;
        dragDir = Vector2.ClampMagnitude(dragDir, maxDistance);
        
        playerMovement.InputJoystick(dragDir.normalized.x, dragDir.normalized.y);
        currentPos = startPos + dragDir;

        handleUI.transform.position = currentPos;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.InputJoystick(0f,0f);
        handleUI.transform.localPosition = Vector3.zero;
        backgroundUI.SetActive(false);
    }
}
