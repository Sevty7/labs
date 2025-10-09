using System.Text;

namespace lab3
{
    class Text
    {
        public List<Sentence> sentences { get; private set; } = new List<Sentence>();

        public void AddSentence(Sentence sentence)
        {
            sentences.Add(sentence);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var sentence in sentences)
            {
                if (result.Length > 0)
                    result.Append(' ');
                result.Append(sentence.ToString());
            }
            return result.ToString();
        }
    }
}
