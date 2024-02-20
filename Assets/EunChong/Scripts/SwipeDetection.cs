using System;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTime = 1;
    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = .9f;

    [HideInInspector]
    public Dice dice;

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
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        StartHolding();
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
        StopHolding();
    }

    private void DetectSwipe()
    {
        if (!canShow)
        {
            if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && (endTime - startTime) <= maximumTime)
            {
                Vector3 direction = endPosition - startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
                SwipeDirection(direction2D);
            }
        }

        canShow = false;
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (dice != null)
        {
            if (Vector2.Dot(new Vector2(-1, 1), direction) > directionThreshold)
            {
                dice.order = 0;
            }

            else if (Vector2.Dot(new Vector2(-1, -1), direction) > directionThreshold)
            {
                dice.order = 1;
            }

            else if (Vector2.Dot(new Vector2(1, -1), direction) > directionThreshold)
            {
                dice.order = 2;
            }

            else if (Vector2.Dot(new Vector2(1, 1), direction) > directionThreshold)
            {
                dice.order = 3;
            }

            else
            {
                dice.order = -1;
            }
        }
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
