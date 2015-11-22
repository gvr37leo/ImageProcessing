using System.Drawing;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    class Mainr
    {
        static void Main(string[] args)
        {
            //ImageProcessor ima = new ImageProcessor();
            Bitmap imageIn = new Bitmap("C:/Users/Gebruiker/Documents/visual studio 2015/Projects/ConsoleApplication2/ConsoleApplication2/input.png");
            Bitmap imageOut;
            int[,] kernel =
            {
                {1,1,1},
                {1,1,1},
                {1,1,1}
            };
            imageOut = ImageProcessor.blur(imageIn, ImageProcessor.generateKernel(4,1,1));
            //imageOut = ImageProcessor.greyifi(imageIn);
            imageOut.Save("C:/Users/Gebruiker/Documents/visual studio 2015/Projects/ConsoleApplication2/ConsoleApplication2/output.png");
        }
    } 
}
