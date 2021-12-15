namespace DesignPatternsDemosClient.Services.Minis.Converters;

public interface IXmlConverter
{
     public T? ToObject<T>(string xmlString) where T : class;
}

public class XmlConverter: IXmlConverter
{
     public T? ToObject<T>(string xml) where T : class
     {
          var serializer = new XmlSerializer(typeof(T));
          using var stringReader = new StringReader(xml);

          return serializer.Deserialize(stringReader) as T;
     }
}