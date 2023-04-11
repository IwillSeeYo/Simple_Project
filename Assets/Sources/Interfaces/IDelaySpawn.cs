using System;

public interface IDelaySpawn
{
    event Action Spawn;
    void StartDelay(float minDelay, float maxDelay);
    void StopDelay();
}