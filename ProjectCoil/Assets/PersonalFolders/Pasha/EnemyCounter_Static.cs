using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyCounter_Static
{
    public static int enemyCount=0;

    public static void GlobalCounter_AddEnemy()
    {
        enemyCount++;
    }
    public static void GlobalCounter_RemoveEnemy()
    {
        enemyCount--;
    }

}
