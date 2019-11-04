using EventFlow.Core;

namespace poc.eventflow
{
    public class ProcesoIdentity : Identity<ProcesoIdentity>
    {
        public ProcesoIdentity(string value) : base(value)
        {
        }
    }
}