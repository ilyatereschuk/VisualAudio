using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisualAudio.MainPoint
{
    public class RGB24Bitmap
    {
        private static Bitmap Generate24bitSquareBitmapFromByteBuffer(byte[] byteBuffer)
        {
            var pixelsQuantity = byteBuffer.Length / 3; //Количество пикселей втрое меньше, чем байт
            Int32 squareSide = Convert.ToInt32(Math.Sqrt(pixelsQuantity)); //Сторона квадрата

            //Here create the Bitmap to the know height, width and format
            Bitmap bitmap = new Bitmap(squareSide, squareSide, PixelFormat.Format24bppRgb);

            //Create a BitmapData and Lock all pixels to be written 
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, squareSide, squareSide), 
                ImageLockMode.WriteOnly, 
                bitmap.PixelFormat);

            //Copy the data from the byte array into BitmapData.Scan0
            Marshal.Copy(byteBuffer, 0, bitmapData.Scan0, byteBuffer.Length);

            //Unlock the pixels
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        public static Bitmap Load24bitSquareBitmapFromFile(String filePath)
        {
            try
            { 
                Bitmap bitmap = new Bitmap(filePath);
                Boolean isBitmapValid =
                    bitmap.PixelFormat == PixelFormat.Format24bppRgb &&
                    bitmap.Width == bitmap.Height &&
                    bitmap.Width % 4 == 0;
                if (isBitmapValid) return bitmap;
                else throw new Exception("Параметры данного изображения не подходят");
                
            }
            catch(IOException)
            {
                throw new Exception("Программа не может открыть данный файл");
            }
        }

        public static void Save24bitSquareBitmapToFile(byte[] bitmapArray, String filePath)
        {
            try
            {
                Bitmap bitmap = Generate24bitSquareBitmapFromByteBuffer(bitmapArray);
                bitmap.Save(filePath);
            }
            catch (IOException)
            {
                throw new Exception("Программа не может сохранить файл в данном расположении");
            }
        }
        /*
        public static byte[] GetByteArrayFromBitmap(Bitmap bitmap)
        {
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite,
                bitmap.PixelFormat);

            byte[] byteBuffer = new byte[bitmapData.Stride * bitmapData.Height];

            Marshal.Copy(bitmapData.Scan0, byteBuffer, 0, byteBuffer.Length);

            return byteBuffer;
        }*/
    }
}
