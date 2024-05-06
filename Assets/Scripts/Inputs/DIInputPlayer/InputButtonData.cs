using Unity.Mathematics;

namespace Input
{
    public struct InputButtonData
    {
        public float2 WASD;//движение оси WASD
        public float Tab;
        public float Esc;
        public float E;
        public float F;
        public float R;
        public float Space;
        //
        public Mode ModeAction;
        public Mode[] Modes;
        //
        //public Ray Ray;
    }
}

