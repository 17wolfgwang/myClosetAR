using UnityEngine;

public class VisibilityController : MonoBehaviour
{

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerArea"))
        {
            // 박스 안에 들어오면 항상 활성화
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerArea"))
        {
            // 박스 안에 들어오면 항상 활성화
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }
}