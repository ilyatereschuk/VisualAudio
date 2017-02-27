namespace VisualAudio.MainPoint
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonConvertWaveFormToImage = new System.Windows.Forms.Button();
            this.labelSoundDescription = new System.Windows.Forms.Label();
            this.buttonConvertImageToWaveForm = new System.Windows.Forms.Button();
            this.labelProgramDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConvertWaveFormToImage
            // 
            this.buttonConvertWaveFormToImage.Location = new System.Drawing.Point(12, 43);
            this.buttonConvertWaveFormToImage.Name = "buttonConvertWaveFormToImage";
            this.buttonConvertWaveFormToImage.Size = new System.Drawing.Size(360, 30);
            this.buttonConvertWaveFormToImage.TabIndex = 0;
            this.buttonConvertWaveFormToImage.Text = "Конвертировать звук в изображение";
            this.buttonConvertWaveFormToImage.UseVisualStyleBackColor = true;
            this.buttonConvertWaveFormToImage.Click += new System.EventHandler(this.buttonConvertWaveFormToImage_Click);
            // 
            // labelSoundDescription
            // 
            this.labelSoundDescription.Location = new System.Drawing.Point(12, 76);
            this.labelSoundDescription.Name = "labelSoundDescription";
            this.labelSoundDescription.Size = new System.Drawing.Size(360, 15);
            this.labelSoundDescription.TabIndex = 1;
            this.labelSoundDescription.Text = "(24-битный WAV в моно)";
            this.labelSoundDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConvertImageToWaveForm
            // 
            this.buttonConvertImageToWaveForm.Location = new System.Drawing.Point(12, 105);
            this.buttonConvertImageToWaveForm.Name = "buttonConvertImageToWaveForm";
            this.buttonConvertImageToWaveForm.Size = new System.Drawing.Size(360, 30);
            this.buttonConvertImageToWaveForm.TabIndex = 2;
            this.buttonConvertImageToWaveForm.Text = "Конвертировать изображение в звук";
            this.buttonConvertImageToWaveForm.UseVisualStyleBackColor = true;
            this.buttonConvertImageToWaveForm.Click += new System.EventHandler(this.buttonConvertImageToWaveForm_Click);
            // 
            // labelProgramDescription
            // 
            this.labelProgramDescription.Location = new System.Drawing.Point(12, 0);
            this.labelProgramDescription.Name = "labelProgramDescription";
            this.labelProgramDescription.Size = new System.Drawing.Size(360, 40);
            this.labelProgramDescription.TabIndex = 3;
            this.labelProgramDescription.Text = "Преобразование звуковых файлов в изображения и обратно";
            this.labelProgramDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "(BMP с исходными пропорциями) ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 171);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelProgramDescription);
            this.Controls.Add(this.buttonConvertImageToWaveForm);
            this.Controls.Add(this.labelSoundDescription);
            this.Controls.Add(this.buttonConvertWaveFormToImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Картинка из музыки и музыка из картинки";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConvertWaveFormToImage;
        private System.Windows.Forms.Label labelSoundDescription;
        private System.Windows.Forms.Button buttonConvertImageToWaveForm;
        private System.Windows.Forms.Label labelProgramDescription;
        private System.Windows.Forms.Label label1;
    }
}

