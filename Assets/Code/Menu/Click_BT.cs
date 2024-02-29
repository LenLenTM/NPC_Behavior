using UnityEngine;

public class Click_BT : MonoBehaviour
{
        public GameObject BT_Entity;
        public GameObject World;
        public GameObject Menu;

        private void OnMouseDown()
        {
                BT_Entity.SetActive(true);
                World.SetActive(true);
                Menu.SetActive(false);
        }
}