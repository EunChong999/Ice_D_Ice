using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoffMaskUI : Image
{
    protected override void Awake()
    {
        SetMaterialForRendering();
    }

    // materialForRendering 속성 오버라이딩
    public override Material materialForRendering
    {
        get
        {
            // 부모 클래스의 materialForRendering 속성 반환
            return base.material;
        }
    }

    // SetMaterialForRendering 메서드
    private void SetMaterialForRendering()
    {
        // 부모 클래스의 materialForRendering을 복제하여 새로운 Material 생성
        Material material = new Material(base.materialForRendering);
        // 스텐실 비교 함수를 NotEqual로 설정
        material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
        // 새로 생성한 재질을 기본 재질로 설정
        base.material = material;
    }
}
