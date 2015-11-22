using System.Drawing;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap imageIn = new Bitmap("C:/Users/Gebruiker/Documents/visual studio 2015/Projects/ConsoleApplication2/ConsoleApplication2/input.png");
            Bitmap imageOut;
            int[,] kernel =
            {
                {1,2,1},
                {2,4,2},
                {1,2,1}
            };
            imageOut = blur(imageIn, kernel);
            imageOut.Save("C:/Users/Gebruiker/Documents/visual studio 2015/Projects/ConsoleApplication2/ConsoleApplication2/output.png");
        }

        public static Bitmap blur(Bitmap image, int[,] kernel)
        {
            Bitmap imageOut = image;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    List<Position> grid = getGrid(x, y, image);
                    int averageR = 0;
                    int averageG = 0;
                    int averageB = 0;
                    for (int i = 0; i < grid.Count; i++)
                    {
                        Color pixel = image.GetPixel(grid[i].x, grid[i].y);
                        averageR += pixel.R;
                        averageG += pixel.G;
                        averageB += pixel.B;
                    }
                    Color newPixel = Color.FromArgb(averageR /= grid.Count, averageG /= grid.Count, averageB /= grid.Count);
                    imageOut.SetPixel(x, y, newPixel);
                }
            }
            return imageOut;
        }

        public static Bitmap greyifi(Bitmap image)
        {
            Bitmap imageOut = image;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {

                }
            }
            return imageOut;
        }

        public static List<Position> getGrid(int xpos, int ypos, Bitmap image)
        {
            List<Position> grid = new List<Position>();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!(xpos + x - 1 < 0 || ypos + y - 1 < 0 || xpos + x > image.Width || ypos + y > image.Height))
                    {
                        grid.Add(new Position(xpos + x - 1, ypos + y - 1));
                    }
                }
            }
            return grid;
        }

        public class Position
        {
            public int x;
            public int y;
            public Position(int x , int y)
            {
                this.x = x;
                this.y = y;
            }
            
        }
    } 
}
