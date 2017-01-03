using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Combine_Meshes : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>(true);

        Mesh finalMesh = new Mesh();

        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].subMeshIndex = 0;
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            //meshFilters[i].gameObject.SetActive(false);
        }

        finalMesh.CombineMeshes(combine);
        GetComponent<MeshFilter>().sharedMesh = finalMesh;

//        transform.GetComponent<MeshFilter>().mesh = new Mesh();
//        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
//        transform.gameObject.SetActive(true);
	
	}
	
}
