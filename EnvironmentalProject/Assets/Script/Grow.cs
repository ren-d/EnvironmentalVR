using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 newScale;
    private float timer = 0;
    public float timeToGrow = 3;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        originalScale = new Vector3(originalScale.x, 1, originalScale.z);
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y < 1.0f)
        {
            timer += Time.deltaTime;
            newScale = originalScale * (timer / timeToGrow);

            transform.localScale = newScale;
        }

        if (!gameObject.active)
            return;

  
    }
}
