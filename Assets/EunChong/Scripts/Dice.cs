using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public int speed = 300;
    bool isMoving = false;
    bool canReveal = false;
    bool isRevealing = false;

    [SerializeField] Image[] hiddenImages;
    [SerializeField] Sprite[] diceFaces;
    [SerializeField] GameObject hiddenFaces;
    public Checker[] checkers;
    public Point[] xPoints;
    public Point[] yPoints;
    public Point[] zPoints;

    private void Update()
    {
        foreach (var x in xPoints)
        {
            if (x.isHidden)
            {
                hiddenImages[1].sprite = diceFaces[x.num - 1];
            }
        }

        foreach (var y in yPoints)
        {
            if (y.isHidden)
            {
                hiddenImages[2].sprite = diceFaces[y.num - 1];
            }
        }

        foreach (var z in zPoints)
        {
            if (z.isHidden)
            {
                hiddenImages[0].sprite = diceFaces[z.num - 1];
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            hiddenFaces.SetActive(false);
            canReveal = false;
            isRevealing = false;
        }

        if (!isMoving)
        {
            if (!canReveal)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(CoolTime());
                    canReveal = true;
                }
            }

            if (isRevealing)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    hiddenFaces.SetActive(true);
                }
            }

            if (Input.GetKey(KeyCode.W) && checkers[0].isCollisioning) // Z축으로 움직일 때
            {
                StartCoroutine(Roll(Vector3.forward));

                ChangeYZAxis();
            }
            else if (Input.GetKey(KeyCode.A) && checkers[1].isCollisioning) // X축으로 움직일 때
            {
                StartCoroutine(Roll(Vector3.left));

                ChangeXYAxis();
            }
            else if (Input.GetKey(KeyCode.S) && checkers[2].isCollisioning) // Z축으로 움직일 때
            {
                StartCoroutine(Roll(Vector3.back));

                ChangeYZAxis();
            }
            else if (Input.GetKey(KeyCode.D) && checkers[3].isCollisioning) // X축으로 움직일 때
            {
                StartCoroutine(Roll(Vector3.right));

                ChangeXYAxis();
            }
        }
        else
        {
            hiddenFaces.SetActive(false);
            canReveal = false;
            isRevealing = false;
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(0.1f);
        isRevealing = true;
    }

    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while(remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        Round();

        isMoving = false;
    }

    void Round()
    {
        // 현재 오브젝트의 포지션을 첫 번째 소수점에서 반올림합니다.
        Vector3 roundedPosition = new Vector3(
            Mathf.Round(transform.position.x * 10.0f) / 10.0f,
            Mathf.Round(transform.position.y * 10.0f) / 10.0f,
            Mathf.Round(transform.position.z * 10.0f) / 10.0f
        );

        // 반올림된 포지션을 현재 오브젝트에 적용합니다.
        transform.position = roundedPosition;

        // 현재 오브젝트의 회전을 첫 번째 소수점에서 반올림합니다.
        Vector3 roundedRotation = new Vector3(
            Mathf.Round(transform.rotation.eulerAngles.x * 10.0f) / 10.0f,
            Mathf.Round(transform.rotation.eulerAngles.y * 10.0f) / 10.0f,
            Mathf.Round(transform.rotation.eulerAngles.z * 10.0f) / 10.0f
        );

        // 반올림된 회전을 현재 오브젝트에 적용합니다.
        transform.rotation = Quaternion.Euler(roundedRotation);
    }

    void ChangeXYAxis()
    {
        Point[] xPointTemps = xPoints;
        Point[] yPointTemps = yPoints;

        foreach (var zPoint in zPoints)
        {
            zPoint.isShapeChanged = !zPoint.isShapeChanged;
        }

        xPoints = yPointTemps;
        yPoints = xPointTemps;
    }

    void ChangeYZAxis()
    {
        Point[] yPointTemps = yPoints;
        Point[] zPointTemps = zPoints;

        foreach (var xPoint in xPoints)
        {
            xPoint.isShapeChanged = !xPoint.isShapeChanged;
        }

        yPoints = zPointTemps;
        zPoints = yPointTemps;
    }
}

