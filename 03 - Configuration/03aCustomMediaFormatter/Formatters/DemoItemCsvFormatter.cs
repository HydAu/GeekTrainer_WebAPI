using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using _03aCustomMediaFormatter.Models;

namespace _03aCustomMediaFormatter.Formatters
{
    public class DemoItemCsvFormatter : BufferedMediaTypeFormatter
    {
        public DemoItemCsvFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv-demoitem"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(DemoItem) || typeof(IEnumerable<DemoItem>).IsAssignableFrom(type);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                writer.WriteLine("Id,Number,Text");

                var list = value as IEnumerable<DemoItem>;
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        WriteDemoItem(item, writer);
                    }
                }
                else
                {
                    var item = value as DemoItem;
                    if (item == null)
                    {
                        throw new InvalidOperationException("Type not supported.");
                    }
                    WriteDemoItem(item, writer);
                }
            }
        }

        private static void WriteDemoItem(DemoItem item, TextWriter writer)
        {
            writer.WriteLine("\"{0}\",{1},\"{2}\"", item.Id, item.Number, item.Text);
        }
    }
}