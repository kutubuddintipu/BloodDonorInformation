using DonorInformation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonorInformation.Controllers
{
    public class DonorController : Controller
    {
        private readonly DonorContext _Db;
        public DonorController(DonorContext Db)
        {
            _Db = Db;
        }
        public IActionResult DonorList()
        {
           
            try
            {
                //var donorList = _Db.Donor.ToList();

                var donorList = from a in _Db.Donor
                                join b in _Db.BloodGroup
                                on a.groupId equals b.groupId
                                into Grp
                                from b in Grp.DefaultIfEmpty()

                                select new Donor
                                {
                                    Id = a.Id,
                                    Name=a.Name,
                                    Address=a.Address,
                                    Mobile=a.Mobile,
                                    Email=a.Email,
                                    groupId=a.groupId,

                                    BloodGroup=b==null?"":b.BloodGroup

                                };
                              


                return View(donorList);
            }
            catch (Exception ex)
            {

                return View();
            }
           
        }

        public IActionResult Create(Donor obj)
        {
            loadDDL();
            return View(obj);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddDonor(Donor obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.Id == 0)
                    {
                        _Db.Donor.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                   
                    return RedirectToAction("DonorList");
                }
                

                return View();
            }
            catch (Exception ex)
            {


                return RedirectToAction("DonorList");
            }
        }

        public async Task<IActionResult> DeleteDnr(int Id)
        {
            try
            {
                var dnr = await _Db.Donor.FindAsync(Id);
                if(dnr!=null)
                {
                    _Db.Donor.Remove(dnr);
                    await _Db.SaveChangesAsync();
                }


                return RedirectToAction("DonorList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("DonorList");
            }
        }

        private void loadDDL()
        {
            try
            {
                List<Group> grpList = new List<Group>();
                grpList = _Db.BloodGroup.ToList();

                grpList.Insert(0, new Group { groupId = 0, BloodGroup = "Please Select" });

                ViewBag.GrpList = grpList;
            }
            catch (Exception ex)
            {

              
            }
        }
    }
}
