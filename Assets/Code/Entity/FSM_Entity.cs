using System;
using TMPro;

public class FSM_Entity : StateMachine
{
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
                _hungerIndicator = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
                _tirednessIndicator = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
                _work2DoIndicator = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshPro>();
        }

        private void LateUpdate()
        {
                Hunger.Hungry += 0.002 * World.Speed;
                Sleep.Tiredness += 0.0015 * World.Speed;
                PrintUpdate();
        }

        private void PrintUpdate()
        {
                _hungerIndicator.SetText("Hunger: " + Math.Round(Hunger.Hungry, 2));
                _tirednessIndicator.SetText("Tiredness: " + Math.Round(Sleep.Tiredness, 2));
                _work2DoIndicator.SetText("Work2Do: " + Math.Round(Work.Work2Do, 2));
        }
}