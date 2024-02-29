using UnityEngine;

public class Click_FSM : MonoBehaviour
{
        public GameObject FSM_Entity;
        public GameObject World;
        public GameObject Menu;

        private void OnMouseDown()
        {
                FSM_Entity.SetActive(true);
                World.SetActive(true);
                Menu.SetActive(false);
        }
}