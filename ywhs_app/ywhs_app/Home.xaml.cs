using Newtonsoft.Json;
using System;
using System.Net;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ywhs_app.jsonModels.meal;
using ywhs_app.jsonModels.schedule;
using Xamarin.Essentials;

namespace ywhs_app
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public string Now;

        public Home()
        {
            InitializeComponent();

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                if (Now == null || Now != DateTime.Now.ToString("MM"))
                {
                    UpdateLabels();
                    Now = DateTime.Now.ToString("MM");
                }

                Now = DateTime.Now.ToString("MM");

                return true;
            });
        }

        public void UpdateLabels()
        {
            var now = DateTime.Now;
            date.Text = now.ToString("yyyy년 MM월 dd일");
            UpdateMealData(now.ToString("yyyyMMdd"));
            UpdateSchedule(now.ToString("yyyyMMdd"));
        }

        public void UpdateSchedule(string today)
        {
            using (WebClient wc = new WebClient())
            {
                var json = new WebClient().DownloadString("https://open.neis.go.kr/hub/SchoolSchedule?Type=json&ATPT_OFCDC_SC_CODE=K10&SD_SCHUL_CODE=7800076&AA_YMD=" + today);
                ScheduleData scheduleData = JsonConvert.DeserializeObject<ScheduleData>(json);

                try
                {
                    schedule.Text = scheduleData.SchoolSchedule[1].row[0].EVENT_NM;
                }
                catch (Exception)
                {
                    schedule.Text = "특별한 일정이 없습니다";
                }
            }

        }


        public void UpdateMealData(string today)
        {
            using (WebClient wc = new WebClient())
            {
                var json = new WebClient().DownloadString("https://open.neis.go.kr/hub/mealServiceDietInfo?ATPT_OFCDC_SC_CODE=K10&SD_SCHUL_CODE=7800076&MLSV_YMD=" + today + "&Type=json");
                MealData mealData = JsonConvert.DeserializeObject<MealData>(json);

                try
                {
                    breakfast.Text = mealData.MealServiceDietInfo[1].Row[0].DDISHNM;
                    breakfast.Text = Regex.Replace(breakfast.Text, @"\d", "").Replace(".", "").Replace("<br/>", "\n");
                }
                catch (Exception)
                {
                    breakfast.Text = "해당하는 급식이 없습니다";
                }

                try
                {
                    lunch.Text = mealData.MealServiceDietInfo[1].Row[1].DDISHNM;
                    lunch.Text = Regex.Replace(lunch.Text, @"\d", "").Replace(".", "").Replace("<br/>", "\n");
                }
                catch (Exception)
                {
                    lunch.Text = "해당하는 급식이 없습니다";
                }

                try
                {
                    dinner.Text = mealData.MealServiceDietInfo[1].Row[2].DDISHNM;
                    dinner.Text = Regex.Replace(dinner.Text, @"\d", "").Replace(".", "").Replace("<br/>", "\n");
                }
                catch (Exception)
                {
                    dinner.Text = "해당하는 급식이 없습니다";
                }

                if (breakfast.Text == "해당하는 급식이 없습니다" && lunch.Text == "해당하는 급식이 없습니다" && dinner.Text == "해당하는 급식이 없습니다")
                {
                    viewMealData.IsVisible = false;
                    noneMeal.IsVisible = true;
                }


            }

        }
    }
}