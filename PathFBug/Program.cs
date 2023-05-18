using Microsoft.Maui.Graphics;

namespace PathFBug;

internal static class Program
{
    private static void Main()
    {
        float n = (float)(4 * (Math.Sqrt(2) - 1) / 3);
        var path1 = GetOval(100, 100, 100, 100, n * 100, n * 100, 0);
        var path2 = GetOval(222, 324, 222, 324, 167, 146, 0);
        var path3 = GetOval(222, 324, 222, 324, 167, 146, 1);
        
        Console.WriteLine(path1.Bounds);
        Console.WriteLine(path2.Bounds);
        Console.WriteLine(path3.Bounds);
    }
    
    private static PathF GetOval(float x, float y, float radiusX, float radiusY, float cDx, float cDy, float deviation)
    {
        PathF path = new PathF();
        
        float x1 = 0;
        float xm = radiusX;
        float x2 = radiusX * 2;
        
        float y1 = 0;
        float ym = radiusY;
        float y2 = radiusY * 2;

        x -= radiusX;
        y -= radiusY;

        float cX1 = xm - cDx;
        float cX2 = xm + cDx;
        
        float cY1 = ym - cDy;
        float cY2 = ym + cDy;

        path.MoveTo(x + xm, y + y2);
        path.CurveTo(x + cX1 + deviation * 2, y + y2, x + x1, y + cY2, x + x1, y + ym);
        path.CurveTo(x + x1, y + cY1, x + cX1 - deviation, y + y1, x + xm, y + y1);
        path.CurveTo(x + cX2, y + y1, x + x2, y + cY1, x + x2, y + ym);
        path.CurveTo(x + x2, y + cY2, x + cX2, y + y2, x + xm, y + y2);
        path.Close();

        return path;
    }
}