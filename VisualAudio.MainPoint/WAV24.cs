using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualAudio.MainPoint
{
    public class WAV24
    {
        //Метод для извлечения массива байтов из указанного файла WAV 
        public static byte[] Load24bitWaveFormFromFile(String filePath)
        {
            WaveFileReader waveFileReader = null; //Из библиотеки NAudio
            try
            {
                waveFileReader = new WaveFileReader(filePath); //Пробуем открыть файл
                if (waveFileReader.WaveFormat.BitsPerSample == 24) //Проверяем разрядность
                {
                    byte[] byteBuffer = new byte[waveFileReader.Length]; //Создаём массив
                    waveFileReader.Read(byteBuffer, 0, byteBuffer.Length); //Считываем туда файл
                    return byteBuffer; //Передаём готовый массив наружу
                }
                else
                {
                    throw new Exception("Параметры данного звукового файла не подходят");
                }
            }
            catch(IOException)
            {
                throw new Exception("Программа не может открыть данный файл");
            }
            finally
            {
                if (waveFileReader != null) waveFileReader.Close();
            }
        }

        public static void Save24bitWaveFormToFile(byte[] waveForm, String filePath)
        {
            WaveFormat waveFormat = new WaveFormat(48000, 24, 1);
            WaveFileWriter waveFileWriter = null;
            try
            {
                waveFileWriter = new WaveFileWriter(filePath, waveFormat);
                waveFileWriter.Write(waveForm, 0, waveForm.Length);
            }
            catch(IOException)
            {
                throw new Exception("Программа не может создать файл в указанном расположении");
            }
            finally
            {
                if (waveFileWriter != null) waveFileWriter.Close();
            }
        }
    }
}
