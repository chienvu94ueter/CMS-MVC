
using System.Collections.Generic;
using System.Linq;
using ModelCPro.EntityFrameWork;

namespace ModelCPro.DataAccessLayer
{
    public class MenuDal
    {
        private CProDbContext db = null;

        public MenuDal()
        {
            db = new CProDbContext();
        }
        // Lay ra tat ca cac danh muc trong co so du lieu
        // Lay theo TypeID
        public List<Menu> GetAllMenus(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId).ToList(); 
        } 
    }
}
