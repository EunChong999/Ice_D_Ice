using System;
using UnityEngine;

public class FlyweightObject : MonoBehaviour
{
    #region Inspector
    public GameObject mesh;
    public string meshRendererAddress;
    public string materialAddress;
    #endregion

    private void Awake()
    {
        // mesh GameObject에 MeshRenderer를 추가합니다.
        MeshRenderer meshRenderer = mesh.AddComponent<MeshRenderer>();
        
        meshRenderer.material = Resources.Load<Material>(materialAddress);

        // mesh GameObject에 MeshFilter를 추가합니다.
        MeshFilter meshFilter = mesh.AddComponent<MeshFilter>();
        // mesh GameObject의 Mesh를 Low Poly Tree의 Mesh로 설정합니다.
        meshFilter.sharedMesh = Resources.Load<MeshRenderer>(meshRendererAddress).GetComponent<MeshFilter>().sharedMesh;

        // 크기 설정
        // 현재 객체의 크기를 (X: 10, Y: 10, Z: 10)으로 설정합니다.
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
