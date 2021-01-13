using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kolomio : MonoBehaviour
{
    // Start is called before the first frame update
    void OnValidate()
    {
        Mesh jarmo = new Mesh();
        int[] jorma = new int[3]{ 0,2,1};
        Vector3[] jaroslav = new Vector3[3] { new Vector3( -1, -1,0), new Vector3(1, 1,0), new Vector3(-1, 1,0) };
        jarmo.vertices = jaroslav;
        jarmo.triangles = jorma;
        GetComponent<MeshFilter>().mesh=jarmo;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Screen.width / 800f * -4f, transform.position.y, transform.position.z);
    }
}
