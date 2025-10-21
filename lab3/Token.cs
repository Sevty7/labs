using System.Xml.Serialization;

namespace lab3
{
    [XmlInclude(typeof(Word))]
    [XmlInclude(typeof(Punctuation))]
    public abstract class Token
    {
        [XmlText]
        public string value { get; set; }

        public Token() { }

        public Token(string value)
        {
            this.value = value;
        }
        public override string ToString() => value;
    }
}
