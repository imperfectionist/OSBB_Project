using OSBB_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBB_DAL.DB
{
    public class OSBB_DbInitializer : CreateDatabaseIfNotExists<OSBB_Context>
    {
        protected override void Seed(OSBB_Context context)
        {
            IList<Benefit> defaultBenefits = new List<Benefit>
            {
                new Benefit { BenefitId = 1, BenefitName = "Учасник бойових дій", BenefitPercent = 75 },
                new Benefit { BenefitId = 2, BenefitName = "Багатодітна сім’я", BenefitPercent = 50 },
                new Benefit { BenefitId = 3, BenefitName = "Особа ЧАЕС – 2 категорія – ліквідатор", BenefitPercent = 50 },
                new Benefit { BenefitId = 4, BenefitName = "Особа ЧАЕС – 2 категорія – потерпілий", BenefitPercent = 50 }
            };

            context.Benefits.AddRange(defaultBenefits);

            IList<Apartment> defaultApartments = new List<Apartment>
            {
                new Apartment { ApartmentId = 1, ApartmentNumber = 1, AccountNumber = "1203589", OwnerName = "Карпенко Т.М.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 1},
                new Apartment { ApartmentId = 2, ApartmentNumber = 2, AccountNumber = "1203590", OwnerName = "Шандер Л.М.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 4},
                new Apartment { ApartmentId = 3, ApartmentNumber = 3, AccountNumber = "1203591", OwnerName = "Сернецька І.П.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 4, ApartmentNumber = 4, AccountNumber = "1203592", OwnerName = "Багдай Р.Р.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 1},
                new Apartment { ApartmentId = 5, ApartmentNumber = 5, AccountNumber = "1203593", OwnerName = "Чуяшенко Є.Ю.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 4, BenefitId = 2},
                new Apartment { ApartmentId = 6, ApartmentNumber = 6, AccountNumber = "1203594", OwnerName = "Калза А.М.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 4, BenefitId = 2},
                new Apartment { ApartmentId = 7, ApartmentNumber = 7, AccountNumber = "1203595", OwnerName = "Ревкова Л.П.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 3},
                new Apartment { ApartmentId = 8, ApartmentNumber = 8, AccountNumber = "1203596", OwnerName = "Мусієнко О.М.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 1},
                new Apartment { ApartmentId = 9, ApartmentNumber = 9, AccountNumber = "1203597", OwnerName = "Левченко А.С.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 1},
                new Apartment { ApartmentId = 10, ApartmentNumber = 10, AccountNumber = "1203598", OwnerName = "Сердюк С.М.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 2},
                new Apartment { ApartmentId = 11, ApartmentNumber = 11, AccountNumber = "1203599", OwnerName = "Балта Т.Й.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 3},
                new Apartment { ApartmentId = 12, ApartmentNumber = 12, AccountNumber = "1203600", OwnerName = "Смик П.С.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 4},
                new Apartment { ApartmentId = 13, ApartmentNumber = 13, AccountNumber = "1203601", OwnerName = "Горбачова Л.М.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 2},
                new Apartment { ApartmentId = 14, ApartmentNumber = 14, AccountNumber = "1203602", OwnerName = "Маменко В.І.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 4},
                new Apartment { ApartmentId = 15, ApartmentNumber = 15, AccountNumber = "1203603", OwnerName = "Доліна У.Б.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 3},
                new Apartment { ApartmentId = 16, ApartmentNumber = 16, AccountNumber = "1203604", OwnerName = "Лелюк Л.С.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 4},
                new Apartment { ApartmentId = 17, ApartmentNumber = 17, AccountNumber = "1203605", OwnerName = "Романюк С.В.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 3},
                new Apartment { ApartmentId = 18, ApartmentNumber = 18, AccountNumber = "1203606", OwnerName = "Павлюк О.І.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 2},
                new Apartment { ApartmentId = 19, ApartmentNumber = 19, AccountNumber = "1203607", OwnerName = "Квітка Г.Г.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 3},
                new Apartment { ApartmentId = 20, ApartmentNumber = 20, AccountNumber = "1203608", OwnerName = "Войтюк Т.М.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 2},
                new Apartment { ApartmentId = 21, ApartmentNumber = 21, AccountNumber = "1203609", OwnerName = "Безсмертна В.А.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 3},
                new Apartment { ApartmentId = 22, ApartmentNumber = 22, AccountNumber = "1203610", OwnerName = "Малиш-Зайченко Ю.В.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 3},
                new Apartment { ApartmentId = 23, ApartmentNumber = 23, AccountNumber = "1203611", OwnerName = "Поліщук Н.Д.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 24, ApartmentNumber = 24, AccountNumber = "1203612", OwnerName = "Ковальова Н.С.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 2},
                new Apartment { ApartmentId = 25, ApartmentNumber = 25, AccountNumber = "1203613", OwnerName = "Кириліна Н.І.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 3},
                new Apartment { ApartmentId = 26, ApartmentNumber = 26, AccountNumber = "1203614", OwnerName = "Долгер Б.М.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 2},
                new Apartment { ApartmentId = 27, ApartmentNumber = 27, AccountNumber = "1203615", OwnerName = "Беднарчук Г.Г.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 3},
                new Apartment { ApartmentId = 28, ApartmentNumber = 28, AccountNumber = "1203616", OwnerName = "Заяць Ю.О.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 29, ApartmentNumber = 29, AccountNumber = "1203617", OwnerName = "Антоневська Т.М.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 2},
                new Apartment { ApartmentId = 30, ApartmentNumber = 30, AccountNumber = "1203618", OwnerName = "Данилюк Н.Ф.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 1},
                new Apartment { ApartmentId = 31, ApartmentNumber = 31, AccountNumber = "1203619", OwnerName = "Василенко І.О.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 3},
                new Apartment { ApartmentId = 32, ApartmentNumber = 32, AccountNumber = "1203620", OwnerName = "Косенко О.О.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 3},
                new Apartment { ApartmentId = 33, ApartmentNumber = 33, AccountNumber = "1203621", OwnerName = "Панфілов Д.М.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 34, ApartmentNumber = 34, AccountNumber = "1203622", OwnerName = "Прищепа Л.М.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 3},
                new Apartment { ApartmentId = 35, ApartmentNumber = 35, AccountNumber = "1203623", OwnerName = "Бондаренко В.З.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 2},
                new Apartment { ApartmentId = 36, ApartmentNumber = 36, AccountNumber = "1203624", OwnerName = "Медведєва О.В.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 3},
                new Apartment { ApartmentId = 37, ApartmentNumber = 37, AccountNumber = "1203625", OwnerName = "Климчук Н.І.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 3},
                new Apartment { ApartmentId = 38, ApartmentNumber = 38, AccountNumber = "1203626", OwnerName = "Шевела В.В.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 4, BenefitId = 2},
                new Apartment { ApartmentId = 39, ApartmentNumber = 39, AccountNumber = "1203627", OwnerName = "Брігіда Л.Г.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 1},
                new Apartment { ApartmentId = 40, ApartmentNumber = 40, AccountNumber = "1203628", OwnerName = "Синенко Л.А.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 1},
                new Apartment { ApartmentId = 41, ApartmentNumber = 41, AccountNumber = "1203629", OwnerName = "Сокіркіна З.О.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 1},
                new Apartment { ApartmentId = 42, ApartmentNumber = 42, AccountNumber = "1203630", OwnerName = "Доста В.О.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 1, BenefitId = 4},
                new Apartment { ApartmentId = 43, ApartmentNumber = 43, AccountNumber = "1203631", OwnerName = "Томич М.М.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 2},
                new Apartment { ApartmentId = 44, ApartmentNumber = 44, AccountNumber = "1203632", OwnerName = "Заболотня Н.В.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 2},
                new Apartment { ApartmentId = 45, ApartmentNumber = 45, AccountNumber = "1203633", OwnerName = "Сливка Т.О.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 4},
                new Apartment { ApartmentId = 46, ApartmentNumber = 46, AccountNumber = "1203634", OwnerName = "Хаков П.П.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 1},
                new Apartment { ApartmentId = 47, ApartmentNumber = 47, AccountNumber = "1203635", OwnerName = "Кривінський Я.І.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 2},
                new Apartment { ApartmentId = 48, ApartmentNumber = 48, AccountNumber = "1203636", OwnerName = "Кізляк Д.Д.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 49, ApartmentNumber = 49, AccountNumber = "1203637", OwnerName = "Чумак С.В.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 4},
                new Apartment { ApartmentId = 50, ApartmentNumber = 50, AccountNumber = "1203638", OwnerName = "Канюк В.В.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 4},
                new Apartment { ApartmentId = 51, ApartmentNumber = 51, AccountNumber = "1203639", OwnerName = "Волкова С.І.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 1},
                new Apartment { ApartmentId = 52, ApartmentNumber = 52, AccountNumber = "1203640", OwnerName = "Кучеров М.О.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 4},
                new Apartment { ApartmentId = 53, ApartmentNumber = 53, AccountNumber = "1203641", OwnerName = "Койнак М.С.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 2},
                new Apartment { ApartmentId = 54, ApartmentNumber = 54, AccountNumber = "1203642", OwnerName = "Соколова С.М.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 2},
                new Apartment { ApartmentId = 55, ApartmentNumber = 55, AccountNumber = "1203643", OwnerName = "Омельченко А.І.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 3},
                new Apartment { ApartmentId = 56, ApartmentNumber = 56, AccountNumber = "1203644", OwnerName = "Сидоренко Т.І.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 2},
                new Apartment { ApartmentId = 57, ApartmentNumber = 57, AccountNumber = "1203645", OwnerName = "Грипіч С.В.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 4},
                new Apartment { ApartmentId = 58, ApartmentNumber = 58, AccountNumber = "1203646", OwnerName = "Заплюй Л.В.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 59, ApartmentNumber = 59, AccountNumber = "1203647", OwnerName = "Жмудь М.С.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 4},
                new Apartment { ApartmentId = 60, ApartmentNumber = 60, AccountNumber = "1203648", OwnerName = "Рибаченко В.С.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 3},
                new Apartment { ApartmentId = 61, ApartmentNumber = 61, AccountNumber = "1203649", OwnerName = "Гниря А.М.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 4},
                new Apartment { ApartmentId = 62, ApartmentNumber = 62, AccountNumber = "1203650", OwnerName = "Рибіна Ю.О.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 2},
                new Apartment { ApartmentId = 63, ApartmentNumber = 63, AccountNumber = "1203651", OwnerName = "Потороченко О.М.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 64, ApartmentNumber = 64, AccountNumber = "1203652", OwnerName = "Фоп Л.А.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 4},
                new Apartment { ApartmentId = 65, ApartmentNumber = 65, AccountNumber = "1203653", OwnerName = "Омельченко І.А.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 3},
                new Apartment { ApartmentId = 66, ApartmentNumber = 66, AccountNumber = "1203654", OwnerName = "Мушкета Р.Б.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 1},
                new Apartment { ApartmentId = 67, ApartmentNumber = 67, AccountNumber = "1203655", OwnerName = "Ситник М.М.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 3},
                new Apartment { ApartmentId = 68, ApartmentNumber = 68, AccountNumber = "1203656", OwnerName = "Бобяк М.Ф.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 69, ApartmentNumber = 69, AccountNumber = "1203657", OwnerName = "Штефанич Г.Г.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 4},
                new Apartment { ApartmentId = 70, ApartmentNumber = 70, AccountNumber = "1203658", OwnerName = "Лисюк О.В.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 2},
                new Apartment { ApartmentId = 71, ApartmentNumber = 71, AccountNumber = "1203659", OwnerName = "Бондар Т.С.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 3},
                new Apartment { ApartmentId = 72, ApartmentNumber = 72, AccountNumber = "1203660", OwnerName = "Захарчук М.А.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 2},
                new Apartment { ApartmentId = 73, ApartmentNumber = 73, AccountNumber = "1203661", OwnerName = "Волкова П.О.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 1},
                new Apartment { ApartmentId = 74, ApartmentNumber = 74, AccountNumber = "1203662", OwnerName = "Гриненко Д.В.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 3},
                new Apartment { ApartmentId = 75, ApartmentNumber = 75, AccountNumber = "1203663", OwnerName = "Халайджи Л.А.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 4},
                new Apartment { ApartmentId = 76, ApartmentNumber = 76, AccountNumber = "1203664", OwnerName = "Тішаєв М.О.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 3},
                new Apartment { ApartmentId = 77, ApartmentNumber = 77, AccountNumber = "1203665", OwnerName = "Чокаль С.І.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 2},
                new Apartment { ApartmentId = 78, ApartmentNumber = 78, AccountNumber = "1203666", OwnerName = "Чуль М.С.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 4},
                new Apartment { ApartmentId = 79, ApartmentNumber = 79, AccountNumber = "1203667", OwnerName = "Скляренко В.М.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 2},
                new Apartment { ApartmentId = 80, ApartmentNumber = 80, AccountNumber = "1203668", OwnerName = "Бондаренко В.М.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 2},
                new Apartment { ApartmentId = 81, ApartmentNumber = 81, AccountNumber = "1203669", OwnerName = "Кліндухов П.М.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 2},
                new Apartment { ApartmentId = 82, ApartmentNumber = 82, AccountNumber = "1203670", OwnerName = "Сатановський І.Г.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 4, BenefitId = 1},
                new Apartment { ApartmentId = 83, ApartmentNumber = 83, AccountNumber = "1203671", OwnerName = "Главняк В.В.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 2},
                new Apartment { ApartmentId = 84, ApartmentNumber = 84, AccountNumber = "1203672", OwnerName = "Іванов Я.О.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 3},
                new Apartment { ApartmentId = 85, ApartmentNumber = 85, AccountNumber = "1203673", OwnerName = "Штефанько І.В.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 4},
                new Apartment { ApartmentId = 86, ApartmentNumber = 86, AccountNumber = "1203674", OwnerName = "Назарова Є.В.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 4},
                new Apartment { ApartmentId = 87, ApartmentNumber = 87, AccountNumber = "1203675", OwnerName = "Прозор В.С.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 1},
                new Apartment { ApartmentId = 88, ApartmentNumber = 88, AccountNumber = "1203676", OwnerName = "Сталенний В.Т.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 89, ApartmentNumber = 89, AccountNumber = "1203677", OwnerName = "Луценко Т.Д.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 1, BenefitId = 1},
                new Apartment { ApartmentId = 90, ApartmentNumber = 90, AccountNumber = "1203678", OwnerName = "Григорєва Т.М.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 4},
                new Apartment { ApartmentId = 91, ApartmentNumber = 91, AccountNumber = "1203679", OwnerName = "Мисько Б.С.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 4},
                new Apartment { ApartmentId = 92, ApartmentNumber = 92, AccountNumber = "1203680", OwnerName = "Дубей Г.М.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 4},
                new Apartment { ApartmentId = 93, ApartmentNumber = 93, AccountNumber = "1203681", OwnerName = "Капраль В.М.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 2},
                new Apartment { ApartmentId = 94, ApartmentNumber = 94, AccountNumber = "1203682", OwnerName = "Федченко Т.М.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 3},
                new Apartment { ApartmentId = 95, ApartmentNumber = 95, AccountNumber = "1203683", OwnerName = "Таран О.Л.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 2},
                new Apartment { ApartmentId = 96, ApartmentNumber = 96, AccountNumber = "1203684", OwnerName = "Васечко К.М.",  TotalSquare = (decimal)42.42,  LivingSquare = (decimal)41.15, Tenants = 3},
                new Apartment { ApartmentId = 97, ApartmentNumber = 97, AccountNumber = "1203685", OwnerName = "Цимбаленко І.Д.",  TotalSquare = (decimal)115.14,  LivingSquare = (decimal)109.38, Tenants = 4},
                new Apartment { ApartmentId = 98, ApartmentNumber = 98, AccountNumber = "1203686", OwnerName = "Яценко П.П.",  TotalSquare = (decimal)106.05,  LivingSquare = (decimal)100.75, Tenants = 3},
                new Apartment { ApartmentId = 99, ApartmentNumber = 99, AccountNumber = "1203687", OwnerName = "Хижко Г.К.",  TotalSquare = (decimal)75.75,  LivingSquare = (decimal)72.72, Tenants = 1},
                new Apartment { ApartmentId = 100, ApartmentNumber = 100, AccountNumber = "1203688", OwnerName = "Шевченко Г.С.",  TotalSquare = (decimal)48.48,  LivingSquare = (decimal)47.03, Tenants = 1},
                new Apartment { ApartmentId = 101, ApartmentNumber = 1000, AccountNumber = "1111111", OwnerName = "Тест", Username = "lenasmiyan@rambler.ru", TotalSquare = (decimal)120.00, LivingSquare = (decimal)100.00, Tenants = 7, BenefitId = 2},
            };

            context.Apartments.AddRange(defaultApartments);

            IList<MonthPayment> defaultMonthPayments = new List<MonthPayment>
            {
                new MonthPayment{ MonthPaymentsId = 2, MonthPaymentsNum = 5, ApartmentId = 101, IsCurrent = 0},
                new MonthPayment{ MonthPaymentsId = 3, MonthPaymentsNum = 6, ApartmentId = 101, IsCurrent = 0},
                new MonthPayment{ MonthPaymentsId = 4, MonthPaymentsNum = 7, ApartmentId = 101, IsCurrent = 0},
                new MonthPayment{ MonthPaymentsId = 1, MonthPaymentsNum = 4, ApartmentId = 101, IsCurrent = 0},
            };

            context.MonthPayments.AddRange(defaultMonthPayments);

            IList<Unit> defaultUnits = new List<Unit>
            {
                new Unit{ UnitId = 1, UnitName = "куб.м"},
                new Unit{ UnitId = 2, UnitName = "кВт.год"},
                new Unit{ UnitId = 3, UnitName = "Гкал"},
                new Unit{ UnitId = 4, UnitName = "кв.м"},
            };

            context.Units.AddRange(defaultUnits);

            IList<Utility> defaultUtilities = new List<Utility>
            {
                new Utility{ UtilityId = 1, UtilityName = "Центральне опалення", UnitId = 3, UtilityPrice = (decimal)1654.41, UtilityNorm = (decimal)0.04 },
                new Utility{ UtilityId = 2, UtilityName = "Газопостачання", UnitId = 1, UtilityPrice = (decimal)21.24, UtilityNorm = (decimal)3.28 },
                new Utility{ UtilityId = 3, UtilityName = "Постачання холодної води", UnitId = 1, UtilityPrice = (decimal)15.79, UtilityNorm = (decimal)2.40 },
                new Utility{ UtilityId = 4, UtilityName = "Постачання гарячої води", UnitId = 1, UtilityPrice = (decimal)83.10, UtilityNorm = (decimal)1.60 },
                new Utility{ UtilityId = 5, UtilityName = "Електроенергія", UnitId = 2, UtilityPrice = (decimal)1.68, UtilityNorm = (decimal)110.00 },
                new Utility{ UtilityId = 6, UtilityName = "Вивезення побутових відходів", UtilityPrice = (decimal)32.41, UtilityNorm = (decimal)1 },
                new Utility{ UtilityId = 7, UtilityName = "Членський внесок", UtilityPrice = (decimal)30.00, UtilityNorm = (decimal)1 }
            };

            context.Utilities.AddRange(defaultUtilities);

            IList<MonthPaymentsDetail> defaultMonthPaymentDetails = new List<MonthPaymentsDetail>
            {
                new MonthPaymentsDetail{ MonthPaymentsId = 1, UtilityId = 3, MeterIndexStart = 75, MeterIndexEnd = 81, PaymentSum = (decimal)83.54 },
                new MonthPaymentsDetail{ MonthPaymentsId = 1, UtilityId = 4, MeterIndexStart = 62, MeterIndexEnd = 65, PaymentSum = (decimal)238.10 },
                new MonthPaymentsDetail{ MonthPaymentsId = 1, UtilityId = 5, MeterIndexStart = 425505, MeterIndexEnd = 426127, PaymentSum = (decimal)1033.76 },
                new MonthPaymentsDetail{ MonthPaymentsId = 1, UtilityId = 6, PaymentSum = (decimal)32.41 },
                new MonthPaymentsDetail{ MonthPaymentsId = 2, UtilityId = 3, MeterIndexStart = 81, MeterIndexEnd = 87, PaymentSum = (decimal)87.22 },
                new MonthPaymentsDetail{ MonthPaymentsId = 2, UtilityId = 4, MeterIndexStart = 65, MeterIndexEnd = 68, PaymentSum = (decimal)241.78 },
                new MonthPaymentsDetail{ MonthPaymentsId = 2, UtilityId = 5, MeterIndexStart = 426127, MeterIndexEnd = 426749, PaymentSum = (decimal)1037.44 },
                new MonthPaymentsDetail{ MonthPaymentsId = 2, UtilityId = 6, PaymentSum = (decimal)32.41 },
                new MonthPaymentsDetail{ MonthPaymentsId = 3, UtilityId = 3, MeterIndexStart = 87, MeterIndexEnd = 93, PaymentSum = (decimal)90.39 },
                new MonthPaymentsDetail{ MonthPaymentsId = 3, UtilityId = 4, MeterIndexStart = 68, MeterIndexEnd = 71, PaymentSum = (decimal)244.95 },
                new MonthPaymentsDetail{ MonthPaymentsId = 3, UtilityId = 5, MeterIndexStart = 426749, MeterIndexEnd = 427371, PaymentSum = (decimal)1040.61 },
                new MonthPaymentsDetail{ MonthPaymentsId = 3, UtilityId = 6, PaymentSum = (decimal)32.41 },
                new MonthPaymentsDetail{ MonthPaymentsId = 4, UtilityId = 3, MeterIndexStart = 93, MeterIndexEnd = 99, PaymentSum = (decimal)94.74 },
                new MonthPaymentsDetail{ MonthPaymentsId = 4, UtilityId = 4, MeterIndexStart = 71, MeterIndexEnd = 74, PaymentSum = (decimal)249.30 },
                new MonthPaymentsDetail{ MonthPaymentsId = 4, UtilityId = 5, MeterIndexStart = 427371, MeterIndexEnd = 427993, PaymentSum = (decimal)1044.96 },
                new MonthPaymentsDetail{ MonthPaymentsId = 4, UtilityId = 6, PaymentSum = (decimal)32.41 }
            };

            context.MonthPaymentsDetails.AddRange(defaultMonthPaymentDetails);

            base.Seed(context);
        }
    }
}
