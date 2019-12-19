using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrow : MonoBehaviour
{
    private bool isGrowing = false;

    private float minSize, maxSize;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < maxSize && isGrowing)
        {
            Vector3 localObjScale = transform.localScale;
            localObjScale += new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
            transform.localScale = localObjScale;
        }
        else if (transform.localScale.x > minSize && !isGrowing)
        {
            Vector3 localObjScale = transform.localScale;
            localObjScale -= new Vector3(Time.deltaTime * 5.0f, Time.deltaTime * 5.0f, Time.deltaTime * 5.0f);
            transform.localScale = localObjScale;
        }
    }
    public void GrowObj(string objMaxSize)
    {
        isGrowing = true;
        maxSize = float.Parse(objMaxSize);
    }
    public void ShrinkObj(string objMinSize)
    {
        isGrowing = false;
        minSize = float.Parse(objMinSize);
    }
}
