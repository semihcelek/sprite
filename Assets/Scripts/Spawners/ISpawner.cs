using System.Collections;

namespace Spawners
{
    public interface ISpawner
    {
        // public float minWait;
        // public float maxWait;
        public IEnumerator Spawn();
    }
}