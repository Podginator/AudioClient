﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioClient_Tom.Utilities
{
    class ProducerConsumerStream : Stream
    {
        private readonly MemoryStream innerStream;
        private long readPosition;
        private long writePosition;

        public ProducerConsumerStream()
        {
            innerStream = new MemoryStream();
        }

        public override bool CanRead { get { return true; } }

        public override bool CanSeek { get { return false; } }

        public override bool CanWrite { get { return true; } }

        public override void Flush()
        {
            lock (innerStream)
            {
                innerStream.Flush();
            }
        }


        public long ReadPosition
        {
            get
            {
                lock (innerStream)
                {
                    return readPosition;
                }
            }

            set
            {
                lock (innerStream)
                {
                    readPosition = value;
                }
            }
        }

        public long WritePosition
        {
            get
            {
                lock (innerStream)
                {
                    return writePosition;
                }
            }

            set
            {
                lock (innerStream)
                {
                    writePosition = value;
                }
            }
        }

        public override long Length
        {
            get
            {
                lock (innerStream)
                {
                    return innerStream.Length;
                }
            }
        }

        public override long Position
        {
            get
            {
                return innerStream.Position;
            }
            set
            {
                readPosition = value;
                writePosition = value;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            lock (innerStream)
            {
                innerStream.Position = readPosition;
                int red = innerStream.Read(buffer, offset, count);
                readPosition = innerStream.Position;

                return red;
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            lock (innerStream)
            {
                innerStream.Position = writePosition;
                innerStream.Write(buffer, offset, count);
                writePosition = innerStream.Position;
            }
        }
    }
}
