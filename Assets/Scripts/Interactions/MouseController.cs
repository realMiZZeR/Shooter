using System;
using UnityEngine;

namespace Shooter.Interactions
{
    public class MouseController
    {
        public event Action LeftMouseButtonPressed;
        public event Action LeftMouseButtonReleased;
        public event Action RightMouseButtonPressed;
        public event Action RightMouseButtonReleased;
        public event Action MiddleMouseButtonPressed;
        public event Action MiddleMouseButtonReleased;
        public event Action<float> Scrolled;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                LeftMouseButtonPressed?.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                LeftMouseButtonReleased?.Invoke();
            }

            if (Input.GetMouseButtonDown(1))
            {
                RightMouseButtonPressed?.Invoke();
            }

            if (Input.GetMouseButtonUp(1))
            {
                RightMouseButtonReleased?.Invoke();
            }

            if (Input.GetMouseButtonDown(2))
            {
                MiddleMouseButtonPressed?.Invoke();
            }

            if (Input.GetMouseButtonUp(2))
            {
                MiddleMouseButtonReleased?.Invoke();
            }

            Scrolled?.Invoke(Input.GetAxis("Mouse ScrollWheel"));
        }
    }
}
