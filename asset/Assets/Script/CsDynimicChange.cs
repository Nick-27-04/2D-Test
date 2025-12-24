using UnityEngine;
using UnityEngine.UI;

public class CsDynimicChange : MonoBehaviour
{
    CsMaterialSet01 csMat;
    CsMatSetActive csSetAc;

    public Button[] btn;

    int nKind = 0;

    bool bModel = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        csMat = GetComponent<CsMaterialSet01>();
       

        csMat.helmet02.SetActive(false);
        csMat.shirts02.SetActive(false);
        csMat.pants02.SetActive(false);
        csMat.boots02.SetActive(false);
    }

    public void Changehelmet01()
    {
        csMat.helmet02.SetActive(true);
        csMat.helmet01.SetActive(false);

        nKind++;

        if (nKind > csMat.helmet.Length-1)
        {
            nKind = 0;

        }

        csMat.CharMaterialSet(csMat.helmet01, csMat.helmet[nKind]);
    }

    public void Changehelmet02()
    {
        csMat.helmet02.SetActive(true);
        csMat.helmet01.SetActive(false);

        nKind++;

        if (nKind > csMat.helmet.Length - 1)
        {
            nKind = 0;

        }

        csMat.CharMaterialSet(csMat.helmet02, csMat.helmet[nKind]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
