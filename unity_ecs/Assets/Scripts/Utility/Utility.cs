using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;
using System.Data.SqlTypes;

public class Utility
{
    public static async Task<T> GetTotaValue<T>(List<T> valueList) where T : struct
    {
        var retValue = default(T);

        bool isCompleted = false;
        Func<bool> condition = () => 
        {
            return isCompleted;
        };

        var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromSeconds(5));

        var waitTask = Task.Run(async () =>
        {
            while (!condition())
            {
                await Task.Delay(500, cts.Token);
            }
        });

        await waitTask;

        return retValue;
    }
}
