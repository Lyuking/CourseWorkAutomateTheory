using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class SyntaxExceptions
    {
        public class PublicIsMissingException : Exception
        {
            public PublicIsMissingException(string currentValue) : base(String.Format("Ожидалось Public, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class SubIsMissingException : Exception
        {
            public SubIsMissingException(string currentValue) : base(String.Format("Ожидалось Sub, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class MainIsMissingException : Exception
        {
            public MainIsMissingException(string currentValue) : base(String.Format("Ожидалось Main, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class LeftBracketIsMissingException : Exception
        {
            public LeftBracketIsMissingException(string currentValue) : base(String.Format("Ожидалось (, вместо этого обнаружено: {0}", currentValue))  { }
        }
        public class RightBracketIsMissingException : Exception
        {
            public RightBracketIsMissingException(string currentValue) : base(String.Format("Ожидалось ), вместо этого обнаружено: {0}", currentValue)) { }       
        }
        public class NewLineIsMissingException : Exception
        {
            public NewLineIsMissingException(string currentValue) : base(String.Format("Ожидался переход на новую строку (/n), вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class DimForIdIsMissingException : Exception
        {
            public DimForIdIsMissingException(string currentValue) : base(String.Format("Ожидалость dim/for/id, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class ForIsMissingException : Exception
        {
            public ForIsMissingException(string currentValue) : base(String.Format("Ожидалость for, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class DimIsMissingException : Exception
        {
            public DimIsMissingException(string currentValue) : base(String.Format("Ожидалость dim, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class IdIsMissingException : Exception
        {
            public IdIsMissingException(string currentValue) : base(String.Format("Ожидалость id, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class EndSubIsMissingException : Exception
        {
            public EndSubIsMissingException(string currentValue) : base(String.Format("Ожидалость EndSub, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class IdOrLitIsMissingException : Exception
        {
            public IdOrLitIsMissingException(string currentValue) : base(String.Format("Ожидалость id/lit, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class TypeIsMissingException : Exception
        {
            public TypeIsMissingException(string currentValue) : base(String.Format("Ожидалость integer/float/boolean, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class EqualIsMissingException : Exception
        {
            public EqualIsMissingException(string currentValue) : base(String.Format("Ожидалость =, вместо этого обнаружено: \"{0}\"", currentValue)) { }
        }
        public class NextIsMissingException : Exception
        {
            public NextIsMissingException(string currentValue) : base(String.Format("Ожидалость next, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class ToIsMissingException : Exception
        {
            public ToIsMissingException(string currentValue) : base(String.Format("Ожидалость to, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class CommaIsMissingException : Exception
        {
            public CommaIsMissingException(string currentValue) : base(String.Format("Ожидалость \",\", вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class AsIsMissingException : Exception
        {
            public AsIsMissingException(string currentValue) : base(String.Format("Ожидалость as, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class CommaOrAsIsMissingException : Exception
        {
            public CommaOrAsIsMissingException(string currentValue) : base(String.Format("Ожидалость as или \",\", вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class EqualsOrNewLineIsMissingException : Exception
        {
            public EqualsOrNewLineIsMissingException(string currentValue) : base(String.Format("Ожидалость = или \\n , вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class DimForIdEndSubNextIsMissingException : Exception
        {
            public DimForIdEndSubNextIsMissingException(string currentValue) : base(String.Format("Ожидалость dim/for/id/EndSub/next, вместо этого обнаружено: {0}", currentValue)) { }
        }
        public class StackIsEmptyException : Exception
        {
            public StackIsEmptyException(string currentValue) : base(String.Format("Не хватает операндов для выполнения указанных арифметических операций, ошибка возникла на лексеме № {0}", currentValue)) { }
        }
        public class StackIsNotEmptyException : Exception
        {
            public StackIsNotEmptyException(string currentValue) : base(String.Format("Найдено лишнее действие или число на лексеме № {0}", currentValue)) { }
        }
    }
}
