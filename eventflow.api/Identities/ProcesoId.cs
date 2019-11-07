using EventFlow.Core;

namespace poc.eventflow
{
    public class ProcesoId : Identity<ProcesoId>
    {
        public ProcesoId(string value) : base(value)
        {
        }
    }
}