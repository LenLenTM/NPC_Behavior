using UnityEngine;

public class Click_GOAP : MonoBehaviour
{
        public GameObject GOAP_Entity;
        public GameObject World;
        public GameObject Menu;

        private void OnMouseDown()
        {
                GOAP_Entity.SetActive(true);
                World.SetActive(true);
                Menu.SetActive(false);
        }
}