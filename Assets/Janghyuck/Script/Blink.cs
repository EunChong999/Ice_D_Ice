using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Blink : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // TextMeshProUGUI 컴포넌트를 가져옵니다.
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // 깜빡이는 코루틴을 시작합니다.
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            // 텍스트를 비활성화합니다.
            textMeshPro.enabled = false;

            // 0.5초 동안 대기합니다.
            yield return new WaitForSeconds(0.5f);

            // 텍스트를 활성화합니다.
            textMeshPro.enabled = true;

            // 0.5초 동안 대기합니다.
            yield return new WaitForSeconds(0.5f);
        }
    }
}
