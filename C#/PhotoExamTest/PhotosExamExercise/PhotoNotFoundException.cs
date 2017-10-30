using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PhotosExamExercise
{
    public class PhotoNotFoundException : Exception
    {
        public PhotoNotFoundException()
        {
        }

        public PhotoNotFoundException(string message) : base(message)
        {
        }

        public PhotoNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PhotoNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
