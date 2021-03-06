﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1
{
    public class NotificationsHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void AddUserOperation()
        {
            
            int? id = -1;
            Cache.gen_lock.WaitOne();
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {
                    entity.Users.Add(((Users)SingletonCache.Instance().Storage[Context.User.Identity.Name]));
                    entity.SaveChanges();
                   
                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    string strm = ((Users)(SingletonCache.Instance().Storage[Context.User.Identity.Name])).IDCardNumber;
                    id = entity2.Users.Where(x => x.IDCardNumber == strm).First().ID;
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,משתמש נוסף למערכת";
            }
            catch (Exception e)
            {
                
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,הוספת משתמש נכשלה";
              
            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if(SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s=string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void EditUserOperation()
        {

            int? id = -1;
            Cache.gen_lock.WaitOne();
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {
                   
                    var original = entity.Users.Find(((Users)SingletonCache.Instance().Storage[Context.User.Identity.Name]).ID);

                    if (original != null)
                    {
                        entity.Entry(original).CurrentValues.SetValues(((Users)SingletonCache.Instance().Storage[Context.User.Identity.Name]));
                        entity.SaveChanges();
                    }
                   
                    entity.SaveChanges();
                   
                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    string strm = ((Users)(SingletonCache.Instance().Storage[Context.User.Identity.Name])).IDCardNumber;
                    id = entity2.Users.Where(x => x.IDCardNumber == strm).First().ID;
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,משתמש עודכן במערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,עדכון משתמש נכשל";
               
            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void AddAuctionOperation()
        {

            int? id = -1;
            Cache.gen_lock.WaitOne();
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {
                    entity.Auctions.Add(((Auctions)SingletonCache.Instance().Storage[Context.User.Identity.Name]));
                    entity.SaveChanges();

                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    string strm = ((Auctions)(SingletonCache.Instance().Storage[Context.User.Identity.Name])).AuctionNumber;
                    id = entity2.Auctions.Where(x => x.AuctionNumber == strm).First().ID;
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,מכרז נוסף למערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,הוספת מכרז נכשלה";
                
            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void EditAuctionOperation()
        {

            int? id = -1;
            Cache.gen_lock.WaitOne();
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {

                    var original = entity.Auctions.Find(((Auctions)SingletonCache.Instance().Storage[Context.User.Identity.Name]).ID);

                    if (original != null)
                    {
                        entity.Entry(original).CurrentValues.SetValues(((Auctions)SingletonCache.Instance().Storage[Context.User.Identity.Name]));
                        entity.SaveChanges();
                    }

                    entity.SaveChanges();

                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    string strm = ((Auctions)(SingletonCache.Instance().Storage[Context.User.Identity.Name])).AuctionNumber;
                    id = entity2.Auctions.Where(x => x.AuctionNumber == strm).First().ID;
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,מכרז עודכן במערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,עדכון מכרז נכשל";
                
            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void AddClusetrOperation()
        {

            int? id = -1;
            Cache.gen_lock.WaitOne();
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {
                    entity.Clusetrs.Add(((Clusetrs)SingletonCache.Instance().Storage[Context.User.Identity.Name]));
                    entity.SaveChanges();

                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    byte strm = ((Clusetrs)(SingletonCache.Instance().Storage[Context.User.Identity.Name])).DisplayNumber.Value;
                    id = entity2.Clusetrs.Where(x => x.DisplayNumber == strm).First().ID;
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,סל נוסף למערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,הוספת סל נכשלה";
              
            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void EditClusetrOperation()
        {

            int? id = -1;
            Cache.gen_lock.WaitOne();
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {

                    var original = entity.Clusetrs.Find(((Clusetrs)SingletonCache.Instance().Storage[Context.User.Identity.Name]).ID);

                    if (original != null)
                    {
                        entity.Entry(original).CurrentValues.SetValues(((Clusetrs)SingletonCache.Instance().Storage[Context.User.Identity.Name]));
                        entity.SaveChanges();
                    }

                    entity.SaveChanges();

                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    byte strm = ((Clusetrs)(SingletonCache.Instance().Storage[Context.User.Identity.Name])).DisplayNumber.Value;
                    id = entity2.Clusetrs.Where(x => x.DisplayNumber == strm).First().ID;
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,סל עודכן במערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,עדכון סל נכשל";
                
            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void AddUnitOperation()
        {

            int? id = -1;
            Cache.gen_lock.WaitOne();
            UnitFModel mf = ((UnitFModel)SingletonCache.Instance().Storage[Context.User.Identity.Name]);
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {
                    
                    entity.Units.Add(mf.unit);
                    entity.SaveChanges();

                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    string strm = mf.unit.Name;
                    id = entity2.Units.Where(x => x.Name == strm).First().ID;
                    if (mf.Limitions != null)
                    {
                        foreach (int i in mf.Limitions)
                        {
                            UnitsAuctions ua = new UnitsAuctions();
                            ua.AuctionID = i;
                            ua.UnitID = id;
                            entity2.UnitsAuctions.Add(ua);
                        }
                    }
                    entity2.SaveChanges();
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,יחידה נוספה למערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,הוספת יחידה נכשלה";
                
            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void editUnitOperation()
        {

            int? id = -1;
            Cache.gen_lock.WaitOne();
            UnitFModel mf = ((UnitFModel)SingletonCache.Instance().Storage[Context.User.Identity.Name]);
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {

                    var original = entity.Units.Find(mf.unit.ID);
             

                    if (original != null)
                    {
                         entity.UnitsAuctions.RemoveRange(entity.UnitsAuctions.Where(x => x.UnitID == mf.unit.ID));
                        if (mf.Limitions != null)
                        {
                            foreach (int i in mf.Limitions)
                            {
                                UnitsAuctions ua = new UnitsAuctions();
                                ua.AuctionID = i;
                                ua.UnitID = mf.unit.ID;
                                entity.UnitsAuctions.Add(ua);
                            }
                        }
                        entity.Entry(original).CurrentValues.SetValues(((UnitFModel)SingletonCache.Instance().Storage[Context.User.Identity.Name]).unit);
                        entity.SaveChanges();
                    }

                    

                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    int strm = mf.unit.ID;
                    id = entity2.Units.Where(x => x.ID == strm).First().ID;
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,יחידה עודכה במערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,הוספת יחידה נכשלה במערכת";
               
            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void AddSupplierOperation()
        {
            
            int? id = -1;
            Cache.gen_lock.WaitOne();
            SupplierFModel mf = ((SupplierFModel)SingletonCache.Instance().Storage[Context.User.Identity.Name]);
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {
                    if(mf.ActualEmail==null)
                    {
                        mf.supliers.EmailAddress = "";
                    }
                    else
                    {
                        mf.supliers.EmailAddress = mf.ActualEmail;
                    }
                    
                  mf.supliers.PhoneNumber = mf.Prefix + mf.ActualNumber;
                    entity.Suppliers.Add(mf.supliers);
                    entity.SaveChanges();

                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    string strm = mf.supliers.Name;
                    id = entity2.Suppliers.Where(x => x.Name == strm).First().ID;
                    if (mf.Limitions != null)
                    {
                        foreach (int i in mf.Limitions)
                        {
                            SuppliersClusetrs ua = new SuppliersClusetrs();
                            ua.ClusetrID = i;
                            ua.SupplierID = id;
                            ua.FormarLastTimeInList = new DateTime(2000,1,1);
                            ua.LastTimeInList = new DateTime(2000, 1, 1);
                            ua.StatusID = 1;
                            entity2.SuppliersClusetrs.Add(ua);
                        }
                    }
                    entity2.SaveChanges();
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,ספק נוספה למערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,הוספת ספק נכשלה";

            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void editSupplierOperation()
        {

            int? id = -1;
            Cache.gen_lock.WaitOne();
            SupplierFModel mf = ((SupplierFModel)SingletonCache.Instance().Storage[Context.User.Identity.Name]);
            try
            {
                using (TimchurDatabaseEntities entity = new TimchurDatabaseEntities())
                {

                    var original = entity.Suppliers.Find(mf.supliers.ID);


                    if (original != null)
                    {
                        
                        if (mf.Limitions != null)
                        {
                            foreach (int i in mf.Limitions)
                            {
                                SuppliersClusetrs ua = new SuppliersClusetrs();
                                if (entity.SuppliersClusetrs.Where(x => x.ClusetrID == i && x.SupplierID == mf.supliers.ID).Count() > 0)
                                {
                                    entity.SuppliersClusetrs.Where(x => x.ClusetrID == i && x.SupplierID == mf.supliers.ID).First().StatusID = 1;
                                }
                                else
                                {
                                    ua.ClusetrID = i;
                                    ua.SupplierID = id;
                                    ua.FormarLastTimeInList = new DateTime(2000, 1, 1);
                                    ua.LastTimeInList = new DateTime(2000, 1, 1);
                                    ua.StatusID = 1;
                                    entity.SuppliersClusetrs.Add(ua);
                                }
                            }
                       
                           
                        }
                        foreach (SuppliersClusetrs sc in entity.SuppliersClusetrs.Where(x => !mf.Limitions.Contains(x.ClusetrID) && x.SupplierID == mf.supliers.ID))
                        {
                            sc.StatusID = 2;
                        }
                        if (mf.ActualEmail == null)
                        {
                            mf.supliers.EmailAddress = "";
                        }
                        else
                        {
                            mf.supliers.EmailAddress = mf.ActualEmail;
                        }

                        mf.supliers.PhoneNumber = mf.Prefix + mf.ActualNumber;
                        entity.Entry(original).CurrentValues.SetValues(((SupplierFModel)SingletonCache.Instance().Storage[Context.User.Identity.Name]).supliers);
                        entity.SaveChanges();
                    }



                }
                using (TimchurDatabaseEntities entity2 = new TimchurDatabaseEntities())
                {
                    int strm = mf.supliers.ID;
                    id = entity2.Suppliers.Where(x => x.ID == strm).First().ID;
                }
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,יחידה עודכה במערכת";
            }
            catch (Exception e)
            {

                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = "בפעולה האחרונה,הוספת יחידה נכשלה במערכת";

            }
            Cache.gen_lock.ReleaseMutex();
            string str = Context.User.Identity.Name;
            string msg = "";
            if (SingletonCache.Instance().last_msg.Keys.Contains(str))
            {
                msg = SingletonCache.Instance().last_msg[str];
            }
            string to_s = string.Format("סטאטוס:" + msg);
            Clients.Caller.sendMessage(id.Value.ToString());
        }
        public void SendNotification()
        {
            if (SingletonCache.Instance().last_msg[Context.User.Identity.Name] != null)
            {
                string message = (string)(SingletonCache.Instance().last_msg[Context.User.Identity.Name].Clone());
                SingletonCache.Instance().last_msg[Context.User.Identity.Name] = null;
                Clients.Caller.broadcastNotification(message);
            }
        }
    }
}