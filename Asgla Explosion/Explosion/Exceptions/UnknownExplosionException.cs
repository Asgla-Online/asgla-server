using System;
using System.Runtime.Serialization;

namespace Asgla.Explosion.Exceptions {

    [Serializable]
    public class UnknownExplosionException : Exception {
        public UnknownExplosionException() { }
        public UnknownExplosionException(string message) : base(message) { }
        public UnknownExplosionException(string message, Exception inner) : base(message, inner) { }
        protected UnknownExplosionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
