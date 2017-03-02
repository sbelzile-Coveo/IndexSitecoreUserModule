
using Sitecore.Pipelines;

namespace SitecoreUser.Pipelines
{
    public class PipelineRunnerHandler : IPipelineRunnerHandler
    {
        private readonly IPipelineRunner m_PipelineRunner;

        public PipelineRunnerHandler(IPipelineRunner p_PipelineRunner)
        {
            m_PipelineRunner = p_PipelineRunner;
        }

        public void RunPipeline(PipelineArgs p_Args)
        {
            string pipelineName = GetPipelineName(p_Args);
            if (pipelineName != null)
            {
                m_PipelineRunner.Run(pipelineName, p_Args);
            }
        }

        public void RunPipeline(PipelineArgs p_Args, string p_PipelineName)
        {
            m_PipelineRunner.Run(p_PipelineName, p_Args);
        }

        public static string GetPipelineName(PipelineArgs p_Args)
        {
            IPipelineArgs coveoPipelineArgs = p_Args as IPipelineArgs;
            return coveoPipelineArgs?.PipelineName;
        }
    }
}
