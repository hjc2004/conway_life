namespace conway_life
{
    public class scene
    {
        private int _x;
        private int _y;
        private int _edge_x;
        private int _edge_y;
        private int[,] _chassis;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int[,] Chassis { get => _chassis; set => _chassis = value; }
        public int Edge_x { get => _edge_x; set => _edge_x = value; }
        public int Edge_y { get => _edge_y; set => _edge_y = value; }

        public int[,] Next()
        {
            int[,] value = new int[Y, X];
            int miny = 0, maxy = 0;
            int minx = 0, maxx = 0;
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    if (j == 0) minx = 9;
                    else minx = j - 1;
                    if (j == 9) maxx = 0;
                    else maxx = j + 1;
                    if (i == 0) miny = 9;
                    else miny = i - 1;
                    if (i == 9) maxy = 0;
                    else maxy = i + 1;
                    value[i, j] += Chassis[i, minx] + Chassis[i, maxx];
                    value[i, j] += Chassis[miny, j] + Chassis[maxy, j];
                    value[i, j] += Chassis[miny, minx] + Chassis[maxy, maxx] + Chassis[miny, maxx] + Chassis[maxy, minx];
                    if (value[i, j] == 3) value[i, j] = 1;
                    else if (value[i, j] == 2) value[i, j] = Chassis[i, j];
                    else if (value[i, j] < 2) value[i, j] = 0;
                    else if (value[i, j] > 3) value[i, j] = 0;
                }
            }
            NewChassis(value);
            return value;
        }
        private void NewChassis(int[,] scene)
        {
            Chassis = scene;
        }
        public scene(int[,] Scene, int x, int y)
        {
            this._chassis = Scene;
            this.X = x;
            this.Edge_x = x - 1;
            this.Edge_y = y - 1;
            this.Y = y;
        }
    }
}