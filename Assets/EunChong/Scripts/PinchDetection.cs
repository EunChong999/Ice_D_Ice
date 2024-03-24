using Cinemachine;
using System.Collections;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{
    public bool isZooming;
    private bool canZoom;

    [SerializeField]
    private float cameraSpeed = 4f;

    private PlayerControls controls;
    private Coroutine zoomCoroutine;

    public CinemachineVirtualCamera cinemachine;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        cinemachine = FindObjectOfType<CinemachineVirtualCamera>();
        controls.Touch.SecondaryTouchContact.started += _ => ZoomStart();
        controls.Touch.PrimaryTouchContact.canceled += _ => ZoomEnd();
        controls.Touch.SecondaryTouchContact.canceled += _ => ZoomEnd();
    }

    private void ZoomStart()
    {
        isZooming = true;
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd()
    {
        isZooming = false;
        StopCoroutine(zoomCoroutine);
    }

    IEnumerator ZoomDetection()
    {
        float previousDistance = 0f, distance = 0f;
        while (true)
        {
            distance = Vector2.Distance(controls.Touch.PrimaryFingerPosition.ReadValue<Vector2>(),
                controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());

            // 줌아웃
            if (distance > previousDistance)
            {
                float targetPosition = cinemachine.m_Lens.OrthographicSize;
                targetPosition -= 1;
                cinemachine.m_Lens.OrthographicSize = Mathf.MoveTowards(cinemachine.m_Lens.OrthographicSize, 
                    targetPosition, 
                    Time.deltaTime * cameraSpeed);
                cinemachine.m_Lens.OrthographicSize = Mathf.Clamp(cinemachine.m_Lens.OrthographicSize, 6f, 10f);
            }

            // 줌인
            else if (distance < previousDistance)
            {
                float targetPosition = cinemachine.m_Lens.OrthographicSize;
                targetPosition += 1;
                cinemachine.m_Lens.OrthographicSize = Mathf.MoveTowards(cinemachine.m_Lens.OrthographicSize,
                    targetPosition,
                    Time.deltaTime * cameraSpeed);
                cinemachine.m_Lens.OrthographicSize = Mathf.Clamp(cinemachine.m_Lens.OrthographicSize, 6f, 10f);
            }

            // 다음 루프를 위해 이전 거리를 기록
            previousDistance = distance;
            yield return null;
        }
    }
}

