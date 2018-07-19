
namespace Lands.Models
{
    using Newtonsoft.Json;

    public class Currency
    {
        //https://www.youtube.com/watch?v=JIFT4GY1qFg&t=1609s 30:00
        // al convertir la información de Json2sharp trae el nombre de las propiedades en minusculas
        //como en sharp las manejamos primera en mayúscula, entonces hacemos propertyname para indicar como vienen
        //y aqui le colocamos un alias de como queremos llamarlo

        [JsonProperty(PropertyName="code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }
    }
}
