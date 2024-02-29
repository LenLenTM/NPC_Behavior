using TMPro;
using UnityEngine;

public class HoverArrow : MonoBehaviour
{
    public void OnMouseEnter()
    {
        this.transform.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public void OnMouseExit()
    {
        this.transform.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDown()
    {
        this.transform.GetComponent<SpriteRenderer>().color = Color.white;
    }
}