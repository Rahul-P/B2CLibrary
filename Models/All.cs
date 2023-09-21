
namespace B2CLibrary.Models
{
    public sealed class CreateApplication
    {
        public string Name { get; private set; }
        public CreateApplication(string _passedName)
        {
            this.Name = _passedName;
        }
    }

    public sealed class ReqRoles
    {
        public string ApplicationId { get; private set; }
        public string ResourceAppId { get; private set; }
        public string[] RoleIds { get; private set; }

        public ReqRoles(string _passedApplicationId, string _passedResourceAppId, string[] _passedRoleIds)
        {
            this.ApplicationId = _passedApplicationId;
            this.ResourceAppId = _passedResourceAppId;
            this.RoleIds = _passedRoleIds;
        }
    }

    public sealed class CreateSecret
    {
        public string Name { get; private set; }
        public string ApplicationObjectId { get; private set; }

        public CreateSecret(string _passedName, string _passedApplicationObjectId)
        {
            this.Name = _passedName;
            this.ApplicationObjectId = _passedApplicationObjectId;
        }
    }

    public sealed class CreateServicePrincipal
    {
        public string ApplicationId { get; private set; }

        public CreateServicePrincipal(string _passedApplicationId)
        {
            this.ApplicationId = _passedApplicationId;
        }
    }

    public sealed class AssignRoleToServicePrincipal {
        public string PrincipalId { get; private set; }
        public string ResourceId { get; private set; }
        public string ApplicationRoleId { get; private set; }

        public AssignRoleToServicePrincipal(string _passedPrincipalId, string _passedResourceId, string _passedApplicationRoleId)
        {
            this.PrincipalId = _passedPrincipalId;
            this.ResourceId = _passedResourceId;
            this.ApplicationRoleId = _passedApplicationRoleId;
        }
    }
}
