
using Sitecore.Pipelines;

namespace SitecoreUser.Pipelines
{
    public interface IPipelineRunner
    {
        void Run(string p_PipelineName,
                 PipelineArgs p_Args);
    }
}
