using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheCube : MonoBehaviour
{
    public float inputThreshold;
    public float duration;

    [SerializeField] bool isRolling = false;
    float scale;

    private void Start()
    {
        scale = transform.localScale.x / 2;
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (!isRolling &&
            ((x > inputThreshold || x < -inputThreshold) || 
            (y > inputThreshold || y < -inputThreshold)))
        {
            isRolling = true;
            StartCoroutine(RollingCube(x, y));
            transform.Translate(Vector3.left * x * 10 * Time.deltaTime);
        }
    }

    IEnumerator RollingCube(float x, float y)
    {
        float elapsed = 0;
        Vector3 point = Vector3.zero;
        Vector3 axis = Vector3.zero;
        float angle = 0;
        Vector3 direction = Vector3.zero;

        if (x != 0)
        {
            axis = Vector3.forward;
            point = x > 0 ?
                transform.position + (Vector3.right * scale) :
                transform.position + (Vector3.left * scale);
            angle = x > 0 ? -90 : 90;
            direction = x > 0 ? Vector3.right : Vector3.left;
        }
        else if (y != 0)
        {
            axis = Vector3.right;
            point = y > 0 ?
                transform.position + (Vector3.forward * scale) :
                transform.position + (Vector3.back * scale);
            angle = y > 0 ? 90 : -90;
            direction = y > 0 ? Vector3.forward : Vector3.back;
        }
        point += new Vector3(0, -scale, 0);
        Vector3 adjustPos = (point + direction * scale) - new Vector3(0, -0.5f, 0);
        Quaternion adjustRotation = Quaternion.Euler(direction);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            transform.RotateAround(
                point,
                axis,
                angle / duration * Time.deltaTime 
            );

            yield return null;
        }

        transform.position = adjustPos;
        transform.rotation = adjustRotation;
        isRolling = false;
    }
}
