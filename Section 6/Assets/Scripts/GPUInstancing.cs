using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUInstancing : MonoBehaviour {

    public int instances;
    public Mesh mesh;
    public Material material;
    public Vector3 maxPos;

    private Matrix4x4[] matrices;

	// Use this for initialization
	void Start () {
        matrices = new Matrix4x4[instances];
        for (int i = 0; i < instances; i++)
        {
            Vector3 newPos = new Vector3(Random.Range(-maxPos.x, maxPos.x),
                                         Random.Range(-maxPos.y, maxPos.y),
                                         Random.Range(-maxPos.z, maxPos.z));
            matrices[i] = Matrix4x4.TRS(newPos, Quaternion.identity, Vector3.one);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Graphics.DrawMeshInstanced(mesh, 0, material, matrices);
	}
}
