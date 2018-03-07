using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSnow : MonoBehaviour {
    public Camera _Camera;
    public Shader _drawShader;
    public GameObject WheelesBL;
    public GameObject WheelesBR;


    private RenderTexture _splatmap;
    private Material _snowMaterial, _drawMaterial;
    private RaycastHit _hit;
    private RaycastHit _Wheele1;

	// Use this for initialization
	void Start () {
        _drawMaterial = new Material(_drawShader);
        _drawMaterial.SetVector("_Color", Color.red);

        _snowMaterial = GetComponent<MeshRenderer>().material;
        _splatmap = new RenderTexture(2048, 2048, 0, RenderTextureFormat.ARGBFloat);
        _snowMaterial.SetTexture("_Splat", _splatmap);
    }
	
	// Update is called once per frame
	void Update () {

       if (Physics.Raycast(WheelesBL.transform.position, new Vector3(0,-1,0), out _hit))
            {
            RaycastHitWheele();
            }
        if (Physics.Raycast(WheelesBR.transform.position, new Vector3(0, -1, 0), out _hit))
        {
            RaycastHitWheele();
        }
    }
    private void OnGUI()
    {
        //GUI.DrawTexture(new Rect(0, 0, 256, 256), _splatmap, ScaleMode.ScaleToFit, false, 1);
    }

    private void RaycastHitWheele()
    {
        _drawMaterial.SetVector("_Coordinate", new Vector4(_hit.textureCoord.x, _hit.textureCoord.y, 0, 0));
        RenderTexture temp = RenderTexture.GetTemporary(_splatmap.width, _splatmap.height, 0, RenderTextureFormat.ARGBFloat);
        Graphics.Blit(_splatmap, temp);
        Graphics.Blit(temp, _splatmap, _drawMaterial);
        RenderTexture.ReleaseTemporary(temp);
    }
}
