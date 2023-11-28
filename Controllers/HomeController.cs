using agency.Data;
using agency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace agency.Controllers
{
    public class HomeController : Controller
    {
        private readonly agencyContext _context;

        public static int currentUserId;

        private object locker=new object();

        public HomeController(agencyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult chooser()
        {
            return View();
        }

        public IActionResult chooser2()
        {
            return View();
        }
        public IActionResult registration1()
        {
            return View();
        }

        public IActionResult registration2()
        {
            return View();
        }
        public IActionResult autorization1()
        {
            return View();
        }

        public IActionResult autorization2()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create1(Employer usr)
        {
            usr.accessTime = 0;
            usr.companyName = "";
            usr.Description = "";
            _context.Add(usr);
            await _context.SaveChangesAsync();
            return View("~/Views/Home/Index.cshtml");

        }


        [HttpPost]
        public async Task<IActionResult> Create2(Employee usr)
        {
            usr.aboutMe = "null";
            usr.expirience = 0;
            usr.age = 0;
            usr.requestedSalary = 0;
            usr.accessTime = 0;
            usr.education = "null";
            usr.reuestedPost = "null";
                _context.Add(usr);
            await _context.SaveChangesAsync();
            return View("~/Views/Home/Index.cshtml");
            
        }

        [HttpPost]
        public async Task<IActionResult> Enter1(Employer usr)
        {
            List<Employer> list = _context.Employer.ToList();
            foreach (Employer curs in  list)
            {
                if (curs.Name==usr.Name&&curs.Password==usr.Password)
                {
                    currentUserId = usr.Id;
                    return View("~/Views/Home/HomeEmployer.cshtml",curs);
                }
            }
            
            return View("~/Views/Home/Index.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> Enter2(Employee usr)
        {
            List<Employee> list = _context.Employee.ToList();
            foreach (Employee curs in list)
            {
                if (curs.Name == usr.Name && curs.Password == usr.Password)
                {
                    currentUserId = curs.Id;
                    /*
                    Thread time = new Thread(start);
                    time.IsBackground = true;
                    time.Start();*/
                    await start(curs.Id);
                    return View("~/Views/Home/HomeEmployee.cshtml", curs);
                   
                }
            }

            return View("~/Views/Home/Index.cshtml");

        }

        public IActionResult pay(int id)
        {
                
                List<Employee>  list= _context.Employee.ToList();
                foreach (Employee curs in list)
                {
                    if (curs.Id == id)
                    {
                        return View(curs);
                    }
                }
                return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> payDay(int id)
        {
            List<Employee> list = _context.Employee.ToList();
            foreach (Employee curs in list)
            {
                if (curs.Id==id)
                {
                    curs.accessTime += 24;
                    _context.Update(curs);
                    await _context.SaveChangesAsync();
                    return View("~/Views/Home/HomeEmployee.cshtml", curs);
                }
            }
            return View("~/Views/Home/Index.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> payWeek(int id)
        {
            List<Employee> list = _context.Employee.ToList();
            foreach (Employee curs in list)
            {
                if (curs.Id == id)
                {
                    curs.accessTime += (24*7);
                    _context.Update(curs);
                    await _context.SaveChangesAsync();
                    return View("~/Views/Home/HomeEmployee.cshtml", curs);
                }
            }
            return View("~/Views/Home/Index.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> payMounth(int id)
        {
            List<Employee> list = _context.Employee.ToList();
            foreach (Employee curs in list)
            {
                if (curs.Id == id)
                {
                    curs.accessTime += (24*30);
                    _context.Update(curs);
                    await _context.SaveChangesAsync();
                    return View("~/Views/Home/HomeEmployee.cshtml", curs);
                }
            }
            return View("~/Views/Home/Index.cshtml");

        }

        public async Task<IActionResult> resume(int id)
        {
            var employee =await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);
            
            if (employee.accessTime > 0) 
            {
                return View(employee); 
            }
            else
            {
                return View("~/Views/Home/HomeEmployee.cshtml",employee);
            }
           
           
        }
        public async Task<IActionResult> FillRes(Employee resume)
        {
            _context.Update(resume);
            await _context.SaveChangesAsync();
            return View("~/Views/Home/HomeEmployee.cshtml",resume);
        }

        public IActionResult pay2(int id)
        {

            List<Employer> list = _context.Employer.ToList();
            foreach (Employer curs in list)
            {
                if (curs.Id == id)
                {
                    return View(curs);
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> payDay2(int id)
        {
            List<Employer> list = _context.Employer.ToList();
            foreach (Employer curs in list)
            {
                if (curs.Id == id)
                {
                    curs.accessTime += 24;
                    _context.Update(curs);
                    await _context.SaveChangesAsync();
                    return View("~/Views/Home/HomeEmployer.cshtml", curs);
                }
            }
            return View("~/Views/Home/Index.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> payWeek2(int id)
        {
            List<Employer> list = _context.Employer.ToList();
            foreach (Employer curs in list)
            {
                if (curs.Id == id)
                {
                    curs.accessTime += (24 * 7);
                    _context.Update(curs);
                    await _context.SaveChangesAsync();
                    return View("~/Views/Home/HomeEmployer.cshtml", curs);
                }
            }
            return View("~/Views/Home/Index.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> payMounth2(int id)
        {
            List<Employer> list = _context.Employer.ToList();
            foreach (Employer curs in list)
            {
                if (curs.Id == id)
                {
                    curs.accessTime += (24 * 30);
                    _context.Update(curs);
                    await _context.SaveChangesAsync();
                    return View("~/Views/Home/HomeEmployer.cshtml", curs);
                }
            }
            return View("~/Views/Home/Index.cshtml");

        }

        public IActionResult myVacList(int id)
        {
            List<Vacancy> Target=new List<Vacancy>();
            List<Vacancy> list = _context.Vacancy.ToList();
            foreach (Vacancy curs in list)
            {
                if (curs.CompanyId == id)
                {
                    Target.Add(curs);
                }
            }
            VacList listik=new VacList();
            listik.list = Target;
            listik.companyId = id;
            return View(listik);
        }

        public IActionResult backHome(VacList list)
        {
            int id = list.companyId;
            List<Employer> employers = _context.Employer.ToList();
            foreach(var employer in employers)
            {
                if (employer.Id == id)
                {
                    return View("~/Views/Home/HomeEmployer.cshtml",employer);
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

        public async Task<IActionResult> addvac(Vacancy vac)
        {
            List<Employer> list = _context.Employer.ToList();
            foreach (var employer in list)
            {
                if (employer.Id == vac.CompanyId)
                {
                    vac.CompanyId = employer.Id;
                    _context.Add(vac);
                    await _context.SaveChangesAsync();
                }
            }
            List<Vacancy> Target = new List<Vacancy>();
            List<Vacancy> list1 = _context.Vacancy.ToList();
            foreach (Vacancy curs in list1)
            {
                if (curs.CompanyId == vac.CompanyId)
                {
                    Target.Add(curs);
                }
            }
            VacList listik = new VacList();
            listik.list = Target;
            listik.companyId = vac.CompanyId;
            return View("~/Views/Home/myVacList.cshtml",listik);

        }
        public IActionResult createVac(VacList listik) 
        { 
            Vacancy vac = new Vacancy();
            vac.CompanyId = listik.companyId;
            return View(vac); 
        }

        public IActionResult viewvacancies(Employee employee)
        {
            List<Vacancy> list1 = _context.Vacancy.ToList();
            VacList listik = new VacList();
            listik.list = list1;
            listik.companyId = employee.Id;
            return View(listik);
        }

        public IActionResult backHome1(VacList list)
        {
            int id = list.companyId;
            List<Employee> employees = _context.Employee.ToList();
            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    return View("~/Views/Home/HomeEmployee.cshtml", employee);
                }
            }
            return View("~/Views/Home/Index.cshtml");
        }

        public async Task<IActionResult> dropVac(VacList listik)
        {
            List<Vacancy> list = _context.Vacancy.ToList();
            Vacancy target = new Vacancy();
            List<Vacancy> targetlist = new List<Vacancy>();
            foreach(var curs in list)
            {
                if(listik.curVacId == curs.Id)
                {
                    target = curs;
                }
            }
            _context.Vacancy.Remove(target);
            await _context.SaveChangesAsync();
            list = _context.Vacancy.ToList();
            foreach (var curs in list)
            {
                if (listik.companyId == curs.CompanyId)
                {
                    targetlist.Add(curs);
                }
            }
            listik.list=targetlist;
           return View("~/Views/Home/myVacList.cshtml", listik);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        
        static Timer t;
        static long interval = 3600000;
        static long interval2 = 30000;
        public async Task start(int id)
        {
                t = new Timer(new TimerCallback(a), null, 0, interval);
           
        }

        public async void a(object sender)
        {
            await substruct();
        }
        private async Task substruct()
        {
            var options = new DbContextOptionsBuilder<agencyContext>();
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=agency.Data;Trusted_Connection=True;MultipleActiveResultSets=true");
            using (agencyContext context = new agencyContext(options.Options))
            {
                List<Employee> list = context.Employee.ToList();
                foreach (Employee curs in list)
                {
                    if (curs.Id == currentUserId)
                    {
                        curs.accessTime -= 1;
                        context.Update(curs);
                        await context.SaveChangesAsync();
                    }
            }
            }
            
                   
                
        } 
    }
            
            
            
}
       

