﻿using DAN_XLII_MilosPeric.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLII_MilosPeric.Service
{
    class DataBaseService
    {
        internal List<vwWorker> GetAllWorkerRecords()
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    List<vwWorker> list = new List<vwWorker>();
                    list = (from x in context.vwWorkers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal vwWorker AddWorker(vwWorker worker)
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    tblWorker newWorker = new tblWorker();
                    newWorker.FirstName = worker.FirstName;
                    newWorker.LastName = worker.LastName;
                    newWorker.DateOfBirth = worker.DateOfBirth;
                    newWorker.PersonalIDNumber = worker.PersonalIDNumber;
                    newWorker.JMBG = worker.JMBG;
                    newWorker.GenderID = worker.GenderID;
                    newWorker.PhoneNumber = worker.PhoneNumber;
                    newWorker.SectorID = worker.SectorID;
                    newWorker.LocationID = worker.LocationID;
                    newWorker.ManagerID = worker.ManagerID;
                    context.tblWorkers.Add(newWorker);
                    context.SaveChanges();
                    worker.WorkerID = newWorker.WorkerID;
                    return worker;                   
                }               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal vwWorker EditWorker(vwWorker worker)
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    tblWorker workerToEdit = (from w in context.tblWorkers where w.WorkerID == worker.WorkerID select w).First();
                    workerToEdit.FirstName = worker.FirstName;
                    workerToEdit.LastName = worker.LastName;
                    workerToEdit.DateOfBirth = worker.DateOfBirth;
                    workerToEdit.PersonalIDNumber = worker.PersonalIDNumber;
                    workerToEdit.JMBG = worker.JMBG;
                    workerToEdit.GenderID = worker.GenderID;
                    workerToEdit.PhoneNumber = worker.PhoneNumber;
                    workerToEdit.SectorID = worker.SectorID;
                    workerToEdit.LocationID = worker.LocationID;
                    workerToEdit.ManagerID = worker.ManagerID;
                    context.SaveChanges();
                    return worker;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal void DeleteWorker(int workerID)
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    tblWorker workerToDelete = (from w in context.tblWorkers where w.WorkerID == workerID select w).First();
                    context.tblWorkers.Remove(workerToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        internal List<tblLocation> AddLocationsToDataBase(List<tblLocation> locationListFromFile)
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    foreach (var location in locationListFromFile)
                    {
                        tblLocation locations = new tblLocation();
                        locations.Address = location.Address;
                        locations.City = location.City;
                        locations.Country = location.Country;
                        context.tblLocations.Add(locations);
                        context.SaveChanges();
                    }
                    return locationListFromFile;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal List<vwLocation> GetAllLocations()
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    List<vwLocation> list = new List<vwLocation>();
                    list = (from x in context.vwLocations select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal List<tblGender> GetAllGenders()
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    List<tblGender> list = new List<tblGender>();
                    list = (from x in context.tblGenders select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal List<tblSector> GetAllSectors()
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    List<tblSector> list = new List<tblSector>();
                    list = (from x in context.tblSectors select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        internal List<vwManager> GetAllManagers()
        {
            try
            {
                using (WorkerManagementEntities context = new WorkerManagementEntities())
                {
                    List<vwManager> list = new List<vwManager>();
                    list = (from x in context.vwManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
