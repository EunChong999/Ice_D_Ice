using UnityEngine;

public class Tree : MonoBehaviour
{
    #region Inspector
    public GameObject mesh;
    public Vector3 size;
    public string meshRendererAddress;
    public string materialAddress;
    #endregion

    private static MeshRenderer _treeMeshRenderer = null;
    /// <summary>
    /// 메쉬 참조
    /// </summary>
    private static MeshRenderer GetMeshRenderer(string address)
    {
        if (_treeMeshRenderer == null)
        {
            _treeMeshRenderer = Resources.Load<MeshRenderer>(address);
        }

        return _treeMeshRenderer;
    }

    private static Material _material = null;
    /// <summary>
    /// 머터리얼 참조
    /// </summary>
    private static Material GetMaterial(string address)
    {
        if (_material == null)
        {
            _material = Resources.Load<Material>(address);
        }

        return _material;
    }

    private void Awake()
    {
        // mesh GameObject에 MeshRenderer를 추가
        MeshRenderer meshRenderer = mesh.AddComponent<MeshRenderer>();

        // 머터리얼 할당
        meshRenderer.material = GetMaterial(materialAddress); 

        // mesh GameObject에 MeshFilter를 추가
        MeshFilter meshFilter = mesh.AddComponent<MeshFilter>();

        // 메쉬 할당
        meshFilter.sharedMesh = GetMeshRenderer(meshRendererAddress).GetComponent<MeshFilter>().sharedMesh;

        // 크기 설정
        mesh.transform.localScale = size;
    }
}
