using SalesWebMVC.Data;
using SalesWebMVC.Models;
using System.Runtime.Intrinsics.Arm;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(dp => dp.Name).ToList();
        }

    }
}
