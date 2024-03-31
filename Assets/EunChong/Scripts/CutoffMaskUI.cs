using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoffMaskUI : Image
{
    private bool materialNeedsUpdate = true;

    private void LateUpdate()
    {
        // 재질이 업데이트되어야 하는지 확인
        if (materialNeedsUpdate)
        {
            // 렌더링을 위한 재질 설정 메서드 호출
            SetMaterialForRendering();
            // 재질이 업데이트되었음을 표시
            materialNeedsUpdate = false;
        }
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

    // 클래스 외부에서 재질 업데이트를 트리거하는 메서드
    public new void UpdateMaterial()
    {
        // 재질 업데이트 필요 플래그를 설정
        materialNeedsUpdate = true;
    }
}
