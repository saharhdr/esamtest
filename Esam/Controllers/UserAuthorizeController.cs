using Component;
using Esam.Logic;
using Esam.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Esam.Models;
using Esam.DataAccess;
using System.Net.Mail;
using System.IO;
using System.Data;
using static User_cls;
using System.Net;

namespace Esam.Controllers
{
    public class userauthorizeController : Controller
    {

        [HttpPost]
        public ActionResult login(CustomRegModel model)
        {
            userauthorizeMan_Logic userauthorize = new userauthorizeMan_Logic();
            userauthorize.Logoutwithoutredirect();

            if (!string.IsNullOrEmpty(model.email) && !string.IsNullOrEmpty(model.password))
            {
                if (userauthorize.Login(model.email, model.password))
                {
                    TempData["JS"] = "شما با موفقیت وارد سایت شده اید .";
                }
                else
                {
                    TempData["JS"] ="نام کاربری و یا کلمه عبور اشتباه است .";
                }
            }
            else
                TempData["JS"] = "لطفا نام کاربری و کلمه عبور را وارد نمایید .";

            return RedirectToAction("signup");
        }

        public ActionResult signup()
        {
            CustomRegModel Model = new CustomRegModel();
            return View(Model);
        }

        [HttpPost]
        public ActionResult signup(CustomRegModel model)
        {
            TempData["JS"] = null;

            if (!ModelState.IsValid)
            {
                return RedirectToAction("signup");
            }

            UserInfoMan_Logic logic = new UserInfoMan_Logic();
            User_cls user;

            userauthorizeMan_Logic userauthorize = new userauthorizeMan_Logic();
            userauthorize.Logoutwithoutredirect();

            user = Convert(model);

            DBmessage resultuserregister = logic.RegisterUser(user);
            if (resultuserregister.Type == DBMessageType.Sucsess)
            {
                user.UserID = (int)resultuserregister.Parameter[0];

                if (user.UserID != 0)
                {
                    TempData["uid"] = user.UserID.ToString();
                    return RedirectToAction("confirm");
                }
                //else
                //{
                //    //Error Message...
                //    //return RedirectToAction("confirm");
                //}
            }
            else
            {
                TempData["JS"] =resultuserregister.Message;

                return RedirectToAction("signup");
            }

            return RedirectToAction("signup");
        }

        public ActionResult confirm(string ty = "")
        {
            int id = 0;
            if (TempData["uid"] != null && TempData["uid"].ToString() != "")
                id = System.Convert.ToInt32(TempData["uid"]);

            Random random = new Random();
            if (id == 0)
                return RedirectToAction("signup");

            UserInfoMan_Logic logic = new UserInfoMan_Logic();
            CustomRegModel value = logic.GetByUserID(id);

            if (value != null && value.userid != 0)
            {
                if (value.VerifyAccount == new VerifyAccountType(VerifyAccountType.VerifybyEmail))
                {
                    TempData["JS"] = "این کاربر قبلا فعال شده است.";
                    return RedirectToAction("signup");
                }
                else if (ty != "n")
                    if (!string.IsNullOrEmpty(value.email))
                    {
                        string EmailCode = (System.Convert.ToString(random.Next(100000, 999999)));
                        string ConfirmEmailRes = logic.RequestCodeRegisetr(id, EmailCode, RequestCodeType.ConfirmEmail);
                        if (ConfirmEmailRes == "4101")
                        {
                            try { 
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress("esamproject1@gmail.com");
                            mail.To.Add(value.email);
                            //mail.To.Add("Sahar.hdr@gmail.com");
                            mail.Subject = "تایید پست الکترونیکی";
                            mail.IsBodyHtml = true;

                            StreamReader sr = new StreamReader(Server.MapPath("~/content/mail_activatingemial.html"));
                            string Body = sr.ReadToEnd();
                            sr.Close();

                            Body = Body.Replace("#EmailAddress", value.fname + " " + value.lname);
                            Body = Body.Replace("#Code", EmailCode);

                            mail.Body = Body;
                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("esamproject1@gmail.com", "esam123456");
                            SmtpServer.EnableSsl = true;
                            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                                SmtpServer.Send(mail);
                            }
                            catch
                            {
                                TempData["JS"] = "لطفا پست الکترونیکی را صحیح وارد نمایید .";
                                return RedirectToAction("signup");
                            }
                        }
                    }
            }
            else
            {
                TempData["JS"] = "کاربر مورد نظر یافت نشد ، لطفا مجدد ثبت نام خود را انجام دهید .";
                return RedirectToAction("signup");
            }
            return View(value);
        }

        [HttpPost]
        public ActionResult confirm(CustomRegModel model)
        {
            TempData["JS"] = null;
            TempData["uid"] = model.userid;

            if (model == null || model.userid == 0)
            {
                TempData["JS"] ="اطلاعات وارد شده اشتباه است ، لطفا مجدد ثبت نام خود را انجام دهید .";
                return RedirectToAction("signup");
            }
            if (string.IsNullOrEmpty(model.confirmemail))
            {
                TempData["JS"] = "لطفا پست الکترونیکی خود را تایید کنید .";
                return RedirectToAction("confirm", new { ty = "n" });
            }

            UserInfoMan_Logic logic = new UserInfoMan_Logic();
            CustomRegModel value = logic.GetByUserID(model.userid);
            if (value == null || value.userid == 0)
            {
                TempData["JS"] ="اطلاعات وارد شده اشتباه است ، لطفا مجدد ثبت نام خود را انجام دهید .";
                return RedirectToAction("signup");
            }

            model.password = value.password;
            model.email = value.email;

            DataTable Dt;
            if (!string.IsNullOrEmpty(model.confirmemail))
            {
                Dt = new DataTable();
                Dt = logic.RequestCodeGet(model.userid, model.confirmemail, RequestCodeType.ConfirmEmail);
                if (Dt == null || Dt.Rows.Count == 0)
                {
                    TempData["JS"] = "کد وارد شده برای تایید پست الکترونیکی شما صحیح نمی باشد و یا منقضی شده است .";
                    return RedirectToAction("confirm", new { ty = "n" });
                }
            }

            int VerifyStatus = VerifyAccountType.NotVerified;

            if (!string.IsNullOrEmpty(model.confirmemail))
                VerifyStatus = VerifyAccountType.VerifybyEmail;

            userauthorizeMan_Logic userauthorize = new userauthorizeMan_Logic();
            DBmessage resultauthor = logic.UpdateVerifyAccount(model.userid, VerifyStatus);
            if (resultauthor.Type == DBMessageType.Sucsess)
            {
                Role role = new Role(false);
                role[RoleType.Customer] = true;
                resultauthor = logic.RegisterRole(model.userid, role, SysProperty.Client.UserID);

                if (userauthorize.LoginHashPassword(model.email, model.password))
                {
                    TempData["JS"] = "ثبت نام شما با موفقیت انجام شد . شما با موفقیت وارد سایت شده اید.";

                    return RedirectToAction("signup");
                }
                else
                {
                    return RedirectToAction("signup");
                }
            }
            else
            {
                TempData["JS"] = resultauthor.Message;

                return RedirectToAction("signup");
            }
        }

    }
}