using System.Xml.Serialization;

namespace lab3
{
    [XmlType("word")]
    public class Word : Token
    {
        public string content
        {
            get { return value; }
        }
        public int length
        {
            get { return value.Length; }
        }

        public Word() : base() { }

        public Word(string content) : base(content)
        {
        }
    }
}
