﻿using System;
using UnityEngine;

namespace Input
{
    public interface IInputPlayerExecutor
    {
        Action<InputMouseData> OnMoveMouse { get; set; }
        Camera Camera { get; set; }
        Action<Vector2> OnMousePoint { get; set; }
        Action<InputMouseData> OnStartPressMouse { get; set; }
        Action<InputButtonData> OnMoveButton { get; set; }
        Action<InputButtonData> OnStartPressButton { get; set; }
        Action<InputButtonData> OnCancelPressButton { get; set; }
        void Enable();
        void OnDisable();
        ////
        //RaycastHit MousPoint(InputMouseData _inputMouseData, Camera thisCamera);
    }
}