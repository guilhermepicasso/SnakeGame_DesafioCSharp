using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Cordenadas
    {
        private int x;
        private int y;

        public int GetX { get { return x; } }
        public int GetY { get { return y; } }

        public Cordenadas(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType())) 
                return false;
            Cordenadas other = (Cordenadas)obj;
            return x == other.x && y == other.y;
        }
        public void MovimentoDirecao(DirecaoEnum direcao)
        {
            switch(direcao)
            {
                case DirecaoEnum.Left:
                    x--;
                    break;
                case DirecaoEnum.Right:
                    x++;
                    break;
                case DirecaoEnum.Down:
                    y++;
                    break;
                case DirecaoEnum.Up:
                    y--;
                    break;
            }
        }
    }
}
