using System;

namespace GXPEngine.Core
{
	public struct Vector2
	{
		public float x;
		public float y;
		
		public Vector2 (float x, float y)
		{
			this.x = x;
			this.y = y;
		}
		
		override public string ToString() {
			return "[Vector2 " + x + ", " + y + "]";
		}

        //added by Sybren de Haas
        public void Normalize()
        {
            float length = Magnitude();
            if (length != 0)
            {
                x /= length;
                y /= length;
            }
        }

        public float Magnitude() //hypotenuse 
        {
            return Mathf.Sqrt(x * x + y * y);
        }


    }
}

