using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public bool isFlickering;
    public int Flickermode;
    public float FlickerTime;

     public GameObject lightSource;
    // Start is called before the first frame update
    void Start()
    {
        isFlickering = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickerLight());
        }
    }

    IEnumerator FlickerLight()
    {
        if (Flickermode == 1)
        {
            //this.gameObject.GetComponent<Light>().enabled = false;
            lightSource.SetActive(false);
            FlickerTime = Random.Range(0f, 0.26f);
            yield return new WaitForSeconds(FlickerTime);
            lightSource.SetActive(true);
            //this.gameObject.GetComponent<Light>().enabled = true;
            isFlickering = false;
        }
    }
}
