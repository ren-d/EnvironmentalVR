using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public GameObject objectGrab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(this.gameObject.transform.position, this.gameObject.transform.forward);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.GetComponent<TrashItem>())
            {
                objectGrab = hit.collider.gameObject;
            }
        }
    }
}
