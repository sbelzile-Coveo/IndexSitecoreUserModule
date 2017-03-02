
using Sitecore.Pipelines;

namespace SitecoreUser.Pipelines
{
    public interface IPipelineRunnerHandler
    {
        void RunPipeline(PipelineArgs p_Args);

        void RunPipeline(PipelineArgs p_Args,
                         string p_PipelineName);
    }
}
