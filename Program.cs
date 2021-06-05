using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using DotLiquid.Util;

namespace Converter_Image_to_ASCII
{
    class Program
    {
        private const double WIDTH_OFFSET = 2.0;
        private const int MaxWindth = 600;
        [System.STAThread]
        static void Main(string[] args)
        {

            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp ; *.png ; *.Jpg; *.JPEG "
            };

            openFileDialog.ShowDialog();



            while (true)
            {
                System.Console.ReadLine();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    continue;
                }
                System.Console.Clear();
                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.ToGrayScale();
                var converter = new BItmapToASCIIConverter(bitmap);
                var rows = converter.convert();
                foreach (var row in rows)
                {
                    System.Console.WriteLine(row);
                }
                var rowsNegative = converter.convertNegative();
                File.WriteAllLines("image.txt", rowsNegative.Select(r => new string(r)));
                System.Console.SetCursorPosition(0, 0);
            }
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap)//изменение пропорций (ширины и высоты) картинки
        {
            var newHeight = bitmap.Height / WIDTH_OFFSET * MaxWindth / bitmap.Width;
            if(bitmap.Width > MaxWindth || bitmap.Height > newHeight)
            {
                bitmap = new Bitmap(bitmap, new Size(MaxWindth, (int)newHeight));
            }
                return bitmap;
        }
    }
}
