using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupTables();
        }

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
            ClearDataGridViews();
            try
            {
                LexicalAnalizator analizator = new LexicalAnalizator(textBoxCode.Text);
                FillDataInTables(analizator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

            foreach (var item in analizator.tokens)
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
    }
    class LexicalAnalizator
    {
        private List<(string, string)> typesValuesPairs;
        List<string> variables = new List<string>();
        public List<string> Variables
        {
            get { return variables; }
            private set { variables = value; }
        }
        public List<string> Literals
        {
            get { return literals; }
            private set { literals = value; }
        }
        List<string> literals = new List<string>();
        public List<(string, int)> tokens = new List<(string, int)>();
        public List<(string, int)> Tokens
        {
            get { return tokens; }
            private set { tokens = value; }
        }

        public List<(string, string)> TypesValuesPairs
        {
            get { return typesValuesPairs; }
            private set { typesValuesPairs = value; }
        }
        string line;

        readonly string separatorsSingle = "+-*/=,.\n()><!"; 
        readonly string[] separatorsPairs = { "++", "--", "+=", "-=", "*=", "/=", "==", "!=", ">=", "<=" };
        public readonly string[] KeyWords = { "Dim", "as", "integer", "double", "float", "for", "to", "next" };
        string[] separators;
        public string[] Separators
        {
            get { return separators; }
            private set { separators = value; }
        }

        

        string state = "S";
        string buffer = "";
        public LexicalAnalizator(string line)
        {
            this.line = line;
            typesValuesPairs = new List<(string, string)>();
            StartAnalys();
            CompleteAnalys();
        }

        void CompleteAnalys()
        {
            //////////////////////////////////починить костыль
            string[] tmp = new string[separatorsSingle.Length];            
            for (int i = 0; i < tmp.Length; i++)
                tmp[i] = separatorsSingle[i].ToString();
            //////////////////////////////////////////////////////

            string type = "Unknown";
            separators = new string[separatorsSingle.Length + separatorsPairs.Length];
            Array.Copy(tmp, separators, separatorsSingle.Length);
            Array.Copy(separatorsPairs, 0, separators, separatorsSingle.Length, separatorsPairs.Length);
            for (int i = 0; i < typesValuesPairs.Count; i++)
            {

                if (KeyWords.Any(typesValuesPairs[i].Item1.Contains))
                    type = "Keyword";
                else if (separators.Any(typesValuesPairs[i].Item1.Contains))
                    type = "Separator";
                else if (typesValuesPairs[i].Item2 == "I")
                    type = "Variable";
                else if (typesValuesPairs[i].Item2 == "D")
                    type = "Literal";
                else
                    throw new Exception("Неопределенные данные в таблице");
                type = CreateToken(type, separators, i);
            }
        }

        private string CreateToken(string type, string[] separators, int i)
        {
            switch (type)
            {
                case "Keyword":
                    for (int j = 0; j < KeyWords.Length; j++)
                        if (KeyWords[j] == typesValuesPairs[i].Item1)
                        {
                            tokens.Add((type, j));
                            goto default;
                        }
                    goto default;
                case "Separator":
                    for (int j = 0; j < separators.Length; j++)
                        if (separators[j] == typesValuesPairs[i].Item1)
                        {
                            tokens.Add((type, j));
                            goto default;
                        }
                    goto default;
                case "Variable":
                    if (!variables.Contains(typesValuesPairs[i].Item1))
                        variables.Add(typesValuesPairs[i].Item1);
                    tokens.Add((type, variables.IndexOf(typesValuesPairs[i].Item1)));
                    goto default;
                case "Literal":
                    if (!literals.Contains(typesValuesPairs[i].Item1))
                        literals.Add(typesValuesPairs[i].Item1);
                    tokens.Add((type, literals.IndexOf(typesValuesPairs[i].Item1)));
                    goto default;
                default:
                    type = "Unknown";
                    break;
            }
            return type;
        }

        void StartAnalys()
        {
            state = "S";
            for (int i = 0; i < line.Length; i++)
            {
                switch (state)
                {
                    case "S": //состояние неопределенности
                        if (CheckIsDigit(i)) //проверка на числа
                        {
                            state = "D";
                            goto case "D";
                        }
                        else if (CheckIsEnglishAlph(i)) //проверка на английский алфавит
                        {
                            state = "I";
                            goto case "I";
                        }
                        else if (CheckIsSingleSeparators(i)) //Проверка на сепараторы
                        {
                            state = "R";
                            goto case "R";
                        }
                        else if (CheckIsSpace(i) || CheckIsR(i)) //Проверка на пообел
                        {
                            continue;
                        }
                        else
                        {
                            throw new Exception("Неверно задан код");
                        }
                    case "R": //состояние сепаратора
                        Add(i);                      
                        if (CheckOutOfRange(i + 1) && CheckIsNotSingleSeparators(i+1))
                        {
                            i = Next(i);
                            goto case "R";
                        }
                        else
                        {
                            Out(buffer, state);
                            goto default;
                        }
                    case "D": //состояние литерала 
                        Add(i);
                        if (CheckOutOfRange(i + 1) && (CheckIsDigit(i + 1)))
                        {
                            i = Next(i);
                            goto case "D";
                        }
                        else
                        {
                            Out(buffer, state);
                            goto default;
                        }
                    case "I": //состояние идентификатора
                        Add(i);
                        if (CheckOutOfRange(i + 1) && ((CheckIsDigit(i + 1)) || CheckIsEnglishAlph(i + 1)))
                        {
                            i = Next(i);
                            goto case "I";
                        }
                        else
                        {
                            Out(buffer, state);
                            goto default;
                        }
                    default:
                        state = "S";
                        break;
                }

            }
        }

        private static int Next(int i)
        {
            return ++i;
        }

        private bool CheckOutOfRange(int i)
        {
            return i < line.Length;
        }

        private bool CheckIsSpace(int i)
        {
            return line[i] == ' ';
        }
        private bool CheckIsR(int i)
        {
            return line[i] == '\r';
        }
        private bool CheckIsDigit(int i)
        {
            return Char.IsDigit(line[i]) /*&& (state == "S" || state == "D")*/;
        }

        private bool CheckIsEnglishAlph(int i)
        {
            return ((int)line[i] >= 65 && (int)line[i] <= 90) || ((int)line[i] >= 97 && (int)line[i] <=122);
        }

        private bool CheckIsSingleSeparators(int i)
        {
            return line[i].ToString().Any(letter => separatorsSingle.Contains(letter));
        }
        private bool CheckIsNotSingleSeparators(int i)
        {
            string tmp = buffer + line[i];
            bool check = false;
            foreach (var item in separatorsPairs)         
                if (item == tmp)
                    check = true;
            return check; 
        }

        private void Add(int i)
        {
            buffer += line[i];
        }
        private void Out(string buffer, string state)
        {
            if (buffer.Length > 0)
            {
                typesValuesPairs.Add((buffer, state));
                this.buffer = "";
            }
        }
    }

}
