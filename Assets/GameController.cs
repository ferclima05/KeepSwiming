using UnityEngine;

public static class GameController
{
    public static bool gameOver { get; private set; }

    public static void Init()
    {
        gameOver = false;
    }

    public static void FinalizarJogo()
    {
        gameOver = true;
    }
}