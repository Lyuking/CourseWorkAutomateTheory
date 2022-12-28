using System;
using System.Collections.Generic;

namespace CourseWork
{
    public class SyntaxAnalizator
    {
        List<string> matrix;
        public List<string> Matrix
        {
            get { return matrix; } 
        }
        LexicalAnalizator lexicalAnalizator;
        int lexemeCounter , exprCounter;
        public SyntaxAnalizator(LexicalAnalizator lexicalAnalizator)
        {
            this.lexicalAnalizator = lexicalAnalizator;
            matrix = new List<string>();
        }
        private string getLexemeFromTokens(string lexemeTypeName, int num)
        {
            switch(lexemeTypeName)
            {
                case "Keyword":
                 return lexicalAnalizator.KeyWords[num];
                case "Variable":
                    return "id";
                case "Literal":
                    return "lit";
                case "Separator":
                    return lexicalAnalizator.Separators[num];
                default:
                    return "undefined";
            }
        }
        private string getIDOrLitLexemeFromTokens(string lexemeTypeName, int num)
        {
            switch (lexemeTypeName)
            {
                case "Keyword":
                    goto default;
                case "Variable":
                    return lexicalAnalizator.Variables[num];
                case "Literal":
                    return lexicalAnalizator.Literals[num];
                case "Separator":
                    goto default;
                default:
                    return "undefined";
            }
        }
        public bool StartAnalys()
        {
            lexemeCounter = 0;
            matrix.Clear();
            return Progamma();
        }
        
