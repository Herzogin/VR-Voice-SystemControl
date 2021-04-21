using System.Collections;
using UnityEngine;

public class InfotextCanvasAppears : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InfotextAppears());
        StartCoroutine(InfotextVanishes());
    }

    private IEnumerator InfotextAppears()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Canvas>().enabled = true;
    }

    private IEnumerator InfotextVanishes()
    {
        yield return new WaitForSeconds(10f);
        GetComponent<Canvas>().enabled = false;
    }
}