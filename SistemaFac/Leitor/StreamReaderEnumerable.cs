using System;
using System.Collections.Generic;
using System.IO;

namespace SistemaFac.Leitor
{
    public static class StreamReaderEnumerable
    {
        public static IEnumerable<String> Lines(this StreamReader source)
        {
            String line;

            if (source == null)
                throw new ArgumentNullException("source");

            while ((line = source.ReadLine()) != null)
                yield return line;
        }
    }
}
