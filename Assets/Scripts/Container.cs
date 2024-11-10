using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerArea")) // Make sure your area has this tag
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerArea"))
        {
            // gameObject.SetActive(false); // Hide the GameObject
            gameObject.GetComponent<MeshRenderer>().enabled = false;

        }
    }
}
