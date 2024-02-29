using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FSM_Entity : StateMachine
{
        public Slider HungerSlider;
        public Slider TirednessSlider;
        public Slider WorkSlider;
        public GameObject HungerValue;
        public GameObject TirednessValue;
        public GameObject WorkValue;
        
        public static float ViewRange = 2f;
        public Hunger Hunger = new Hunger(55f);
        public Sleep Sleep = new Sleep(0f);
        public static Work Work = new Work(55f);

        private TextMeshPro _hungerIndicator;
        private TextMeshPro _tirednessIndicator;
        private TextMeshPro _work2DoIndicator;
        
        public Idle Idle;
        public GoHome GoHome;
        public Eating_FSM Eating;
        public GoEat GoEat;
        public Sleeping_FSM Sleeping;
        public GoSleep_FSM GoSleep;
        public Work_FSM Working;
        public GoWork_FSM GoWork;
        public LeisureActivity Leisure;
        public GoLeisure GoLeisure;

        public void ResetStats()
        {
                Hunger = new Hunger(55f);
                Sleep = new Sleep(0f);
                Work = new Work(55f);
        }
        
        private void Awake()
        {
                InitChildren();
                Idle = new Idle(this);
                GoHome = new GoHome(this);
                Eating = new Eating_FSM(this);
                GoEat = new GoEat(this);
                Sleeping = new Sleeping_FSM(this);
                GoSleep = new GoSleep_FSM(this);
                Working = new Work_FSM(this);
                GoWork = new GoWork_FSM(this);
                Leisure = new LeisureActivity(this);
                GoLeisure = new GoLeisure(this);
        }

        protected override BaseState GetInitialState()
        {
                return Idle;
        }

        private void InitChildren()
        {
                _hungerIndicator = HungerValue.GetComponent<TextMeshPro>();
                _tirednessIndicator = TirednessValue.GetComponent<TextMeshPro>();
                _work2DoIndicator = WorkValue.GetComponent<TextMeshPro>();
                
                HungerSlider.value = (float)Hunger.Hungry;
                TirednessSlider.value = (float)Sleep.Tiredness;
                WorkSlider.value = (float)Work.Work2Do;
        }

        private void LateUpdate()
        {
                Hunger.Hungry += 0.002 * World.Speed;
                Sleep.Tiredness += 0.0015 * World.Speed;
                HungerSlider.value = (float)Hunger.Hungry;
                TirednessSlider.value = (float)Sleep.Tiredness;
                WorkSlider.value = (float)Work.Work2Do;
                Hunger.Hungry = HungerSlider.value;
                Sleep.Tiredness = TirednessSlider.value;
                Work.Work2Do = WorkSlider.value;
                PrintUpdate();
        }

        private void PrintUpdate()
        {
                _hungerIndicator.SetText("Hunger: " + Math.Round(Hunger.Hungry, 2));
                _tirednessIndicator.SetText("Tiredness: " + Math.Round(Sleep.Tiredness, 2));
                _work2DoIndicator.SetText("Work2Do: " + Math.Round(Work.Work2Do, 2));
        }

        public void UpdateHunger(double value)
        {
                Hunger.Hungry += value;
        }
        
        public void UpdateTiredness(double value)
        {
                Sleep.Tiredness += value;
        }
        
        public void UpdateWork(double value)
        {
                Work.Work2Do += value;
        }
}