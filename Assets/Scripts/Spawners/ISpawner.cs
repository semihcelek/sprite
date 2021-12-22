using System.Collections;

namespace Sprinter.Spawners
{
    public interface ISpawner
    {
        // public float minWait;
        // public float maxWait;
        public IEnumerator Spawn();
    }
}