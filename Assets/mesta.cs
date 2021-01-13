using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesta : MonoBehaviour
{

    public Vector3 erootus;
    public int uusien_lukumaara;
    public Transform perimmäänen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [ContextMenu("laita muutama")]
    private void laita_muutama_mesta()
    {
        Vector3 spede = transform.position+erootus;
        for (int a = 1; a < uusien_lukumaara; a++)
        {
            var pekka = Instantiate(gameObject, Vector3.Lerp(transform.position,perimmäänen.position,((float)a)/uusien_lukumaara), new Quaternion());
            pekka.transform.parent=transform.parent;
            pekka.transform.localScale = transform.localScale;
            spede += erootus;
        }
    }

}
