﻿using System.IO;

namespace Varus.Paradox.Console.Interpreters.Python
{
    internal class OutputBufferWriter : StreamWriter
    {
        private readonly IOutputBuffer _output;

        public OutputBufferWriter(Stream s, IOutputBuffer output)
            : base(s)
        {
            _output = output;            
        }        

        public override void Write(string value)
        {            
            if (value != "\r\n")
                _output.Append(value);            
        }
    }    
}
