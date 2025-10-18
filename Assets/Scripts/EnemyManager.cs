using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [SerializeField] private GameOverMenu youWinMenu;
    private int aliveEnemies = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterEnemy()
    {
        aliveEnemies++;
    }

    public void OnEnemyDied()
    {
        aliveEnemies--;

        if (aliveEnemies <= 0)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        youWinMenu.Show();
    }
}