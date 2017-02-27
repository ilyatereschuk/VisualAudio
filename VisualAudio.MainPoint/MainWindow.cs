using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualAudio.MainPoint
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonConvertWaveFormToImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файл WAV (*.wav)|*.wav";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = false; //Пока операция продолжается, выключим кнопки

                try
                {
                    byte[] waveForm = WAV24.Load24bitWaveFormFromFile(openFileDialog.FileName);
                    byte[] waveFormAligned = RGB24Matrix.GetAligned24bitAudioBufferToQuartersSquare(waveForm);
                    RGB24[] rgb24MatrixPlain = RGB24Matrix.GetRgb24ArrayFromByteArray(waveFormAligned);
                    RGB24[] rgb24MatrixSpiral = RGB24Matrix.TransformRgb24PlainSequentialMatrixToPlainSpiralMatrix(rgb24MatrixPlain);
                    byte[] convertedRgb24MatrixSpiral = RGB24Matrix.GetByteArrayFromRgb24Array(rgb24MatrixSpiral);

                    try
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Файл BMP (*.bmp)|*.bmp";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            RGB24Bitmap.Save24bitSquareBitmapToFile(convertedRgb24MatrixSpiral, saveFileDialog.FileName);
                            MessageBox.Show(
                                "Звук успешно сконвертирован в изображение",
                                "Операция завершена",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(
                            exception.Message,
                            "Ошибка записи изображения в файл",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(
                        exception.Message,
                        "Ошибка трансформации звукового файла",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                this.Enabled = true; //По завершению операции управление снова доступно
            }
        }

        private void buttonConvertImageToWaveForm_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файл BMP (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Enabled = false; //Пока операция продолжается, выключим кнопки

                Bitmap bitmap = RGB24Bitmap.Load24bitSquareBitmapFromFile(openFileDialog.FileName);

                RGB24[] rgb24MatrixSpiral = RGB24Matrix.GetRgb24MatrixFromBitmap(bitmap);

                byte[] convertedRgb24MatrixPlain = RGB24Matrix.TransformRgb24PlainSpiralMatrixToBytePlainSequentialMatrix(rgb24MatrixSpiral);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Файл WAV (*.wav)|*.wav";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    WAV24.Save24bitWaveFormToFile(convertedRgb24MatrixPlain, saveFileDialog.FileName);
                    MessageBox.Show(
                        "Изображение успешно сконвертировано в звук",
                        "Операция завершена",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                this.Enabled = true; //По завершению операции управление снова доступно
            }
        }
    }
}
