using System;
using UnityEngine;

public class IndicatorArrows : MonoBehaviour
{
    public GameObject WorldObject;

    private GameObject _fsm;
    private GameObject _bt;
    private GameObject _goap;
    
    private void Awake()
    {
        _fsm = WorldObject.transform.Find("FSM_Entity").gameObject;
        _bt = WorldObject.transform.Find("BT_Entity").gameObject;
        _goap = WorldObject.transform.Find("GOAP_Entity").gameObject;
    }

    private void OnMouseDown()
    {
        if (name.Contains("Work"))
        {
            if (name.Contains("Less"))
            {
                if (_fsm.activeSelf)
                {
                    _fsm.GetComponent<FSM_Entity>().UpdateWork(-5f);
                }
                else if (_bt.activeSelf)
                {
                    _bt.GetComponent<BT_Entity>().UpdateWork(-5f);
                }
                else if (_goap.activeSelf)
                {
                    _goap.GetComponent<GOAP_Entity>().UpdateWork(-5f);
                }
            }
            else if (name.Contains("More"))
            {
                if (_fsm.activeSelf)
                {
                    _fsm.GetComponent<FSM_Entity>().UpdateWork(5f);
                }
                else if (_bt.activeSelf)
                {
                    _bt.GetComponent<BT_Entity>().UpdateWork(5f);
                }
                else if (_goap.activeSelf)
                {
                    _goap.GetComponent<GOAP_Entity>().UpdateWork(5f);
                }
            }
        }
        
        
        else if (name.Contains("Tiredness"))
        {
            if (name.Contains("Less"))
            {
                if (_fsm.activeSelf)
                {
                    _fsm.GetComponent<FSM_Entity>().UpdateTiredness(-5f);
                }
                else if (_bt.activeSelf)
                {
                    _bt.GetComponent<BT_Entity>().UpdateTiredness(-5f);
                }
                else if (_goap.activeSelf)
                {
                    _goap.GetComponent<GOAP_Entity>().UpdateTiredness(-5f);
                }
            }
            else if (name.Contains("More"))
            {
                if (_fsm.activeSelf)
                {
                    _fsm.GetComponent<FSM_Entity>().UpdateTiredness(5f);
                }
                else if (_bt.activeSelf)
                {
                    _bt.GetComponent<BT_Entity>().UpdateTiredness(5f);
                }
                else if (_goap.activeSelf)
                {
                    _goap.GetComponent<GOAP_Entity>().UpdateTiredness(5f);
                }
            }
        }
        
        
        else if (name.Contains("Hunger"))
        {
            if (name.Contains("Less"))
            {
                if (_fsm.activeSelf)
                {
                    _fsm.GetComponent<FSM_Entity>().UpdateHunger(-5f);
                }
                else if (_bt.activeSelf)
                {
                    _bt.GetComponent<BT_Entity>().UpdateHunger(-5f);
                }
                else if (_goap.activeSelf)
                {
                    _goap.GetComponent<GOAP_Entity>().UpdateHunger(-5f);
                }
            }
            else if (name.Contains("More"))
            {
                if (_fsm.activeSelf)
                {
                    _fsm.GetComponent<FSM_Entity>().UpdateHunger(5f);
                }
                else if (_bt.activeSelf)
                {
                    _bt.GetComponent<BT_Entity>().UpdateHunger(5f);
                }
                else if (_goap.activeSelf)
                {
                    _goap.GetComponent<GOAP_Entity>().UpdateHunger(5f);
                }
            }
        }
    }
}