using System.Drawing;

namespace Converter_Image_to_ASCII
{
    public class BItmapToASCIIConverter
    {
        private readonly char[] _AsciiTable = { '.', ',', ':', '+', '*', '?', '%', 's', '#', '@' };
        private readonly char[] _AsciiTableNegative = { '@', '#', 's', '%', '?', '*', '+', ':', ',', '.' };
        private readonly Bitmap _bitmap;
        public BItmapToASCIIConverter(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }

        public char[][] convertNegative()
        {
            var result = new char[_bitmap.Height][];
            for (int y = 0; y < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];
                for (int x = 0; x < _bitmap.Width; x++)
                {
                    int indexMap = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0, _AsciiTableNegative.Length - 1);
                    result[y][x] = _AsciiTableNegative[indexMap];
                }
            }
            return result;
        }

        public char[][] convert()
        {
            var result = new char[_bitmap.Height][];
            for(int y = 0; y  < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];
                for(int x =0; x<_bitmap.Width; x++)
                {
                    int indexMap = (int)Map(_bitmap.GetPixel(x, y).R, 0, 255, 0 , _AsciiTable.Length - 1);
                    result[y][x] = _AsciiTable[indexMap];
                }
            }
            return result;
        }

        private float Map(float valueToMap, float start1 , float stop1 , float start2 , float stop2)
        {
            return ((valueToMap - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
    }
}
