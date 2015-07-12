using System.Web.Mvc;
using AutoMapper;
using MVC5.DataLayer.Context;
using MVC5.ServiceLayer.Contracts;

namespace MVC5.Web.Areas.Adminstrator.Controllers
{
    public partial class GroupController : Controller
    {

        #region Fields

        private readonly IMappingEngine _mappingEngine;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupService _groupService;
        private readonly IApplicationRoleManager _roleManager;
        #endregion

        #region Constructor

        public GroupController(IUnitOfWork unitOfWork, IGroupService groupService, IApplicationRoleManager roleManager, IMappingEngine mappingEngine)
        {
            _unitOfWork = unitOfWork;
            _groupService = groupService;
            _mappingEngine = mappingEngine;
            _roleManager = roleManager;
        }
        #endregion
      
    }
}