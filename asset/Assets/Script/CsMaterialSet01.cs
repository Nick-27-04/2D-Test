using UnityEngine;
using System.Collections;


public class CsMaterialSet01 : MonoBehaviour
{

    public Material[] colors;
    public Material[] boots;
    public Material[] pants;
    public Material[] shirts;

    public Material[] helmet = new Material[2];

    public GameObject arms;
    public GameObject brows;
    public GameObject hair;
    public GameObject head;

    public GameObject tail;

    public GameObject boots01;
    public GameObject boots02;
    public GameObject pants01;
    public GameObject pants02;
    public GameObject helmet01;
    public GameObject helmet02;
    public GameObject shirts01;
    public GameObject shirts02;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharMaterialSet(arms, colors[0]);
        CharMaterialSet(brows, colors[0]);
        CharMaterialSet(hair, colors[0]);
        CharMaterialSet(head, colors[0]);

        CharMaterialSet(boots01, boots[0]);
        CharMaterialSet(boots02, boots[1]);

        CharMaterialSet(pants01, pants[0]);
        CharMaterialSet(pants02, pants[1]);

        CharMaterialSet(shirts01, shirts[0]);
        CharMaterialSet(shirts02, shirts[1]);

        CharMaterialSet(helmet01, helmet[0]);
        CharMaterialSet(helmet02, helmet[1]);

    }

    public void CharMaterialSet(GameObject obj, Material mat)
    {
        obj.GetComponent<SkinnedMeshRenderer>().material = mat;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
