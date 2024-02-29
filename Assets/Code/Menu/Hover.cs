using TMPro;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public void OnMouseEnter()
    {
        this.transform.GetComponent<TextMeshPro>().color = Color.gray;
    }

    public void OnMouseExit()
    {
        this.transform.GetComponent<TextMeshPro>().color = Color.white;
    }

    private void OnMouseDown()
    {
        this.transform.GetComponent<TextMeshPro>().color = Color.white;
    }
}