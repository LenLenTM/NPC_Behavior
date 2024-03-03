using System;
using Unity.VisualScripting;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
        public GameObject WorldObject;
        public GameObject Menu;
        public GameObject FSM_Entity;
        public GameObject BT_Entity;
        public GameObject GOAP_Entity;

        private void OnMouseDown()
        {
                PerformanceMeter.ResetState();
                DateTime today = DateTime.Now;
                World.Time =  new DateTime(today.Year, today.Month, today.Day, 6, 0, 0);

                BT_Entity.GetComponent<BT_Entity>().ResetStats();
                FSM_Entity.GetComponent<FSM_Entity>().ResetStats();
                GOAP_Entity.GetComponent<GOAP_Entity>().ResetStats();
                
                WorldObject.SetActive(false);
                Menu.SetActive(true);
                FSM_Entity.SetActive(false);
                BT_Entity.SetActive(false);
                GOAP_Entity.SetActive(false);
                Logger.ResetLog();
        }
}