#define zuoshang
#define zuoxia
#define youshang
#define youxia
#define horn
#undef horn
using conway_life;

int[,] chassis = new int[10, 10];

// #define
int X = 10;
int Y = 10;
int biology = 1;

//chassis 底层
for (int i = 0; i < Y; i++)
{
    for (int j = 0; j < X; j++)
    {
        chassis[i, j] = 0;
    }
}

#if horn ==true
# if zuoshang == true
chassis[0, 1] = biology;
chassis[0, 0] = biology;
#endif
#if youxia == true 
chassis[9, 8] = biology;
chassis[9, 9] = biology;
#endif
#if zuoxia== true
chassis[9, 1] = biology;
chassis[9, 0] = biology;
#endif
#if youshang== true
chassis[1, 9] = biology;
chassis[0, 9] = biology;
#endif
#endif

chassis[3, 3] = biology;
chassis[3, 4] = biology;
chassis[3, 5] = biology;
chassis[2, 5] = biology;
chassis[1, 4] = biology;

for (int i = 0; i < Y; i++)
{
    for (int j = 0; j < X; j++)
    {
        if (chassis[i, j] == 1) Console.Write("■");
        else Console.Write("□");
    }
    Console.WriteLine();
}

Console.WriteLine();

Scene scene = new Scene(chassis, 10, 10);
chassis = scene.Next();
Thread th = new Thread(new ThreadStart(() =>
{
    while (true)
    {
        chassis = scene.Next();
        Console.Clear();
        for (int i = 0; i < Y; i++)
        {
            for (int j = 0; j < X; j++)
            {
                if (chassis[i, j] == 1) Console.Write("■");
                else Console.Write("□");
            }
            Console.WriteLine();
        }
        Thread.Sleep(1000);
    }

}));
th.Start();
