using Framework.Data;
using Runtime.Runtime.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Layout
{
    public class DelimitedLayoutBuilder
    {
        private readonly FileLayoutBuilderOptions BuilderOptions;
        private string[] Header;
        private MetaBase Layout { get; set; }
        public DelimitedLayoutBuilder(FileLayoutBuilderOptions builderOptions)
        {
            BuilderOptions = builderOptions;
        }
        public void Build()
        {
            ReadHeaderFromFile();
            BuildLayout();
        }

        private void ReadHeaderFromFile()
        {
            using (var reader = new DelimitedReader())
            {
                reader.Read();
                Header = reader.Header;
            }
        }

        private void BuildLayout()
        {
            Layout = new MetaFlatObject();
            foreach (var column in Header)
            {
                var element = new MetaElement() { Name = column };
                Layout.Elements.Add(element);
            }
        }

    }

    public class FileLayoutBuilderOptions
    {
        private string FilePath { get; set; }
    }
}
