using System;
using Sitecore.Pipelines;

namespace SitecoreUser.Pipelines
{
    public class PipelineRunner : IPipelineRunner
    {
        public void Run(string p_PipelineName, PipelineArgs p_Args)
        {
            // TODO : Preconditions
            try
            {
                CorePipeline.Run(p_PipelineName, p_Args);
            }
            catch (InvalidOperationException exception)
            {
                // TODO : log exception
            }
            catch (Exception ex)
            {
                // TODO : logexception
                throw;
            }
        }
    }
}
