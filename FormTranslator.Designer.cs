
namespace CourseWork
{
    partial class FormTranslator
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
            this.dataGridViewLexeme = new System.Windows.Forms.DataGridView();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewKeywords = new System.Windows.Forms.DataGridView();
            this.dataGridViewSeparators = new System.Windows.Forms.DataGridView();
            this.dataGridViewVariables = new System.Windows.Forms.DataGridView();
            this.dataGridViewLiterals = new System.Windows.Forms.DataGridView();
            this.dataGridViewTokens = new System.Windows.Forms.DataGridView();
            this.buttonSynytaxAnalys = new System.Windows.Forms.Button();
            this.listBoxMatrix = new System.Windows.Forms.ListBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLexeme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeywords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeparators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLiterals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLexeme
            // 
            this.dataGridViewLexeme.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewLexeme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLexeme.Location = new System.Drawing.Point(290, 12);
            this.dataGridViewLexeme.Name = "dataGridViewLexeme";
            this.dataGridViewLexeme.RowHeadersVisible = false;
            this.dataGridViewLexeme.Size = new System.Drawing.Size(252, 666);
            this.dataGridViewLexeme.TabIndex = 0;
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(12, 360);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(62, 48);
            this.ButtonOpenFile.TabIndex = 1;
            this.ButtonOpenFile.Text = "Открыть файл";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(12, 12);
            this.textBoxCode.Multiline = true;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(239, 342);
            this.textBoxCode.TabIndex = 3;
            this.textBoxCode.Text = "Public Sub Main(  )\r\n\tDim x as integer\r\n\tDim i, a as boolean\r\n\tfor i=1 to 10\r\n\t  " +
    "  x= i*(4+3)/a+60/(6+4)*5-12\r\n                next i\r\nEndSub";
            // 
            // dataGridViewKeywords
            // 
            this.dataGridViewKeywords.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewKeywords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeywords.Location = new System.Drawing.Point(584, 12);
            this.dataGridViewKeywords.Name = "dataGridViewKeywords";
            this.dataGridViewKeywords.RowHeadersVisible = false;
            this.dataGridViewKeywords.Size = new System.Drawing.Size(189, 396);
            this.dataGridViewKeywords.TabIndex = 4;
            // 
            // dataGridViewSeparators
            // 
            this.dataGridViewSeparators.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewSeparators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeparators.Location = new System.Drawing.Point(801, 12);
            this.dataGridViewSeparators.Name = "dataGridViewSeparators";
            this.dataGridViewSeparators.RowHeadersVisible = false;
            this.dataGridViewSeparators.Size = new System.Drawing.Size(189, 396);
            this.dataGridViewSeparators.TabIndex = 5;
            // 
            // dataGridViewVariables
            // 
            this.dataGridViewVariables.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVariables.Location = new System.Drawing.Point(584, 414);
            this.dataGridViewVariables.Name = "dataGridViewVariables";
            this.dataGridViewVariables.RowHeadersVisible = false;
            this.dataGridViewVariables.Size = new System.Drawing.Size(189, 264);
            this.dataGridViewVariables.TabIndex = 6;
            // 
            // dataGridViewLiterals
            // 
            this.dataGridViewLiterals.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewLiterals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLiterals.Location = new System.Drawing.Point(801, 414);
            this.dataGridViewLiterals.Name = "dataGridViewLiterals";
            this.dataGridViewLiterals.RowHeadersVisible = false;
            this.dataGridViewLiterals.Size = new System.Drawing.Size(189, 264);
            this.dataGridViewLiterals.TabIndex = 7;
            // 
            // dataGridViewTokens
            // 
            this.dataGridViewTokens.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTokens.Location = new System.Drawing.Point(1009, 12);
            this.dataGridViewTokens.Name = "dataGridViewTokens";
            this.dataGridViewTokens.RowHeadersVisible = false;
            this.dataGridViewTokens.Size = new System.Drawing.Size(252, 666);
            this.dataGridViewTokens.TabIndex = 8;
            // 
            // buttonSynytaxAnalys
            // 
            this.buttonSynytaxAnalys.Location = new System.Drawing.Point(146, 360);
            this.buttonSynytaxAnalys.Name = "buttonSynytaxAnalys";
            this.buttonSynytaxAnalys.Size = new System.Drawing.Size(105, 48);
            this.buttonSynytaxAnalys.TabIndex = 9;
            this.buttonSynytaxAnalys.Text = "Анализировать код";
            this.buttonSynytaxAnalys.UseVisualStyleBackColor = true;
            this.buttonSynytaxAnalys.Click += new System.EventHandler(this.buttonSynytaxAnalys_Click);
            // 
            // listBoxMatrix
            // 
            this.listBoxMatrix.FormattingEnabled = true;
            this.listBoxMatrix.Location = new System.Drawing.Point(12, 414);
            this.listBoxMatrix.Name = "listBoxMatrix";
            this.listBoxMatrix.Size = new System.Drawing.Size(239, 264);
            this.listBoxMatrix.TabIndex = 10;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 681);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 13);
            this.labelMessage.TabIndex = 11;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(78, 360);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(62, 48);
            this.resetButton.TabIndex = 12;
            this.resetButton.Text = "Сброс";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // FormTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 699);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.listBoxMatrix);
            this.Controls.Add(this.buttonSynytaxAnalys);
            this.Controls.Add(this.dataGridViewTokens);
            this.Controls.Add(this.dataGridViewLiterals);
            this.Controls.Add(this.dataGridViewVariables);
            this.Controls.Add(this.dataGridViewSeparators);
            this.Controls.Add(this.dataGridViewKeywords);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.ButtonOpenFile);
            this.Controls.Add(this.dataGridViewLexeme);
            this.Name = "FormTranslator";
            this.Text = "Транслятор подмножества языка VB";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLexeme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeywords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeparators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLiterals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLexeme;
        private System.Windows.Forms.Button ButtonOpenFile;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dataGridViewKeywords;
        private System.Windows.Forms.DataGridView dataGridViewSeparators;
        private System.Windows.Forms.DataGridView dataGridViewVariables;
        private System.Windows.Forms.DataGridView dataGridViewLiterals;
        private System.Windows.Forms.DataGridView dataGridViewTokens;
        private System.Windows.Forms.Button buttonSynytaxAnalys;
        private System.Windows.Forms.ListBox listBoxMatrix;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button resetButton;
    }
}

