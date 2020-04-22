using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    [SerializeField] private GameObject enemyprefab = null;
    private float cooldown = 0f;

    private int enemycount = 0;
    private int wave = 1;
    private int enemiesinwave = 0;
    public bool wavestart = false;
    private TowerB[] productiontowers;
    private Enemy[] enemies;
    private bool wavespawnend = false;

    void Update()
    {
       switch(wave)
        {
            case 1:
                enemiesinwave = 5;
                break;
            case 2:
                enemiesinwave = 8;
                break;
            case 3:
                enemiesinwave = 10;
                break;
            case 4:
                enemiesinwave = 16;
                break;
            case 5:
                enemiesinwave = 22;
                break;
            case 6:
                enemiesinwave = 30;
                break;
            case 7:
                enemiesinwave = 46;
                break;
            case 8:
                enemiesinwave = 60;
                break;
        }

        productiontowers = FindObjectsOfType<TowerB>();
        enemies = FindObjectsOfType<Enemy>();

        cooldown -= Time.deltaTime;

        if (enemycount < enemiesinwave && cooldown <= 0f && wavestart)
        {
            GameObject enemy = Instantiate(enemyprefab, transform.position, transform.rotation);
            enemy.SetActive(true);
            enemycount++;
            cooldown = 0.2f;
        }
        else if(enemycount >= enemiesinwave)
        {
            wavestart = false;

            wavespawnend = false;
            if (enemies.Length == 0)
            {
                WaveEnd();
            }
        }

        if (wavespawnend)
        {

        }
    }

    public void startwave()
    {
        wavestart = true;
        enemycount = 0;
    }

    private void WaveEnd()
    {
        wave++;

        for (int i = 0; i < productiontowers.Length; i++)
        {
            productiontowers[i].WaveEnd();
        }
    }
}
