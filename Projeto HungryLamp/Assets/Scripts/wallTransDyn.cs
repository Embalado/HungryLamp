using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallTransDyn : MonoBehaviour
{
    private transparentWall transWallScript;
    private Renderer renderMaterial = new Renderer();
    public Material[] material;
    bool canChange = false;
    // Use this for initialization
    float timer = 0.03f;
    void Start()
    {
        GameObject transp = GameObject.Find("Main Camera");
        transWallScript = transp.GetComponent<transparentWall>();

        renderMaterial = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transWallScript.hitpoint.transform == transform)
        {
            // renderMaterial.sharedMaterial = material[1];
            StartCoroutine(FadeOutMaterial(0.2f));
            

            //if (renderMaterial.materials[0].color.a > 0.5f)
            //{
            //    Color cor = renderMaterial.materials[0].color;
            //    timer -= 0.002f*Time.deltaTime;
            //    cor.a -= timer;
            //    renderMaterial.materials[0].color = cor;
            //    Debug.Log("cor"+cor.a);
            //}
            //else if (renderMaterial.materials[0].color.a < 1)
            //{
            //    timer += Time.deltaTime;
            //    Color cor = renderMaterial.materials[0].color;
            //    cor.a = timer; ;
            //   renderMaterial.materials[0].color = cor;
            //}
        }
        else
        {
            if (canChange==true)
            {
                StartCoroutine(FadeInObject());
                canChange = false;
            }
             
            // renderMaterial.sharedMaterial = material[0];
        }


    }
    public IEnumerator FadeInObject()
    {

        while (this.GetComponent<Renderer>().material.color.a < 1)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + (timer * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;

        }
        renderMaterial.sharedMaterial = material[0];
    }
    IEnumerator FadeOutMaterial(float fadeSpeed)
    {
        renderMaterial.sharedMaterial = material[1];
        Color matColor = renderMaterial.material.color;
        float alphaValue = renderMaterial.material.color.a;

        while (renderMaterial.material.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            renderMaterial.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        renderMaterial.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        canChange = true;

    }



}

