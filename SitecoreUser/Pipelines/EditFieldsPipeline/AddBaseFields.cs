using System;

namespace SitecoreUser.Pipelines.EditFieldsPipeline
{
    public class AddBaseFields : IProcessor<EditFieldsPipelineArgs>
    {
        public void Process(EditFieldsPipelineArgs p_Args)
        {
            p_Args.Item.SetField(FieldsConstants.USER_NAME_FIELD_NAME, p_Args.User.FullName);
            p_Args.Item.SetField(FieldsConstants.USER_EMAIL_FIELD_NAME, p_Args.User.Email);
            p_Args.Item.SetField(FieldsConstants.USER_DESCRIPTION_FIELD_NAME, p_Args.User.Description);
        }
    }
}
