using LotaBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotaRuntime
{
    public class Terrain
    {
        public const int YSize = 11;
        public const int XSize = 11;
        private Chunk[] chunks;
        public Terrain()
        {
            chunks = new Chunk[YSize * XSize];
        }
        public void Inser(int x, int y, Chunk chunk)
        {
            chunks[y * XSize + x] = chunk;
        }
    }
}
