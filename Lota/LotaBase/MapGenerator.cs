using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotaBase
{
    public abstract class MapGenerator
    {
        public abstract Chunk GetChunk(int chunkX, int chunkY);
    }
}
