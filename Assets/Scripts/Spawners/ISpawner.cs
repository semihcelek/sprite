using System.Collections;

namespace SemihCelek.Sprinter.Spawners
{
    public interface ISpawner
    {
        IEnumerator SpawnCoroutine();
    }
}