using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class FormTranslator : Form
    {
        public FormTranslator()
        {
            InitializeComponent();
            SetupTables();
        }
        LexicalAnalizator lexicalAnalizator;
        private void SetupTables()
        {
            dataGridViewLexeme.Columns.Add("Word", "Слово");
            dataGridViewLexeme.Columns.Add("Lexeme", "Лексема");
            dataGridViewLexeme.Columns[0].Width = dataGridViewLexeme.Width / 2;
            dataGridViewLexeme.Columns[1].Width = dataGridViewLexeme.Width / 2;

            dataGridViewKeywords.Columns.Add("Keywords", "Ключевые слова");
            dataGridViewKeywords.Columns.Add("Value", "Значение");
            dataGridViewKeywords.Columns[0].Width = dataGridViewKeywords.Width / 2;
            dataGridViewKeywords.Columns[1].Width = dataGridViewKeywords.Width / 2;

            dataGridViewSeparators.Columns.Add("Separators", "Разделители");
            dataGridViewSeparators.Columns.Add("Value", "Значение");
            dataGridViewSeparators.Columns[0].Width = dataGridViewSeparators.Width / 2;
            dataGridViewSeparators.Columns[1].Width = dataGridViewSeparators.Width / 2;

            dataGridViewVariables.Columns.Add("Variables", "Переменные");
            dataGridViewVariables.Columns.Add("Value", "Значение");
            dataGridViewVariables.Columns[0].Width = dataGridViewVariables.Width / 2;
            dataGridViewVariables.Columns[1].Width = dataGridViewVariables.Width / 2;

            dataGridViewLiterals.Columns.Add("Literals", "Литералы");
            dataGridViewLiterals.Columns.Add("Value", "Значение");
            dataGridViewLiterals.Columns[0].Width = dataGridViewLiterals.Width / 2;
            dataGridViewLiterals.Columns[1].Width = dataGridViewLiterals.Width / 2;

            dataGridViewTokens.Columns.Add("Table", "Таблица");
            dataGridViewTokens.Columns.Add("Value", "Значение");
            dataGridViewTokens.Columns[0].Width = dataGridViewTokens.Width / 2;
            dataGridViewTokens.Columns[1].Width = dataGridViewTokens.Width / 2;
        }

        private void ButtonLexemeAnalys_Click(object sender, EventArgs e)
        {
            
        }

        private void ClearDataGridViews()
        {
            dataGridViewLexeme.Rows.Clear();
            dataGridViewKeywords.Rows.Clear();
            dataGridViewVariables.Rows.Clear();
            dataGridViewSeparators.Rows.Clear();
            dataGridViewLiterals.Rows.Clear();
            dataGridViewTokens.Rows.Clear();
        }

        private void FillDataInTables(LexicalAnalizator analizator)
        {
            foreach (var item in analizator.TypesValuesPairs)
                dataGridViewLexeme.Rows.Add(item.Item1 != "\n" ? item.Item1 : "\\n", item.Item2);

            for (int i = 0; i < analizator.KeyWords.Length; i++)
                dataGridViewKeywords.Rows.Add(analizator.KeyWords[i], i);
            for (int i = 0; i < analizator.Separators.Length; i++)
                dataGridViewSeparators.Rows.Add(analizator.Separators[i], i);
            for (int i = 0; i < analizator.Variables.Count; i++)
                dataGridViewVariables.Rows.Add(analizator.Variables[i], i);
            for (int i = 0; i < analizator.Literals.Count; i++)
                dataGridViewLiterals.Rows.Add(analizator.Literals[i], i);

            foreach (var item in analizator.Tokens)
                dataGridViewTokens.Rows.Add(item.Item1, item.Item2);
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                string filename = openFileDialog.FileName;
                string fileText = GetTextFromTextFile(filename);
                textBoxCode.Text = fileText;
            }
        }

        private static string GetTextFromTextFile(string path)
        {

            return System.IO.File.ReadAllText(path);           
        }

        private void buttonSynytaxAnalys_Click(object sender, EventArgs e)
        {
            ClearDataGridViews();
            try
            {
                lexicalAnalizator = new LexicalAnalizator(textBoxCode.Text);
                FillDataInTables(lexicalAnalizator);
                if (lexicalAnalizator != null)
                {
                    SyntaxAnalizator syntaxAnalizator = new SyntaxAnalizator(lexicalAnalizator);
                    listBoxMatrix.Items.Clear();
                    syntaxAnalizator.StartAnalys();                  
                    foreach (var item in syntaxAnalizator.Matrix)
                    {
                        listBoxMatrix.Items.Add(item);
                    }
                    labelMessage.Text = DateTime.Now.ToString("HH:mm:ss") + " Успешный разбор.";
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = DateTime.Now.ToString("HH:mm:ss") + " Ошибка. " + ex.Message;
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            textBoxCode.Text = @"Public Sub Main(  )
	Dim x as integer
	Dim i, a as boolean
	for i=1 to 10
	    x= i*(4+3)/a+60/(6+4)*5-12
                next i
EndSub
";
        }
    }

}
