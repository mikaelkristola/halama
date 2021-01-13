using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SiirtojenMääränLaskin : MonoBehaviour
{
    private int siirtojenMäärä = 0;

    void Start()
    {
    }

    void Update()
    {
    }

    public void TehtiinSiirto()
    {
        siirtojenMäärä++;
        GetComponent<TextMeshPro>().text = $"Siirtojen\nmäärä:\n{siirtojenMäärä}";
    }
}
