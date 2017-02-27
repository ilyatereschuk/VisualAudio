using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisualAudio.MainPoint
{
    public class RGB24Matrix
    {
        public static byte[] GetByteArrayFromRgb24Array(RGB24[] rgbArray)
        {
            byte[] byteArray = new byte[rgbArray.Length * 3];
            for (int i = 0; i < rgbArray.Length; i++)
            {
                Int32 currentPixelBytePosition = i * 3;
                byteArray[currentPixelBytePosition] = rgbArray[i].R;
                byteArray[currentPixelBytePosition + 1] = rgbArray[i].G;
                byteArray[currentPixelBytePosition + 2] = rgbArray[i].B;
            }
            return byteArray;
        }

        //Метод для получения массива цветов RGB из массива байт
        public static RGB24[] GetRgb24ArrayFromByteArray(byte[] byteArray)
        {
            int pixelsCount = byteArray.Length / 3;
            RGB24[] rgb24Array = new RGB24[pixelsCount];
            for (int i = 0; i < pixelsCount; i++)
            {
                Int32 currentPixelBytePosition = i * 3;
                rgb24Array[i] = new RGB24
                {
                    R = byteArray[currentPixelBytePosition],
                    G = byteArray[currentPixelBytePosition + 1],
                    B = byteArray[currentPixelBytePosition + 2]
                };
            }
            return rgb24Array;
        }
        //Метод для выравнивания массива до размера, который подойдёт для алгоритма спирали
        public static byte[] GetAligned24bitAudioBufferToQuartersSquare(byte[] byteBuffer)
        {
            //В 1 значении 24 бита (3 байта) - найдем количество пикселей, разделив длину массива на 3
            Int32 rgbPixelsQuantity = byteBuffer.Length / 3;
            //Найдём квадратный корень из количества пикселей
            Double pixelsQuantitySquareRoot = Math.Sqrt(rgbPixelsQuantity);
            //Округлим корень в сторону увеличения 
            Int32 rgbSquareSide = Convert.ToInt32(Math.Ceiling(pixelsQuantitySquareRoot));
            //Чтобы алгоритм спирали работал правильно, увеличим сторону до ближайшего делимого на 4
            while (rgbSquareSide % 4 != 0) rgbSquareSide++;
            //Умножим "выоровненную" сторону саму на себя, и потом на 3. Это новое количество пикселей
            Int32 resultingRgbPixelsQuantity = rgbSquareSide * rgbSquareSide * 3;
            //Создадим соответствующий новый массив
            Byte[] newByteBuffer = new byte[resultingRgbPixelsQuantity];
            //Скопируем в него старый
            Array.Copy(byteBuffer, 0, newByteBuffer, newByteBuffer.Length - byteBuffer.Length, byteBuffer.Length);
            return newByteBuffer; //Отдаём готовые данные
        }

        public static byte[] TransformRgb24PlainSpiralMatrixToBytePlainSequentialMatrix(RGB24[] rgbPlainSpiralMatrix)
        {
            //RGB24[] rgbPlainSpiralMatrix = GetRgb24ArrayFromByteArray(plainSpiralMatrix);
            Int32 matrixSide = Convert.ToInt32(Math.Sqrt(rgbPlainSpiralMatrix.Length));
            RGB24[] rgbPlainSequentialMatrix = new RGB24[rgbPlainSpiralMatrix.Length];

            int position = 0;
            int count = matrixSide;
            int value = -matrixSide;
            int sum = -1;

            do
            {
                value = -1 * value / matrixSide;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    rgbPlainSequentialMatrix[position++] = rgbPlainSpiralMatrix[matrixSide * (sum / matrixSide) + sum % matrixSide];
                }
                value *= matrixSide;
                count--;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    rgbPlainSequentialMatrix[position++] = rgbPlainSpiralMatrix[matrixSide * (sum / matrixSide) + sum % matrixSide];
                }
            } while (count > 0);

            return GetByteArrayFromRgb24Array(rgbPlainSequentialMatrix);
        }

        //Метод, который делает из линейного массива спираль в матрице, и отдаёт эту матрицу в линейном виде
        public static RGB24[] TransformRgb24PlainSequentialMatrixToPlainSpiralMatrix(RGB24[] plainSequentialMatrix)
        {
            Int32 matrixSide = Convert.ToInt32(Math.Sqrt(plainSequentialMatrix.Length));
            RGB24[,] spiralMatrix = new RGB24[matrixSide, matrixSide];

            int position = 0;
            int count = matrixSide;
            int value = -matrixSide;
            int sum = -1;

            do
            {
                value = -1 * value / matrixSide;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    spiralMatrix[sum / matrixSide, sum % matrixSide] = plainSequentialMatrix[position++];
                }
                value *= matrixSide;
                count--;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    spiralMatrix[sum / matrixSide, sum % matrixSide] = plainSequentialMatrix[position++];
                }
            } while (count > 0);

            return spiralMatrix.Cast<RGB24>().ToArray();
        }

        public static RGB24[] GetRgb24MatrixFromBitmap(Bitmap bitmap)
        {
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly,
                bitmap.PixelFormat);

            byte[] byteBuffer = new byte[bitmapData.Stride * bitmapData.Height];

            Marshal.Copy(bitmapData.Scan0, byteBuffer, 0, byteBuffer.Length);

            return GetRgb24ArrayFromByteArray(byteBuffer);
        }
    }
}
