using SnakeGame;
using System.Threading;

Cordenadas campo = new Cordenadas(40, 25);
Cordenadas snakePosicao = new Cordenadas(10, 1);
Random rand = new Random();
Cordenadas pointPosicao = new Cordenadas(rand.Next(1, campo.GetX - 1), rand.Next(1, campo.GetY - 1));
int frame = 100;
DirecaoEnum movimento = DirecaoEnum.Down;
List<Cordenadas> snakeCordenadas = new List<Cordenadas>();
int snakeTamanho = 1;
int pontuacao = 0;

Console.CursorVisible = false; 

while (true)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Score " + pontuacao);

    snakePosicao.MovimentoDirecao(movimento);

    for (int y = 0; y < campo.GetY; y++)
    {
        for (int x = 0; x < campo.GetX; x++)
        {
            Cordenadas cordenadaAtual = new Cordenadas(x, y);
            if (snakePosicao.Equals(cordenadaAtual) || snakeCordenadas.Contains(cordenadaAtual))
                Console.Write("■");
            else if (pointPosicao.Equals(cordenadaAtual))
                Console.Write('o');
            else if (x == 0 || y == 0 || x == campo.GetX - 1 || y == campo.GetY - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }

    if (snakePosicao.Equals(pointPosicao))
    {
        snakeTamanho++;
        pontuacao++;
        pointPosicao = new Cordenadas(rand.Next(1, campo.GetX - 1), rand.Next(1, campo.GetY - 1));
    }
    else if (snakePosicao.GetX == 0 || snakePosicao.GetY == 0 || snakePosicao.GetX == campo.GetX - 1
        || snakePosicao.GetY == campo.GetY - 1 || snakeCordenadas.Contains(snakePosicao))
    {
        pontuacao = 0;
        snakeTamanho = 1;
        snakePosicao = new Cordenadas(10, 1);
        snakeCordenadas.Clear();
        movimento = DirecaoEnum.Down;
        continue;
    }

    snakeCordenadas.Add(new Cordenadas(snakePosicao.GetX, snakePosicao.GetY));
    if (snakeCordenadas.Count > snakeTamanho)
        snakeCordenadas.RemoveAt(0);

    if (Console.KeyAvailable)
    {
        ConsoleKey key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.LeftArrow:
                movimento = DirecaoEnum.Left;
                break;
            case ConsoleKey.RightArrow:
                movimento = DirecaoEnum.Right;
                break;
            case ConsoleKey.UpArrow:
                movimento = DirecaoEnum.Up;
                break;
            case ConsoleKey.DownArrow:
                movimento = DirecaoEnum.Down;
                break;
        }
    }

    Thread.Sleep(frame);
}
