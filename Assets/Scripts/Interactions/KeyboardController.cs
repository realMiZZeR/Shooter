using System;
using UnityEngine;

namespace Shooter.Interactions
{
    public class KeyboardController
    {
        public event Action<Vector3> AxisButtonPressed;
        public event Action SpacePressed;

        public void Tick()
        {
            HandleAxis();
            HandleSpaceButton();
        }

        private void HandleAxis()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            var direction = new Vector3(horizontal, 0, vertical);

            if (direction != Vector3.zero)
                AxisButtonPressed?.Invoke(direction);
        }

        private void HandleSpaceButton()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpacePressed?.Invoke();
        }
    }
}


