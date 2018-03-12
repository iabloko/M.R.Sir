using UnityEngine;

public class ScriptSnow : MonoBehaviour {
    public Shader _drawShader;
    public GameObject WheelesBL, WheelesBR, _Terrain;


    [Range(1,5000)]
    public float _brushSize;
    [Range(1,100)]
    public float _brushStrength;

    private RenderTexture _splatmap;
    private Material _snowMaterial, _drawMaterial;
    private RaycastHit _Wheele1;

	void Start () {
        _drawMaterial = new Material(_drawShader);

        _snowMaterial = GetComponent<MeshRenderer>().material;
        _splatmap = new RenderTexture(2048, 2048, 0, RenderTextureFormat.ARGBFloat);
        _snowMaterial.SetTexture("_Splat", _splatmap);
    }
	

	void FixedUpdate() {
       if (Physics.Raycast(WheelesBL.transform.position, new Vector3(0, -1, 0), out _Wheele1))
            {
                RaycastHitWheele();
            }
       if (Physics.Raycast(WheelesBR.transform.position, new Vector3(0, -1, 0), out _Wheele1))
            {
                RaycastHitWheele();
            }
    }

    private void RaycastHitWheele()
    {
        _drawMaterial.SetVector("_Coordinate", new Vector4(_Wheele1.textureCoord.x, _Wheele1.textureCoord.y, 0, 0));
        _drawMaterial.SetFloat("_Strenght", _brushStrength);
        _drawMaterial.SetFloat("_Size", _brushSize);
        RenderTexture temp = RenderTexture.GetTemporary(_splatmap.width, _splatmap.height, 0, RenderTextureFormat.ARGBFloat);
        Graphics.Blit(_splatmap, temp);
        Graphics.Blit(temp, _splatmap, _drawMaterial);
        RenderTexture.ReleaseTemporary(temp);
    }
}
