using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingDetection : MonoBehaviour
{
    private InputManager inputManager;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;

    private float holdingTime;

    [SerializeField]
    private float limitTime;

    [HideInInspector]
    public bool holding;

    [HideInInspector]
    public bool canShow;

    [HideInInspector]
    public Dice dice;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void Start()
    {
        dice = GetComponent<Dice>();
    }

    private void Update()
    {
        if (holding)
        {
            holdingTime += Time.deltaTime;
        }

        if (holdingTime > limitTime)
        {
            canShow = true;
        }
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += HoldingStart;
        inputManager.OnEndTouch += HoldingEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= HoldingStart;
        inputManager.OnEndTouch -= HoldingEnd;
    }

    private void HoldingStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        StartHolding();
    }

    private void HoldingEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        StopHolding();
    }

    private void StartHolding()
    {
        holding = true;
    }

    private void StopHolding()
    {
        holding = false;
        holdingTime = 0;
    }
}