        bool Progamma()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "Public")
            {
                throw new SyntaxExceptions.PublicIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));         
            }
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "Sub")
            {
                throw new SyntaxExceptions.SubIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "Main")
            {
                throw new SyntaxExceptions.MainIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "(")
            {
                throw new SyntaxExceptions.LeftBracketIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != ")")
            {
                throw new SyntaxExceptions.RightBracketIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "\n")
            {
                throw new SyntaxExceptions.NewLineIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
            IncreaseLexemeCounter();
            SpisokOperatorov();          
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "\n")
            {
                throw new SyntaxExceptions.NewLineIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "EndSub")
            {
                throw new SyntaxExceptions.EndSubIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));

            }
            return true;
        }
        private void IncreaseLexemeCounter()
        {
            ++lexemeCounter;
        }

        void SpisokOperatorov()
        {
            string currentLexeme = getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2);
            if (currentLexeme == "Dim" || currentLexeme == "for" || currentLexeme == "id")
            {
                TeloSpiska();
                Fact1();
            }
            else
            {
                throw new SyntaxExceptions.DimForIdIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
        }
        void TeloSpiska()
        {
            string currentLexeme = getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2);
            if (currentLexeme == "Dim")
            {
                ObyavleniePeremennih();
            }
            else if (currentLexeme == "for")
            {
                CycleOper();
            }
            else if (currentLexeme == "id")
            {
                PrisvaivanieOper();
            }
            else
            {
                throw new SyntaxExceptions.DimForIdIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
        }
        void Fact1()
        {
            if(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "\n")
            {
                throw new SyntaxExceptions.NewLineIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            }
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter + 1].Item1, lexicalAnalizator.Tokens[lexemeCounter + 1].Item2) == "Dim" ||
                getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter + 1].Item1, lexicalAnalizator.Tokens[lexemeCounter + 1].Item2) == "for" ||
                getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter + 1].Item1, lexicalAnalizator.Tokens[lexemeCounter + 1].Item2) == "id")
            {
                Rec1();
            }
            else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter + 1].Item1, lexicalAnalizator.Tokens[lexemeCounter + 1].Item2) == "EndSub" ||
                getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter + 1].Item1, lexicalAnalizator.Tokens[lexemeCounter + 1].Item2) == "next")
                return;
            else
                throw new SyntaxExceptions.DimForIdEndSubNextIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter + 1].Item1, lexicalAnalizator.Tokens[lexemeCounter + 1].Item2));
        }
        void Rec1()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "\n")
                throw new SyntaxExceptions.NewLineIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); TeloSpiska(); Fact1();
        }
        
        void ObyavleniePeremennih()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "Dim")
                throw new SyntaxExceptions.DimIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); SpisokPeremennih();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "as")
                throw new SyntaxExceptions.AsIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); Type(); IncreaseLexemeCounter(); Initialization();
        }
        void Type()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "integer" &&
                 getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "float" &&
                 getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "boolean")
                throw new SyntaxExceptions.TypeIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            return;
        }
        void Initialization()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "=")
            {
                IncreaseLexemeCounter(); Operand();
            }
            else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "\n")
            {
                return;
            }
            else throw new SyntaxExceptions.EqualsOrNewLineIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
        }
        void SpisokPeremennih()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "id")
                throw new SyntaxExceptions.IdIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); Fact2();
        }
        void Fact2()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == ",")
            {
                Rec2();
            }
            else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "as")
                return;
            else throw new SyntaxExceptions.CommaOrAsIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
        }
        void Rec2()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != ",")
                throw new SyntaxExceptions.CommaIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "id")
                throw new SyntaxExceptions.IdIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); Fact2();
        }
        void CycleOper()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "for")
                throw new SyntaxExceptions.ForIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "id")
                throw new SyntaxExceptions.IdIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "=")
                throw new SyntaxExceptions.EqualIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); Operand(); IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "to")
                throw new SyntaxExceptions.ToIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); Operand(); IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "\n")
                throw new SyntaxExceptions.NewLineIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); SpisokOperatorov(); //question mark
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "\n")
                throw new SyntaxExceptions.NewLineIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "next")
                throw new SyntaxExceptions.NextIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "id")
                throw new SyntaxExceptions.IdIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter();
        }
        void PrisvaivanieOper()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "id")
                throw new SyntaxExceptions.IdIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter();
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "=")
                throw new SyntaxExceptions.EqualIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            IncreaseLexemeCounter(); 
            if(getIDOrLitLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "undefined" && 
                (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "(" && getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != ")"))
                throw new SyntaxExceptions.IdOrLitIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            List<string> tmpmatrix = Expr();
            if (tmpmatrix.Count > 0)
            {
                matrix.AddRange(tmpmatrix);
                matrix.Add("-----------------------------------------");
            }
            //question mark
        }
        void Operand()
        {
            if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "id" &&
                 getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) != "lit")
                throw new SyntaxExceptions.IdOrLitIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
            return;
        }
        List<string> Expr()
        {
            //IncreaseLexemeCounter();
            Stack<string> T = new Stack<string>();
            Stack<string> E = new Stack<string>();
            List<string> matrix = new List<string>();
            exprCounter = 0;
            if ((getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "\n"))
                throw new Exception("Ошибка! После \"=\" Отсутствует выражение или операнд.");
            if ((getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "id" ||
                getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "lit")
                && getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter + 1].Item1, lexicalAnalizator.Tokens[lexemeCounter + 1].Item2) == "\n")
            {
                IncreaseLexemeCounter(); return matrix;
            }
            do
            {
                if (IsOperator())
                {
                    Koperand(E, getIDOrLitLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                }
                else if (IsOperation())
                {
                    string s = getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2);
                    if (T.Count == 0)
                    {
                        if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "\n")
                            if (T.Count == 0 && E.Count <= 1)
                                return matrix; //D6
                            else
                                throw new SyntaxExceptions.StackIsNotEmptyException(exprCounter.ToString());
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "(")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "+" ||
                            getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "-")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "*" ||
                            getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "/")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == ")")
                            D5(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2), "(");
                    }
                    else if (T.Peek() == "(")
                    {
                        if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "\n")
                            D5(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2), ")");
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "(")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "+" ||
                            getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "-")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "*" ||
                            getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "/")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == ")")
                            D3(T);
                    }
                    else if (T.Peek() == "+" || T.Peek() == "-")
                    {
                        if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "\n")
                            D4(matrix, E, T);
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "(")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "+" ||
                            getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "-")
                            D2(matrix, E, T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "*" ||
                            getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "/")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == ")")
                            D4(matrix, E, T);
                    }
                    else if(T.Peek() == "*" || T.Peek() == "/")
                    {
                        if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "\n")
                            D4(matrix, E, T);
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "(")
                            D1(T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "+" ||
                            getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "-")
                            D4(matrix, E, T);
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "*" ||
                            getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "/")
                            D2(matrix, E, T, getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                        else if (getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == ")")
                            D4(matrix, E, T);
                    }
              
                } 
                else
                {
                    throw new SyntaxExceptions.IdOrLitIsMissingException(getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2));
                }
            } while (true);
            return matrix;
        }
        void Koperand(Stack<string> E, string operand)
        {
            E.Push(operand);
            IncreaseLexemeCounter();
            ++exprCounter;
        }

        void D1(Stack<string> T, string operation)
        {
            T.Push(operation);
            IncreaseLexemeCounter();
            ++exprCounter;

        }
        void D3(Stack<string> T)
        {
            T.Pop();
            IncreaseLexemeCounter();
            ++exprCounter;

        }
        void D2(List<string> matrix, Stack<string> E, Stack<string> T, string operation)
        {
            Koperation(matrix, E, T.Pop());
            T.Push(operation);
            IncreaseLexemeCounter();
            ++exprCounter;
        }
        void Koperation(List<string> matrix, Stack<string> E, string operation)
        {
            try
            {
                string operand2 = E.Pop();
                string operand1 = E.Pop();
                matrix.Add($"M{matrix.Count + 1}:= {operation} {operand1} {operand2}");
            }
            catch 
            {
                throw new SyntaxExceptions.StackIsEmptyException(exprCounter.ToString());
            }
            E.Push($"M{matrix.Count}");
        }
        void D4(List<string> matrix, Stack<string> E, Stack<string> T)
        {
            Koperation(matrix, E, T.Pop());
        }
        void D5(string currentLexeme, string expectedLexeme)
        {
            if (currentLexeme == "\n")
                currentLexeme = "\\n";
            throw new Exception($"Несогласованность скобок, отсутствует \"{expectedLexeme}\", причина вызова: \"{currentLexeme}\""); 
        }
        private bool IsOperator()
        {
            return getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "id" ||
                        getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "lit";
        }

        private bool IsOperation()
        {
            return getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "(" ||
                        getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == ")" ||
                        getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "+" ||
                        getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "-" ||
                        getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "*" ||
                        getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "/" ||
                        getLexemeFromTokens(lexicalAnalizator.Tokens[lexemeCounter].Item1, lexicalAnalizator.Tokens[lexemeCounter].Item2) == "\n";
        }
    }

}
