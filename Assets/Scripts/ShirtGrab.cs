using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtGrab : MonoBehaviour
{

    public GameObject Shirt;

    public string colliderName;

    private string childName = "Casual_Look_Final_Top";
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
        if (other.gameObject.name == colliderName) // Make sure your area has this tag
        {
            Debug.Log("wear the clothes now");
            Shirt.SetActive(true);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("TriggerArea")) // Make sure your area has this tag
        {
            Transform child = gameObject.transform.Find(childName);
            child.gameObject.SetActive(true);
            //gameObject.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("enter");
        }


    }

        private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerArea"))
        {
            Transform child = gameObject.transform.Find(childName);
            child.gameObject.SetActive(true);

        }
    }
}
