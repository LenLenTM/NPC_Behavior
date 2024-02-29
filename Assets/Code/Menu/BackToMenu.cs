using System;
using Unity.VisualScripting;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
        public GameObject World;
        public GameObject Menu;
        public GameObject FSM_Entity;
        public GameObject BT_Entity;
        public GameObject GOAP_Entity;

        private void OnMouseDown()
        {
                World.SetActive(false);
                Menu.SetActive(true);
                FSM_Entity.SetActive(false);
                BT_Entity.SetActive(false);
                GOAP_Entity.SetActive(false);
        }
}