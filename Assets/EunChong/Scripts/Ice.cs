using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] GameObject body;
    public GameObject[] ices;
    float angle;

    public void ChangeBody(int num, bool isShapeChanged)
    {
        Destroy(body);

        if (isShapeChanged)
        {
            switch(num)
            {
                case 2:
                    angle = 90;
                    break;
                case 3:
                    angle = 90;
                    break;
                case 6:
                    angle = 0;
                    break;
                default:
                    angle = 0;
                    break;
            }
        }
        else
        {
            switch (num)
            {
                case 2:
                    angle = 0;
                    break;
                case 3:
                    angle = 0;
                    break;
                case 6:
                    angle = 90;
                    break;
                default:
                    angle = 0;
                    break;
            }
        }

        body = Instantiate(ices[num - 1], transform.position, Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z)); 
    }
}
