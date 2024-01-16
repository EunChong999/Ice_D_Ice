using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CutoffMaskUI : Image
{
    private bool materialNeedsUpdate = true;

    // LateUpdate is called after Update each frame
    private void LateUpdate()
    {
        // Check if material needs to be updated
        if (materialNeedsUpdate)
        {
            SetMaterialForRendering();
            materialNeedsUpdate = false;
        }
    }

    // materialForRendering property overriding
    public override Material materialForRendering
    {
        get
        {
            // Return the base materialForRendering without modifying it here
            return base.material;
        }
    }

    // SetMaterialForRendering method
    private void SetMaterialForRendering()
    {
        Material material = new Material(base.materialForRendering);
        material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);

        // Assign the new material to the base material property
        base.material = material;
    }

    // Method to trigger material update from outside the class
    public new void UpdateMaterial()
    {
        materialNeedsUpdate = true;
    }
}
