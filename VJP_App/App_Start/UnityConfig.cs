using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using VJP_Interface;
using VJP_Repository;

namespace VJP_App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IAccountTypeRepository, AccountTypeRepository>();
            container.RegisterType<ICommentsRepository, CommentsRepository>();
            container.RegisterType<IEducationDetailsRepository, EducationDetailsRepository>();
            container.RegisterType<IEventRepository, EventRepository>();
            container.RegisterType<IEventSubscribeRepository, EventSubscribeRepository>();
            container.RegisterType<IEventCategoryRepository, EventCategoryRepository>();
            container.RegisterType<IProjectCategoryEventRepository, ProjectCategoryEventRepository>();
            container.RegisterType<IExperienceDetailsRepository, ExperienceDetailsRepository>();
            container.RegisterType<IJobApplyActivityRepository, JobApplyActivityRepository>();
            container.RegisterType<IJobCategoryRepository, JobCategoryRepository>();
            container.RegisterType<IJobPostRepository, JobPostRepository>();
            container.RegisterType<IJudgeRepository, JudgeRepository>();
            container.RegisterType<IOrganizationRepository, OrganizationRepository>();
            container.RegisterType<IProjectRepository, ProjectRepository>();
            container.RegisterType<IProjectCategoryRepository, ProjectCategoryRepository>();
            container.RegisterType<IProjectGroupRepository, ProjectGroupRepository>();
            container.RegisterType<IRatingRepository, RatingRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}