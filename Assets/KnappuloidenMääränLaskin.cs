using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class KnappuloidenMääränLaskin : MonoBehaviour
{
    public GameObject lopputeksti;

    void Start()
    {
    }

    void Update()
    {
    }

    public void LaskeKnappuloidenMäärä()
    {
        int perilleRaijjattujenMäärä = FindObjectsOfType<Knappula>().Count(knappula => knappula.tämänhetkinenRivinumero > 13);
        GetComponent<TextMeshPro>().text = $"Raijjattu perille:\n{perilleRaijjattujenMäärä}/10";

        if (perilleRaijjattujenMäärä == 10)
        {
            lopputeksti.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
