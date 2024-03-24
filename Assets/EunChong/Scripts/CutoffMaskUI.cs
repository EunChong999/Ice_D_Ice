using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoffMaskUI : Image
{
    private bool materialNeedsUpdate = true;

    // LateUpdate는 매 프레임마다 Update 후에 호출됩니다.
    private void LateUpdate()
    {
        // 재질이 업데이트되어야 하는지 확인합니다.
        if (materialNeedsUpdate)
        {
            SetMaterialForRendering();
            materialNeedsUpdate = false;
        }
    }

    // materialForRendering 속성 오버라이딩
    public override Material materialForRendering
    {
        get
        {
            // 여기서는 기본 materialForRendering을 수정하지 않고 반환합니다.
            return base.material;
        }
    }

    // SetMaterialForRendering 메서드
    private void SetMaterialForRendering()
    {
        Material material = new Material(base.materialForRendering);
        material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);

        // 새로운 재질을 기본 재질 속성에 할당합니다.
        base.material = material;
    }

    // 클래스 외부에서 재질 업데이트를 트리거하는 메서드
    public new void UpdateMaterial()
    {
        materialNeedsUpdate = true;
    }
}
