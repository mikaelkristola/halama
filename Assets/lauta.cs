using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lauta : MonoBehaviour
{
    //Vector2 ernesti;
    public Knappula tälläHetkelläRaijattavaKnappula;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDrag()
    {
    }

    private void OnMouseDown()
    {
        Debug.Log("Jarmo");
    }

    public GameObject mesta;

    public int reiska;

    [Range(0.85f,0.9f)]
    public float välimatka_y = 0.03f;

    public float välimatka_x = 0.03f;

    public float y_alootus = 0;
    public float x_alootus = 0;

    private mesta mestaJohonOllaanHyppäämääsillään;
    private Vector2 pisteJohnaHiiriMeniAlaha;

    //[ContextMenu("tee mestat")]
    private void OnValidate()
    {
        int[] rivit=new int[17];

        rivit[0] = 1;
        rivit[1] = 2;
        rivit[2] = 3;
        rivit[3] = 4;
        rivit[4] = 13;
        rivit[5] = 12;
        rivit[6] = 11;
        rivit[7] = 10;
        rivit[8] = 9;
        rivit[9] = 10;
        rivit[10] = 11;
        rivit[11] = 12;
        rivit[12] = 13;
        rivit[13] = 4;
        rivit[14] = 3;
        rivit[15] = 2;
        rivit[16] = 1;

        int reiska = 0;

        List<mesta> mestat = new List<mesta>();
        GetComponentsInChildren<mesta>(mestat);

//        össi.Clear();

        int monesko_rivi = 0;
        foreach (int a in rivit)
        {
            monesko_rivi++;
            for(int b = 0; b < a; b++)
            {
                
                 if (reiska >= mestat.Count)
                                {
                                            GameObject spede = Instantiate(mesta, new Vector3(), new Quaternion());
                                            spede.transform.parent = transform;
                                    mestat.Add(spede.GetComponent<mesta>());
                                }
                                mestat[reiska].transform.position = new Vector3(b * välimatka_x-a*välimatka_x/2+x_alootus, monesko_rivi * välimatka_y+y_alootus, -1);

                mestat[reiska].GetComponent<SpriteRenderer>().enabled = false;

//                össi.Add(new Vector2(b * välimatka_x - a * välimatka_x / 2 + x_alootus, monesko_rivi * välimatka_y + y_alootus));

                reiska++;
            }
        }

        


    }

/*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach(var paavo in össi){
            Gizmos.DrawSphere(paavo, 0.3f);
        }
    }
*/

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            //ernesti = vasili;
            foreach (Collider2D coll in Physics2D.OverlapPointAll(mouseWorld))
            {
                Knappula knappula = coll.GetComponent<Knappula>();
                if (knappula)
                {
                    tälläHetkelläRaijattavaKnappula = knappula;
                    pisteJohnaHiiriMeniAlaha = mouseWorld;
                }
            }
        }

        if (Input.GetMouseButton(0) && tälläHetkelläRaijattavaKnappula != null)
        {
            Vector2 raijausSuunta = mouseWorld - pisteJohnaHiiriMeniAlaha;
            //int taneli = KulmaJohonaPäinNappulaOn(raijausSuunta);
            float taneli = Mathf.Round(Mathf.Atan2(raijausSuunta.y, raijausSuunta.x) / Mathf.PI * 3f) / 3f * Mathf.PI;
            //Debug.Log(Mathf.Round(Mathf.Atan2(raijausSuunta.y, raijausSuunta.x) / Mathf.PI * 3f) / 3f * Mathf.PI * Mathf.Rad2Deg);
            mestaJohonOllaanHyppäämääsillään = null;

            Vector2 heikki;
            heikki.x = Mathf.Cos(taneli);
            heikki.y = Mathf.Sin(taneli);
            heikki *= välimatka_x;

            foreach (Collider2D coll in Physics2D.OverlapPointAll(
                tälläHetkelläRaijattavaKnappula.transform.position + new Vector3(heikki.x, heikki.y, 0f)))
            {
                mesta mst = coll.GetComponent<mesta>();
                if (mst && raijausSuunta.magnitude > 0.5f)
                {
                    mestaJohonOllaanHyppäämääsillään = mst;
                    Debug.DrawLine(
                        mst.transform.position - new Vector3(0.3f, 0, 0),
                        mst.transform.position + new Vector3(0.3f, 0, 0), Color.red);
                    Debug.DrawLine(
                        mst.transform.position - new Vector3(0, 0.3f, 0),
                        mst.transform.position + new Vector3(0, 0.3f, 0), Color.red);
                }
            }
          
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (tälläHetkelläRaijattavaKnappula && mestaJohonOllaanHyppäämääsillään)
            {
                // Paa knappula uuteen paikkaan
                tälläHetkelläRaijattavaKnappula.transform.position = mestaJohonOllaanHyppäämääsillään.transform.position;
            }
            tälläHetkelläRaijattavaKnappula = null;
            mestaJohonOllaanHyppäämääsillään = null;
        }
    }

    private int KulmaJohonaPäinNappulaOn(Vector2 suunta)
    {
        if (suunta.x < 0)
        {

            if (suunta.y < -50)
            {
                return 240;
            }
            if (suunta.y > 50)
            {
                return 120;
            }
            if (Mathf.Abs(suunta.y) < 50)
            {
                return 180;
            }
        }
        else
        {
            if (suunta.y < -50)
            {
                return 300;
            }
            if (suunta.y > 50)
            {
                return 60;
            }
            if (Mathf.Abs(suunta.y) < 50)
            {
                return 0;
            }
        }
        return 0;
    }
}
