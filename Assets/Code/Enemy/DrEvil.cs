using System;
using UnityEngine;

public class DrEvil : Enemy
{

        public float posX = 0.5f;
        public float posY = 0f;
        protected override string SetupEnemy()
        {
                return "Dr.Evil";
        }

        private void Update()
        {
                transform.position = new Vector3(posX, posY, 0);
        }
}