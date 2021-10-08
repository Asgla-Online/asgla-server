using Newtonsoft.Json.Linq;

namespace Asgla.Explosion.Interface {
    interface IDispatch {

        void Dispatch(string[] json);

        void Dispatch(JObject json);

    }
}
