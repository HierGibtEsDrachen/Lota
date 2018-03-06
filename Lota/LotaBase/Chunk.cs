namespace LotaBase
{
    public class Chunk
    {
        public static void Set(float[] array, int x, int y, float value)
        {
            array[y * XSize + x] = value;
        }
        public static float Get(float[] array, int x, int y)
        {
            return array[y * XSize + x];
        }
        public const int YSize = 50;
        public const int XSize = 50;
        public float[] Heightmap { get; }
        public float[] Temperatur { get; }
        public Chunk()
        {
            Heightmap = new float[XSize * YSize];
            Temperatur = new float[XSize * YSize];
        }
        public float GetHeight(int x, int y)
        {
            return Heightmap[y * YSize + x];
        }
        public float GetTemperatur(int x, int y)
        {
            return Temperatur[y * YSize + x];
        }
    }
}
