using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Exp
{
    public static int[] ExpScale = { 0, 100, 220, 360, 520, 700, 900, 1120 };

    public static int LvlByExp(int exp)
    {
        int a = 0;
        while (exp >= ExpScale[a])
        {
            a++;
        }

        return a;
    }
}
