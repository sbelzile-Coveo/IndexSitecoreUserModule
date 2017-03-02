
using Sitecore.Pipelines;

namespace SitecoreUser.Pipelines
{
    public interface IProcessor<in T> where T : PipelineArgs
    {
        void Process(T p_Args);
    }
}
