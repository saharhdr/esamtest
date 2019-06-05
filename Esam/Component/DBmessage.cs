using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Component
{
    /// <summary>
    /// Summary description for DBmessage
    /// </summary>
    public class DBmessage
    {
        private string _message;
        private int _id;
        private DataContainer _parameter;
        private DBMessageType _type;
        public DataContainer Parameter
        {
            get { return _parameter; }
            set { _parameter = value; }
        }
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        public int ID
        {
            set
            {
                _id = value;
                int num = value % 10;
                if (num == 0)
                    _type = DBMessageType.NoShow;
                else if (num == 1)
                    _type = DBMessageType.Sucsess;
                else if (num > 1 && num < 8)
                    _type = DBMessageType.Error;
                else if (num == 8)
                    _type = DBMessageType.Info;
                else if (num == 9)
                    _type = DBMessageType.Warning;

            }
            get { return _id; }
        }
        public DBMessageType Type
        {
            get { return _type; }
        }
        public DBmessage(int id)
        {
            this.Parameter = new DataContainer();
            ID = id;
            switch (ID)
            {
                case 4101:
                    Message = "عملیات درج با موفقیت انجام شد";
                    break;
                case 4102:
                    Message = "عملیات درج با موفقیت انجام نشد";
                    break;
                case 4103:
                    Message = "حداقل یکی از سر گروه های انتخابی شما زیر مجموعه این گروه است";
                    break;
                case 4104:
                    Message = "ویژگی مورد نظر قبلا در زیر مجموعه یک گروه ویژگی بوده و دیگر نمی توان آن را به تنهایی به گروهی اختصاص داد";
                    break;
                case 4105:
                    Message = "کاربر مورد نظر در سیستم موجود نیست";
                    break;
                case 4106:
                    Message = "نام ساعت کاری تکراری است";
                    break;
                case 4107:
                    Message = "مجوز خروج ثبتی شما با دیگر مجوزات خروج تداخل دارد";
                    break;
                case 4201:
                    Message = "عملیات حذف با موفقیت انجام شد";
                    break;
                case 4202:
                    Message = "عملیات حذف با موفقیت انجام نشد";
                    break;
                case 4203:
                    Message = "این تردد قبلا حذف شده است یا وجود ندارد";
                    break;
                case 4204:
                    Message = "این شیف دارای کارمند می باشد";
                    break;
                case 4205:
                    Message = "ساعت کاری موظفی و اضافه کاری را نمی توان حذف کرد";
                    break;
                case 4206:
                    Message = "این نوع ساعت کاری در یک الگوی شیفت استفاده شده است";
                    break;
                case 4301:
                    Message = "عملیات ویرایش با موفقیت انجام شد";
                    break;
                case 4302:
                    Message = "عملیات ویرایش با موفقیت انجام نشد";
                    break;
                case 4303:
                    Message = "شماره کارت نمی تواند تغییر کند";
                    break;
                case 4304:
                    Message = "کارمند با این مشخصات یافت نشد";
                    break;
                case 4305:
                    Message = "گروه کاری با این مشخصات وجود دارد";
                    break;
                case 4306:
                    Message = "خطا در ویرایش، لطفا مجددا سعی کنید";
                    break;
                case 4307:
                    Message = "تاریخ تردد جدید با تاریخ امروز برابر نیست";
                    break;
                case 4312:
                    Message = "نگهبانی موجود نمی باشد";
                    break;
                case 4313:
                    Message = "شما نمی توانید نام اضافه کاری یا موظفی را تغییر دهید";
                    break;
                case 4400:
                    Message = "عملیات انتخاب با موفقیت انجام شد";
                    break;
                case 4402:
                    Message = "عملیات انتخاب با موفقیت انجام نشد";
                    break;
                case 4403:
                    Message = "کارمندی با شماره کارت وجود دارد";
                    break;
                case 4404:
                    Message = "شماره پرسنلی تکراری است";
                    break;
                case 4405:
                    Message = "شماره ملی تکراری است";
                    break;
                case 4406:
                    Message = "شماره کارت تکراری است";
                    break;
                case 4407:
                    Message = "شناسه تردد یافت نشد";
                    break;
                case 4408:
                    Message = "موردی یافت نشد";
                    break;
                case 4409:
                    Message = "این گروه دارای شیفت تعطیل است";
                    break;
                case 4412:
                    Message = "این گروه کاری دارای کارمند می باشد";
                    break;
                case 4413:
                    Message = "تردد با این مشخصات یافت نشد";
                    break;
                case 4418:
                    Message = "کارمند مورد نظر یافت نشد";
                    break;
                case 4422:
                    Message = "نام گروه شیفت تکراری است";
                    break;
                case 4423:
                    Message = "بازه زمانی داده شده با سایر شیفت های این گروه تداخل دارد";
                    break;
                case 4424:
                    Message = "شیفت موظفی و شیفت تعطیل در یک گروه نمی تواند باشد";
                    break;
                case 4425:
                    Message = "مدت زمان کاری در این شیفت بیشتر از 24 ساعت است";
                    break;
                case 4426:
                    Message = "مدت زمان کاری نمی تواند صفر باشد";
                    break;
                case 4427:
                    Message = "نوغ شیفت انتخابی وجود ندارد";
                    break;
                case 4428:
                    Message = " نوع ساعت کاری انتخابی وجود ندارد";
                    break;
                case 4432:
                    Message = "نوع ساعت کاری انتخابی وجود ندارد";
                    break;
                case 4433:
                    Message = "کارمند در این روز دارای شیفت است";
                    break;
                case 4434:
                    Message = "شیفت مورد نظر یافت نشد";
                    break;
                case 4435:
                    Message = "فایل مورد نظر برای ویرایش به درستی انتخاب نشده است.";
                    break;
                case 4436:
                    Message = "فایلی برای حذف انتخاب نشده است.";
                    break;
                /////////////START: code zir system marja felan injast\\\\\\\\\\\\\\\\\
                case 1101:
                    Message = "عملیات درج با موفقیت انجام شد";
                    break;
                case 1102:
                    Message = "عملیات درج با موفقیت انجام نشد";
                    break;
                case 1104:
                    Message = "شما قبلا با این پست الکترونیکی و شماره همراه در سامانه ثبت نام کرده اید ، اگر کلمه عبور خود را فراموش کرده اید لطفا در قسمت  ورود مشتری از لینک فراموشی کلمه عبور استفاده کنید.";
                    break;
                case 1105:
                    Message = "شما قبلا با این پست الکترونیکی در سامانه ثبت نام کرده اید ، اگر کلمه عبور خود را فراموش کرده اید لطفا در قسمت  ورود مشتری از لینک فراموشی کلمه عبور استفاده کنید.";
                    break;
                case 1106:
                    Message = "شما قبلا با این شماره همراه در سامانه ثبت نام کرده اید ، اگر کلمه عبور خود را فراموش کرده اید لطفا در قسمت  ورود مشتری از لینک فراموشی کلمه عبور استفاده کنید.";
                    break;
                //case 1106:
                //    Message = "کد ملی تکراری است";
                //    break;
                case 1107:
                    Message = "رمز عبور اشتباه می باشد";
                    break;
                case 1301:
                    Message = "عملیات ویرایش با موفقیت انجام شد";
                    break;
                case 1302:
                    Message = "عملیات ویرایش با موفقیت انجام نشد";
                    break;
                case 1305:
                    Message = "نام کاربری  تکراری است";
                    break;
                case 1400:
                    Message = "عملیات انتخاب با موفقیت انجام شد";
                    break;
                case 1408:
                    Message = "موردی یافت نشد";
                    break;
                case 1201:
                    Message = "عملیات حذف با موفقیت انجام شد";
                    break;
                case 1202:
                    Message = "عملیات حذف با موفقیت انجام نشد";
                    break;
                default:

                    ////////////END :   code zir system marja felan injast\\\\\\\\\\\\\\\\\\\\
                    throw new Exception("id from db not found");

            }

        }
        /// <summary>
        /// yek message dorost mikonad ke id va message motabeghe argoman ast va niaz nist az ghabl id sabt shode bashad, faghat standard cod gozari rayat shavad
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public DBmessage(int id, string message)
        {
            ID = id;
            _message = message;
        }
    }
    public enum DBMessageType
    {
        Sucsess,
        Info,
        Warning,
        Error,
        NoShow,
    }
}
