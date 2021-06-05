﻿using System.Drawing;

namespace Converter_Image_to_ASCII
{
    public static class Extensions
    {
        public static void ToGrayScale(this Bitmap bitmap)
        {
            for(int y = 0; y<bitmap.Height; y++)
            {
                for(int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    var avg = (pixel.R + pixel.G + pixel.B) / 3;
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, avg, avg, avg));
                }
            }
        }
    }
}