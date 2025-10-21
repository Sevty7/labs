using System.Xml.Serialization;

namespace lab3
{
    public class TextSerializer
    {
        public static void Serialize(Text text, string fileName)
        {
            var serializer = new XmlSerializer(typeof(Text));

            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, text);
            }
        }
    }
}
