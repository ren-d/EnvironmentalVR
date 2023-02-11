using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 newScale;
    public GameObject newModel;
    private float timer = 0;
    public float timeToShrink = 3;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.active)
            return;

        timer += Time.deltaTime;
        newScale = originalScale * (1 - (timer / timeToShrink));

        transform.localScale = newScale;
        if (transform.localScale.y <= 0.1)
        {
            GameObject g = Instantiate(newModel, transform.position, Quaternion.identity);
            this.transform.gameObject.SetActive(false);
        }
    }

}
