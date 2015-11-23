using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApplication2
{
    static class ImageProcessor
    {
        public static Bitmap greyifi(Bitmap image)
        {
            Bitmap imageOut = image;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int average = (int)((0.3 * pixel.R) + (0.6 * pixel.G) + (0.1 * pixel.B));
                    imageOut.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            return imageOut;
        }

        public static Bitmap sobel(Bitmap image)
        {
            Bitmap imageOut = image;
            int[,] xKernel =
            {
                {1,0,1},
                {2,0,2},
                {1,0,1}
            };
            int[,] yKernel =
            {
                {1,2,1},
                {0,0,0},
                {1,2,1}
            };
            return imageOut;
        }

        public static Bitmap blur(Bitmap image, int[,] kernel)
        {
            Bitmap imageOut = image;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Position[,] grid = getGrid(x, y, image, kernel.GetLength(0), kernel.GetLength(1));
                    int totalR = 0;
                    int totalG = 0;
                    int totalB = 0;
                    int totalMultiplication = 0;
                    for (int gridx = 0; gridx < grid.GetLength(0); gridx++)
                    {
                        for (int gridy = 0; gridy < grid.GetLength(1); gridy++)
                        {
                            if (grid[gridx, gridy] != null)
                            {
                                Color pixel = image.GetPixel(grid[gridx, gridy].x, grid[gridx, gridy].y);
                                totalR += pixel.R * kernel[gridx, gridy];
                                totalG += pixel.G * kernel[gridx, gridy];
                                totalB += pixel.B * kernel[gridx, gridy];
                                totalMultiplication += kernel[gridx, gridy];
                            }
                            
                        }
                    }
                    Color newPixel = Color.FromArgb(totalR /= totalMultiplication, totalG /= totalMultiplication, totalB /= totalMultiplication);
                    imageOut.SetPixel(x, y, newPixel);
                }
            }
            return imageOut;
        }

        public static Position[,] getGrid(int xpos, int ypos, Bitmap image, int width, int height)
        {
            Position[,] grid = new Position[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (!(xpos + x - width / 2 < 0 || ypos + y - height / 2 < 0 || xpos + x >= image.Width || ypos + y >= image.Height))
                    {
                        grid[x,y] = new Position(xpos + x - width / 2, ypos + y - height / 2);
                    }
                }
            }
            return grid;
        }

        public static int[,] generateKernel(int size, int mean, int sd)
        {
            int[,] kernel = new int[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    kernel[x,y] = 1;
                }
            }
            return kernel;
        }

        public class Position
        {
            public int x;
            public int y;
            public Position(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }
    }
}
