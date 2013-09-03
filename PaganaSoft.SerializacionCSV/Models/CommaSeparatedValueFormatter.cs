using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PaganaSoft.SerializacionCSV.Models
{
    public class CommaSeparatedValueFormatter : IFormatter
    {
        public CommaSeparatedValueFormatter()
        {
            this.Context = new StreamingContext(StreamingContextStates.All);
        }

        #region IFormatter Members

        public SerializationBinder Binder { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }
        public StreamingContext Context { get; set; }

        public object Deserialize(System.IO.Stream serializationStream)
        {
            throw new NotImplementedException();
        }

        public void Serialize(System.IO.Stream serializationStream, object graph)
        {
            var Campos = FormatterServices.GetSerializableMembers(graph.GetType(),
                  this.Context);
            var Datos = FormatterServices.GetObjectData(graph, Campos);
            StreamWriter sw = new StreamWriter(serializationStream);
            sw.WriteLine("@ClassName={0}", graph.GetType().FullName);
            for (int i = 0; i < Campos.Length; i++)
            {
                sw.WriteLine("{0}={1}", Campos[i].Name, Datos[i].ToString());
            }
            sw.Close();
        }      
       

        #endregion
    }
}
